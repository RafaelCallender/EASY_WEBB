using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using EASYPROJECT01.EASY_CALLENDER01.SERVICES.SECURITY_SERVICES;
using EASYPROJECT01.EASY_CALLENDER01.SERVICES.LINUX.LINUX_SERVICES;
using EASY_CALLENDER01.MODEL.WEB_MODEL.LINUX_VIEW_MODEL;

namespace EASYPROJECT01.EASY_WEBB.Pages.LINUX_VIEW.LINUX_SELECTION_VIEW
{
    public class Linux_Selection_View02 : PageModel
    {
        [BindProperty]
        public Linux_View_Model01 Linux_View_M01 { get; set; } = new Linux_View_Model01();
        private string[] data01 = new string[100];
        private static Security_Services01 Security_Serv01 = new Security_Services01();
        private static string menu_string01 = $"github_upload_all_projects\n" +
               $"github_upload_EASYWEBB\n" +
               $"github_upload_EASYCONSOLE\n" +
               $"github_upload_EASY_MOBILE\n" +
               $"github_upload_EASY_CALLENDER01\n" +
               $"create repository\n" +
               $"choose repository\n" +
               $"delete repository\n";
        private static string[] menu_array01 = menu_string01.Split("\n");
        private static Linux_Services02 Linux_S02 = new Linux_Services02();
        private static Dictionary<string, Action> _commands = new Dictionary<string, Action>(StringComparer.OrdinalIgnoreCase);
        public void OnGet()
        {
            OnPost();

        }
        private void load_Selection_data01()
        {
            string procedure = menu_array01[int.Parse(Linux_View_M01.SelectedProject) - 1].Trim();
            switch (procedure)
            {

                case "github_upload_all_projects":
                    _commands.Add(procedure, github_upload_all_projects);
                    break;
                case "github_upload_EASYWEBB":
                    _commands.Add(procedure, github_upload_EASYWEBB);
                    break;
                case "github_upload_EASYCONSOLE":
                    _commands.Add(procedure, github_upload_EASYCONSOLE);
                    break;
                case "github_upload_EASY_MOBILE":
                    _commands.Add(procedure, github_upload_EASY_MOBILE);
                    break;
                case "github_upload_EASY_CALLENDER01":
                    _commands.Add(procedure, github_upload_EASY_CALLENDER01);
                    break;
                case "create_repository":
                    _commands.Add(procedure, create_repository);
                    break;
                case "choose_repository":
                    _commands.Add(procedure, choose_repository);
                    break;
                case "delete_repository":
                    _commands.Add(procedure, delete_repository);
                    break;
            }
        }
         private void Picker01_SelectedIndexChanged()
        {

            switch (menu_array01[int.Parse(Linux_View_M01.SelectedProject) - 1].Trim())
            {
                case "display images":
                load_default_view();
                    break;
                case "github_upload_all_projects":
                load_default_view();
                    break;
                case "github_upload_EASYWEBB":
                load_default_view();
                    break;
                case "github_upload_EASYCONSOLE":
                load_default_view();
                    break;
                case "github_upload_EASY_MOBILE":
                load_default_view();
                    break;
                case "github_upload_EASY_CALLENDER01":
                load_default_view();
                    break;
                case "create repository":
                load_default_view();
                    break;
                case "choose repository":
                load_default_view();
                    break;
                case "delete repository":
                load_default_view();
                    break;
            }
        }


        private void github_upload_all_projects()
        {
             Linux_View_M01.StatusMessage01= Linux_S02.github_upload_all_projects();
        }
        private void github_upload_EASYWEBB()
        {
             Linux_View_M01.StatusMessage01= Linux_S02.github_upload_EASYWEBB();
        }
        private void github_upload_EASYCONSOLE()
        {
             Linux_View_M01.StatusMessage01= Linux_S02.github_upload_EASYCONSOLE();

        }
        private void github_upload_EASY_MOBILE()
        {
             Linux_View_M01.StatusMessage01= Linux_S02.github_upload_EASY_MOBILE();
        }
        private void github_upload_EASY_CALLENDER01()
        {
             Linux_View_M01.StatusMessage01= Linux_S02.github_upload_EASY_CALLENDER01();
        }
        private void create_repository()
        {
            if (Security_Serv01.empty_string(Linux_View_M01.input01, out data01[23]) == true)
            {
                 Linux_View_M01.StatusMessage01= Linux_S02.github_create_repository(Linux_View_M01.input01);
            }
            else
            {
                 Linux_View_M01.StatusMessage01= data01[23];
            }
        }
        private void choose_repository()
        {
            if (Security_Serv01.empty_string(Linux_View_M01.input01, out data01[23]) == true)
            {

                 Linux_View_M01.StatusMessage01= Linux_S02.github_list_repository(Linux_View_M01.input01);
            }
            else
            {
                 Linux_View_M01.StatusMessage01= data01[23];
            }

        }
        private void delete_repository()
        {
            if (Security_Serv01.empty_string(Linux_View_M01.input01, out data01[23]) == true)
            {
                 Linux_View_M01.StatusMessage01= Linux_S02.github_delete_repository(Linux_View_M01.input01);
            }
            else
            {
                 Linux_View_M01.StatusMessage01= data01[23];
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
