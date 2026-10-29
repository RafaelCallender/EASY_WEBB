using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;


namespace EASYPROJECT01.EASY_WEBB.Pages.STUIDO_VIEW.STUDIO_MAIN_VIEW
{
    public class Studio_Main_View01 : PageModel
    {
        public string[] button_text { get; set; } =
   {
                 $"studio",
                                      
           $"go back"

        };
        public string[] button_destinations { get; set; } =
        {
               $"Studio_Selection_View01",

               $"go back"
        };

        public void OnGet()
        {

        }
        public IActionResult OnPostNavigate(string destination)
        {
            return destination switch
            {
                "Studio_Selection_View01" => RedirectToPage("/STUIDO_VIEW/STUIDIO_SELECTION_VIEW/Studio_Selection_View01"),
                "go back" => RedirectToPage("/Index"),
                _ => NotFound()
            };
        }
    }
}
