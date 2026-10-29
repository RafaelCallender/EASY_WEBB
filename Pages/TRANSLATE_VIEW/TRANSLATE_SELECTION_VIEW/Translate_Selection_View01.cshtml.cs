using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq;
using EASYPROJECT01.EASY_CALLENDER01.SERVICES.AI_SERVICES.AI_TEXT_TO_TEXT;
using EASYPROJECT01.EASY_CALLENDER01.SERVICES.LANGUAGE.LANGUAGE_HELPER;
using EASYPROJECT01.EASY_CALLENDER01.SERVICES.LANGUAGE.LANGUAGE_SERVICES;
using EASYPROJECT01.EASY_CALLENDER01.SERVICES.SECURITY_SERVICES;
using EASYPROJECT01.EASY_CALLENDER01.SERVICES.FILES.FILE_HELPER;
using EASYPROJECT01.EASY_CALLENDER01.MODEL.WEB_MODEL.TRANSLATE_VIEW_MODEL;
using EASYPROJECT01.EASY_CALLENDER01.SERVICES.AUDIO_SERVICES;

namespace EASYPROJECT01.EASY_WEBB.Pages.TRANSLATE_VIEW.TRANSLATE_SELECTION_VIEW
{
    public class Translate_Selection_View01 : PageModel
    {
        [BindProperty]
        public Translate_View_Model01 Translate_View_M01 { get; set; } = new Translate_View_Model01();
        private static string[] data01 = new string[100];
        private static Security_Services01 Security_Serv01 = new Security_Services01();
        private static Language_Services01 Language_Serv01 = new Language_Services01();
        private static File_Helper01 File_H01 = new File_Helper01();
        private static Language_Helper01 Language_H01 = new Language_Helper01();
        private static Dictionary<string, Action> _commands = new Dictionary<string, Action>(StringComparer.OrdinalIgnoreCase);
        private static string menu_string01 =
        $"Tranlate_Text\n" +
           $"Tranlate_Text 01\n" +
       $"Batch_Translation\n" +
       $"Translate_JSON\n" +
       $"Translate_HTML\n" +
       $"Detect_Language\n" +
       $"Translate text to voice\n" +
       $"Supported_languages\n";

        private static string[] menu_array01 = menu_string01.Split("\n");
        private static int counter01 = 0;
        private static Audio_Services01 Audio_Serv01 = new Audio_Services01();
        private static string[] array01 = Language_H01.language.ToArray();
        public void OnGet()
        {
            OnPost();

        }

        private void Picker01_SelectedIndexChanged()
        {
            switch (menu_array01[int.Parse(Translate_View_M01.SelectedProject) - 1].Trim())
            {
                case "Tranlate_Text":
                    load_default_view03();
                    break;
                case "Tranlate_Text 01":
                    load_default_view();
                    break;
                case "Batch_Translation":
                    load_default_view();
                    break;
                case "Translate_JSON":
                    load_default_view();
                    break;
                case "Translate_HTML":
                    load_default_view();
                    break;
                case "Detect_Language":
                    load_default_view();
                    break;
                case "Supported_languages":
                    load_default_view();
                    break;
                case "Translate text to voice":
                    load_default_view03();
                    break;
                default:
                    load_default_view();
                    break;

            }
        }


        public IActionResult OnPost()
        {


            load_default_view();
            if (Security_Serv01.isPicker_selected_web(Translate_View_M01.SelectedProject,
            menu_array01, out data01[1]) == true)
            {
                Translate_View_M01.StatusMessage01 = string.Empty;
                Picker01_SelectedIndexChanged();

            }
            else
            {
                Translate_View_M01.StatusMessage01 = data01[1];

            }

            LoadOptions();
            LoadOptions01();
            return Page();
        }


        private void LoadOptions()
        {
            Translate_View_M01.ProjectOptions = new List<SelectListItem>();
            for (int i = 0; i < menu_array01.Length; i++)
            {
                Translate_View_M01.ProjectOptions.Add(
                    new SelectListItem
                    {
                        Value = (i + 1).ToString(),
                        Text = menu_array01[i].Trim()

                    });
            }
        }
        private void LoadOptions01()
        {


            Translate_View_M01.ProjectOptions01 = new List<SelectListItem>();
            for (int i = 0; i < array01.Length; i++)
            {
                Translate_View_M01.ProjectOptions01.Add(
                    new SelectListItem
                    {
                        Value = (i + 1).ToString(),
                        Text = array01[i].Trim()

                    });
            }
        }


        private void load_Selection_data01()
        {
            string procedure = menu_array01[int.Parse(Translate_View_M01.SelectedProject) - 1].Trim();
            switch (procedure)
            {

                case "Tranlate_Text":
                    _commands[procedure] = Tranlate_Text;
                    break;
                case "Tranlate_Text 01":
                    _commands[procedure] = Tranlate_Text;
                    break;
                case "Batch_Translation":
                    _commands[procedure] = Batch_Translation;
                    break;
                case "Translate_JSON":
                    _commands[procedure] = Translate_JSON;
                    break;
                case "Translate_HTML":
                    _commands[procedure] = Translate_HTML;
                    break;
                case "Detect_Language":
                    _commands[procedure] = Detect_Language;
                    break;
                case "Supported_languages":
                    _commands[procedure] = Supported_languages;
                    break;
                case "Translate text to voice":
                    _commands[procedure] = Translate_text_to_voice;
                    break;

            }
        }
        private async void Translate_text_to_voice()
        {

            counter01 = 0;
            if (Security_Serv01.isPicker_selected_web(Translate_View_M01.SelectedProject01, menu_array01, out data01[23]) == true)
            {
                counter01++;

                Translate_View_M01.StatusMessage01 = string.Empty;
            }
            else
            {
                counter01--;

                Translate_View_M01.StatusMessage01 = $"{data01[23]}\n";
            }
            if (Security_Serv01.empty_string(Translate_View_M01.input01, out data01[24]) == true)
            {
                Translate_View_M01.StatusMessage01 = string.Empty;
                counter01++;
            }
            else
            {
                counter01--;
                Translate_View_M01.StatusMessage01 = $"{data01[24]}\n";
            }
            if (counter01 == 2)
            {
                var res = await Security_Serv01.is_connected_to_netwrok_linux();
                if (res.success == true)
                {
                    try
                    {
                        string lang01 = await Language_Serv01.Tranlate_Text(Language_H01.code[int.Parse(Translate_View_M01.SelectedProject01) - 1], Translate_View_M01.input01.Trim());
                        Translate_View_M01.StatusMessage01 = lang01;
                        await Audio_Serv01.convert_text_to_voice01_linux(lang01);

                    }
                    catch (Exception exception)
                    {
                        Translate_View_M01.StatusMessage01 = $"Translation failed: {exception.Message}";
                    }
                }
                else
                {
                    Translate_View_M01.StatusMessage01 = res.output;
                }
            }
            else
            {
                Translate_View_M01.StatusMessage01 = $"fix the errors\n";

            }
        }
        private void Batch_Translation()
        {
            Translate_View_M01.StatusMessage01 = $"needs work";
        }
        private void Translate_JSON()
        {
            Translate_View_M01.StatusMessage01 = $"needs work";
        }
        private void Translate_HTML()
        {
            Translate_View_M01.StatusMessage01 = $"needs work";
        }
        private async void Detect_Language()
        {
            if (Security_Serv01.empty_string(Translate_View_M01.input01, out data01[24]) == true)
            {
                var res = await Security_Serv01.is_connected_to_netwrok_linux();
                if (res.success == true)
                {
                    Translate_View_M01.StatusMessage01 = await Language_Serv01.Detect_Language(Translate_View_M01.input01);

                }
                else
                {
                    Translate_View_M01.StatusMessage01 = res.output;
                }
            }
            else
            {
                Translate_View_M01.StatusMessage01 = $"{data01[24]}\n";
            }


        }
        private async void Supported_languages()
        {
            var res = await Security_Serv01.is_connected_to_netwrok_linux();
            if (res.success == true)
            {
                Translate_View_M01.StatusMessage01 = await Language_Serv01.Supported_languages();
            }
            else
            {
                Translate_View_M01.StatusMessage01 = data01[25];
            }
        }
        private async void Tranlate_Text()
        {
            counter01 = 0;

            if (Security_Serv01.isPicker_selected_web(Translate_View_M01.SelectedProject, menu_array01, out data01[23]) == true)
            {
                counter01++;
                Translate_View_M01.StatusMessage01 = string.Empty;
            }
            else
            {
                counter01--;

                Translate_View_M01.StatusMessage01 = $"{data01[23]}\n";
            }
            if (Security_Serv01.empty_string(Translate_View_M01.input01, out data01[24]) == true)
            {
                Translate_View_M01.StatusMessage01 = string.Empty;
                counter01++;
            }
            else
            {
                counter01--;
                Translate_View_M01.StatusMessage01 = $"{data01[24]}\n";
            }
            if (counter01 == 2)
            {
                var res = await Security_Serv01.is_connected_to_netwrok_linux();
                if (res.success == true)
                {
                    try
                    {
                        Translate_View_M01.StatusMessage01 = await Language_Serv01.Tranlate_Text(Language_H01.code[int.Parse(Translate_View_M01.SelectedProject01) - 1], Translate_View_M01.input01.Trim());
                    }
                    catch (Exception exception)
                    {
                        Translate_View_M01.StatusMessage01 = $"Translation failed: {exception.Message}";
                    }
                }
                else
                {
                    Translate_View_M01.StatusMessage01 = res.output;
                }
            }
            else
            {
                Translate_View_M01.StatusMessage01 = $"fix the errors\n";

            }
        }



        private void load_default_view()
        {
            Translate_View_M01.ShowInput01 = false;
            Translate_View_M01.ShowInput02 = false;

        }
        private void load_default_view01()
        {
            Translate_View_M01.ShowInput01 = true;
            Translate_View_M01.ShowInput02 = false;

        }
        private void load_default_view02()
        {
            Translate_View_M01.ShowInput01 = false;
            Translate_View_M01.ShowInput02 = true;

        }
        private void load_default_view03()
        {
            Translate_View_M01.ShowInput01 = true;
            Translate_View_M01.ShowInput02 = true;

        }
        private void load_Selection01()
        {

            string key = menu_array01[int.Parse(Translate_View_M01.SelectedProject) - 1].Trim();
            load_Selection_data01();
            if (_commands.TryGetValue(key, out Action action))
            {
                action();
                _commands.Clear();
            }
            else
            {
                Translate_View_M01.StatusMessage01 = $"{key} command not found";
            }

        }
        public IActionResult OnPostOk()
        {

            if (Security_Serv01.isPicker_selected_web(Translate_View_M01.SelectedProject,
     menu_array01, out data01[1]) == true)
            {
                Translate_View_M01.StatusMessage01 = string.Empty;
                Picker01_SelectedIndexChanged();
                load_Selection01();
            }
            else
            {
                Translate_View_M01.StatusMessage01 = data01[1];


            }

            LoadOptions();
            LoadOptions01();
            return Page();
        }

        public IActionResult OnPostBack()
        {
            return RedirectToPage("/LOCATION_VIEW/LOCATION_MAIN_VIEW/Location_Main_View01");

        }
    }
}
