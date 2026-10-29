using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using EASYPROJECT01.EASY_CALLENDER01.SERVICES.FILES.FILE_MANAGER;
using EASYPROJECT01.EASY_CALLENDER01.SERVICES.SECURITY_SERVICES;
using EASYPROJECT01.EASY_CALLENDER01.SERVICES.FILES.FILE_HELPER;
using EASYPROJECT01.EASY_CALLENDER01.MODEL.WEB_MODEL.TEST_VIEW_MODEL;

namespace EASYPROJECT01.EASY_WEBB.Pages.TEST_VIEW.TEST_SELECTION_VIEW
{
    public class Test_Selection_View02 : PageModel
    {

        private static string[] data01 = new string[100];
        [BindProperty]
        public Test_View_Model01 Test_View_M01 { get; set; } = new Test_View_Model01();
        private static File_Manger02 File_M02 = new File_Manger02();
        private static Dictionary<string, Action> _commands = new Dictionary<string, Action>(StringComparer.OrdinalIgnoreCase);
        private static Security_Services01 Security_Serv01 = new Security_Services01();
        private static string menu_string =
                  $"API01\n" +
                   $"API02\n" +
                   $"API03\n" +
                   $"Client_Textfile01\n" +
                   $"Client_Textfile02\n" +
                   $"Client_Textfile03\n" +
                   $"Client_Textfile04\n" +
                   $"Client_Textfile05\n" +
                   $"cloudinary_com_text01\n" +
                   $"cloudinary_com_text02\n" +
                   $"cloudinary_com_text03\n" +
                   $"Admin_text01\n" +
                   $"Admin_text02\n" +
                   $"Admin_text03\n" +
                   $"Admin_text04\n" +
                   $"Linux_text04\n" +
                   $"Linux_text05\n" +
                   $"Linux_text06\n" +
                   $"list all textfiles\n" +
                   $"list all textfiles 01\n" +
                   $"list all saved textfiles\n" +
                   $"list all saved textfiles 01\n" +
                   $"list all directories\n" +
                    $"list all directories 01\n" +
                    $"data reader\n" +
$"data reader 01\n" +
$"file array\n" +
   $"back\n";
        private static string[] menu_array01 = menu_string.Split("\n");
        public void OnGet()
        {
            OnPost();
        }

        private void load_Selection_data01()
        {
            string procedure = menu_array01[int.Parse(Test_View_M01.SelectedProject) - 1].Trim();
            switch (procedure)
            {


                case "API01":
                    _commands.Add(procedure, API01);
                    break;
                case "API02":
                    _commands.Add(procedure, API02);
                    break;
                case "API03":
                    _commands.Add(procedure, API03);
                    break;
                case "Client_Textfile01":
                    _commands.Add(procedure, Client_Textfile01);
                    break;
                case "Client_Textfile02":
                    _commands.Add(procedure, Client_Textfile02);
                    break;
                case "Client_Textfile03":
                    _commands.Add(procedure, Client_Textfile03);
                    break;
                case "Client_Textfile04":
                    _commands.Add(procedure, Client_Textfile04);
                    break;
                case "Client_Textfile05":
                    _commands.Add(procedure, Client_Textfile05);
                    break;
                case "cloudinary_com_text01":
                    _commands.Add(procedure, cloudinary_com_text01);
                    break;
                case "cloudinary_com_text02":
                    _commands.Add(procedure, cloudinary_com_text02);
                    break;
                case "cloudinary_com_text03":
                    _commands.Add(procedure, cloudinary_com_text03);
                    break;
                case "Admin_text01":
                    _commands.Add(procedure, Admin_text01);
                    break;
                case "Admin_text02":
                    _commands.Add(procedure, Admin_text02);
                    break;
                case "Admin_text03":
                    _commands.Add(procedure, Admin_text03);
                    break;
                case "Admin_text04":
                    _commands.Add(procedure, Admin_text04);
                    break;
                case "Linux_text04":
                    _commands.Add(procedure, Linux_text04);
                    break;
                case "Linux_text05":
                    _commands.Add(procedure, Linux_text05);
                    break;
                case "Linux_text06":
                    _commands.Add(procedure, Linux_text06);
                    break;
                case "list all textfiles":
                    _commands.Add(procedure, list_all_textfiles);
                    break;
                case "list all saved textfiles":
                    _commands.Add(procedure, list_all_saved_textfiles);
                    break;
                case "list all saved textfiles 01":
                    _commands.Add(procedure, list_all_saved_textfiles01);
                    break;
                case "list all directories":
                    _commands.Add(procedure, list_all_directories);
                    break;
                case "list all directories 01":
                    _commands.Add(procedure, list_all_directories_01);
                    break;
                case "data reader":
                    _commands.Add(procedure, data_reader);
                    break;
                case "data reader 01":
                    _commands.Add(procedure, data_reader_01);
                    break;
                case "file array":
                    _commands.Add(procedure, file_array);
                    break;

            }
        }
        private void list_all_directories()
        {
            foreach (string a in File_Helper01.directories)
            {
                Test_View_M01.StatusMessage01 += $"{a}\n";
            }
        }
        private void list_all_directories_01()
        {
            Test_View_M01.StatusMessage01 =
       $"{File_Helper01.directories[(int)File_Helper01.directories_string.dog_breads]}\n" +
   $"{File_Helper01.directories[(int)File_Helper01.directories_string.cashapp01]}\n" +
            $"{File_Helper01.directories[(int)File_Helper01.directories_string.default_group_face01]}\n" +
            $"{File_Helper01.directories[(int)File_Helper01.directories_string.default_single_face01]}\n" +
            $"{File_Helper01.directories[(int)File_Helper01.directories_string.default_single_face02]}\n" +
            $"{File_Helper01.directories[(int)File_Helper01.directories_string.default_single_face03]}\n" +
            $"{File_Helper01.directories[(int)File_Helper01.directories_string.cashapp02]}\n" +
            $"{File_Helper01.directories[(int)File_Helper01.directories_string.cashapp03]}\n" +
            $"{File_Helper01.directories[(int)File_Helper01.directories_string.EYE_ICON01]}\n" +
            $"{File_Helper01.directories[(int)File_Helper01.directories_string.paypal01]}\n" +
            $"{File_Helper01.directories[(int)File_Helper01.directories_string.paypal02]}\n" +
            $"{File_Helper01.directories[(int)File_Helper01.directories_string.paypal03]}\n" +
            $"{File_Helper01.directories[(int)File_Helper01.directories_string.venmo02]}\n" +
            $"{File_Helper01.directories[(int)File_Helper01.directories_string.venmo03]}\n" +
            $"{File_Helper01.directories[(int)File_Helper01.directories_string.zelleimage01]}\n" +
            $"{File_Helper01.directories[(int)File_Helper01.directories_string.zelleimages02]}\n" +
            $"{File_Helper01.directories[(int)File_Helper01.directories_string.learning_icon01]}\n" +
            $"{File_Helper01.directories[(int)File_Helper01.directories_string.person01]}\n" +
            $"{File_Helper01.directories[(int)File_Helper01.directories_string.Easy_Callender_page_1]}\n" +
            $"{File_Helper01.directories[(int)File_Helper01.directories_string.venmo01]}\n" +
            $"{File_Helper01.directories[(int)File_Helper01.directories_string.GMAIL01]}\n" +
            $"{File_Helper01.directories[(int)File_Helper01.directories_string.Book_of_Jasher]}\n" +
            $"{File_Helper01.directories[(int)File_Helper01.directories_string.book_of_judith]}\n" +
            $"{File_Helper01.directories[(int)File_Helper01.directories_string.Dead_Sea_Scrolls]}\n" +
            $"{File_Helper01.directories[(int)File_Helper01.directories_string.The_Book_of_Enoch]}\n" +
            $"{File_Helper01.directories[(int)File_Helper01.directories_string.The_Book_of_Jubilees]}\n" +
            $"{File_Helper01.directories[(int)File_Helper01.directories_string.The_Book_of_TOB]}\n" +
            $"{File_Helper01.directories[(int)File_Helper01.directories_string.Admin]}\n" +
            $"{File_Helper01.directories[(int)File_Helper01.directories_string.API]}\n" +
            $"{File_Helper01.directories[(int)File_Helper01.directories_string.Chemistry]}\n" +
            $"{File_Helper01.directories[(int)File_Helper01.directories_string.Chemistry01]}\n" +
            $"{File_Helper01.directories[(int)File_Helper01.directories_string.Client_Textfile01]}\n" +
            $"{File_Helper01.directories[(int)File_Helper01.directories_string.cloudinary_com]}\n" +
            $"{File_Helper01.directories[(int)File_Helper01.directories_string.GMAIL_CREDENTIAL]}\n" +
            $"{File_Helper01.directories[(int)File_Helper01.directories_string.hairstyle_info_01]}\n" +
            $"{File_Helper01.directories[(int)File_Helper01.directories_string.hairstyle_info_02]}\n" +
            $"{File_Helper01.directories[(int)File_Helper01.directories_string.Language_Abbreviation]}\n" +
            $"{File_Helper01.directories[(int)File_Helper01.directories_string.Language_Name]}\n" +
            $"{File_Helper01.directories[(int)File_Helper01.directories_string.Sql_info01]}\n" +
            $"{File_Helper01.directories[(int)File_Helper01.directories_string.The_Bible_KJV]}\n" +
            $"{File_Helper01.directories[(int)File_Helper01.directories_string.The_Book_of_Enoch_pdf]}\n" +
            $"{File_Helper01.directories[(int)File_Helper01.directories_string.The_Book_of_Jubilees_pdf]}\n" +
            $"{File_Helper01.directories[(int)File_Helper01.directories_string.nba_text]}\n" +
            $"{File_Helper01.directories[(int)File_Helper01.directories_string.Linux01]}\n" +
            $"{File_Helper01.directories[(int)File_Helper01.directories_string.mytextfile01]}\n" +
           $"{File_Helper01.directories[(int)File_Helper01.directories_string.mytextfile02]}\n" +
            $"{File_Helper01.directories[(int)File_Helper01.directories_string.mytextfile03]}\n" +
            $"{File_Helper01.directories[(int)File_Helper01.directories_string.mytextfile04]}\n" +
            $"{File_Helper01.directories[(int)File_Helper01.directories_string.mytextfile05]}\n" +
            $"{File_Helper01.directories[(int)File_Helper01.directories_string.mytextfile06]}\n" +
            $"{File_Helper01.directories[(int)File_Helper01.directories_string.mytextfile07]}\n" +
            $"{File_Helper01.directories[(int)File_Helper01.directories_string.aboutus]}\n" +
            $"{File_Helper01.directories[(int)File_Helper01.directories_string.resume01]}\n"

        ;
        }

        private void list_all_saved_textfiles01()
        {
            Test_View_M01.StatusMessage01 = $"{File_Helper01.SavedTextDirectory01[(int)File_Helper01.SavedTextDirectory_strings.mytextfile01]}\n" +
                              $"{File_Helper01.SavedTextDirectory01[(int)File_Helper01.SavedTextDirectory_strings.mytextfile02]}\n" +
                              $"{File_Helper01.SavedTextDirectory01[(int)File_Helper01.SavedTextDirectory_strings.mytextfile03]}\n" +
                              $"{File_Helper01.SavedTextDirectory01[(int)File_Helper01.SavedTextDirectory_strings.mytextfile04]}\n" +
                              $"{File_Helper01.SavedTextDirectory01[(int)File_Helper01.SavedTextDirectory_strings.mytextfile05]}\n" +
                              $"{File_Helper01.SavedTextDirectory01[(int)File_Helper01.SavedTextDirectory_strings.mytextfile06]}\n"



            ;

        }

        private void data_reader()
        {
            foreach (string a in File_Helper01.data01)
            {
                Test_View_M01.StatusMessage01 = $"{a}\n";
            }

        }

        private void file_array()
        {
            foreach (string a in File_Helper01.file_array01)
            {
                Test_View_M01.StatusMessage01 = $"{a}\n";
            }

        }
        private void data_reader_01()
        {
            Test_View_M01.StatusMessage01 =

      $"Admin:{File_Helper01.data01[(int)File_Helper01.text_string.Admin]}\n" +
        $"API: {File_Helper01.data01[(int)File_Helper01.text_string.API]}\n" +
  $"Chemistry: {File_Helper01.data01[(int)File_Helper01.text_string.Chemistry]}\n" +
  $"Chemistry01: {File_Helper01.data01[(int)File_Helper01.text_string.Chemistry01]}\n" +
  $"Client_Textfile01: {File_Helper01.data01[(int)File_Helper01.text_string.Client_Textfile01]}\n" +
  $"cloudinary_com: {File_Helper01.data01[(int)File_Helper01.text_string.cloudinary_com]}\n" +
  $"GMAIL_CREDENTIAL: {File_Helper01.data01[(int)File_Helper01.text_string.GMAIL_CREDENTIAL]}\n" +
  $"hairstyle_info_01: {File_Helper01.data01[(int)File_Helper01.text_string.hairstyle_info_01]}\n" +
  $"hairstyle_info_02: {File_Helper01.data01[(int)File_Helper01.text_string.hairstyle_info_02]}\n" +
  $"Language_Abbreviation: {File_Helper01.data01[(int)File_Helper01.text_string.Language_Abbreviation]}\n" +
  $"Language_Name:{File_Helper01.data01[(int)File_Helper01.text_string.Language_Name]}\n" +
  $"Sql_info01:{File_Helper01.data01[(int)File_Helper01.text_string.Sql_info01]}\n" +
  $"The_Bible_KJV:{File_Helper01.data01[(int)File_Helper01.text_string.The_Bible_KJV]}\n" +
  $"The_Book_of_Enoch:{File_Helper01.data01[(int)File_Helper01.text_string.The_Book_of_Enoch]}\n" +
  $"The_Book_of_Jubilees:{File_Helper01.data01[(int)File_Helper01.text_string.The_Book_of_Jubilees]}\n" +
  $"nba_text:{File_Helper01.data01[(int)File_Helper01.text_string.nba_text]}\n" +
  $"Linux01:{File_Helper01.data01[(int)File_Helper01.text_string.Linux01]}\n" +
  $"mytextfile01:{File_Helper01.data01[(int)File_Helper01.text_string.mytextfile01]}\n" +
  $"mytextfile02:{File_Helper01.data01[(int)File_Helper01.text_string.mytextfile02]}\n" +
  $"mytextfile03:{File_Helper01.data01[(int)File_Helper01.text_string.mytextfile03]}\n" +
  $"mytextfile04:{File_Helper01.data01[(int)File_Helper01.text_string.mytextfile04]}\n" +
  $"mytextfile05:{File_Helper01.data01[(int)File_Helper01.text_string.mytextfile05]}\n" +
  $"mytextfile06:{File_Helper01.data01[(int)File_Helper01.text_string.mytextfile06]}\n" +
  $"mytextfile07:{File_Helper01.data01[(int)File_Helper01.text_string.mytextfile07]}\n" +
  $"aboutus:{File_Helper01.data01[(int)File_Helper01.text_string.aboutus]}\n"

      ;

        }


        private void API01()
        {
            Test_View_M01.StatusMessage01 = File_Manger01.API01;
        }
        private void API02()
        {

            Test_View_M01.StatusMessage01 = File_Manger01.API02;
        }
        private void API03()
        {

            Test_View_M01.StatusMessage01 = File_Manger01.API03;
        }
        private void Client_Textfile01()
        {
            Test_View_M01.StatusMessage01 = File_Manger01.API03;
        }
        private void Client_Textfile02()
        {
            Test_View_M01.StatusMessage01 = File_Manger01.API03;
        }
        private void Client_Textfile03()
        {
            Test_View_M01.StatusMessage01 = File_Manger01.API03;
        }
        private void Client_Textfile04()
        {
            Test_View_M01.StatusMessage01 = File_Manger01.API03;
        }
        private void Client_Textfile05()
        {
            Test_View_M01.StatusMessage01 = File_Manger01.API03;
        }
        private void cloudinary_com_text01()
        {
            Test_View_M01.StatusMessage01 = File_Manger01.API03;
        }
        private void cloudinary_com_text02()
        {
            Test_View_M01.StatusMessage01 = File_Manger01.API03;
        }
        private void cloudinary_com_text03()
        {
            Test_View_M01.StatusMessage01 = File_Manger01.API03;
        }
        private void Admin_text01()
        {
            Test_View_M01.StatusMessage01 = File_Manger01.API03;
        }
        private void Admin_text02()
        {
            Test_View_M01.StatusMessage01 = File_Manger01.API03;
        }
        private void Admin_text03()
        {
            Test_View_M01.StatusMessage01 = File_Manger01.API03;
        }
        private void Admin_text04()
        {
            Test_View_M01.StatusMessage01 = File_Manger01.API03;
        }
        private void Linux_text04()
        {
            Test_View_M01.StatusMessage01 = File_Manger01.API03;
        }
        private void Linux_text05()
        {
            Test_View_M01.StatusMessage01 = File_Manger01.API03;
        }
        private void Linux_text06()
        {
            Test_View_M01.StatusMessage01 = File_Manger01.API03;
        }
        private void list_all_textfiles()
        {
            int count = 0;
            foreach (string a in File_Helper01.text_files_list)
            {
                count++;
                Test_View_M01.StatusMessage01 = $"{count}.){a}\n";
            }

        }
        private void list_all_saved_textfiles()
        {
            Test_View_M01.StatusMessage01 = $"{File_Helper01.SavedTextDirectory[(int)File_Helper01.SavedTextDirectory_strings.mytextfile01]}\n" +
                                  $"{File_Helper01.SavedTextDirectory[(int)File_Helper01.SavedTextDirectory_strings.mytextfile02]}\n" +
                                  $"{File_Helper01.SavedTextDirectory[(int)File_Helper01.SavedTextDirectory_strings.mytextfile03]}\n" +
                                  $"{File_Helper01.SavedTextDirectory[(int)File_Helper01.SavedTextDirectory_strings.mytextfile04]}\n" +
                                  $"{File_Helper01.SavedTextDirectory[(int)File_Helper01.SavedTextDirectory_strings.mytextfile05]}\n" +
                                  $"{File_Helper01.SavedTextDirectory[(int)File_Helper01.SavedTextDirectory_strings.mytextfile06]}\n";

        }

        private void LoadOptions()
        {

            Test_View_M01.ProjectOptions = new List<SelectListItem>();
            for (int i = 0; i < menu_array01.Length; i++)
            {
                Test_View_M01.ProjectOptions.Add(
                    new SelectListItem
                    {
                        Value = (i + 1).ToString(),
                        Text = menu_array01[i].Trim()
                    });
            }
        }
        private void load_default_view()
        {
            Test_View_M01.ShowInput01 = false;

        }
        private void load_default_view01()
        {
            Test_View_M01.ShowInput01 = true;
        }
        private void Picker01_SelectedIndexChanged()
        {

            switch (menu_array01[int.Parse(Test_View_M01.SelectedProject) - 1].Trim())
            {
                case "API01":
                    load_default_view();
                    break;
                case "API02":
                    load_default_view();
                    break;
                case "API03":
                    load_default_view();
                    break;
                case "Client_Textfile01":
                    load_default_view();
                    break;
                case "Client_Textfile02":
                    load_default_view();
                    break;
                case "Client_Textfile03":
                    load_default_view();
                    break;
                case "Client_Textfile04":
                    load_default_view();
                    break;
                case "Client_Textfile05":
                    load_default_view();
                    break;
                case "cloudinary_com_text01":
                    load_default_view();
                    break;
                case "cloudinary_com_text02":
                    load_default_view();
                    break;
                case "cloudinary_com_text03":
                    load_default_view();
                    break;
                case "Admin_text01":
                    load_default_view();
                    break;
                case "Admin_text02":
                    load_default_view();
                    break;
                case "Admin_text03":
                    load_default_view();
                    break;
                case "Admin_text04":
                    load_default_view();
                    break;
                case "Linux_text04":
                    load_default_view();
                    break;
                case "Linux_text05":
                    load_default_view();
                    break;
                case "Linux_text06":
                    load_default_view();
                    break;
                case "list all textfiles":
                    load_default_view();
                    break;
                case "list all saved textfiles":
                    load_default_view();
                    break;
                case "list all saved textfiles 01":
                    load_default_view();
                    break;
                case "list all directories":
                    load_default_view();
                    break;
                case "list all directories 01":
                    load_default_view();
                    break;
                case "data reader":
                    load_default_view();
                    break;
                case "data reader 01":
                    load_default_view();
                    break;
                case "file array":
                    load_default_view();
                    break;


            }
        }

        private void load_Selection01()
        {
            if (Security_Serv01.isPicker_selected_web(Test_View_M01.SelectedProject, menu_array01, out data01[24]) == true)
            {
                string key = menu_array01[int.Parse(Test_View_M01.SelectedProject) - 1].Trim();
                load_Selection_data01();
                if (_commands.TryGetValue(key, out Action action))
                {
                    action();
                    _commands.Clear();
                }
                else
                {
                    Test_View_M01.StatusMessage01 = $"{key} command not found";
                }
            }
            else
            {
                Test_View_M01.StatusMessage01 = data01[24];
            }
        }
        public IActionResult OnPost()
        {

            load_default_view();
            if (Security_Serv01.isPicker_selected_web(Test_View_M01.SelectedProject,
            menu_array01, out data01[1]) == true)
            {
                Test_View_M01.StatusMessage01 = string.Empty;
                Picker01_SelectedIndexChanged();

            }
            else
            {
                Test_View_M01.StatusMessage01 = data01[1];
            }
            LoadOptions();
            return Page();
        }
        public IActionResult OnPostOk()
        {
            load_Selection01();
            if (Security_Serv01.isPicker_selected_web(Test_View_M01.SelectedProject,
     menu_array01, out data01[1]) == true)
            {
                Test_View_M01.StatusMessage01 = string.Empty;
                Picker01_SelectedIndexChanged();

            }
            else
            {
                Test_View_M01.StatusMessage01 = data01[1];
                Picker01_SelectedIndexChanged();

            }
            LoadOptions();
            return Page();
        }
        public IActionResult OnPostBack()
        {
            return RedirectToPage("/TEST_VIEW/TEST_MAIN_VIEW/Test_Main_View01");
        }
    }
}
