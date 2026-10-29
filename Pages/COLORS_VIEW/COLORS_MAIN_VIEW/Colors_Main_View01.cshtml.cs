using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EASYPROJECT01.EASY_WEBB.Pages.COLORS_VIEW.COLORS_MAIN_VIEW
{
    public class Colors_Main_View01 : PageModel
    {
        public string[] button_text { get; set; } =
{
         $"colors",
                                       $"go back"
        };
        public string[] button_destinations { get; set; } =
        {
               $"Colors_Selection_View01",

                                       $"go back"
        };
        public void OnGet()
        {

        }
        public IActionResult OnPostNavigate(string destination)
        {
            return destination switch
            {
                "Colors_Selection_View01" => RedirectToPage("/COLORS_VIEW/COLORS_SELECTION_VIEW/Colors_Selection_View01"),
                "go back" => RedirectToPage("/Index"),
                _ => NotFound()
            };
        }
    }
}
