using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EASYPROJECT01.EASY_WEBB.Pages.AI_VIEW.AI_SELECTION_VIEW
{
    public class Ai_Selection_View03 : PageModel
    {
        public void OnGet()
        {




        }
        public IActionResult OnPostBack()
        {
            return RedirectToPage("/AI_VIEW/AI_MAIN_VIEW/Ai_Main_View01");
        }
    }
}
