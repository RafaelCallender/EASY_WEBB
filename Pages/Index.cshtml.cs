using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
namespace EASYPROJECT01.EASY_WEBB.Pages
{
    public class Index : PageModel
    {
        public string[] button_text { get; set; } =
{
               "Ai_Main_View01",
                "go back",
                "Client_Main_View01",
                "Colors_Main_View01",
                "Email_Main_View01",
                "Journal_Main_View01",
                "Life_Main_View01",
                "Linux_Main_View01",
                "Location_Main_View01",
                "Mac_Main_View01",
                "Movies_Main_View01",
                "Network_Main_View01",
                "News_Main_View01",
                "Science_Main_View01",
                "Sports_Main_View01",
                "Studio_Main_View01",
                "Test_Main_View01",
                "Translate_Main_View01",
                "User_Main_View01",
                "Windows_Main_View01",
                "aboutus",
                "Document_Main_View01",
                "Device_Main_View01",
        };
        public string[] button_destinations { get; set; } =
        {
                "Ai_Main_View01",
                "go back",
                "Client_Main_View01",
                "Colors_Main_View01",
                "Email_Main_View01",
                "Journal_Main_View01",
                "Life_Main_View01",
                "Linux_Main_View01",
                "Location_Main_View01",
                "Mac_Main_View01",
                "Movies_Main_View01",
                "Network_Main_View01",
                "News_Main_View01",
                "Science_Main_View01",
                "Sports_Main_View01",
                "Studio_Main_View01",
                "Test_Main_View01",
                "Translate_Main_View01",
                "User_Main_View01",
                "Windows_Main_View01",
                "aboutus",
                "Document_Main_View01",
                "Device_Main_View01",
        };
        public void OnGet()
        {

        }
        public IActionResult OnPostNavigate(string destination)
        {
            return destination switch
            {
                "Ai_Main_View01" => RedirectToPage("/AI_VIEW/AI_MAIN_VIEW/Ai_Main_View01"),
                "go back"=>RedirectToPage("/Index"),
                "Client_Main_View01" => RedirectToPage("CLIENT_VIEW/CLIENT_MAIN_VIEW/Client_Main_View01"),
                "Colors_Main_View01" => RedirectToPage("/COLORS_VIEW/COLORS_MAIN_VIEW/Colors_Main_View01"),
                "Email_Main_View01" => RedirectToPage("/EMAIL_VIEW/EMAIL_MAIN_VIEW/Email_Main_View01"),
                "Journal_Main_View01" => RedirectToPage("/JOURNAL_VIEW/JOURNAL_MAIN_VIEW/Journal_Main_View01"),
                "Life_Main_View01" => RedirectToPage("/LIFE_STUDY_VIEW/LIFE_MAIN_VIEW/Life_Main_View01"),
                "Linux_Main_View01" => RedirectToPage("/LINUX_VIEW/LINUX_MAIN_VIEW/Linux_Main_View01"),
                "Location_Main_View01" => RedirectToPage("/LOCATION_VIEW/LOCATION_MAIN_VIEW/Location_Main_View01"),
                "Mac_Main_View01" => RedirectToPage("/MAC_VIEW/MAC_MAIN_VIEW/Mac_Main_View01"),
                "Movies_Main_View01" => RedirectToPage("/MOVIES_VIEW/MOVIES_MAIN_VIEW/Movies_Main_View01"),
                "Network_Main_View01" => RedirectToPage("/NETWORK_VIEW/NETWORK_MAIN_VIEW/Network_Main_View01"),
                "News_Main_View01" => RedirectToPage("/NEWS_VIEW/NEWS_MAIN_VIEW/News_Main_View01"),
                "Science_Main_View01" => RedirectToPage("/SCIENCE_VIEW/SCIENCE_MAIN_VIEW/Science_Main_View01"),
                "Sports_Main_View01" => RedirectToPage("/SPORTS_VIEW/SPORTS_MAIN_VIEW/Sports_Main_View01"),
                "Studio_Main_View01" => RedirectToPage("/STUIDO_VIEW/STUDIO_MAIN_VIEW/Studio_Main_View01"),
                "Test_Main_View01" => RedirectToPage("/TEST_VIEW/TEST_MAIN_VIEW/Test_Main_View01"),
                "Translate_Main_View01" => RedirectToPage("/TRANSLATE_VIEW/TRANSLATE_MAIN_VIEW/Translate_Main_View01"),
                "User_Main_View01" => RedirectToPage("/USER_VIEW/USER_MAIN_VIEW/User_Main_View01"),
                "Windows_Main_View01" => RedirectToPage("/WINDOWS_VIEW/WINDOWS_MAIN_VIEW/Windows_Main_View01"),
                "aboutus" => RedirectToPage("/ABOUT_US_VIEW/ABOUT_US_MAIN_VIEW/About_Main_View01"),
                "Document_Main_View01" => RedirectToPage("/DOCUMENT_VIEW/DOCUMENT_MAIN_VIEW/Document_Main_View01"),
                "Device_Main_View01" => RedirectToPage("/DEVICE_VIEW/DEVICE_MAIN_VIEW/Device_Main_View01"),
                _ => NotFound()
            };
        }


    }

}

