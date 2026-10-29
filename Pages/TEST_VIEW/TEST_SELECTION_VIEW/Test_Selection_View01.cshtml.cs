using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using EASYPROJECT01.EASY_CALLENDER01.SERVICES.FILES.FILE_MANAGER;
using EASYPROJECT01.EASY_CALLENDER01.SERVICES.SECURITY_SERVICES;
using EASYPROJECT01.EASY_CALLENDER01.SERVICES.FILES.FILE_SERVICES;
using EASYPROJECT01.EASY_CALLENDER01.SERVICES.FILE_SERVICES.FILE_PICKER;
using EASYPROJECT01.EASY_CALLENDER01.MODEL.WEB_MODEL.TEST_VIEW_MODEL;

namespace EASYPROJECT01.EASY_WEBB.Pages.TEST_VIEW.TEST_SELECTION_VIEW
{
    public class Test_Selection_View01 : PageModel
    {
        [BindProperty]
        public Test_View_Model01 Test_View_M01 { get; set; } = new Test_View_Model01();
        private static string[] data01 = new string[100];
        private static Security_Services01 Security_Serv01 = new Security_Services01();
        private static string menu_string = $"read all document01\n";
        private static string[] menu_array01 = menu_string.Split("\n");
        private static File_Servicesr01 File_S01 = new File_Servicesr01();
        private static File_Picker01 File_P01 = new File_Picker01();
        private static Dictionary<string, Action> _commands = new Dictionary<string, Action>(StringComparer.OrdinalIgnoreCase);
        public void OnGet()
        {
            OnPost();
        }
        private void load_Selection_data01()
        {
            string procedure = menu_array01[int.Parse(Test_View_M01.SelectedProject) - 1].Trim();
            switch (procedure)
            {
                case "read all document01":
                    _commands.Add(procedure, read_all_document01);
                    break;
            }
        }

        private void Picker01_SelectedIndexChanged()
        {
            switch (menu_array01[int.Parse(Test_View_M01.SelectedProject) - 1].Trim())
            {
                case "read_all_document01":
                    load_default_view01();
                    break;
                default:
                    load_default_view01();
                    break;
            }
        }
        private void load_default_view()
        {
            Test_View_M01.ShowInput01 = false;
            Test_View_M01.ShowInput02 = false;


        }
        private void load_default_view01()
        {
            Test_View_M01.ShowInput01 = true;
            Test_View_M01.ShowInput02 = false;


        }
        private async void read_all_document01()
        {
            var res = await File_P01.file_picker_andriod_mobile();
            if (res.success == true)
            {
                if (File_S01.Read_Document01(res.output, out data01[26]) == true)
                {
                    Test_View_M01.StatusMessage01 = data01[26];
                }
                else
                {
                    Test_View_M01.StatusMessage01 = data01[26];
                }
            }
            else
            {
                Test_View_M01.StatusMessage01 = res.output;

            }

        }

        public IActionResult OnPost()
        {

            load_default_view01();
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
        private void load_Selection01()
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
