using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using EASYPROJECT01.EASY_CALLENDER01.SERVICES.SECURITY_SERVICES;
using EASYPROJECT01.EASY_CALLENDER01.SERVICES.FILE_SERVICES.FILE_PICKER;
using EASYPROJECT01.EASY_CALLENDER01.MODEL.WEB_MODEL.DOCUMENT_VIEW_MODEL;
using EASYPROJECT01.EASY_CALLENDER01.SERVICES.FILES.FILE_MANAGER;
using EASYPROJECT01.EASY_CALLENDER01.SERVICES.FILES.FILE_HELPER;
using EASYPROJECT01.EASY_CALLENDER01.SERVICES.FILES.FILE_SERVICES;
using EASYPROJECT01.EASY_CALLENDER01.TEMPLATE.WEB_TEMPLATE;

namespace EASYPROJECT01.EASY_WEBB.Pages.DOCUMENT_VIEW.DOCUMENT_SELECTION_VIEW
{
    public class Document_Selection_View01 : PageModel
    {
        public string css01 { get; set; } = Web_Template01.ccs01;
        [BindProperty]
        public Document_View_Model01 Document_View_M01 { get; set; } = new Document_View_Model01();
        private static string[] data01 = new string[100];
        private static Security_Services01 Security_Serv01 = new Security_Services01();
        private static string menu_string01 = $"upload file\n";
        private static string[] menu_array01 = menu_string01.Split(
            '\n', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);
        private Dictionary<string, Func<Task>> _commands = new Dictionary<string, Func<Task>>(StringComparer.OrdinalIgnoreCase);
        private static bool bool01 = false;



        public void OnGet()
        {
            OnPost();

        }
        public IActionResult OnPost()
        {
            LoadOptions();
            load_default_view();
            if (Security_Serv01.isPicker_selected_web(Document_View_M01.SelectedProject,
            menu_array01, out data01[1]) == true)
            {

                Picker01_SelectedIndexChanged();

            }
            else
            {

                Document_View_M01.StatusMessage01 = data01[1];

            }
            return Page();
        }


        private void LoadOptions()
        {

            Document_View_M01.ProjectOptions = new List<SelectListItem>();

            for (int i = 0; i < menu_array01.Length; i++)
            {
                Document_View_M01.ProjectOptions.Add(
                    new SelectListItem
                    {
                        Value = (i + 1).ToString(),
                        Text = menu_array01[i].Trim()

                    });
            }
        }

        private void Picker01_SelectedIndexChanged()
        {
            switch (menu_array01[int.Parse(Document_View_M01.SelectedProject) - 1])
            {

                case "upload file":
                    load_default_view02();
                    break;
                default:
                    load_default_view();
                    break;
            }
        }

        private void load_Selection_data01()
        {

            string procedure = menu_array01[int.Parse(Document_View_M01.SelectedProject) - 1].Trim();
            switch (procedure)
            {

                case "upload file":

                    _commands.Add(procedure, () => { upload_file(); return Task.CompletedTask; });

                    break;

            }
        }

        private void upload_file()
        {
            if (bool01 == true)
            {
                Document_View_M01.StatusMessage01 = data01[80];
            }
            else
            {
                Document_View_M01.StatusMessage01 = "upload document";
            }

        }

        private void load_default_view()
        {

            Document_View_M01.ShowInput01 = false;
            Document_View_M01.ShowInput02 = false;

        }
        private void load_default_view01()
        {

            Document_View_M01.ShowInput01 = true;
            Document_View_M01.ShowInput02 = false;

        }
        private void load_default_view02()
        {
            Document_View_M01.ShowInput01 = false;
            Document_View_M01.ShowInput02 = true;

        }
        private void load_default_view03()
        {
            Document_View_M01.ShowInput01 = true;
            Document_View_M01.ShowInput02 = true;

        }


        private async Task load_Selection01()
        {

            string key = menu_array01[int.Parse(Document_View_M01.SelectedProject) - 1].Trim();
            load_Selection_data01();
            if (_commands.TryGetValue(key, out Func<Task> action))
            {
                await action();
                _commands.Clear();
            }
            else
            {
                Document_View_M01.label01 = $"{key} command not found";
            }

        }

        public async Task<IActionResult> OnPostOk()
        {

            LoadOptions();
            if (Security_Serv01.isPicker_selected_web(Document_View_M01.SelectedProject,
            menu_array01, out data01[1]) == true)
            {
                Picker01_SelectedIndexChanged();
                await load_Selection01();

            }
            else
            {

                Document_View_M01.StatusMessage01 = data01[1];

            }
            return Page();
        }
        public async Task<IActionResult> OnPostUpload_file()
        {
            LoadOptions();
            Picker01_SelectedIndexChanged();
            if (Security_Serv01.is_document_selected_linux(out data01[80]) == true)
            {
                Document_View_M01.StatusMessage01 = data01[80];
                bool01 = true;
            }
            else
            {
                Document_View_M01.StatusMessage01 = data01[28];
                bool01 = false;
            }

            return Page();
        }

        public IActionResult OnPostBack()
        {
            return RedirectToPage("/DOCUMENT_VIEW/DOCUMENT_MAIN_VIEW/Document_Main_View01");
        }
    }
}
