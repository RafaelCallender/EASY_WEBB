using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using EASYPROJECT01.EASY_CALLENDER01.TEMPLATE.WEB_TEMPLATE;
namespace EASYPROJECT01.EASY_WEBB.Pages.JOURNAL_VIEW.JOURNAL_SELECTION_VIEW
{
    public class Journal_Selection_View02 : PageModel
    {
        public string css01 { get; set; } = Web_Template01.ccs01;
        public void OnGet()
        {


        }
        public IActionResult OnPostBack()
        {

            return RedirectToPage("/JOURNAL_VIEW/JOURNAL_MAIN_VIEW/Journal_Main_View01");
        }
    }
}
