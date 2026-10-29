using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
namespace EASYPROJECT01.EASY_WEBB.Pages.TEST_VIEW.TEST_MAIN_VIEW
{
    public class Test_Main_View01 : PageModel
    {
        public string[] button_text { get; set; } =
        {

                                            $"Read all documents",
                                            $"read all text files",
                                            $"movies files",
                                            $"sqlexpress search",
                                            $"read saved text files",
                                            $"Mysql search",
                                            $"sqlite search",
                                            $"linux commands",
                                            $"gguf_01",
                                            $"read pdf"+
                                            $"go back"

        };
        public string[] button_destinations { get; set; } =
        {
                $"Test_Selection_View01",
                $"Test_Selection_View02",
                $"Test_Selection_View03",
                $"Test_Selection_View04",
                $"Test_Selection_View05",
                $"Test_Selection_View07",
                $"Test_Selection_View08",
                $"Test_Selection_View09",
                $"Test_Selection_View09",
                $"go back"
        };
        public void OnGet()
        {

        }
        public IActionResult OnPostNavigate(string destination)
        {
            return destination switch
            {

                "Test_Selection_View01" => RedirectToPage("/TEST_VIEW/TEST_SELECTION_VIEW/Test_Selection_View01"),
                "Test_Selection_View02" => RedirectToPage("/TEST_VIEW/TEST_SELECTION_VIEW/Test_Selection_View02"),
                "Test_Selection_View03" => RedirectToPage("/TEST_VIEW/TEST_SELECTION_VIEW/Test_Selection_View03"),
                "Test_Selection_View04" => RedirectToPage("/TEST_VIEW/TEST_SELECTION_VIEW/Test_Selection_View04"),
                "Test_Selection_View05" => RedirectToPage("/TEST_VIEW/TEST_SELECTION_VIEW/Test_Selection_View05"),
                "Test_Selection_View06" => RedirectToPage("/TEST_VIEW/TEST_SELECTION_VIEW/Test_Selection_View06"),
                "Test_Selection_View07" => RedirectToPage("/TEST_VIEW/TEST_SELECTION_VIEW/Test_Selection_View07"),
                "Test_Selection_View08" => RedirectToPage("/TEST_VIEW/TEST_SELECTION_VIEW/Test_Selection_View08"),
                "Test_Selection_View09" => RedirectToPage("/TEST_VIEW/TEST_SELECTION_VIEW/Test_Selection_View09"),
                "go back" => RedirectToPage("/Index"),
                _ => NotFound()
            };
        }
    }
}
