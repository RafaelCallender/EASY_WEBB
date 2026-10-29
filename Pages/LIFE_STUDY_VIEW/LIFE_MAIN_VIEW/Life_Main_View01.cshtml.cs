using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EASYPROJECT01.EASY_WEBB.Pages.LIFE_STUDY_VIEW.LIFE_MAIN_VIEW
{
    public class Life_Main_View01 : PageModel
    {
        public string[] button_text { get; set; } =
{
       $"The Bible",
            $"The Book of Enoch",
            $"The Book of Jubilees",
            $"all Books",
            $"Book_of_Jasher",
            $"book_of_judith",
            $"Dead_Sea_Scrolls",
            $"The_Book_of_TOB",
                                       $"go back"
        };
        public string[] button_destinations { get; set; } =
        {
               $"Life_Selection_View01",
                $"Life_Selection_View02",
                 $"Life_Selection_View03",
                  $"Life_Selection_View04",
                   $"Life_Selection_View05",
 $"Life_Selection_View06",
  $"Life_Selection_View07",
    $"Life_Selection_View08",
                                       $"go back"
        };
        public void OnGet()
        {

        }
        public IActionResult OnPostNavigate(string destination)
        {
            return destination switch
            {
                "Life_Selection_View01" => RedirectToPage("/LIFE_STUDY_VIEW/LIFE_SELECTION_VIEW/Life_Selection_View01"),
                "Life_Selection_View02" => RedirectToPage("/LIFE_STUDY_VIEW/LIFE_SELECTION_VIEW/Life_Selection_View02"),
                "Life_Selection_View03" => RedirectToPage("/LIFE_STUDY_VIEW/LIFE_SELECTION_VIEW/Life_Selection_View03"),
                "Life_Selection_View04" => RedirectToPage("/LIFE_STUDY_VIEW/LIFE_SELECTION_VIEW/Life_Selection_View04"),
                "Life_Selection_View05" => RedirectToPage("/LIFE_STUDY_VIEW/LIFE_SELECTION_VIEW/Life_Selection_View05"),
                "Life_Selection_View06" => RedirectToPage("/LIFE_STUDY_VIEW/LIFE_SELECTION_VIEW/Life_Selection_View06"),
                "Life_Selection_View07" => RedirectToPage("/LIFE_STUDY_VIEW/LIFE_SELECTION_VIEW/Life_Selection_View07"),
                "Life_Selection_View08" => RedirectToPage("/LIFE_STUDY_VIEW/LIFE_SELECTION_VIEW/Life_Selection_View08"),
                "go back" => RedirectToPage("/Index"),
                _ => NotFound()
            };
        }
    }
}

