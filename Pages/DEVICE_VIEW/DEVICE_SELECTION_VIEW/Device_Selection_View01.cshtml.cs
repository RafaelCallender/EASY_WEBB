using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using EASYPROJECT01.EASY_CALLENDER01.MODEL.WEB_MODEL.DEVICE_VIEW_MODEL;
using EASYPROJECT01.EASY_CALLENDER01.SERVICES.SECURITY_SERVICES;
using EASYPROJECT01.EASY_CALLENDER01.SERVICES.DEVICES.DEVICE_HELPER;


namespace EASYPROJECT01.EASY_WEBB.Pages.DEVICE_VIEW.DEVICE_SELECTION_VIEW
{
    public class Device_Selection_View01 : PageModel
    {
        [BindProperty]
        public Device_View_Model01 Device_View_M01 { get; set; } = new Device_View_Model01();
        private string[] data01 = new string[100];
        private static Security_Services01 Security_S01 = new Security_Services01();

        private static Device_Helpers01 Device_H01 = new Device_Helpers01();
        private static string menu_string01 =
                                           $"device details 01\n" +
                                           $"OS_String\n" +
                                           $"load_device_details01\n" +
                                           $"OS_details\n" +
                                           $"Linux details\n" +
                                           $"GetEnvironmentVariables_string\n";


        private static string[] menu_array01 = menu_string01.Split("\n");
        private static Dictionary<string, Action> _commands = new Dictionary<string, Action>(StringComparer.OrdinalIgnoreCase);

        public void OnGet()
        {
            OnPost();
        }

        public IActionResult OnPost()
        {
            Device_View_M01.ShowInput01 =
    !string.IsNullOrEmpty(Device_View_M01.SelectedProject);
            LoadOptions();
            load_default_view();
            return Page();
        }
        private void load_Selection_data01()
        {

            string procedure = menu_array01[int.Parse(Device_View_M01.SelectedProject) - 1].Trim();
            switch (procedure)
            {

                case "device details 01":
                    _commands.Add(procedure, device_details_01);
                    break;
                case "OS_String":
                    _commands.Add(procedure, OS_String);
                    break;
                case "load_device_details01":
                    _commands.Add(procedure, load_device_details01);
                    break;
                case "OS_details":
                    _commands.Add(procedure, OS_details);
                    break;
                case "Linux details":
                    _commands.Add(procedure, OS_details);
                    break;
                case "GetEnvironmentVariables_string":
                    _commands.Add(procedure, GetEnvironmentVariables_string);
                    break;



            }
        }

        private void device_details_01()
        {
            Device_View_M01.StatusMessage01 = $"needs work";
        }
        private void OS_String()
        {
            Device_View_M01.StatusMessage01 = $"{Device_H01.OS_String}";
        }
        private void load_device_details01()
        {
            Device_View_M01.StatusMessage01 = $"{Device_H01.windows_info01}";
        }
        private void OS_details()
        {
            Device_View_M01.StatusMessage01 = $"{Device_H01.windows_info01}";
        }
        private void Linux_details()
        {
            Device_View_M01.StatusMessage01 = $"{Device_H01.windows_info01}";
        }
        private void GetEnvironmentVariables_string()
        {
            Device_View_M01.StatusMessage01 = $"{Device_H01.GetEnvironmentVariables_string}";
        }
        private void LoadOptions()
        {

            Device_View_M01.ProjectOptions = new List<SelectListItem>();

            for (int i = 0; i < menu_array01.Length; i++)
            {
                Device_View_M01.ProjectOptions.Add(
                    new SelectListItem
                    {
                        Value = (i + 1).ToString(),
                        Text = menu_array01[i].Trim()
                    });
            }
        }
        private void load_default_view()
        {

            Device_View_M01.ShowInput01 = false;
        }

        private void Picker01_SelectedIndexChanged()
        {
            switch (menu_array01[int.Parse(Device_View_M01.SelectedProject) - 1].Trim())
            {

                case "device details 01":
                    load_default_view();
                    break;
                case "OS_String":
                    load_default_view();
                    break;
                case "load_device_details0":
                    load_default_view();
                    break;
                case "OS_details":
                    load_default_view();
                    break;
                case "Linux details":
                    load_default_view();
                    break;
                case "GetEnvironmentVariables_string":
                    load_default_view();
                    break;
                default:
                    load_default_view();
                    break;
            }
        }
        private void load_Selection01()
        {
            string key = menu_array01[int.Parse(Device_View_M01.SelectedProject) - 1].Trim();
            load_Selection_data01();
            if (_commands.TryGetValue(key, out Action action))
            {
                action();
                _commands.Clear();
            }
            else
            {
                Device_View_M01.StatusMessage01 = $"{key} command not found";
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
            return RedirectToPage("/DEVICE_VIEW/DEVICE_MAIN_VIEW/Device_Main_View01");
        }
    }
}
