using System.Diagnostics;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading;
using EASYPROJECT01.EASY_CALLENDER01.SERVICES.FILES.FILE_MANAGER;

namespace EASYPROJECT01.EASY_WEBB.Services;

public sealed class LocalAiRunnerService : IAsyncDisposable
{
    private readonly SemaphoreSlim _startLock = new(1, 1);
    private readonly SemaphoreSlim _chatLock = new(1, 1);
    private readonly object _stateLock = new();
    private Process? _process;
    private TaskCompletionSource<bool>? _ready;
    private PendingResponse? _pendingResponse;
    private string _status = "NotStarted";
    private string? _lastError;
    private Task<string>? _stderrTask;

    public string Status
    {
        get
        {
            lock (_stateLock)
                return _status;
        }
    }

    public string? LastError
    {
        get
        {
            lock (_stateLock)
                return _lastError;
        }
    }

    public async Task EnsureStartedAsync()
    {
        await _startLock.WaitAsync();
        try
        {
            if (_process is { HasExited: false })
                return;

            var projectPath = FindRunnerProjectPath();
            if (projectPath is null)
            {
                var error = "Could not locate EASYCONSOLE/AI_RUNNER/EASYAI_RUNNER.csproj.";
                SetStatus("Error", error);
                throw new InvalidOperationException(error);
            }

            var startInfo = new ProcessStartInfo("dotnet")
            {
                WorkingDirectory = Path.GetDirectoryName(projectPath)!,
                UseShellExecute = false,
                RedirectStandardInput = true,
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                CreateNoWindow = true
            };
            startInfo.ArgumentList.Add("run");
            startInfo.ArgumentList.Add("--project");
            startInfo.ArgumentList.Add(projectPath);
            startInfo.ArgumentList.Add("--");
            startInfo.ArgumentList.Add("--server");
            startInfo.ArgumentList.Add("--model");
            startInfo.ArgumentList.Add(File_Manger05.text_to_text_local01_gguf);

            var process = new Process { StartInfo = startInfo };
            try
            {
                if (!process.Start())
                    throw new InvalidOperationException("Failed to start the local AI runner.");
            }
            catch (Exception ex)
            {
                process.Dispose();
                SetStatus("Error", ex.Message);
                throw;
            }

            _process = process;
            _ready = new TaskCompletionSource<bool>(
                TaskCreationOptions.RunContinuationsAsynchronously);
            SetStatus("Loading", null);
            _stderrTask = PumpErrorAsync(process);
            _ = PumpOutputAsync(process);
        }
        finally
        {
            _startLock.Release();
        }
    }

    public async Task<string> ChatAsync(string conversationId, string prompt)
    {
        await _chatLock.WaitAsync();
        try
        {
            var ready = _ready;
            if (ready is null)
                throw new InvalidOperationException("The AI model has not started.");

            if (!await ready.Task)
                throw new InvalidOperationException(
                    LastError ?? "The AI runner failed to load the model.");
            var process = _process;
            if (process is null || process.HasExited)
                throw new InvalidOperationException("The AI runner is not running.");

            var completion = new TaskCompletionSource<RunnerResponse>(
                TaskCreationOptions.RunContinuationsAsynchronously);
            var response = new PendingResponse(conversationId, completion);
            lock (_stateLock)
                _pendingResponse = response;

            var request = new RunnerRequest
            {
                Id = conversationId,
                Prompt = prompt
            };
            await process.StandardInput.WriteLineAsync(JsonSerializer.Serialize(request));
            await process.StandardInput.FlushAsync();

            var result = await completion.Task;
            if (!string.IsNullOrEmpty(result.Error))
                throw new InvalidOperationException(result.Error);

            return result.Text ?? string.Empty;
        }
        finally
        {
            lock (_stateLock)
                _pendingResponse = null;
            _chatLock.Release();
        }
    }

    private async Task PumpOutputAsync(Process process)
    {
        try
        {
            string? line;
            while ((line = await process.StandardOutput.ReadLineAsync()) is not null)
            {
                RunnerMessage? message;
                try
                {
                    message = JsonSerializer.Deserialize<RunnerMessage>(line);
                }
                catch (JsonException)
                {
                    continue;
                }

                if (message is null)
                    continue;

                switch (message.Type)
                {
                    case "ready":
                        SetStatus("Ready");
                        _ready?.TrySetResult(true);
                        break;
                    case "response":
                        lock (_stateLock)
                        {
                            if (_pendingResponse?.Id == message.Id)
                            {
                                _pendingResponse.Completion.TrySetResult(
                                    new RunnerResponse(message.Text, message.Error));
                            }
                        }
                        break;
                    case "error":
                        SetStatus("Error", message.Message ?? "AI runner failed.");
                        _ready?.TrySetResult(false);
                        lock (_stateLock)
                            _pendingResponse?.Completion.TrySetResult(
                                new RunnerResponse(null, message.Message ?? "AI runner failed."));
                        break;
                }
            }

            var stderr = _stderrTask is null ? string.Empty : await _stderrTask;
            var errorMessage = string.IsNullOrWhiteSpace(stderr)
                ? "The local AI runner stopped unexpectedly."
                : stderr.Trim();
            if (Status != "Error")
                SetStatus("Error", errorMessage);

            var error = new InvalidOperationException(errorMessage);
            _ready?.TrySetResult(false);
            lock (_stateLock)
                _pendingResponse?.Completion.TrySetResult(new RunnerResponse(null, error.Message));
        }
        catch (Exception ex)
        {
            SetStatus("Error", ex.Message);
            _ready?.TrySetResult(false);
            lock (_stateLock)
                _pendingResponse?.Completion.TrySetResult(new RunnerResponse(null, ex.Message));
        }
    }

    private static Task<string> PumpErrorAsync(Process process)
    {
        return process.StandardError.ReadToEndAsync();
    }

    private void SetStatus(string status, string? error = null)
    {
        lock (_stateLock)
        {
            _status = status;
            _lastError = error;
        }
    }

    private static string? FindRunnerProjectPath()
    {
        foreach (var root in new[] { AppContext.BaseDirectory, Environment.CurrentDirectory })
        {
            var directory = new DirectoryInfo(root);
            while (directory is not null)
            {
                var projectPath = Path.Combine(
                    directory.FullName,
                    "EASYCONSOLE",
                    "AI_RUNNER",
                    "EASYAI_RUNNER.csproj");

                if (File.Exists(projectPath))
                    return Path.GetFullPath(projectPath);

                directory = directory.Parent;
            }
        }

        return null;
    }

    public async ValueTask DisposeAsync()
    {
        var process = _process;
        if (process is not null)
        {
            try
            {
                if (!process.HasExited)
                    process.Kill(entireProcessTree: true);
                await process.WaitForExitAsync();
            }
            catch (InvalidOperationException)
            {
            }
            finally
            {
                process.Dispose();
            }
        }

        _startLock.Dispose();
        _chatLock.Dispose();
    }

    private sealed class RunnerRequest
    {
        [JsonPropertyName("id")]
        public string Id { get; init; } = string.Empty;

        [JsonPropertyName("prompt")]
        public string Prompt { get; init; } = string.Empty;
    }

    private sealed class RunnerMessage
    {
        [JsonPropertyName("type")]
        public string Type { get; init; } = string.Empty;

        [JsonPropertyName("id")]
        public string? Id { get; init; }

        [JsonPropertyName("text")]
        public string? Text { get; init; }

        [JsonPropertyName("message")]
        public string? Message { get; init; }

        [JsonPropertyName("error")]
        public string? Error { get; init; }
    }

    private sealed record PendingResponse(
        string Id,
        TaskCompletionSource<RunnerResponse> Completion);

    private sealed record RunnerResponse(string? Text, string? Error = null);
}
