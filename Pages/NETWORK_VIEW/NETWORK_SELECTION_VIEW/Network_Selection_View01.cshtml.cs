using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using EASYPROJECT01.EASY_CALLENDER01.SERVICES.SECURITY_SERVICES;
using EASYPROJECT01.EASY_CALLENDER01.SERVICES.NETWORK_SERVICES;
using EASYPROJECT01.EASY_CALLENDER01.MODEL.WEB_MODEL.NETWORK_VIEW_MODEL;
using EASYPROJECT01.EASY_CALLENDER01.SERVICES.NETWORK_SERVICES;

namespace EASYPROJECT01.EASY_WEBB.Pages.NETWORK_VIEW.NETWORK_SELECTION_VIEW
{
    public class Network_Selection_View01 : PageModel
    {
        [BindProperty]
        public Network_View_Model01 Network_View_M01 { get; set; } = new Network_View_Model01();
        private static string[] data01 = new string[100];
        private static Security_Services01 Security_Serv01 = new Security_Services01();
        private static string menu_string01 = $"scan network\n" +
                       $"network monitor\n" +
                       $"network_monitor01\n";
        private static string[] menu_array01 = menu_string01.Split("\n");
        private static Dictionary<string, Action> _commands = new Dictionary<string, Action>(StringComparer.OrdinalIgnoreCase);
        private static Network_Services01 Network_S01 = new Network_Services01();

        public void OnGet()
        {
            OnPost();

        }
        private void Picker01_SelectedIndexChanged()
        {
            switch (menu_array01[int.Parse(Network_View_M01.SelectedProject) - 1].Trim())
            {
                case "scan network":
                    load_default_view();

                    break;
                case "network monitor":
                    load_default_view();

                    break;
                case "network_monitor01":
                    load_default_view();

                    break;

            }
        }

        private void load_default_view()
        {
            Network_View_M01.ShowInput01 = false;

        }
        public IActionResult OnPost()
        {

            load_default_view();
            if (Security_Serv01.isPicker_selected_web(Network_View_M01.SelectedProject,
            menu_array01, out data01[1]) == true)
            {
                Network_View_M01.StatusMessage01 = string.Empty;
                Picker01_SelectedIndexChanged();

            }
            else
            {
                Network_View_M01.StatusMessage01 = data01[1];

            }
            LoadOptions();
            return Page();
        }


        private void LoadOptions()
        {
            Network_View_M01.ProjectOptions = new List<SelectListItem>();
            for (int i = 0; i < menu_array01.Length; i++)
            {
                Network_View_M01.ProjectOptions.Add(
                    new SelectListItem
                    {
                        Value = (i + 1).ToString(),
                        Text = menu_array01[i].Trim()

                    });
            }
        }


        private void load_Selection_data01()
        {
            string procedure = menu_array01[int.Parse(Network_View_M01.SelectedProject) - 1].Trim();
            switch (procedure)
            {

                case "scan network":
                    _commands.Add(procedure, scan_network);
                    break;
                case "network monitor":
                    _commands.Add(procedure, network_monitor);
                    break;
                case "network monitor01":
                    _commands.Add(procedure, network_monitor01);
                    break;

            }
        }
        private void scan_network()
        {
            Network_View_M01.StatusMessage01 = Network_S01.scan_netwrok();
        }

        private void network_monitor()
        {
            Network_View_M01.StatusMessage01 = Network_S01.network_monitor();
        }

        private void network_monitor01()
        {
            Network_View_M01.StatusMessage01 = Network_S01.network_monitor01();
        }
        private void load_Selection01()
        {

            string key = menu_array01[int.Parse(Network_View_M01.SelectedProject) - 1].Trim();
            load_Selection_data01();
            if (_commands.TryGetValue(key, out Action action))
            {
                action();
                _commands.Clear();
            }
            else
            {
                Network_View_M01.StatusMessage01 = $"{key} command not found";
            }

        }
        public IActionResult OnPostOk()
        {

            if (Security_Serv01.isPicker_selected_web(Network_View_M01.SelectedProject,
     menu_array01, out data01[1]) == true)
            {
                Network_View_M01.StatusMessage01 = string.Empty;
                Picker01_SelectedIndexChanged();
                load_Selection01();
            }
            else
            {
                Network_View_M01.StatusMessage01 = data01[1];


            }

            LoadOptions();
            return Page();
        }

        public IActionResult OnPostBack()
        {

            return RedirectToPage("/NETWORK_VIEW/NETWORK_MAIN_VIEW/Network_Main_View01");
        }
    }
}
