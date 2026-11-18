using LLama;
using LLama.Common;
using LLama.Native;
using LLama.Sampling;
using System.Runtime.InteropServices;
using System.Runtime.Intrinsics.X86;

return await RunAsync(args);

static async Task<int> RunAsync(string[] args)
{
    var modelPath = args.Length > 0
        ? Path.GetFullPath(args[0])
        : FindDefaultModelPath();

    if (!File.Exists(modelPath))
    {
        Console.Error.WriteLine("GGUF model file not found.");
        Console.Error.WriteLine($"Expected path: {modelPath}");
        return 1;
    }

    var customBackendPath = Path.Combine(
        AppContext.BaseDirectory,
        "native",
        "linux-x64",
        "libllama.so");
    var hasCustomBackend =
        RuntimeInformation.IsOSPlatform(OSPlatform.Linux) &&
        RuntimeInformation.ProcessArchitecture == Architecture.X64 &&
        File.Exists(customBackendPath);

    if (hasCustomBackend)
    {
        NativeLibraryConfig.LLama.WithLibrary(customBackendPath);
    }
    else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux) &&
             RuntimeInformation.ProcessArchitecture == Architecture.X64 &&
             !Avx.IsSupported)
    {
        Console.Error.WriteLine(
            "Local GGUF inference is unavailable because this x64 CPU does not support AVX.");
        Console.Error.WriteLine(
            "Build the compatible backend by running EASYCONSOLE/AI_RUNNER/build-native-backend.sh.");
        return 1;
    }

    Console.WriteLine($"Loading AI model from {modelPath}...");

    try
    {
        var parameters = new ModelParams(modelPath)
        {
            ContextSize = 2048,
            GpuLayerCount = 0,
            Threads = Math.Max(1, Environment.ProcessorCount / 2)
        };

        using var model = LLamaWeights.LoadFromFile(parameters);
        using var context = model.CreateContext(parameters);
        var executor = new InteractiveExecutor(context);
        var history = new ChatHistory();
        history.AddMessage(
            AuthorRole.System,
            "You are a helpful AI assistant. Answer clearly and concisely.");
        var session = new ChatSession(executor, history);
        var inferenceParams = new InferenceParams
        {
            MaxTokens = 256,
            SamplingPipeline = new DefaultSamplingPipeline()
        };

        Console.WriteLine("Local AI is ready. Type exit to quit.\n");

        while (true)
        {
            Console.Write("You: ");
            var input = Console.ReadLine();
            if (input is null || input.Equals("exit", StringComparison.OrdinalIgnoreCase))
                break;

            if (string.IsNullOrWhiteSpace(input))
                continue;

            Console.Write("AI: ");
            await foreach (var token in session.ChatAsync(
                new ChatHistory.Message(AuthorRole.User, input),
                inferenceParams))
            {
                Console.Write(token);
            }

            Console.WriteLine("\n");
        }

        return 0;
    }
    catch (Exception ex)
    {
        Console.Error.WriteLine("Failed to load or run the local GGUF model.");
        Console.Error.WriteLine(ex);
        return 1;
    }
}

static string FindDefaultModelPath()
{
    var directory = new DirectoryInfo(AppContext.BaseDirectory);
    while (directory is not null)
    {
        var modelPath = Path.Combine(
            directory.FullName,
            "EASY_CALLENDER01",
            "FILES",
            "EXTERNAL",
            "GGUF",
            "GGUF_LOCAL",
            "text_to_text_local01.gguf");

        if (File.Exists(modelPath))
            return modelPath;

        directory = directory.Parent;
    }

    return Path.Combine(
        AppContext.BaseDirectory,
        "FILES",
        "EXTERNAL",
        "GGUF",
        "GGUF_LOCAL",
        "text_to_text_local01.gguf");
}
