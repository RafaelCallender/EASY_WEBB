using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EASYPROJECT01.EASY_WEBB.Pages.WINDOWS_VIEW.WINDOWS_MAIN_VIEW
{
    public class Windows_Main_View01 : PageModel
    {
                        public string[] button_text { get; set; } =
        {
              $"windows01",                  
           $"go back"

        };
        public string[] button_destinations { get; set; } =
        {
               $"Windows_Selection_View01",
               $"go back"
        };
        public void OnGet()
        {

        }
        public IActionResult OnPostNavigate(string destination)
        {
            return destination switch
            {
            "Windows_Selection_View01" => RedirectToPage("/WINDOWS_VIEW/WINDOWS_SELECTION_VIEW/Windows_Selection_View01"),
                "go back" => RedirectToPage("/Index"),
                _ => NotFound()
            };
        }
    }
}
