using EASYPROJECT01.EASY_CALLENDER01.MODEL.WEB_MODEL.AI_VIEW_MODEL;
using EASYPROJECT01.EASY_CALLENDER01.SERVICES.SECURITY_SERVICES;
using EASYPROJECT01.EASY_WEBB.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using EASYPROJECT01.EASY_CALLENDER01.TEMPLATE.WEB_TEMPLATE;
namespace EASYPROJECT01.EASY_WEBB.Pages.AI_VIEW.AI_SELECTION_VIEW;

public class Ai_Selection_View02 : PageModel
{
      public string css01 { get; set; } = Web_Template01.ccs01;
    private static readonly string[] MenuOptions =
    [
        "Ai text generation",
        "Ai text generation for developers",
        "Ai text generation for web developers"
    ];

    private readonly LocalAiRunnerService _aiRunner;
    private readonly ILogger<Ai_Selection_View02> _logger;
    private static readonly Security_Services01 SecurityServices = new();

    public Ai_Selection_View02(
        LocalAiRunnerService aiRunner,
        ILogger<Ai_Selection_View02> logger)
    {
        _aiRunner = aiRunner;
        _logger = logger;
    }

    [BindProperty]
    public Ai_View_Model02 Ai_View_M02 { get; set; } = new();

    public void OnGet()
    {
        LoadOptions();
        Ai_View_M02.ConversationId = Guid.NewGuid().ToString("N");
    }

    public async Task<IActionResult> OnPostAsync()
    {
        LoadOptions();

        if (!SecurityServices.isPicker_selected_web(
                Ai_View_M02.SelectedProject,
                MenuOptions,
                out var selectionMessage))
        {
            Ai_View_M02.StatusMessage01 = selectionMessage;
            return Page();
        }

        Ai_View_M02.ShowInput01 = true;
        if (Ai_View_M02.SelectedProject == "1")
        {
            try
            {
                await _aiRunner.EnsureStartedAsync();
                UpdateLoadingState();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Unable to start the local AI runner.");
                Ai_View_M02.StatusMessage01 = ex.Message;
            }
        }
        else
        {
            Ai_View_M02.StatusMessage01 = "This AI option is not yet available.";
        }

        return Page();
    }

    public IActionResult OnGetAiStatus()
    {
        return new JsonResult(new
        {
            state = _aiRunner.Status,
            error = _aiRunner.LastError
        });
    }

    public async Task<IActionResult> OnPostChatAsync(
        [FromForm] string? message,
        [FromForm] string? conversationId)
    {
        if (!Guid.TryParseExact(conversationId, "N", out _) ||
            string.IsNullOrWhiteSpace(message) ||
            message.Length > 4000)
        {
            return BadRequest(new { error = "Enter a message of up to 4,000 characters." });
        }

        if (_aiRunner.Status != "Ready")
            return StatusCode(
                StatusCodes.Status409Conflict,
                new { error = "The AI model is still loading." });

        try
        {
            var response = await _aiRunner.ChatAsync(conversationId, message.Trim());
            return new JsonResult(new { response });
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "The local AI runner failed to answer a chat message.");
            return StatusCode(
                StatusCodes.Status500InternalServerError,
                new { error = "The AI could not answer this message. Please try again." });
        }
    }

    public IActionResult OnPostBack()
    {
        return RedirectToPage("/AI_VIEW/AI_MAIN_VIEW/Ai_Main_View01");
    }

    private void UpdateLoadingState()
    {
        Ai_View_M02.IsLoading = _aiRunner.Status == "Loading";
        Ai_View_M02.AiReady = _aiRunner.Status == "Ready";
        Ai_View_M02.StatusMessage01 = _aiRunner.Status switch
        {
            "Loading" => "Loading the AI model. This may take a little while.",
            "Ready" => "AI is ready. You can start chatting.",
            "Error" => _aiRunner.LastError ?? "The AI runner could not be started.",
            _ => string.Empty
        };
    }

    private void LoadOptions()
    {
        Ai_View_M02.ProjectOptions = MenuOptions
            .Select((option, index) => new SelectListItem
            {
                Value = (index + 1).ToString(),
                Text = option
            })
            .ToList();
    }
}
