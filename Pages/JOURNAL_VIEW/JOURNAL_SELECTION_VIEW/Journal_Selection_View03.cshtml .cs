using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using EASYPROJECT01.EASY_CALLENDER01.TEMPLATE.WEB_TEMPLATE;
using EASYPROJECT01.EASY_CALLENDER01.SERVICES.SECURITY_SERVICES;
using EASYPROJECT01.EASY_CALLENDER01.SERVICES.MYSQL.MYSQL_SERVICES.MYSQL_JOURNAL_SERVICES;
using EASYPROJECT01.EASY_CALLENDER01.MODEL.WEB_MODEL.JOURNAL_VIEW_MODEL;
using EASYPROJECT01.EASY_CALLENDER01.MODEL.WEB_MODEL.DEVICE_VIEW_MODEL;

namespace EASYPROJECT01.EASY_WEBB.Pages.JOURNAL_VIEW.JOURNAL_SELECTION_VIEW
{
    public class Journal_Selection_View03 : PageModel
    {
        public string css01 { get; set; } = Web_Template01.ccs01;
        [BindProperty]
        public Journal_View_Model01 Journal_View_M01 { get; set; } = new Journal_View_Model01();
        private static string[] data01 = new string[100];
        private static Security_Services01 Security_Serv01 = new Security_Services01();
        private static MySql_Journal_Services01 MySql_Journal_Serv01 = new MySql_Journal_Services01();
        private static bool stored_procedure_bool = MySql_Journal_Serv01.view_journal_database_storedprocedures(out data01[50]);
        private static string stored_procedure_string = $"{data01[50]}" +
                                                    $"back";
        private static string[] stored_procedure_array = stored_procedure_string.Split("\n");
        private Dictionary<string, Func<Task>> _commands =
            new Dictionary<string, Func<Task>>(StringComparer.OrdinalIgnoreCase);
        public void OnGet()
        {
            OnPost();

        }
        private void load_default_view()
        {
            Journal_View_M01.ShowInput01 = false;

        }
        private void load_default_view01()
        {
            Journal_View_M01.ShowInput01 = true;
        }
        public IActionResult OnPost()
        {

            LoadOptions();
            load_default_view();
            if (Security_Serv01.isPicker_selected_web(Journal_View_M01.SelectedProject,
            stored_procedure_array, out data01[1]) == true)
            {
                if (stored_procedure_bool == true)
                {
                    Picker01_SelectedIndexChanged();
                }
                else
                {
                    Journal_View_M01.StatusMessage01 = stored_procedure_string;
                }

            }
            else
            {

                Journal_View_M01.StatusMessage01 = data01[1];

            }
            return Page();

        }

        private void LoadOptions()
        {
            Journal_View_M01.ProjectOptions = new List<SelectListItem>();
            for (int i = 0; i < stored_procedure_array.Length; i++)
            {
                Journal_View_M01.ProjectOptions.Add(
                    new SelectListItem
                    {
                        Value = (i + 1).ToString(),
                        Text = stored_procedure_array[i].Trim()
                    });
            }
        }
        private void Picker01_SelectedIndexChanged()
        {

            switch (stored_procedure_array[int.Parse(Journal_View_M01.SelectedProject) - 1].Trim())
            {
                case "find_message_using_message":
                    load_default_view01();

                    break;
                case "find_message_using_upload":
                    load_default_view01();

                    break;
                case "find_message_using_username":
                    load_default_view01();

                    break;
                case "find_upload_using_message":
                    load_default_view01();

                    break;
                case "find_upload_using_upload":
                    load_default_view01();

                    break;
                case "find_upload_using_username":
                    load_default_view01();

                    break;
                case "find_username_using_message":
                    load_default_view01();

                    break;
                case "find_username_using_upload":
                    load_default_view01();

                    break;
                case "find_username_using_username":
                    load_default_view01();

                    break;
                case "insert_journal":
                    load_default_view01();

                    break;
            }
        }
        private void load_Selection_data01()
        {
            string procedure = stored_procedure_array[int.Parse(Journal_View_M01.SelectedProject) - 1].Trim();
            switch (procedure)
            {
                case "insert_journal":
                    _commands.Add(procedure, () => { insert_journal(); return Task.CompletedTask; });
                    break;
                case "find_message_using_message":
                    _commands.Add(procedure, () => { find_message_using_message(); return Task.CompletedTask; });
                    break;
                case "find_message_using_upload":
                    _commands.Add(procedure, () => { find_message_using_upload(); return Task.CompletedTask; });
                    break;
                case "find_message_using_username":
                    _commands.Add(procedure, () => { find_message_using_username(); return Task.CompletedTask; });
                    break;
                case "find_upload_using_message":
                    _commands.Add(procedure, () => { find_upload_using_message(); return Task.CompletedTask; });
                    break;
                case "find_upload_using_upload":
                    _commands.Add(procedure, () => { find_upload_using_upload(); return Task.CompletedTask; });
                    break;
                case "find_upload_using_username":
                    _commands.Add(procedure, () => { find_upload_using_username(); return Task.CompletedTask; });
                    break;
                case "find_username_using_message":
                    _commands.Add(procedure, () => { find_username_using_message(); return Task.CompletedTask; });
                    break;
                case "find_username_using_upload":
                    _commands.Add(procedure, () => { find_username_using_upload(); return Task.CompletedTask; });
                    break;
                case "find_username_using_username":
                    _commands.Add(procedure, () => { find_username_using_username(); return Task.CompletedTask; });
                    break;

            }
        }


        private void insert_journal()
        {
            Journal_View_M01.StatusMessage01 = $"not yet developed \n";
        }

        private void find_message_using_message()
        {
            if (Security_Serv01.empty_string(Journal_View_M01.input01, out data01[23]) == true)
            {
                if (MySql_Journal_Serv01.find_message_using_message(Journal_View_M01.input01, out data01[24]) == true)
                {
                    Journal_View_M01.StatusMessage01 = data01[24];
                }
                else
                {
                    Journal_View_M01.StatusMessage01 = data01[24];
                }
            }
            else
            {
                Journal_View_M01.StatusMessage01 = data01[23];
            }

        }
        private void find_message_using_upload()
        {
            if (Security_Serv01.empty_string(Journal_View_M01.input01, out data01[23]) == true)
            {
                if (MySql_Journal_Serv01.find_message_using_upload(Journal_View_M01.input01, out data01[24]) == true)
                {
                    Journal_View_M01.StatusMessage01 = data01[24];
                }
                else
                {
                    Journal_View_M01.StatusMessage01 = data01[24];
                }
            }
            else
            {
                Journal_View_M01.StatusMessage01 = data01[23];
            }

        }
        private void find_message_using_username()
        {
            if (Security_Serv01.empty_string(Journal_View_M01.input01, out data01[23]) == true)
            {
                if (MySql_Journal_Serv01.find_message_using_username(Journal_View_M01.input01, out data01[24]) == true)
                {
                    Journal_View_M01.StatusMessage01 = data01[24];
                }
                else
                {
                    Journal_View_M01.StatusMessage01 = data01[24];
                }
            }
            else
            {
                Journal_View_M01.StatusMessage01 = data01[23];
            }

        }
        private void find_upload_using_message()
        {
            if (Security_Serv01.empty_string(Journal_View_M01.input01, out data01[23]) == true)
            {
                if (MySql_Journal_Serv01.find_upload_using_message(Journal_View_M01.input01, out data01[24]) == true)
                {
                    Journal_View_M01.StatusMessage01 = data01[24];
                }
                else
                {
                    Journal_View_M01.StatusMessage01 = data01[24];
                }
            }
            else
            {
                Journal_View_M01.StatusMessage01 = data01[23];
            }
        }
        private void find_upload_using_upload()
        {
            if (Security_Serv01.empty_string(Journal_View_M01.input01, out data01[23]) == true)
            {
                if (MySql_Journal_Serv01.find_upload_using_upload(Journal_View_M01.input01, out data01[24]) == true)
                {
                    Journal_View_M01.StatusMessage01 = data01[24];
                }
                else
                {
                    Journal_View_M01.StatusMessage01 = data01[24];
                }
            }
            else
            {
                Journal_View_M01.StatusMessage01 = data01[23];
            }

        }
        private void find_upload_using_username()
        {
            if (Security_Serv01.empty_string(Journal_View_M01.input01, out data01[23]) == true)
            {
                if (MySql_Journal_Serv01.find_upload_using_username(Journal_View_M01.input01, out data01[24]) == true)
                {
                    Journal_View_M01.StatusMessage01 = data01[24];
                }
                else
                {
                    Journal_View_M01.StatusMessage01 = data01[24];
                }
            }
            else
            {
                Journal_View_M01.StatusMessage01 = data01[23];
            }

        }
        private void find_username_using_message()
        {
            if (Security_Serv01.empty_string(Journal_View_M01.input01, out data01[23]) == true)
            {
                if (MySql_Journal_Serv01.find_username_using_message(Journal_View_M01.input01, out data01[24]) == true)
                {
                    Journal_View_M01.StatusMessage01 = data01[24];
                }
                else
                {
                    Journal_View_M01.StatusMessage01 = data01[24];
                }
            }
            else
            {
                Journal_View_M01.StatusMessage01 = data01[23];
            }

        }
        private void find_username_using_upload()
        {
            if (Security_Serv01.empty_string(Journal_View_M01.input01, out data01[23]) == true)
            {
                /*   if (MySql_Journal_Serv01.find_username_using_upload(Journal_View_M01.input01, out data01[24]) == true)
                   {
                       Journal_View_M01.StatusMessage01 = data01[24];
                   }
                   else
                   {
                       Journal_View_M01.StatusMessage01 = data01[24];
                   }*/
                Journal_View_M01.StatusMessage01 = "not yet develooped";

            }
            else
            {
                Journal_View_M01.StatusMessage01 = data01[23];
            }

        }
        private void find_username_using_username()
        {
            if (Security_Serv01.empty_string(Journal_View_M01.input01, out data01[23]) == true)
            {
                if (MySql_Journal_Serv01.find_username_using_username(Journal_View_M01.input01, out data01[24]) == true)
                {
                    Journal_View_M01.StatusMessage01 = data01[24];
                }
                else
                {
                    Journal_View_M01.StatusMessage01 = data01[24];
                }
            }
            else
            {
                Journal_View_M01.StatusMessage01 = data01[23];
            }
        }
        private async Task load_Selection01()
        {

            string key = stored_procedure_array[int.Parse(Journal_View_M01.SelectedProject) - 1].Trim();
            load_Selection_data01();
            if (_commands.TryGetValue(key, out Func<Task> action))
            {
                await action();
                _commands.Clear();
            }
            else
            {
                Journal_View_M01.StatusMessage01 = $"{key} command not found";
            }
        }
        public async Task<IActionResult> OnPostOk()
        {
            LoadOptions();
            if (Security_Serv01.isPicker_selected_web(Journal_View_M01.SelectedProject, stored_procedure_array, out data01[1]) == true)
            {
                Picker01_SelectedIndexChanged();
                await load_Selection01();
            }
            else
            {
                Journal_View_M01.StatusMessage01 = data01[1];
            }
            return Page();
        }
        public IActionResult OnPostBack()
        {

            return RedirectToPage("/JOURNAL_VIEW/JOURNAL_MAIN_VIEW/Journal_Main_View01");
        }
    }
}
