using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;


namespace EASYPROJECT01.EASY_WEBB.Pages.NEWS_VIEW.NEWS_MAIN_VIEW
{
    public class News_Main_View01 : PageModel
    {
        public string[] button_text { get; set; } =
          {
                     $"News API 01",
           $"go back"

        };
        public string[] button_destinations { get; set; } =
        {
               $"News_Selection_View01",
               $"go back"
        };

        public void OnGet()
        {

        }
        public IActionResult OnPostNavigate(string destination)
        {
            return destination switch
            {
                "News_Selection_View01" => RedirectToPage("/NEWS_VIEW/NEWS_SELECTION_VIEW/News_Selection_View01"),
                "go back" => RedirectToPage("/Index"),
                _ => NotFound()
            };
        }
    }
}