using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EASYPROJECT01.EASY_WEBB.Pages.NETWORK_VIEW.NETWORK_MAIN_VIEW
{
    public class Network_Main_View01 : PageModel
    {
        public string[] button_text { get; set; } =
          {
                     $"Network01",
           $"go back"

        };
        public string[] button_destinations { get; set; } =
        {
               $"Network_Selection_View01",
               $"go back"
        };

 
        public void OnGet()
        {

        }
        public IActionResult OnPostNavigate(string destination)
        {
            return destination switch
            {
                "Network_Selection_View01" => RedirectToPage("/NETWORK_VIEW/NETWORK_SELECTION_VIEW/Network_Selection_View01"),
                "go back" => RedirectToPage("/Index"),
                _ => NotFound()
            };
        }
    }
}
