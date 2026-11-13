using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using EASYPROJECT01.EASY_CALLENDER01.SERVICES.SECURITY_SERVICES;
using EASYPROJECT01.EASY_CALLENDER01.SERVICES.FILES.FILE_MANAGER;
using EASYPROJECT01.EASY_CALLENDER01.SERVICES.FILE_SERVICES.FILE_PICKER;
using EASYPROJECT01.EASY_CALLENDER01.SERVICES.AI_SERVICES.IMAGE_EDIT;
using EASYPROJECT01.EASY_CALLENDER01.MODEL.WEB_MODEL.AI_VIEW_MODEL;
using EASYPROJECT01.EASY_CALLENDER01.TEMPLATE.WEB_TEMPLATE;
namespace EASYPROJECT01.EASY_WEBB.Pages.AI_VIEW.AI_SELECTION_VIEW
{
    public class Ai_Selection_View04 : PageModel
    {
        public string css01 { get; set; } = Web_Template01.ccs01;
        private string[] data01 = new string[100];
        [BindProperty]
        public Ai_View_Model01 Ai_View_M01 { get; set; } = new Ai_View_Model01();
        private static readonly Security_Services01 Security_Serv01 = new Security_Services01();
        private static readonly string[] menu_array01 =
        [
            "text to image"
        ];
        private static readonly File_Picker01 File_P01 = new File_Picker01();
        private static readonly Ai_Image_Edit01 Ai_Image_E01 = new Ai_Image_Edit01();
        private static Dictionary<string, Action> _commands = new Dictionary<string, Action>(StringComparer.OrdinalIgnoreCase);

        public void OnGet()
        {
            LoadOptions();
            load_default_view01();
        }
        private void load_Selection_View()
        {
            Ai_View_M01.image01 = File_Manger02.data01[(int)File_Manger02.image_index.person01];
        }
        private void load_default_view01()
        {
            Ai_View_M01.ShowInput01 = false;
            Ai_View_M01.ShowInput02 = false;
        }
        private void load_default_view02()
        {
            Ai_View_M01.ShowInput01 = true;
            Ai_View_M01.ShowInput02 = true;
        }
        public IActionResult OnPost()
        {
            LoadOptions();
            load_default_view01();
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
                case "text to image":
                    _commands.Add(procedure, text_to_image);
                    break;
            }
        }
        private async void text_to_image()
        {
            var res = await Security_Serv01.is_connected_to_netwrok_linux();
            if (res.success == true)
            {


                Ai_View_M01.StatusMessage01 = "not yet developed";
            }
            else
            {
                Ai_View_M01.StatusMessage01 = res.output;
            }
        }
        private void Picker01_SelectedIndexChanged()
        {
            switch (menu_array01[int.Parse(Ai_View_M01.SelectedProject) - 1].Trim())
            {
                case "text to image":
                    load_default_view02();
                    break;

                default:
                    load_default_view01();
                    break;
            }
        }
        private void load_Selection01()
        {
            string key = menu_array01[int.Parse(Ai_View_M01.SelectedProject) - 1].Trim();
            load_Selection_data01();
            if (_commands.TryGetValue(key, out Action action))
            {
                action();
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
            Picker01_SelectedIndexChanged();
            if (Security_Serv01.isPicker_selected_web(Ai_View_M01.SelectedProject,
                menu_array01, out data01[22]) == true)
            {

                load_Selection01();
            }
            else
            {
                Ai_View_M01.StatusMessage01 = data01[22];

            }

            return Page();
        }


        public IActionResult OnPostBack()
        {
            return RedirectToPage("/AI_VIEW/AI_MAIN_VIEW/Ai_Main_View01");
        }
    }
}
