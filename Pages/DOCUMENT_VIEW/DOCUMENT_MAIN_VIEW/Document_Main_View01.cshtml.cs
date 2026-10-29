using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using EASYPROJECT01.EASY_WEBB.Pages.DOCUMENT_VIEW.DOCUMENT_MAIN_VIEW;
using EASYPROJECT01.EASY_WEBB.Pages.DOCUMENT_VIEW.DOCUMENT_SELECTION_VIEW;

namespace EASYPROJECT01.EASY_WEBB.Pages.DOCUMENT_VIEW.DOCUMENT_MAIN_VIEW
{
    public class Document_Main_View01 : PageModel
    {
        public string[] button_text { get; set; } =
   {
         $"upload document 01",
                                       $"go back"
        };
        public string[] button_destinations { get; set; } =
        {
               $"Document_Selection_View01",
                
                                       $"go back"
        };
        public void OnGet()
        {

        }

        public IActionResult OnPostNavigate(string destination)
        {
            return destination switch
            {
                "Document_Selection_View01" => RedirectToPage("/DOCUMENT_VIEW/DOCUMENT_SELECTION_VIEW/Document_Selection_View01"),
                "go back" => RedirectToPage("/Index"),
                _ => NotFound()
            };
        }
    }
}