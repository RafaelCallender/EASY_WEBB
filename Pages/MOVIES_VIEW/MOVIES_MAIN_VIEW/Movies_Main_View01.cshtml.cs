using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EASYPROJECT01.EASY_WEBB.Pages.MOVIES_VIEW.MOVIES_MAIN_VIEW
{
    public class Movies_Main_View01 : PageModel
    {
        public string[] button_text { get; set; } =
          {
                     $"movie 01",
           $"go back"

        };
        public string[] button_destinations { get; set; } =
        {
               $"Movies_Selection_View01",
               $"go back"
        };

        public void OnGet()
        {

        }
        public IActionResult OnPostNavigate(string destination)
        {
            return destination switch
            {
                "Movies_Selection_View01" => RedirectToPage("/MOVIES_VIEW/MOVIES_SELECTION_VIEW/Movies_Selection_View01"),
                "go back" => RedirectToPage("/Index"),
                _ => NotFound()
            };
        }

    }
}
