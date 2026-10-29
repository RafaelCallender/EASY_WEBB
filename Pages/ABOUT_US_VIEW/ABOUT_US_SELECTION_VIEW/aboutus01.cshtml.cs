using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using EASYPROJECT01.EASY_CALLENDER01.SERVICES.SECURITY_SERVICES;
using EASYPROJECT01.EASY_CALLENDER01.MODEL.WEB_MODEL.ABOUT_VIEW_MODEL;
using EASYPROJECT01.EASY_CALLENDER01.SERVICES.FILES.FILE_MANAGER;

namespace EASYPROJECT01.EASY_WEBB.Pages.ABOUT_US_VIEW.ABOUT_US_SELECTION_VIEW
{
    public class aboutus01 : PageModel
    {
        private static string[] data01 = new string[100];
        private static Security_Services01 Security_Serv01 = new Security_Services01();
        [BindProperty]
        public About_View_Model01 About_View_M01 { get; set; } = new About_View_Model01();
        private static Security_Services01 Security_S01 = new Security_Services01();
        private static File_Manger02 File_M02 = new File_Manger02();
        private static string menu_string01 = $"about company\n";
        private static string[] menu_array01 = menu_string01.Split("\n");
        private static Dictionary<string, Action> _commands = new Dictionary<string, Action>(StringComparer.OrdinalIgnoreCase);
        public void OnGet()
        {
            OnPost();

        }
        private void load_Selection_data01()
        {
            string procedure = menu_array01[int.Parse(About_View_M01.SelectedProject) - 1].Trim();
            switch (procedure)
            {
                case "about company":
                    _commands.Add(procedure, about_company);
                    break;

            }
        }
        private void about_company()
        {
            About_View_M01.StatusMessage01 = File_Manger01.aboutus;
        }
        public IActionResult OnPost()
        {
            About_View_M01.ShowInput01 =
    !string.IsNullOrEmpty(About_View_M01.SelectedProject);
            LoadOptions();
            load_default_view();
            return Page();
        }


        private void LoadOptions()
        {

            About_View_M01.ProjectOptions = new List<SelectListItem>();
            for (int i = 0; i < menu_array01.Length; i++)
            {
                About_View_M01.ProjectOptions.Add(
                    new SelectListItem
                    {
                        Value = (i + 1).ToString(),
                        Text = menu_array01[i].Trim()
                    });
            }
        }

        private void Picker01_SelectedIndexChanged()
        {
            switch (menu_array01[int.Parse(About_View_M01.SelectedProject) - 1].Trim())
            {

                case "about company":
                    load_default_view();
                    break;
                default:
                    load_default_view();
                    break;
            }
        }
        private void load_default_view()
        {
            About_View_M01.ShowInput01 = false;
        }
        private void load_default_view01()
        {
            About_View_M01.ShowInput01 = true;

        }
        private void load_Selection01()
        {
            string key = menu_array01[int.Parse(About_View_M01.SelectedProject) - 1].Trim();
            load_Selection_data01();
            if (_commands.TryGetValue(key, out Action action))
            {
                action();
                _commands.Clear();
            }
            else
            {
                About_View_M01.label01 = $"{key} command not found";
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
            return RedirectToPage("/Index");
        }
    }
}
