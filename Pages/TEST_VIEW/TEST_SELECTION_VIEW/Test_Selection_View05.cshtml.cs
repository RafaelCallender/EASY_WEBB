using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EASYPROJECT01.EASY_WEBB.Pages.TEST_VIEW.TEST_SELECTION_VIEW
{
    public class Test_Selection_View05 : PageModel
    {
        public void OnGet()
        {


        }
        public IActionResult OnPostBack()
        {


            return RedirectToPage("/TEST_VIEW/TEST_MAIN_VIEW/Test_Main_View01");
        }
    }
}
