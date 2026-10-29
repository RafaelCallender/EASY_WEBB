using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using EASYPROJECT01.EASY_CALLENDER01.MODEL.WEB_MODEL.COLORS_VIEW_MODEL;
using EASYPROJECT01.EASY_CALLENDER01.SERVICES.SECURITY_SERVICES;
using EASYPROJECT01.EASY_CALLENDER01.SERVICES.COLORS.COLORS_HELPER;

namespace EASYPROJECT01.EASY_WEBB.Pages.COLORS_VIEW.COLORS_SELECTION_VIEW
{
    public class Colors_Selection_View01 : PageModel
    {
        [BindProperty]
        public Colors_View_Model01 Colors_View_M01 { get; set; } = new Colors_View_Model01();
        private string[] data01 = new string[100];
        private static Security_Services01 Security_Serv01 = new Security_Services01();
        private static Colors_Helper01 Colors_H01 = new Colors_Helper01();
        private static string menu_string01 = $"get colors\n";
        private static string[] menu_array01 = menu_string01.Split("\n", StringSplitOptions.RemoveEmptyEntries);
        private static Dictionary<string, Action> _commands = new Dictionary<string, Action>(StringComparer.OrdinalIgnoreCase);

        public void OnGet()
        {
            OnPost();
        }

        public IActionResult OnPost()
        {
            Colors_View_M01.ShowInput01 =
    !string.IsNullOrEmpty(Colors_View_M01.SelectedProject);
            LoadOptions();
            load_default_view();
            return Page();
        }


        private void LoadOptions()
        {

            Colors_View_M01.ProjectOptions = new List<SelectListItem>();
            for (int i = 0; i < menu_array01.Length; i++)
            {
                Colors_View_M01.ProjectOptions.Add(
                    new SelectListItem
                    {
                        Value = (i + 1).ToString(),
                        Text = menu_array01[i].Trim()
                    });
            }
        }
        private void load_Selection_data01()
        {

            string procedure = menu_array01[int.Parse(Colors_View_M01.SelectedProject) - 1].Trim();
            switch (procedure)
            {
                case "get colors":
                    _commands.Add(procedure, get_colors);
                    break;
            }
        }
        private void get_colors()
        {
            // Colors_View_M01.StatusMessage01 = Colors_View_M01.SelectedProject;
            Colors_View_M01.StatusMessage01 = $"{string.Join("\n", Colors_H01.color_Name)}";
        }
        private void Picker01_SelectedIndexChanged()
        {
            switch (menu_array01[int.Parse(Colors_View_M01.SelectedProject) - 1].Trim())
            {
                case "get colors":
                    load_default_view();
                    break;
                default:
                    load_default_view();
                    break;
            }
        }

        private void load_default_view()
        {
            Colors_View_M01.ShowInput01 = false;
        }

        private void load_Selection01()
        {

            string key = menu_array01[int.Parse(Colors_View_M01.SelectedProject) - 1].Trim();
            load_Selection_data01();
            if (_commands.TryGetValue(key, out Action action))
            {
                action();
                _commands.Clear();
            }
            else
            {
                Colors_View_M01.StatusMessage01 = $"{key} command not found";
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

            return RedirectToPage("/COLORS_VIEW/COLORS_MAIN_VIEW/Colors_Main_View01");
        }
    }
}
