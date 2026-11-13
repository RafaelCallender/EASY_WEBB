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
    public class Ai_Selection_View01 : PageModel
    {
            public string css01 { get; set; } = Web_Template01.ccs01;
        private string[] data01 = new string[100];
        [BindProperty]
        public Ai_View_Model01 Ai_View_M01 { get; set; } = new Ai_View_Model01();
        private static Security_Services01 Security_Serv01 = new Security_Services01();
        private static readonly string[] menu_array01 =
        [
            "Hairstyle_Changer_Pro"
        ];
        private static File_Picker01 File_P01 = new File_Picker01();
        private static Image_Services01 Image_Serv01 = new Image_Services01();
        private static Dictionary<string, Action> _commands = new Dictionary<string, Action>(StringComparer.OrdinalIgnoreCase);
        private static bool res01 = false;
        private static Image_Edit02 Image_E02 = new Image_Edit02();
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
            Ai_View_M01.ShowInput03 = false;
            Ai_View_M01.ShowInput04 = false;
            Ai_View_M01.ShowInput05 = false;
            Ai_View_M01.ShowInput06 = false;

        }
        private void load_default_view02()
        {
            Ai_View_M01.ShowInput01 = true;
            Ai_View_M01.ShowInput02 = false;
            Ai_View_M01.ShowInput03 = false;
            Ai_View_M01.ShowInput04 = false;
            Ai_View_M01.ShowInput05 = false;
            Ai_View_M01.ShowInput06 = false;

        }

        private void load_default_view03()
        {

            Ai_View_M01.ShowInput01 = true;
            Ai_View_M01.ShowInput02 = true;
            Ai_View_M01.ShowInput03 = false;
            Ai_View_M01.ShowInput04 = true;
            Ai_View_M01.ShowInput05 = true;
            Ai_View_M01.ShowInput06 = true;

        }
        public IActionResult OnPost()
        {

            LoadOptions();
            LoadOptions01();
            LoadOptions02();
            load_default_view01();
            Picker01_SelectedIndexChanged();
            if (Security_Serv01.isPicker_selected_web(Ai_View_M01.SelectedProject,
            menu_array01, out data01[1]) == true)
            {
                Ai_View_M01.StatusMessage01 = string.Empty;


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

        private void LoadOptions01()
        {

            Ai_View_M01.ProjectOptions01 = new List<SelectListItem>();
            for (int i = 0; i < Image_E02.hairstyle_data02.Length; i++)
            {
                Ai_View_M01.ProjectOptions01.Add(
                    new SelectListItem
                    {
                        Value = (i + 1).ToString(),
                        Text = Image_E02.hairstyle_data02[i].Trim()
                    });
            }
        }
        private void LoadOptions02()
        {

            Ai_View_M01.ProjectOptions02 = new List<SelectListItem>();
            for (int i = 0; i < Image_E02.hairstyle_data03.Length; i++)
            {
                Ai_View_M01.ProjectOptions02.Add(
                    new SelectListItem
                    {
                        Value = (i + 1).ToString(),
                        Text = Image_E02.hairstyle_data03[i].Trim()
                    });
            }
        }
        private void load_Selection_data01()
        {

            string procedure = menu_array01[int.Parse(Ai_View_M01.SelectedProject) - 1].Trim();
            switch (procedure)
            {
                case "Hairstyle_Changer_Pro":
                    _commands.Add(procedure, Hairstyle_Changer_Pro);
                    break;
            }
        }
        private async void Hairstyle_Changer_Pro()
        {

            int count = 0;
            if (Security_Serv01.isPicker_selected_web(Ai_View_M01.SelectedProject01,
                Image_E02.hairstyle_data02, out data01[23]) == true)
            {
                count++;
                Ai_View_M01.StatusMessage02 = string.Empty;

            }
            else
            {
                count--;
                Ai_View_M01.StatusMessage02 = data01[23];

            }

            if (Security_Serv01.isPicker_selected_web(Ai_View_M01.SelectedProject02,
                Image_E02.hairstyle_data03, out data01[24]) == true)
            {
                count++;
                Ai_View_M01.StatusMessage03 = string.Empty;

            }
            else
            {
                count--;
                Ai_View_M01.StatusMessage03 = data01[24];

            }
            if (res01 == true)
            {
                count++;
                Ai_View_M01.StatusMessage04 = string.Empty;
            }
            else
            {
                count--;
                Ai_View_M01.StatusMessage04 = "select photo";


            }
            if (count == 3)
            {
                var res = await Security_Serv01.is_connected_to_netwrok_linux();
                if (res.success == true)
                {

                    string output01 = await Image_Serv01.image_to_url(data01[80]);
                    Ai_View_M01.StatusMessage04 = $"{Image_E02.hairstyle_data02[int.Parse(Ai_View_M01.SelectedProject01) - 1]}\n," +
                                                   $"{Image_E02.hairstyle_data03[int.Parse(Ai_View_M01.SelectedProject02) - 1]}\n" +
                                                   $"{output01}\n" +
                                                   $"{await Image_E02.Hairstyle_Changer_Pro(int.Parse(Ai_View_M01.SelectedProject01) - 1, int.Parse(Ai_View_M01.SelectedProject02) - 1, data01[3])}\n" +
                                                   $"{data01[80]}\n";


                }
                else
                {
                    Ai_View_M01.StatusMessage04 = res.output;
                }
            }
            else
            {
                Ai_View_M01.StatusMessage04 = "please fix errors";

            }
        }

        private void Picker01_SelectedIndexChanged()
        {
            switch (menu_array01[int.Parse(Ai_View_M01.SelectedProject) - 1].Trim())
            {
                case "Hairstyle_Changer_Pro":
                    load_default_view03();
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
        public IActionResult OnPostOk()
        {
            LoadOptions();
            LoadOptions();
            LoadOptions01();
            LoadOptions02();
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
        public IActionResult OnPostChoosePhoto()
        {

            LoadOptions();
            LoadOptions01();
            LoadOptions02();
            Picker01_SelectedIndexChanged();
            if (File_P01.FilePickerLinux02(data01[2], out data01[80]) == true)
            {
                if (Security_Serv01.isphoto(data01[80], out data01[28]) == true)
                {
                    res01 = true;
                    Ai_View_M01.StatusMessage04 = data01[80];
                }
                else
                {
                    res01 = false;
                    Ai_View_M01.StatusMessage04 = data01[28];
                }
            }
            else
            {
                res01 = false;
                Ai_View_M01.StatusMessage04 = data01[27];
            }
            return Page();
        }

        public IActionResult OnPostTakePhoto()
        {
            LoadOptions();
            LoadOptions01();
            LoadOptions02();
            Picker01_SelectedIndexChanged();
            if (Security_Serv01.isphoto(data01[25], out data01[26]) == true)
            {
                res01 = true;
                Ai_View_M01.StatusMessage04 = data01[26];

            }
            else
            {
                res01 = false;
                Ai_View_M01.StatusMessage04 = data01[26];
            }

            return Page();
        }

        public IActionResult OnPostBack()
        {
            return RedirectToPage("/AI_VIEW/AI_MAIN_VIEW/Ai_Main_View01");
        }
    }
}
