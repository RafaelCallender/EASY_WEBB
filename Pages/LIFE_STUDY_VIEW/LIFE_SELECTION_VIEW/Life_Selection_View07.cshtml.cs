using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using EASYPROJECT01.EASY_CALLENDER01.MODEL.WEB_MODEL.LIFE_VIEW_MODEL;
using EASYPROJECT01.EASY_CALLENDER01.SERVICES.FILES.FILE_MANAGER;
using EASYPROJECT01.EASY_CALLENDER01.SERVICES.AUDIO_SERVICES;
using EASYPROJECT01.EASY_CALLENDER01.SERVICES.LIFE_STUDY_SERVICES.BOOK_OF_ENOCH;
using EASYPROJECT01.EASY_CALLENDER01.SERVICES.SECURITY_SERVICES;
using EASYPROJECT01.EASY_CALLENDER01.SERVICES.FILES.FILE_HELPER;
using EASYPROJECT01.EASY_CALLENDER01.SERVICES.AI_SERVICES.AI_TEXT_TO_TEXT;
using EASYPROJECT01.EASY_CALLENDER01.SERVICES.LIFE_STUDY_SERVICES.THE_BOOK_OF_JUBILEES;
using EASYPROJECT01.EASY_CALLENDER01.SERVICES.FILES.FILE_SERVICES;

namespace EASYPROJECT01.EASY_WEBB.Pages.LIFE_STUDY_VIEW.LIFE_SELECTION_VIEW
{
    public class Life_Selection_View07 : PageModel
    {
        [BindProperty]
        public Life_View_Model01 Life_View_M01 { get; set; } = new Life_View_Model01();
        private static string[] data01 = new string[100];
        private static Security_Services01 Security_Serv01 = new Security_Services01();
        private static Audio_Services01 Audio_Serv01 = new Audio_Services01();
        private static string menu_string01 = "Read the TOB\n" +
                                            "Audio book of the TOB\n" +
                                            "Questions about the TOB\n" +
                                            "Record thoughts\n";


        private static string[] menu_array01 = menu_string01.Split("\n");
        private static The_Book_Of_Jubilees01 The_Book_Of_Jubilee = new The_Book_Of_Jubilees01();

        private static Dictionary<string, Action> _commands = new Dictionary<string, Action>(StringComparer.OrdinalIgnoreCase);
        private static File_Manger13 File_M13 = new File_Manger13();
        private static string book01 = string.Empty;
        private static File_Servicesr01 File_Serv01 = new File_Servicesr01();
        private static string filepath = File_Helper01.text_files_list[(int)File_Helper01.text_string.mytextfile03].Trim();
        private static bool content_bool = File_Serv01.Read_Document01(filepath, out data01[50]);
        private static string content_string = data01[50];

        public void OnGet()
        {

            OnPost();

        }
        private void Read_the_TOB()
        {
            Life_View_M01.StatusMessage01 = book01;
        }
        private async void audio_book_of_the_TOB()
        {
            Life_View_M01.StatusMessage01 = book01;
            await Audio_Serv01.convert_text_to_voice01_linux(book01);
        }
        private void questions_about_the_TOB()
        {
            if (Security_Serv01.empty_string(Life_View_M01.input01, out data01[23]) == true)
            {

                Life_View_M01.StatusMessage01 = "not yet developed";
            }
            else
            {
                Life_View_M01.StatusMessage01 = data01[23];
            }

        }
        private void record_thoughts()
        {
            Life_View_M01.StatusMessage01 = "not yet developed";
        }


        public IActionResult OnPost()
        {
            book01 = File_M13.The_Book_of_TOB_pdf;
            load_default_view();
            if (Security_Serv01.isPicker_selected_web(Life_View_M01.SelectedProject,
            menu_array01, out data01[1]) == true)
            {
                Life_View_M01.StatusMessage01 = string.Empty;
                Picker01_SelectedIndexChanged();

            }
            else
            {
                Life_View_M01.StatusMessage01 = data01[1];

            }

            LoadOptions();

            return Page();
        }


        private void LoadOptions()
        {
            Life_View_M01.ProjectOptions = new List<SelectListItem>();
            for (int i = 0; i < menu_array01.Length; i++)
            {
                Life_View_M01.ProjectOptions.Add(
                    new SelectListItem
                    {
                        Value = (i + 1).ToString(),
                        Text = menu_array01[i].Trim()

                    });
            }
        }


        private void Picker01_SelectedIndexChanged()
        {
            switch (menu_array01[int.Parse(Life_View_M01.SelectedProject) - 1].Trim())
            {

                case "Read the TOB":
                    load_default_view();
                    break;
                case "Audio book of the TOB":
                    load_default_view();
                    break;
                case "Questions about the TOB":
                    load_default_view();
                    break;
                case "record thoughts":
                    load_default_view();
                    break;
            }
        }
        private void load_Selection_data01()
        {
            string procedure = menu_array01[int.Parse(Life_View_M01.SelectedProject) - 1].Trim();
            switch (procedure)
            {

                case "Read the TOB":
                    _commands.Add(procedure, Read_the_TOB);
                    break;
                case "Audio book of the TOB":
                    _commands.Add(procedure, audio_book_of_the_TOB);
                    break;
                case "Questions about the TOB":
                    _commands.Add(procedure, questions_about_the_TOB);
                    break;
                case "record thoughts":
                    _commands.Add(procedure, record_thoughts);
                    break;



            }

        }

        private void load_default_view()
        {
            Life_View_M01.ShowInput01 = false;

        }
        private void load_Selection01()
        {

            string key = menu_array01[int.Parse(Life_View_M01.SelectedProject) - 1].Trim();
            load_Selection_data01();
            if (_commands.TryGetValue(key, out Action action))
            {
                action();
                _commands.Clear();
            }
            else
            {
                Life_View_M01.StatusMessage01 = $"{key} command not found";
            }

        }
        public IActionResult OnPostOk()
        {

            if (Security_Serv01.isPicker_selected_web(Life_View_M01.SelectedProject,
     menu_array01, out data01[1]) == true)
            {
                Life_View_M01.StatusMessage01 = string.Empty;
                Picker01_SelectedIndexChanged();
                load_Selection01();
            }
            else
            {
                Life_View_M01.StatusMessage01 = data01[1];


            }

            LoadOptions();
            return Page();
        }

        public IActionResult OnPostBack()
        {
            return RedirectToPage("/LIFE_STUDY_VIEW/LIFE_MAIN_VIEW/Life_Main_View01");
        }
    }
}
