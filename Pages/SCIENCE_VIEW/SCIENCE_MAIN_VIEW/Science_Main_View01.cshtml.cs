using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EASYPROJECT01.EASY_WEBB.Pages.SCIENCE_VIEW.SCIENCE_MAIN_VIEW
{
    public class Science_Main_View01 : PageModel
    {
        public string[] button_text { get; set; } =
   {
                     $"chemistry 01",
                     $"chemistry 02",
                     $"chemistry 03",
           $"go back"

        };
        public string[] button_destinations { get; set; } =
        {
               $"Science_Selection_View01",
                $"Science_Selection_View02",
                 $"Science_Selection_View03",
               $"go back"
        };

        public void OnGet()
        {

        }

        public IActionResult OnPostNavigate(string destination)
        {
            return destination switch
            {
                "Science_Selection_View01" => RedirectToPage("/SCIENCE_VIEW/SCIENCE_SELECTION_VIEW/Science_Selection_View01"),
                "Science_Selection_View02" => RedirectToPage("/SCIENCE_VIEW/SCIENCE_SELECTION_VIEW/Science_Selection_View02"),
                "Science_Selection_View03" => RedirectToPage("/SCIENCE_VIEW/SCIENCE_SELECTION_VIEW/Science_Selection_View03"),
                "Science_Selection_View04" => RedirectToPage("/SCIENCE_VIEW/SCIENCE_SELECTION_VIEW/Science_Selection_View04"),
                "go back" => RedirectToPage("/Index"),
                _ => NotFound()
            };
        }
    }
}
