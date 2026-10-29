using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;


namespace EASYPROJECT01.EASY_WEBB.Pages.LOCATION_VIEW.LOCATION_MAIN_VIEW
{
    public class Location_Main_View01 : PageModel
    {
        public string[] button_text { get; set; } =
{
          $"location 01",
           $"go back"

        };
        public string[] button_destinations { get; set; } =
        {
               $"Location_Selection_View01",
               $"go back"
        };
        public void OnGet()
        {

        }
        public IActionResult OnPostNavigate(string destination)
        {
            return destination switch
            {
                "Location_Selection_View01" => RedirectToPage("/LOCATION_VIEW/LOCATION_SELECTION_VIEW/Location_Selection_View01"),
                "go back" => RedirectToPage("/Index"),
                _ => NotFound()
            };
        }
    }
}
