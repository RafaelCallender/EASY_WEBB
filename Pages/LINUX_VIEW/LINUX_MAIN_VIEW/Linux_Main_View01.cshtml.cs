using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EASYPROJECT01.EASY_WEBB.Pages.LINUX_VIEW.LINUX_MAIN_VIEW
{
    public class Linux_Main_View01 : PageModel
    {
        public string[] button_text { get; set; } =
{
     $"linux onedrive 01",
                   $"linux githube 01",

                                       $"go back"
        };
        public string[] button_destinations { get; set; } =
        {
               $"Linux_Selection_View01",
                $"Linux_Selection_View02",

                                       $"go back"
        };
        public void OnGet()
        {

        }

        public IActionResult OnPostNavigate(string destination)
        {
            return destination switch
            {
                "Linux_Selection_View01" => RedirectToPage("/LINUX_VIEW/LINUX_SELECTION_VIEW/Linux_Selection_View01"),
                "Linux_Selection_View02" => RedirectToPage("/LINUX_VIEW/LINUX_SELECTION_VIEW/Linux_Selection_View02"),
                "go back" => RedirectToPage("/Index"),
                _ => NotFound()
            };
        }

    }
}
