using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using EASYPROJECT01.EASY_CALLENDER01.SERVICES.SECURITY_SERVICES;
using EASYPROJECT01.EASY_CALLENDER01.SERVICES.LINUX.LINUX_SERVICES;
using EASY_CALLENDER01.MODEL.WEB_MODEL.LINUX_VIEW_MODEL;

namespace EASYPROJECT01.EASY_WEBB.Pages.LINUX_VIEW.LINUX_SELECTION_VIEW
{
    public class Linux_Selection_View01 : PageModel
    {
        [BindProperty]
        public Linux_View_Model01 Linux_View_M01 { get; set; } = new Linux_View_Model01();
        private string[] data01 = new string[100];
        private static Security_Services01 Security_Serv01 = new Security_Services01();
        private static string menu_string01 = $"delete files to onedive\n" +
                   $"make files to onedive\n" +
                   $"upload files to onedive\n" +
                   $"delete/upload files to onedive\n";
        private static string[] menu_array01 = menu_string01.Split("\n");
        private static Linux_Services01 Linux_S01 = new Linux_Services01();
        private static Dictionary<string, Action> _commands = new Dictionary<string, Action>(StringComparer.OrdinalIgnoreCase);
        public void OnGet()
        {
            OnPost();

        }
        private void delete_files_to_onedive()
        {
            Linux_View_M01.StatusMessage01 = Linux_S01.DeleteRemoteFolder01();
        }
        private void make_files_to_onedive()
        {
            Linux_View_M01.StatusMessage01 = Linux_S01.MakeRemoteFolder01();
        }
        private void upload_files_to_onedive()
        {
            Linux_View_M01.StatusMessage01 = Linux_S01.UploadRemoteFolder01();
        }
        private void delete_upload_files_to_onedive()
        {
            Linux_View_M01.StatusMessage01 = $"{Linux_S01.DeleteRemoteFolder01()}\n" +
             $"{Linux_S01.MakeRemoteFolder01()}\n" +
             $"{Linux_S01.UploadRemoteFolder01()}\n";
        }

        private void Picker01_SelectedIndexChanged()
        {
            switch (menu_array01[int.Parse(Linux_View_M01.SelectedProject) - 1].Trim())
            {
                case "display images":
                    load_default_view();

                    break;
                case "delete files to onedive":
                    load_default_view();

                    break;
                case "make files to onedive":
                    load_default_view();

                    break;
                case "upload files to onedive":
                    load_default_view();

                    break;
                case "delete/upload files to onedive":
                    load_default_view();

                    break;
            }
        }


        public IActionResult OnPost()
        {

            load_default_view();
            if (Security_Serv01.isPicker_selected_web(Linux_View_M01.SelectedProject,
            menu_array01, out data01[1]) == true)
            {
                Linux_View_M01.StatusMessage01 = string.Empty;
                Picker01_SelectedIndexChanged();

            }
            else
            {
                Linux_View_M01.StatusMessage01 = data01[1];

            }
            LoadOptions();
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


        private void load_Selection_data01()
        {
            string procedure = menu_array01[int.Parse(Linux_View_M01.SelectedProject) - 1].Trim();
            switch (menu_array01[int.Parse(data01[4])])
            {

                case "delete files to onedive":
                    _commands.Add(procedure, delete_files_to_onedive);
                    break;
                case "make files to onedive":
                    _commands.Add(procedure, make_files_to_onedive);
                    break;
                case "upload files to onedive":
                    _commands.Add(procedure, upload_files_to_onedive);
                    break;
                case "delete/upload files to onedive":
                    _commands.Add(procedure, delete_upload_files_to_onedive);
                    break;
            }
        }


        private void load_default_view()
        {
            Linux_View_M01.ShowInput01 = false;

        }
        private void load_Selection01()
        {

            string key = menu_array01[int.Parse(Linux_View_M01.SelectedProject) - 1].Trim();
            load_Selection_data01();
            if (_commands.TryGetValue(key, out Action action))
            {
                action();
                _commands.Clear();
            }
            else
            {
                Linux_View_M01.StatusMessage01 = $"{key} command not found";
            }

        }
        public IActionResult OnPostOk()
        {

            if (Security_Serv01.isPicker_selected_web(Linux_View_M01.SelectedProject,
     menu_array01, out data01[1]) == true)
            {
                Linux_View_M01.StatusMessage01 = string.Empty;
                Picker01_SelectedIndexChanged();
                load_Selection01();
            }
            else
            {
                Linux_View_M01.StatusMessage01 = data01[1];


            }

            LoadOptions();
            return Page();
        }

        public IActionResult OnPostBack()
        {
            return RedirectToPage("/LINUX_VIEW/LINUX_MAIN_VIEW/Linux_Main_View01");
        }
    }
}
