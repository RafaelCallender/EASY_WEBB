using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using EASYPROJECT01.EASY_WEBB.Pages.USER_VIEW.USER_SELECTION_VIEW;
namespace EASYPROJECT01.EASY_WEBB.Pages.USER_VIEW.USER_MAIN_VIEW
{
    public class User_Main_View01 : PageModel
    {
                public string[] button_text { get; set; } =
        {
              $"sqlexpress user",
                                           $"mysql user",
                                           $"sqlite",

           $"go back"

        };
        public string[] button_destinations { get; set; } =
        {
               $"User_Selection_View01",
                  $"User_Selection_View02",
                     $"User_Selection_View03",

               $"go back"
        };
        public void OnGet()
        {

        }
        public IActionResult OnPostNavigate(string destination)
        {
            return destination switch
            {
                    "User_Selection_View01" => RedirectToPage("/USER_VIEW/USER_SELECTION_VIEW/User_Selection_View01"),
        
              "User_Selection_View02" => RedirectToPage("/USER_VIEW/USER_SELECTION_VIEW/User_Selection_View02"),
  
               "User_Selection_View03" => RedirectToPage("/USER_VIEW/USER_SELECTION_VIEW/User_Selection_View03"),
                "go back" => RedirectToPage("/Index"),
                _ => NotFound()
            };
        }


         

    }
}
