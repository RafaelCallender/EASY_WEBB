using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;


namespace EASYPROJECT01.EASY_WEBB.Pages.SPORTS_VIEW.SPORTS_MAIN_VIEW.SPORTS_MAIN_VIEW
{
    public class Sports_Main_View01 : PageModel
    {
        public string[] button_text { get; set; } =
   {
                 $"nba",
                 $"nfl",
                 $"go back"

        };
        public string[] button_destinations { get; set; } =
        {
               $"Sports_Selection_Nba_View01",
                $"Sports_Selection_Nba_View02",
               $"go back"
        };

        public void OnGet()
        {

        }

        public IActionResult OnPostNavigate(string destination)
        {
            return destination switch
            {
                "Sports_Selection_Nba_View01" => RedirectToPage("/SPORTS_VIEW/SPORTS_SELECTION_VIEW/SPORTS_SELECCTION_NBA_VIEW/Sports_Selection_Nba_View01"),
                "Sports_Selection_Nfl_View02" => RedirectToPage("/SPORTS_VIEW/SPORTS_SELECTION_VIEW/SPORTS_SELECCTION_NFL_VIEW/Sports_Selection_Nfl_View01"),
                "go back" => RedirectToPage("/Index"),
                _ => NotFound()
            };
        }


    }
}
