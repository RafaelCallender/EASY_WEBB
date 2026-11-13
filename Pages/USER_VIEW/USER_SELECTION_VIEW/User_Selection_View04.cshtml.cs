using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using EASYPROJECT01.EASY_CALLENDER01.TEMPLATE.WEB_TEMPLATE;
namespace EASYPROJECT01.EASY_WEBB.Pages.USER_VIEW.USER_SELECTION_VIEW
{
    public class User_Selection_View04 : PageModel
    {
                public string css01 { get; set; } = Web_Template01.ccs01;
        public void OnGet()
        {


        }
        public IActionResult OnPostBack()
        {


            return RedirectToPage("/USER_VIEW/USER_MAIN_VIEW/User_Main_View01");
        }
    }
}
