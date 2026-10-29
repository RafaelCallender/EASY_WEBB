using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EASYPROJECT01.EASY_WEBB.Pages.CLIENT_VIEW.CLIENT_MAIN_VIEW
{
    public class Client_Main_View01 : PageModel
    {
        public string[] button_text { get; set; } =
        {
         $"client sqlexpress",
                                       $"client sqlite",
                                       $"client Mysql",
                                       $"go back"
        };
        public string[] button_destinations { get; set; } =
        {
               $"Client_Selection_View01",
                                       $"Client_Selection_View02",
                                       $"Client_Selection_View03",
                                       $"go back"
        };

        public void OnGet()
        {

        }
        public IActionResult OnPostNavigate(string destination)
        {
            return destination switch
            {
                "Client_Selection_View01" => RedirectToPage("/CLIENT_VIEW/CLIENT_SELECTION_VIEW/Client_Selection_View01"),
                "Client_Selection_View02" => RedirectToPage("/CLIENT_VIEW/CLIENT_SELECTION_VIEW/Client_Selection_View02"),
                "Client_Selection_View03" => RedirectToPage("/CLIENT_VIEW/CLIENT_SELECTION_VIEW/Client_Selection_View03"),
                "go back" => RedirectToPage("/Index"),
                _ => NotFound()
            };
        }

    }
}
