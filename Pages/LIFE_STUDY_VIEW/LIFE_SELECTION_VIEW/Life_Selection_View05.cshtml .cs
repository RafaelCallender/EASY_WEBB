using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using EASYPROJECT01.EASY_CALLENDER01.MODEL.WEB_MODEL.LIFE_VIEW_MODEL;
using EASYPROJECT01.EASY_CALLENDER01.SERVICES.FILES.FILE_MANAGER;
using EASYPROJECT01.EASY_CALLENDER01.SERVICES.AUDIO_SERVICES;
using EASYPROJECT01.EASY_CALLENDER01.SERVICES.SECURITY_SERVICES;
using EASYPROJECT01.EASY_CALLENDER01.SERVICES.AI_SERVICES.AI_TEXT_TO_TEXT;
using EASYPROJECT01.EASY_CALLENDER01.SERVICES.FILES.FILE_MANAGER;
using EASYPROJECT01.EASY_CALLENDER01.SERVICES.FILES.FILE_SERVICES;
using EASYPROJECT01.EASY_CALLENDER01.SERVICES.FILES.FILE_HELPER;

namespace EASYPROJECT01.EASY_WEBB.Pages.LIFE_STUDY_VIEW.LIFE_SELECTION_VIEW
{
    public class Life_Selection_View05 : PageModel
    {
        [BindProperty]
        public Life_View_Model01 Life_View_M01 { get; set; } = new Life_View_Model01();
        private static string[] data01 = new string[100];
        private static Security_Services01 Security_Serv01 = new Security_Services01();
        private static File_Manger13 File_M13 = new File_Manger13();
        private static Audio_Services01 Audio_Serv01 = new Audio_Services01();
        private static string menu_string01 = "Read the Jasher\n" +
                                            "Audio book of the Jasher\n" +
                                            "Questions about the Jasher\n" +
                                              $"write your thoughts\n" +
                                        $"Speak your thoughts\n" +
                                        $"listen to past recorded thoughts\n" +
                                        $"read past recorded thoughts\n";

        private static string[] menu_array01 = menu_string01.Split("\n");
        private static Dictionary<string, Action> _commands = new Dictionary<string, Action>(StringComparer.OrdinalIgnoreCase);
        private static string book01 = string.Empty;
        private static File_Servicesr01 File_Serv01 = new File_Servicesr01();
        private static string filepath = File_Helper01.text_files_list[(int)File_Helper01.text_string.mytextfile05].Trim();
        private static bool content_bool = File_Serv01.Read_Document01(filepath, out data01[50]);
        private static string content_string = data01[50];
        public void OnGet()
        {
            OnPost();
        }

        public IActionResult OnPost()
        {
            book01 = File_M13.Book_of_Jasher_pdf;
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

                case "Read the Jasher":
                    load_default_view();
                    Life_View_M01.StatusMessage01 = string.Empty;
                    break;
                case "Audio book of the Jasher":
                    load_default_view();
                    Life_View_M01.StatusMessage01 = string.Empty;
                    break;
                case "Questions about the Jasher":
                    load_default_view();
                    Life_View_M01.StatusMessage01 = string.Empty;
                    break;
                case "write your thoughts":
                    load_default_view01();
                    Life_View_M01.StatusMessage01 = string.Empty;
                    break;
                case "Speak your thoughts":
                    load_default_view();
                    Life_View_M01.StatusMessage01 = string.Empty;
                    break;
                case "listen to past recorded thoughts":
                    load_default_view();
                    Life_View_M01.StatusMessage01 = string.Empty;
                    break;
                case "read past recorded thoughts":
                    load_default_view();
                    Life_View_M01.StatusMessage01 = string.Empty;
                    break;



            }
        }
        private void load_Selection_data01()
        {
            string procedure = menu_array01[int.Parse(Life_View_M01.SelectedProject) - 1].Trim();
            switch (procedure)
            {

                case "Read the Jasher":
                    _commands.Add(procedure, Read_the_Jasher);
                    break;
                case "Audio book of the Jasher":
                    _commands.Add(procedure, audio_book_of_the_Jasher);
                    break;
                case "Questions about the Jasher":
                    _commands.Add(procedure, questions_about_the_Jasher);
                    break;
                case "write your thoughts":
                    _commands.Add(procedure, write_your_thoughts);
                    break;
                case "Speak your thoughts":
                    _commands.Add(procedure, Speak_your_thoughts);
                    break;
                case "listen to past recorded thoughts":
                    _commands.Add(procedure, listen_to_past_recorded_thoughts);
                    break;
                case "read past recorded thoughts":
                    _commands.Add(procedure, read_past_recorded_thoughts);
                    break;

            }

        }
        private void Read_the_Jasher()
        {
            Life_View_M01.StatusMessage01 = book01;
        }
        private async void audio_book_of_the_Jasher()
        {
            Life_View_M01.StatusMessage01 = book01;
            await Audio_Serv01.convert_text_to_voice01_linux(book01);
        }
        private void questions_about_the_Jasher()
        {
            if (Security_Serv01.empty_string(Life_View_M01.input01, out data01[23]) == true)
            {
                if (File_Serv01.write_to_texfile01(filepath, Life_View_M01.input01, out data01[24]) == true)
                {
                    Life_View_M01.StatusMessage01 = "not yet developed";
                }
                else
                {
                    Life_View_M01.StatusMessage01 = data01[24];
                }
            }
            else
            {
                Life_View_M01.StatusMessage01 = data01[23];
            }

        }
        private void write_your_thoughts()
        {
            if (Security_Serv01.empty_string(Life_View_M01.input01, out data01[23]) == true)
            {
                if (File_Serv01.write_to_texfile01(filepath, Life_View_M01.input01, out data01[24]) == true)
                {
                    Life_View_M01.StatusMessage01 = data01[24];
                }
                else
                {
                    Life_View_M01.StatusMessage01 = data01[24];
                }
            }
            else
            {
                Life_View_M01.StatusMessage01 = data01[23];
            }

        }
        private void Speak_your_thoughts()
        {
            Life_View_M01.StatusMessage01 = "not yet develop";
        }
        private async void listen_to_past_recorded_thoughts()
        {
            if (content_bool == true)
            {
                await Audio_Serv01.convert_text_to_voice01_linux(content_string);
                Life_View_M01.StatusMessage01 = content_string;
            }
            else
            {
                Life_View_M01.StatusMessage01 = content_string;
            }
        }
        private void read_past_recorded_thoughts()
        {
            if (content_bool == true)
            {
                Life_View_M01.StatusMessage01 = content_string;
            }
            else
            {
                Life_View_M01.StatusMessage01 = content_string;
            }
        }
        private void load_default_view()
        {
            Life_View_M01.ShowInput01 = false;

        }
        private void load_default_view01()
        {
            Life_View_M01.ShowInput01 = true;

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
