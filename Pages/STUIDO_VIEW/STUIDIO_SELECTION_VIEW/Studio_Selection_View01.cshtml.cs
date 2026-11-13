using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using EASYPROJECT01.EASY_CALLENDER01.MODEL.WEB_MODEL.STUDIO_VIEW_MODEL;
using EASYPROJECT01.EASY_CALLENDER01.SERVICES.SECURITY_SERVICES;
using EASYPROJECT01.EASY_CALLENDER01.SERVICES.AUDIO_SERVICES;

using EASYPROJECT01.EASY_CALLENDER01.TEMPLATE.WEB_TEMPLATE;
namespace EASYPROJECT01.EASY_WEBB.Pages.STUIDO_VIEW.STUIDIO_SELECTION_VIEW
{
    public class Studio_Selection_Nba_View01 : PageModel
    {
        public string css01 { get; set; } = Web_Template01.ccs01;
        [BindProperty]
        public Studio_View_Model01 Studio_View_M01 { get; set; } = new Studio_View_Model01();
        private static string menu_string = $"text to speech linux\n" +
                                             $"text to speech andriode\n";

        private static string[] menu_array01 = menu_string.Split("\n");
        private static Dictionary<string, Action> _commands = new Dictionary<string, Action>(StringComparer.OrdinalIgnoreCase);
        private static Security_Services01 Security_Serv01 = new Security_Services01();
        private static string[] data01 = new string[100];
        private static Audio_Services01 Audio_Serv01 = new Audio_Services01();
        public void OnGet()
        {


        }
        public IActionResult OnPost()
        {
            Studio_View_M01.ShowInput01 =
    !string.IsNullOrEmpty(Studio_View_M01.SelectedProject);
            LoadOptions();
            load_default_view();
            return Page();
        }
        private void LoadOptions()
        {

            Studio_View_M01.ProjectOptions = new List<SelectListItem>();
            for (int i = 0; i < menu_array01.Length; i++)
            {
                Studio_View_M01.ProjectOptions.Add(
                    new SelectListItem
                    {
                        Value = (i + 1).ToString(),
                        Text = menu_array01[i].Trim()
                    });
            }
        }
        private void load_Selection_data01()
        {

            string procedure = menu_array01[int.Parse(Studio_View_M01.SelectedProject) - 1].Trim();
            switch (procedure)
            {
                case "text to speech linux":
                    _commands.Add(procedure, text_to_speech_linux);
                    break;
                case "text to speech andriode":
                    _commands.Add(procedure, text_to_speech_andriode);
                    break;

            }
        }
        private void load_default_view()
        {
            Studio_View_M01.ShowInput01 = false;
            Studio_View_M01.ShowInput02 = false;
            Studio_View_M01.ShowInput03 = false;
        }

        private void load_default_view01()
        {
            Studio_View_M01.ShowInput01 = true;
            Studio_View_M01.ShowInput02 = true;
            Studio_View_M01.ShowInput03 = true;
        }
        private void text_to_speech_linux()
        {
            Studio_View_M01.StatusMessage01 = "speek";
        }
        private void text_to_speech_andriode()
        {
            Studio_View_M01.StatusMessage01 = "only for adnriod devices";
        }
        private void Picker01_SelectedIndexChanged()
        {
            switch (menu_array01[int.Parse(Studio_View_M01.SelectedProject) - 1].Trim())
            {
                case "text to speech linux":
                    load_default_view01();
                    break;
                case "text to speech andriode":
                    load_default_view01();
                    break;
                default:
                    load_default_view();
                    break;
            }
        }
        private void load_Selection01()
        {
            if (Security_Serv01.isPicker_selected_web(Studio_View_M01.SelectedProject,
                 menu_array01, out data01[1]) == true)
            {
                string key = menu_array01[int.Parse(Studio_View_M01.SelectedProject) - 1].Trim();
                load_Selection_data01();
                if (_commands.TryGetValue(key, out Action action))
                {
                    action();
                    _commands.Clear();
                }
                else
                {
                    Studio_View_M01.StatusMessage01 = $"{key} command not found";
                }
            }
            else
            {
                Studio_View_M01.StatusMessage01 = $"{data01[1]}";
            }
        }
        public IActionResult OnPostOk()
        {
            Picker01_SelectedIndexChanged();
            load_Selection01();
            OnPost();
            return Page();
        }
        public IActionResult OnPostBack()
        {
            return RedirectToPage("/STUIDO_VIEW/STUDIO_MAIN_VIEW/Studio_Main_View01");

        }
        public async Task<IActionResult> OnPoststart_speaking()
        {
            string output = await Audio_Serv01.speech_to_text_start_linux();
            Studio_View_M01.StatusMessage01 = output;
            return Page();
        }
        public async Task<IActionResult> OnPoststop_recording()
        {
            string output = await Audio_Serv01.speech_to_text_stop_linux();
            Studio_View_M01.StatusMessage01 = output;
            return Page();
        }
        public IActionResult OnPostclear()
        {
            Studio_View_M01.StatusMessage01 = "Ready.";
            return Page();
        }
    }
}
