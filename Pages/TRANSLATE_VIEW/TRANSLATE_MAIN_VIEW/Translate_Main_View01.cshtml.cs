using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EASYPROJECT01.EASY_WEBB.Pages.TRANSLATE_VIEW.TRANSLATE_MAIN_VIEW
{
    public class Translate_Main_View01 : PageModel
    {

        public string[] button_text { get; set; } =
        {
                 $"Translate",

           $"go back"

        };
        public string[] button_destinations { get; set; } =
        {
               $"Translate_Selection_View01",

               $"go back"
        };
        public void OnGet()
        {

        }

        public IActionResult OnPostNavigate(string destination)
        {
            return destination switch
            {
                "Translate_Selection_View01" => RedirectToPage("/TRANSLATE_VIEW/TRANSLATE_SELECTION_VIEW/Translate_Selection_View01"),
                "go back" => RedirectToPage("/Index"),
                _ => NotFound()
            };
        }
    }
}
