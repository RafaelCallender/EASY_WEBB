using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace EASYPROJECT01.EASY_WEBB.Pages.USER_VIEW.USER_SELECTION_VIEW
{
    public class User_Selection_View02 : PageModel
    {
        public void OnGet()
        {


        }
        public IActionResult OnPostBack()
        {
            return RedirectToPage("/USER_VIEW/USER_MAIN_VIEW/User_Main_View01");

        }
    }
}
