using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using EASYPROJECT01.EASY_CALLENDER01.MODEL.WEB_MODEL.STUDIO_VIEW_MODEL;
using EASYPROJECT01.EASY_CALLENDER01.SERVICES.SECURITY_SERVICES;
using EASYPROJECT01.EASY_CALLENDER01.SERVICES.AUDIO_SERVICES;

namespace EASYPROJECT01.EASY_WEBB.Pages.STUIDO_VIEW.STUIDIO_SELECTION_VIEW
{
    public class Studio_Selection_Nba_View01 : PageModel
    {
        [BindProperty]
        public Studio_View_Model01 Studio_View_M01 { get; set; } = new Studio_View_Model01();
        private static string menu_string01 = $"andriod_sound_options\n"


            ;
        private static string[] menu_array01 = menu_string01.Split("\n");
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
                case "andriod_sound_options":
                    _commands.Add(procedure, andriod_sound_options);
                    break;
            }
        }
        private void load_default_view()
        {
            Studio_View_M01.ShowInput01 = false;
        }

        private void Picker01_SelectedIndexChanged()
        {
            switch (menu_array01[int.Parse(Studio_View_M01.SelectedProject) - 1].Trim())
            {
                case "andriod_sound_options":
                    load_default_view();
                    break;
                default:
                    load_default_view();
                    break;
            }
        }
        private void andriod_sound_options()
        {

            Studio_View_M01.StatusMessage01 = Audio_Serv01.andriod_sound_options();
        }

        private void load_Selection01()
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
    }
}
