using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EASYPROJECT01.EASY_WEBB.Pages.JOURNAL_VIEW.JOURNAL_MAIN_VIEW
{
    public class Journal_Main_View01 : PageModel
    {
        public string[] button_text { get; set; } =
 {
       $"Journal sqlexpress",
       $"Journal sqlite",
                  $"Journal Mysql",
                                       $"go back"
        };
        public string[] button_destinations { get; set; } =
        {
               $"Journal_Selection_View01",
               $"Journal_Selection_View02",
               $"Journal_Selection_View03", 
               $"Journal_Selection_View04",
               $"go back"
        };
        public void OnGet()
        {

        }
        public IActionResult OnPostNavigate(string destination)
        {
            return destination switch
            {
                "Journal_Selection_View01" => RedirectToPage("/JOURNAL_VIEW/JOURNAL_SELECTION_VIEW/Journal_Selection_View01"),
                "Journal_Selection_View02" => RedirectToPage("/JOURNAL_VIEW/JOURNAL_SELECTION_VIEW/Journal_Selection_View02"),
                "Journal_Selection_View03" => RedirectToPage("/JOURNAL_VIEW/JOURNAL_SELECTION_VIEW/Journal_Selection_View03"),
                "Journal_Selection_View04" => RedirectToPage("/Index"),
                "go back" => RedirectToPage("/Index"),
                _ => NotFound()
            };
        }
    }
}
