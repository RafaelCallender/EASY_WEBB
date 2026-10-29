
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EASYPROJECT01.EASY_WEBB.Pages.MAC_VIEW.MAC_MAIN_VIEW
{
    public class Mac_Main_View01 : PageModel
    {

        public string[] button_text { get; set; } =
{
          $"mac onedrive",
           $"go back"

        };
        public string[] button_destinations { get; set; } =
        {
               $"Mac_Selection_View01",
               $"go back"
        };
        public void OnGet()
        {

        }
        public IActionResult OnPostNavigate(string destination)
        {
            return destination switch
            {
                "Mac_Selection_View01" => RedirectToPage("/MAC_VIEW/MAC_SELECTION_VIEW/Mac_Selection_View01"),
                "go back" => RedirectToPage("/Index"),
                _ => NotFound()
            };
        }

    }
}
