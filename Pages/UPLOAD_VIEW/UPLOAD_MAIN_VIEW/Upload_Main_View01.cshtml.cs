using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EASYPROJECT01.EASY_WEBB.Pages.UPLOAD_VIEW.UPLOAD_MAIN_VIEW
{
    public class Upload_Main_View01 : PageModel
    {
               public string[] button_text { get; set; } =
        {
               $"upload file using sqlexpress\n" +
                        $"upload file using mysql\n" +
                        $"upload file using sqlite\n" +
           $"go back"

        };
        public string[] button_destinations { get; set; } =
        {
               $"Upload_Selection_View01",
                $"Upload_Selection_View02",
                 $"Upload_Selection_View03",
               $"go back"
        };
        public void OnGet()
        {

        }
        public IActionResult OnPostNavigate(string destination)
        {
            return destination switch
            {
        
             "Upload_Selection_View01" =>  RedirectToPage("/UPLOAD_VIEW/UPLOAD_SELECTION_VIEW/Upload_Selection_View01"),
             "Upload_Selection_View02" =>  RedirectToPage("/UPLOAD_VIEW/UPLOAD_SELECTION_VIEW/Upload_Selection_View02"),
             "Upload_Selection_View03" =>  RedirectToPage("/UPLOAD_VIEW/UPLOAD_SELECTION_VIEW/Upload_Selection_View03"),
                "go back" => RedirectToPage("/Index"),
                _ => NotFound()
            };
        }

   
    }
}
