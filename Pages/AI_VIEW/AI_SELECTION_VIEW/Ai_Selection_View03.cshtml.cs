using EASYPROJECT01.EASY_CALLENDER01.SERVICES.IMAGE_SERVICES;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using EASYPROJECT01.EASY_CALLENDER01.MODEL.WEB_MODEL.AI_VIEW_MODEL;
using Microsoft.AspNetCore.Mvc.Rendering;
using EASYPROJECT01.EASY_CALLENDER01.SERVICES.SECURITY_SERVICES;
using EASYPROJECT01.EASY_CALLENDER01.SERVICES.FILES.FILE_MANAGER;
using EASYPROJECT01.EASY_CALLENDER01.SERVICES.FILE_SERVICES.FILE_PICKER;
using EASYPROJECT01.EASY_CALLENDER01.SERVICES.AI_SERVICES.IMAGE_EDIT;
using EASYPROJECT01.EASY_CALLENDER01.TEMPLATE.WEB_TEMPLATE;
namespace EASYPROJECT01.EASY_WEBB.Pages.AI_VIEW.AI_SELECTION_VIEW
{
    public class Ai_Selection_View03 : PageModel
    {
        public string css01 { get; set; } = Web_Template01.ccs01;
        private static readonly Image_Services01 Image_Serv01 = new Image_Services01();
        private string[] data01 = new string[100];
        [BindProperty]
        public Ai_View_Model01 Ai_View_M01 { get; set; } = new Ai_View_Model01();
        private static readonly Security_Services01 Security_Serv01 = new Security_Services01();
        private static readonly string[] menu_array01 =
        [
            "anime photo"
        ];
        private static readonly File_Picker01 File_P01 = new File_Picker01();
        private static readonly Ai_Image_Edit01 Ai_Image_E01 = new Ai_Image_Edit01();
        private Dictionary<string, Func<Task>> _commands = new Dictionary<string, Func<Task>>(StringComparer.OrdinalIgnoreCase);
        private static bool bool01 = false;
        public void OnGet()
        {
            OnPost();
        }
        private void load_Selection_View()
        {
            Ai_View_M01.ShowInput01 = false;
            Ai_View_M01.ShowInput02 = false;
        }
        private void load_default_view01()
        {
            Ai_View_M01.ShowInput01 = true;
            Ai_View_M01.ShowInput02 = false;
        }
        private void load_default_view02()
        {
            Ai_View_M01.ShowInput01 = false;
            Ai_View_M01.ShowInput02 = true;
        }
        private void load_default_view03()
        {
            Ai_View_M01.ShowInput01 = true;
            Ai_View_M01.ShowInput02 = true;
        }
        public IActionResult OnPost()
        {
            LoadOptions();
            load_Selection_View();
            if (Security_Serv01.isPicker_selected_web(Ai_View_M01.SelectedProject,
            menu_array01, out data01[1]) == true)
            {
                Ai_View_M01.StatusMessage01 = string.Empty;
                Picker01_SelectedIndexChanged();

            }
            else
            {
                Ai_View_M01.StatusMessage01 = data01[1];

            }
            return Page();
        }

        private void LoadOptions()
        {

            Ai_View_M01.ProjectOptions = new List<SelectListItem>();
            for (int i = 0; i < menu_array01.Length; i++)
            {
                Ai_View_M01.ProjectOptions.Add(
                    new SelectListItem
                    {
                        Value = (i + 1).ToString(),
                        Text = menu_array01[i].Trim()
                    });
            }
        }

        private void load_Selection_data01()
        {

            string procedure = menu_array01[int.Parse(Ai_View_M01.SelectedProject) - 1].Trim();
            switch (procedure)
            {
                case "anime photo":
                    _commands.Add(procedure, AnimePhoto);
                    break;
            }
        }
        private async Task AnimePhoto()
        {
            var res = await Security_Serv01.is_connected_to_netwrok_linux();
            if (bool01 == true)
            {
                if (res.success == true)
                {
                    string output01 = await Image_Serv01.image_to_url(data01[80]);
                    Ai_View_M01.StatusMessage01 = await Ai_Image_E01.PhotoAnime(output01.Trim());
                }
                else
                {
                    Ai_View_M01.StatusMessage01 = res.output;
                }
            }
            else
            {
                Ai_View_M01.StatusMessage01 = "take or choose photo";
            }

        }
        private void Picker01_SelectedIndexChanged()
        {
            switch (menu_array01[int.Parse(Ai_View_M01.SelectedProject) - 1].Trim())
            {
                case "anime photo":
                    load_default_view03();
                    break;

                default:
                    load_Selection_View();
                    break;
            }
        }
        private async Task load_Selection01()
        {
            string key = menu_array01[int.Parse(Ai_View_M01.SelectedProject) - 1].Trim();
            load_Selection_data01();
            if (_commands.TryGetValue(key, out Func<Task> action))
            {
                await action();
                _commands.Clear();

            }
            else
            {
                Ai_View_M01.StatusMessage01 = $"{key} command not found";
            }

        }

        public async Task<IActionResult> OnPostOk()
        {
            LoadOptions();
            if (Security_Serv01.isPicker_selected_web(Ai_View_M01.SelectedProject, menu_array01, out data01[1]) == true)
            {

                Picker01_SelectedIndexChanged();
                await load_Selection01();

            }
            else
            {
                Ai_View_M01.StatusMessage01 = data01[1];
            }
            return Page();
        }
        public IActionResult OnPostChoosePhoto()
        {
            LoadOptions();
            Picker01_SelectedIndexChanged();
            if (Security_Serv01.is_photo_selected_linux(out data01[80]) == true)
            {
                Ai_View_M01.StatusMessage01 = data01[80];
                bool01 = true;
            }
            else
            {
                Ai_View_M01.StatusMessage01 = data01[28];
                bool01 = false;
            }

            return Page();
        }


        public IActionResult OnPostTakePhoto()
        {
            LoadOptions();
            Picker01_SelectedIndexChanged();
            if (Security_Serv01.is_photo_selected_linux(out data01[80]) == true)
            {
                Ai_View_M01.StatusMessage01 = data01[80];
                bool01 = true;
            }
            else
            {
                Ai_View_M01.StatusMessage01 = data01[28];
                bool01 = false;
            }

            return Page();
        }

        public IActionResult OnPostBack()
        {
            return RedirectToPage("/AI_VIEW/AI_MAIN_VIEW/Ai_Main_View01");
        }
    }
}
