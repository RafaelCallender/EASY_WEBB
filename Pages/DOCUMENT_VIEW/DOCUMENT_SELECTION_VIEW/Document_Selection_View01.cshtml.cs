using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using EASYPROJECT01.EASY_CALLENDER01.SERVICES.SECURITY_SERVICES;
using EASYPROJECT01.EASY_CALLENDER01.SERVICES.FILE_SERVICES.FILE_PICKER;
using EASYPROJECT01.EASY_CALLENDER01.MODEL.WEB_MODEL.DOCUMENT_VIEW_MODEL;
using EASYPROJECT01.EASY_CALLENDER01.SERVICES.FILES.FILE_MANAGER;
using EASYPROJECT01.EASY_CALLENDER01.SERVICES.FILES.FILE_HELPER;
using EASYPROJECT01.EASY_CALLENDER01.SERVICES.FILES.FILE_SERVICES;

namespace EASYPROJECT01.EASY_WEBB.Pages.DOCUMENT_VIEW.DOCUMENT_SELECTION_VIEW
{
    public class Document_Selection_View01 : PageModel
    {
        [BindProperty]
        public Document_View_Model01 Document_View_M01 { get; set; } = new Document_View_Model01();
        private static string[] data01 = new string[100];
        private static File_Helper01 File_H01 = new File_Helper01();
        private static File_Servicesr01 File_S01 = new File_Servicesr01();
        private static File_Picker01 File_P01 = new File_Picker01();
        private static Security_Services01 Security_S01 = new Security_Services01();

        private static string menu_string01 = $"upload file\n" +
                                            $"upload file 01\n";

        private static string[] menu_array01 = menu_string01.Split("\n");
        private static Dictionary<string, Action> _commands = new Dictionary<string, Action>(StringComparer.OrdinalIgnoreCase);
        public void OnGet()
        {
            OnPost();

        }
        public IActionResult OnPost()
        {

            Document_View_M01.ShowInput01 =
         !string.IsNullOrEmpty(Document_View_M01.SelectedProject);
            LoadOptions();
            load_default_view();
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
            switch (menu_array01[int.Parse(Document_View_M01.SelectedProject)])
            {

                case "upload file":
                    load_default_view01();
                    break;
                case "upload file 01":
                    load_default_view01();
                    break;
                default:
                    load_default_view();
                    break;
            }
        }

        private void load_Selection_data01()
        {

            string procedure = menu_array01[int.Parse(Document_View_M01.SelectedProject)].Trim();
            switch (procedure)
            {

                case "upload file":
                    _commands.Add(procedure, upload_file);
                    break;
                case "upload file 01":
                    _commands.Add(procedure, upload_file_01);
                    break;
            }
        }

        private void upload_file()
        {
            if (File_P01.FilePickerLinux02(data01[2], out data01[25]) == true)
            {
                if (File_S01.Read_Document01(data01[25], out data01[26]))
                {
                    Document_View_M01.StatusMessage01 = data01[26];
                }
                else
                {
                    Document_View_M01.StatusMessage01 = data01[26];
                }
            }
            else
            {
                Document_View_M01.StatusMessage01 = data01[25];
            }
        }
        private void upload_file_01()
        {
            if (File_P01.FilePickerLinux02(data01[2], out data01[25]) == true)
            {
                if (File_S01.Read_Document01(data01[25], out data01[26]))
                {
                    Document_View_M01.StatusMessage01 = data01[26];
                }
                else
                {
                    Document_View_M01.StatusMessage01 = data01[26];
                }
            }
            else
            {
                Document_View_M01.StatusMessage01 = data01[25];
            }
        }


        private void load_default_view()
        {
          
            Document_View_M01.ShowInput01 = false;
            Document_View_M01.ShowInput02 = false;
            Document_View_M01.ShowInput03 = true;
            Document_View_M01.ShowInput04 = true;
        }
        private void load_default_view01()
        {
    
            Document_View_M01.ShowInput01 = false;
            Document_View_M01.ShowInput02 = true;
            Document_View_M01.ShowInput03 = true;
            Document_View_M01.ShowInput04 = true;
        }
        private void load_default_view02()
        {
            Document_View_M01.ShowInput01 = false;
            Document_View_M01.ShowInput02 = true;
            Document_View_M01.ShowInput03 = false;
            Document_View_M01.ShowInput04 = true;
        }

        private void load_default_view03()
        {

            Document_View_M01.ShowInput01 = false;
            Document_View_M01.ShowInput02 = false;
            Document_View_M01.ShowInput03 = true;
            Document_View_M01.ShowInput04 = false;
        }
        private void load_Selection01()
        {

            string key = menu_array01[int.Parse(Document_View_M01.SelectedProject)].Trim();
            load_Selection_data01();
            if (_commands.TryGetValue(key, out Action action))
            {
                action();
                _commands.Clear();
            }
            else
            {
                Document_View_M01.label01 = $"{key} command not found";
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
            return RedirectToPage("/DOCUMENT_VIEW/DOCUMENT_MAIN_VIEW/Document_Main_View01");
        }
    }
}
