using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EASYPROJECT01.EASY_WEBB.Pages.DEVICE_VIEW.DEVICE_MAIN_VIEW
{
    public class Device_Main_View01 : PageModel
    {
        public string[] button_text { get; set; } =
{
            $"device  01",
                                       $"go back"
        };
        public string[] button_destinations { get; set; } =
        {
               $"Device_Selection_View01",

                                       $"go back"
        };
        public void OnGet()
        {

        }
        public IActionResult OnPostNavigate(string destination)
        {
            return destination switch
            {
                "Device_Selection_View01" =>
         RedirectToPage("/DEVICE_VIEW/DEVICE_SELECTION_VIEW/Device_Selection_View01"),

                "go back" =>
                    RedirectToPage("/Index"),

                _ => NotFound()
            };
        }
    }
}
