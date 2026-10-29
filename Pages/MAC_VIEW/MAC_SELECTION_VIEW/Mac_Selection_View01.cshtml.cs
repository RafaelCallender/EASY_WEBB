using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using EASYPROJECT01.EASY_CALLENDER01.MODEL.WEB_MODEL.MAC_VIEW_MODEL;
using EASYPROJECT01.EASY_CALLENDER01.SERVICES.SECURITY_SERVICES;

namespace EASYPROJECT01.EASY_WEBB.Pages.MAC_VIEW.MAC_SELECTION_VIEW
{
    public class Mac_Selection_View01 : PageModel
    {
        [BindProperty]
        public Mac_View_Model01 Mac_View_M01 { get; set; } = new Mac_View_Model01();
        private static string[] data01 = new string[100];
        private static Security_Services01 Security_Serv01 = new Security_Services01();

        private static string menu_string01 =
                 "Mac Details\n";

        private static string[] menu_array01 = menu_string01
            .Split('\n', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);
        private static Dictionary<string, Action> _commands = new Dictionary<string, Action>(StringComparer.OrdinalIgnoreCase);

        public void OnGet()
        {
            OnPost();

        }
        private void Picker01_SelectedIndexChanged()
        {
            switch (menu_array01[int.Parse(Mac_View_M01.SelectedProject) - 1].Trim())
            {
                case "Mac Details":
                    load_default_view();
                    break;

            }
        }

        private void load_default_view()
        {
            Mac_View_M01.ShowInput01 = false;

        }
        public IActionResult OnPost()
        {

            load_default_view();
            if (Security_Serv01.isPicker_selected_web(Mac_View_M01.SelectedProject,
            menu_array01, out data01[1]) == true)
            {
                Mac_View_M01.StatusMessage01 = string.Empty;
                Picker01_SelectedIndexChanged();

            }
            else
            {
                Mac_View_M01.StatusMessage01 = data01[1];

            }
            LoadOptions();
            return Page();
        }


        private void LoadOptions()
        {
            Mac_View_M01.ProjectOptions = new List<SelectListItem>();
            for (int i = 0; i < menu_array01.Length; i++)
            {
                Mac_View_M01.ProjectOptions.Add(
                    new SelectListItem
                    {
                        Value = (i + 1).ToString(),
                        Text = menu_array01[i].Trim()

                    });
            }
        }


        private void load_Selection_data01()
        {
            string procedure = menu_array01[int.Parse(Mac_View_M01.SelectedProject) - 1].Trim();
            switch (procedure)
            {


                case "Mac Details":
                    _commands[procedure] = Mac_Details;
                    break;

            }
        }
        private void Mac_Details()
        {
            Mac_View_M01.StatusMessage01 = "not yet developed";
        }

        private void load_Selection01()
        {

            string key = menu_array01[int.Parse(Mac_View_M01.SelectedProject) - 1].Trim();
            load_Selection_data01();
            if (_commands.TryGetValue(key, out Action action))
            {
                action();
                _commands.Clear();
            }
            else
            {
                Mac_View_M01.StatusMessage01 = $"{key} command not found";
            }

        }
        public IActionResult OnPostOk()
        {

            if (Security_Serv01.isPicker_selected_web(Mac_View_M01.SelectedProject,
     menu_array01, out data01[1]) == true)
            {
                Mac_View_M01.StatusMessage01 = string.Empty;
                Picker01_SelectedIndexChanged();
                load_Selection01();
            }
            else
            {
                Mac_View_M01.StatusMessage01 = data01[1];


            }

            LoadOptions();
            return Page();
        }

        public IActionResult OnPostBack()
        {
            return RedirectToPage("/MAC_VIEW/MAC_MAIN_VIEW/Mac_Main_View01");
        }
    }
}
