using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using EASYPROJECT01.EASY_CALLENDER01.SERVICES.SECURITY_SERVICES;
using EASYPROJECT01.EASY_CALLENDER01.SERVICES.LINUX.LINUX_SERVICES;
using EASY_CALLENDER01.MODEL.WEB_MODEL.LINUX_VIEW_MODEL;
using EASYPROJECT01.EASY_CALLENDER01.TEMPLATE.WEB_TEMPLATE;
namespace EASYPROJECT01.EASY_WEBB.Pages.LINUX_VIEW.LINUX_SELECTION_VIEW
{
    public class Linux_Selection_View03 : PageModel
    {
        public string css01 { get; set; } = Web_Template01.ccs01;
        [BindProperty]
        public Linux_View_Model01 Linux_View_M01 { get; set; } = new Linux_View_Model01();
        private string[] data01 = new string[100];
        private static Security_Services01 Security_Serv01 = new Security_Services01();
        private static string menu_string01 = $"pc_clean_up\n" +
                                              $"go back\n";
        private static string[] menu_array01 = menu_string01.Split("\n");
        private static Linux_Services03 Linux_S03 = new Linux_Services03();
        private Dictionary<string, Func<Task>> _commands = new Dictionary<string, Func<Task>>(StringComparer.OrdinalIgnoreCase);
        public void OnGet()
        {
            OnPost();
        }
        private void load_Selection_data01()
        {
            string procedure = menu_array01[int.Parse(Linux_View_M01.SelectedProject) - 1].Trim();
            switch (procedure)
            {
                case "pc_clean_up":
                    _commands.Add(procedure, pc_clean_up);
                    break;
            }
        }
        private void Picker01_SelectedIndexChanged()
        {

            switch (menu_array01[int.Parse(Linux_View_M01.SelectedProject) - 1].Trim())
            {
                case "gpc_clean_up":
                    load_default_view();
                    break;
            }
        }

        private async Task pc_clean_up()
        {

            var res = await Security_Serv01.is_connected_to_netwrok_linux();
            if (res.success == true)
            {
                Linux_View_M01.StatusMessage01 = Linux_S03.pc_clean_up();
            }
            else
            {
                Linux_View_M01.StatusMessage01 = $"{res.output}";
            }
        }

        public IActionResult OnPost()
        {
            LoadOptions();
            load_default_view();
            if (Security_Serv01.isPicker_selected_web(Linux_View_M01.SelectedProject, menu_array01, out data01[1]) == true)
            {
                Picker01_SelectedIndexChanged();
            }
            else
            {
                Linux_View_M01.StatusMessage01 = data01[1];

            }

            return Page();
        }


        private void LoadOptions()
        {
            Linux_View_M01.ProjectOptions = new List<SelectListItem>();
            for (int i = 0; i < menu_array01.Length; i++)
            {
                Linux_View_M01.ProjectOptions.Add(
                    new SelectListItem
                    {
                        Value = (i + 1).ToString(),
                        Text = menu_array01[i].Trim()

                    });
            }
        }


        private void load_default_view()
        {
            Linux_View_M01.ShowInput01 = false;

        }
        private async Task load_Selection01()
        {

            string key = menu_array01[int.Parse(Linux_View_M01.SelectedProject) - 1].Trim();
            load_Selection_data01();
            if (_commands.TryGetValue(key, out Func<Task> action))
            {
                await action();
                _commands.Clear();
            }
            else
            {
                Linux_View_M01.StatusMessage01 = $"{key} command not found";
            }

        }
        public async Task<IActionResult> OnPostOk()
        {
            LoadOptions();
            if (Security_Serv01.isPicker_selected_web(Linux_View_M01.SelectedProject, menu_array01, out data01[1]) == true)
            {
                Picker01_SelectedIndexChanged();
                await load_Selection01();
            }
            else
            {
                Linux_View_M01.StatusMessage01 = data01[1];
            }
            return Page();
        }

        public IActionResult OnPostBack()
        {
            return RedirectToPage("/LINUX_VIEW/LINUX_MAIN_VIEW/Linux_Main_View01");
        }
    }
}
