using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using EASYPROJECT01.EASY_CALLENDER01.TEMPLATE.WEB_TEMPLATE;
namespace EASYPROJECT01.EASY_WEBB.Pages.WINDOWS_VIEW.WINDOWS_SELECTION_VIEW
{
    public class Windows_Selection_View01 : PageModel
    {
        public string css01 { get; set; } = Web_Template01.ccs01;
        public void OnGet()
        {


        }
        public IActionResult OnPostBack()
        {


            return RedirectToPage("/WINDOWS_VIEW/WINDOWS_MAIN_VIEW/Windows_Main_View01");
        }
    }
}
