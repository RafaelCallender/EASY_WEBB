using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using EASYPROJECT01.EASY_CALLENDER01.SERVICES.FILES.FILE_MANAGER;
using EASYPROJECT01.EASY_CALLENDER01.SERVICES.SECURITY_SERVICES;
using EASYPROJECT01.EASY_CALLENDER01.SERVICES.FILES.FILE_SERVICES;
using EASYPROJECT01.EASY_CALLENDER01.SERVICES.FILE_SERVICES.FILE_PICKER;
using EASYPROJECT01.EASY_CALLENDER01.MODEL.WEB_MODEL.TEST_VIEW_MODEL;
using EASYPROJECT01.EASY_CALLENDER01.TEMPLATE.WEB_TEMPLATE;
namespace EASYPROJECT01.EASY_WEBB.Pages.TEST_VIEW.TEST_SELECTION_VIEW
{
    public class Test_Selection_View09 : PageModel
    {
       public string css01 { get; set; } = Web_Template01.ccs01;
        private static string[] data01 = new string[100];
        [BindProperty]
        public Test_View_Model01 Test_View_M01 { get; set; } = new Test_View_Model01();
        private static File_Manger02 File_M02 = new File_Manger02();
        private Dictionary<string, Func<Task>> _commands =
            new Dictionary<string, Func<Task>>(StringComparer.OrdinalIgnoreCase);
        private static Security_Services01 Security_Serv01 = new Security_Services01();
        private static string menu_string = $"API01\n";
        private static string[] menu_array01 = menu_string.Split("\n");
        public void OnGet()
        {
            OnPost();

        }
        public IActionResult OnPost()
        {

            load_default_view();
            LoadOptions();
            if (Security_Serv01.isPicker_selected_web(Test_View_M01.SelectedProject,
            menu_array01, out data01[1]) == true)
            {
                Picker01_SelectedIndexChanged();
            }
            else
            {
                Test_View_M01.StatusMessage01 = data01[1];
            }
            return Page();
        }
        private void load_Selection_data01()
        {
            string procedure = menu_array01[int.Parse(Test_View_M01.SelectedProject) - 1].Trim();
            switch (procedure)
            {
                case "API01":
                    _commands.Add(procedure, () => { API01(); return Task.CompletedTask; });
                    break;
            }
        }
        private void API01()
        {
            Test_View_M01.StatusMessage01 = "not yet developed";
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
            }
        }
        private async Task load_Selection01()
        {
            if (Security_Serv01.isPicker_selected_web(Test_View_M01.SelectedProject, menu_array01, out data01[24]) == true)
            {
                string key = menu_array01[int.Parse(Test_View_M01.SelectedProject) - 1].Trim();
                load_Selection_data01();
                if (_commands.TryGetValue(key, out Func<Task> action))
                {
                    await action();
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
        public async Task<IActionResult> OnPostOk()
        {
            LoadOptions();
            if (!Security_Serv01.isPicker_selected_web(
                Test_View_M01.SelectedProject, menu_array01, out data01[1]))
            {
                Test_View_M01.StatusMessage01 = data01[1];
                return Page();
            }

            await load_Selection01();
            Picker01_SelectedIndexChanged();
            LoadOptions();
            return Page();
        }
        public IActionResult OnPostBack()
        {
            return RedirectToPage("/TEST_VIEW/TEST_MAIN_VIEW/Test_Main_View01");
        }
    }
}
