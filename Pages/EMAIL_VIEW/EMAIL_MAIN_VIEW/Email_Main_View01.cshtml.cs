using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

using EASYPROJECT01.EASY_CALLENDER01.TEMPLATE.WEB_TEMPLATE;
namespace EASYPROJECT01.EASY_WEBB.Pages.EMAIL_VIEW.EMAIL_MAIN_VIEW
{
    public class Email_Main_View01 : PageModel
    {
        public string css01 { get; set; } = Web_Template01.ccs01;
        public string[] button_text { get; set; } =
{
        $"email using sql",
                $"email using sqlite",
                $"email using Mysql",
                $"send email",
                                       $"go back"
        };
        public string[] button_destinations { get; set; } =
        {
               $"Email_Selection_View01",
               $"Email_Selection_View02",
               $"Email_Selection_View03",
               $"Email_Selection_View04",

                                       $"go back"
        };
        public void OnGet()
        {

        }
        public IActionResult OnPostNavigate(string destination)
        {
            return destination switch
            {

                "Email_Selection_View01" => RedirectToPage("/EMAIL_VIEW/EMAIL_SELECTION_VIEW/Email_Selection_View01"),
                "Email_Selection_View02" => RedirectToPage("/EMAIL_VIEW/EMAIL_SELECTION_VIEW/Email_Selection_View02"),
                "Email_Selection_View03" => RedirectToPage("/EMAIL_VIEW/EMAIL_SELECTION_VIEW/Email_Selection_View03"),
                "Email_Selection_View04" => RedirectToPage("/EMAIL_VIEW/EMAIL_SELECTION_VIEW/Email_Selection_View04"),
                "go back" => RedirectToPage("/Index"),
                _ => NotFound()
            };
        }
    }
}