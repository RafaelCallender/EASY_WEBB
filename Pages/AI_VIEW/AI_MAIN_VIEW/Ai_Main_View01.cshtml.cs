using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using EASYPROJECT01.EASY_CALLENDER01.TEMPLATE.WEB_TEMPLATE;
namespace EASYPROJECT01.EASY_WEBB.Pages.AI_VIEW.AI_MAIN_VIEW
{
    public class Ai_Main_View01 : PageModel
    {
       public string css01 { get; set; } = Web_Template01.ccs01;
        public string[] button_text { get; set; } =
        {
            "Change Hairstyle",
            "AI Text Generation",
            "AnimePhoto",
            "Text to Image Generation",
            "Back"
        };
        public string[] button_destinations { get; set; } =
        {
            "Ai_Selection_View01",
            "Ai_Selection_View02",
            "Ai_Selection_View03",
            "Ai_Selection_View04",
            "Index"
        };
        public void OnGet()
        {
        }
        public IActionResult OnPostNavigate(string destination)
        {
            return destination switch
            {
                "Ai_Selection_View01" =>
                    RedirectToPage("/AI_VIEW/AI_SELECTION_VIEW/Ai_Selection_View01"),

                "Ai_Selection_View02" =>
                    RedirectToPage("/AI_VIEW/AI_SELECTION_VIEW/Ai_Selection_View02"),

                "Ai_Selection_View03" =>
                    RedirectToPage("/AI_VIEW/AI_SELECTION_VIEW/Ai_Selection_View03"),

                "Ai_Selection_View04" =>
                    RedirectToPage("/AI_VIEW/AI_SELECTION_VIEW/Ai_Selection_View04"),

                "Index" =>
                    RedirectToPage("/Index"),

                _ => NotFound()
            };
        }
    }
}