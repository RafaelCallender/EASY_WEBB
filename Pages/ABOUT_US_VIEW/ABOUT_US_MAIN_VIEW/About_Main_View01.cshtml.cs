using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EASYPROJECT01.EASY_WEBB.Pages.ABOUT_US_VIEW.ABOUT_US_MAIN_VIEW
{
    public class About_Main_View01 : PageModel
    {
        public string[] button_text { get; set; } =
        {

                                $"about",
                                $"contact",
                                $"carrer",
                                $"go back"

        };
        public string[] button_destinations { get; set; } =
        {
                $"About_Selection_View01",
                $"About_Selection_View02",
                $"About_Selection_View03",
                $"go back"
        };
        public void OnGet()
        {

        }
        public IActionResult OnPostNavigate(string destination)
        {
            return destination switch
            {
                "About_Selection_View01" => RedirectToPage("/ABOUT_US_VIEW/ABOUT_US_SELECTION_VIEW/aboutus01"),
                "About_Selection_View02" => RedirectToPage("/ABOUT_US_VIEW/ABOUT_US_SELECTION_VIEW/aboutus02"),
                "About_Selection_View03" => RedirectToPage("/ABOUT_US_VIEW/ABOUT_US_SELECTION_VIEW/aboutus03"),
                "go back" => RedirectToPage("/Index"),
                _ => NotFound()
            };
        }
    }
}