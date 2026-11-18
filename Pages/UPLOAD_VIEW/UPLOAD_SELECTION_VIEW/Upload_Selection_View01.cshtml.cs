using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using EASYPROJECT01.EASY_CALLENDER01.SERVICES.SECURITY_SERVICES;
using EASYPROJECT01.EASY_CALLENDER01.MODEL.WEB_MODEL.UPLOAD_VIEW_MODEL;
using EASYPROJECT01.EASY_CALLENDER01.SERVICES.SQL.SQL_SERVICES.SQL_UPLOAD_SERVICES;
using EASYPROJECT01.EASY_CALLENDER01.TEMPLATE.WEB_TEMPLATE;

namespace EASYPROJECT01.EASY_WEBB.Pages.UPLOAD_VIEW.UPLOAD_SELECTION_VIEW
{
    public class Upload_Selection_View01 : PageModel
    {
        public string css01 { get; set; } = Web_Template01.ccs01;
        [BindProperty]
        public Upload_View_Model01 Upload_View_M01 { get; set; } = new Upload_View_Model01();
        private static string[] data01 = new string[100];
        private static Security_Services01 Security_Serv01 = new Security_Services01();
        private static Sql_Upload_Services01 Sql_Upload_S01 = new Sql_Upload_Services01();
        private bool stored_proccedure_bool = Sql_Upload_S01.view_database_storedprocedures(out data01[50]);
        private static string stored_procedure_string = data01[50];
        private static string[] stored_procedure_array = stored_procedure_string.Split("\n");
        private Dictionary<string, Func<Task>> _commands =
            new Dictionary<string, Func<Task>>(StringComparer.OrdinalIgnoreCase);
        private int counter01 = 0;

        public void OnGet()
        {
            OnPost();
        }

        public IActionResult OnPost()
        {
            LoadOptions();
            load_default_view();
            if (Security_Serv01.isPicker_selected_web(Upload_View_M01.SelectedProject,
            stored_procedure_array, out data01[1]) == true)
            {
                Picker01_SelectedIndexChanged();


            }
            else
            {
                Upload_View_M01.StatusMessage01 = data01[1];

            }

            return Page();
        }
        private void Picker01_SelectedIndexChanged()
        {
            switch (stored_procedure_array[int.Parse(Upload_View_M01.SelectedProject) - 1].Trim())
            {
                case "Tranlate_Text":
                    load_default_view();
                    break;
                case "delete_FilePath_using_FilePath":
                    load_default_view();
                    break;
                case "delete_OriginalName_using_OriginalName":
                    load_default_view();
                    break;
                case "delete_StoredName_using_StoredName":
                    load_default_view();
                    break;
                case "delete_Username_using_Username":
                    load_default_view();
                    break;
                case "find_OriginalName_using_FilePath":
                    load_default_view();
                    break;
                case "find_OriginalName_using_OriginalName":
                    load_default_view();
                    break;
                case "find_OriginalName_using_StoredName":
                    load_default_view();
                    break;
                case "find_OriginalName_using_Username":
                    load_default_view();
                    break;
                case "find_StoredName_using_StoredName":
                    load_default_view();
                    break;
                case "find_StoredName_using_Username":
                    load_default_view();
                    break;
                case "find_username_using_FilePath":
                    load_default_view();
                    break;
                case "find_username_using_OriginalName":
                    load_default_view();
                    break;
                case "find_username_using_StoredName":
                    load_default_view();
                    break;
                case "find_username_using_username":
                    load_default_view();
                    break;
                case "insert_data":
                    load_default_view();
                    break;
                case "update_OriginalName_using_OriginalName":
                    load_default_view();
                    break;
                case "update_StoredName_using_StoredName":
                    load_default_view();
                    break;
                case "update_username_using_username":
                    load_default_view();
                    break;
            }
        }
        private void LoadOptions()
        {
            Upload_View_M01.ProjectOptions = new List<SelectListItem>();
            for (int i = 0; i < stored_procedure_array.Length; i++)
            {
                Upload_View_M01.ProjectOptions.Add(
                    new SelectListItem
                    {
                        Value = (i + 1).ToString(),
                        Text = stored_procedure_array[i].Trim()

                    });
            }
        }
        private void load_default_view()
        {
            Upload_View_M01.ShowInput01 = false;
            Upload_View_M01.ShowInput02 = false;
            Upload_View_M01.ShowInput03 = false;
            Upload_View_M01.ShowInput04 = false;
            Upload_View_M01.ShowInput05 = false;
            Upload_View_M01.ShowInput06 = false;
            Upload_View_M01.ShowInput07 = false;
            Upload_View_M01.ShowInput04 = false;
        }

        private void load_Selection_data01()
        {
            string procedure = stored_procedure_array[int.Parse(Upload_View_M01.SelectedProject) - 1].Trim();
            switch (procedure)
            {
                case "delete_FilePath_using_FilePath":
                    _commands.Add(procedure, () => { delete_FilePath_using_FilePath(); return Task.CompletedTask; });
                    break;
                case "delete_OriginalName_using_OriginalName":
                    _commands.Add(procedure, () => { delete_OriginalName_using_OriginalName(); return Task.CompletedTask; });
                    break;
                case "delete_StoredName_using_StoredName":
                    _commands.Add(procedure, () => { delete_StoredName_using_StoredName(); return Task.CompletedTask; });
                    break;
                case "delete_Username_using_Username":
                    _commands.Add(procedure, () => { delete_Username_using_Username(); return Task.CompletedTask; });
                    break;
                case "find_OriginalName_using_FilePath":
                    _commands.Add(procedure, () => { find_OriginalName_using_FilePath(); return Task.CompletedTask; });
                    break;
                case "find_OriginalName_using_OriginalName":
                    _commands.Add(procedure, () => { find_OriginalName_using_OriginalName(); return Task.CompletedTask; });
                    break;
                case "find_OriginalName_using_StoredName":
                    _commands.Add(procedure, () => { find_OriginalName_using_StoredName(); return Task.CompletedTask; });
                    break;
                case "find_OriginalName_using_Username":
                    _commands.Add(procedure, () => { find_OriginalName_using_Username(); return Task.CompletedTask; });
                    break;
                case "find_StoredName_using_StoredName":
                    _commands.Add(procedure, () => { find_StoredName_using_StoredName(); return Task.CompletedTask; });
                    break;
                case "find_StoredName_using_Username":
                    _commands.Add(procedure, () => { find_StoredName_using_Username(); return Task.CompletedTask; });
                    break;
                case "find_username_using_FilePath":
                    _commands.Add(procedure, () => { find_username_using_FilePath(); return Task.CompletedTask; });
                    break;
                case "find_username_using_OriginalName":
                    _commands.Add(procedure, () => { find_username_using_OriginalName(); return Task.CompletedTask; });
                    break;
                case "find_username_using_StoredName":
                    _commands.Add(procedure, () => { find_username_using_StoredName(); return Task.CompletedTask; });
                    break;
                case "find_username_using_username":
                    _commands.Add(procedure, () => { find_username_using_username(); return Task.CompletedTask; });
                    break;
                case "insert_data":
                    _commands.Add(procedure, () => { insert_data(); return Task.CompletedTask; });
                    break;
                case "update_OriginalName_using_OriginalName":
                    _commands.Add(procedure, () => { update_OriginalName_using_OriginalName(); return Task.CompletedTask; });
                    break;
                case "update_StoredName_using_StoredName":
                    _commands.Add(procedure, () => { update_StoredName_using_StoredName(); return Task.CompletedTask; });
                    break;
                case "update_username_using_username":
                    _commands.Add(procedure, () => { update_username_using_username(); return Task.CompletedTask; });
                    break;

            }
        }
        private void delete_FilePath_using_FilePath()
        {
            if (Security_Serv01.empty_string(Upload_View_M01.Input01, out data01[23]) == true)
            {

                if (Sql_Upload_S01.delete_FilePath_using_FilePath(Upload_View_M01.Input01, out data01[25]) == true)
                {

                    Upload_View_M01.StatusMessage01 = $"{data01[25]}\n";
                }
                else
                {

                    Upload_View_M01.StatusMessage01 = $"{data01[25]}\n";
                }
            }
            else
            {

                Upload_View_M01.StatusMessage01 = $"{data01[23]}\n";
            }

        }
        private void delete_OriginalName_using_OriginalName()
        {
            if (Security_Serv01.empty_string(Upload_View_M01.Input01, out data01[23]) == true)
            {

                if (Sql_Upload_S01.delete_OriginalName_using_OriginalName(Upload_View_M01.Input01, out data01[25]) == true)
                {

                    Upload_View_M01.StatusMessage01 = $"{data01[25]}\n";
                }
                else
                {

                    Upload_View_M01.StatusMessage01 = $"{data01[25]}\n";
                }
            }
            else
            {

                Upload_View_M01.StatusMessage01 = $"{data01[23]}\n";
            }

        }
        private void delete_StoredName_using_StoredName()
        {
            if (Security_Serv01.empty_string(Upload_View_M01.Input01, out data01[23]) == true)
            {

                if (Sql_Upload_S01.delete_StoredName_using_StoredName(Upload_View_M01.Input01, out data01[25]) == true)
                {

                    Upload_View_M01.StatusMessage01 = $"{data01[25]}\n";
                }
                else
                {

                    Upload_View_M01.StatusMessage01 = $"{data01[25]}\n";
                }
            }
            else
            {

                Upload_View_M01.StatusMessage01 = $"{data01[23]}\n";
            }

        }
        private void delete_Username_using_Username()
        {
            if (Security_Serv01.empty_string(Upload_View_M01.Input01, out data01[23]) == true)
            {

                if (Sql_Upload_S01.delete_Username_using_Username(Upload_View_M01.Input01, out data01[25]) == true)
                {

                    Upload_View_M01.StatusMessage01 = $"{data01[25]}\n";
                }
                else
                {

                    Upload_View_M01.StatusMessage01 = $"{data01[25]}\n";
                }
            }
            else
            {

                Upload_View_M01.StatusMessage01 = $"{data01[23]}\n";
            }

        }
        private void find_OriginalName_using_FilePath()
        {
            if (Security_Serv01.empty_string(Upload_View_M01.Input01, out data01[23]) == true)
            {

                if (Sql_Upload_S01.find_OriginalName_using_FilePath(Upload_View_M01.Input01, out data01[25]) == true)
                {

                    Upload_View_M01.StatusMessage01 = $"{data01[25]}\n";
                }
                else
                {

                    Upload_View_M01.StatusMessage01 = $"{data01[25]}\n";
                }
            }
            else
            {

                Upload_View_M01.StatusMessage01 = $"{data01[23]}\n";
            }

        }
        private void find_OriginalName_using_OriginalName()
        {
            if (Security_Serv01.empty_string(Upload_View_M01.Input01, out data01[23]) == true)
            {

                if (Sql_Upload_S01.find_OriginalName_using_OriginalName(Upload_View_M01.Input01, out data01[25]) == true)
                {

                    Upload_View_M01.StatusMessage01 = $"{data01[25]}\n";
                }
                else
                {

                    Upload_View_M01.StatusMessage01 = $"{data01[25]}\n";
                }
            }
            else
            {

                Upload_View_M01.StatusMessage01 = $"{data01[23]}\n";
            }

        }
        private void find_OriginalName_using_StoredName()
        {
            if (Security_Serv01.empty_string(Upload_View_M01.Input01, out data01[23]) == true)
            {

                if (Sql_Upload_S01.find_OriginalName_using_StoredName(Upload_View_M01.Input01, out data01[25]) == true)
                {

                    Upload_View_M01.StatusMessage01 = $"{data01[25]}\n";
                }
                else
                {

                    Upload_View_M01.StatusMessage01 = $"{data01[25]}\n";
                }
            }
            else
            {

                Upload_View_M01.StatusMessage01 = $"{data01[23]}\n";
            }

        }
        private void find_OriginalName_using_Username()
        {
            if (Security_Serv01.empty_string(Upload_View_M01.Input01, out data01[23]) == true)
            {

                if (Sql_Upload_S01.find_OriginalName_using_Username(Upload_View_M01.Input01, out data01[25]) == true)
                {

                    Upload_View_M01.StatusMessage01 = $"{data01[25]}\n";
                }
                else
                {

                    Upload_View_M01.StatusMessage01 = $"{data01[25]}\n";
                }
            }
            else
            {

                Upload_View_M01.StatusMessage01 = $"{data01[23]}\n";
            }

        }
        private void find_StoredName_using_StoredName()
        {
            if (Security_Serv01.empty_string(Upload_View_M01.Input01, out data01[23]) == true)
            {

                if (Sql_Upload_S01.find_StoredName_using_StoredName(Upload_View_M01.Input01, out data01[25]) == true)
                {

                    Upload_View_M01.StatusMessage01 = $"{data01[25]}\n";
                }
                else
                {

                    Upload_View_M01.StatusMessage01 = $"{data01[25]}\n";
                }
            }
            else
            {

                Upload_View_M01.StatusMessage01 = $"{data01[23]}\n";
            }

        }
        private void find_StoredName_using_Username()
        {
            if (Security_Serv01.empty_string(Upload_View_M01.Input01, out data01[23]) == true)
            {

                if (Sql_Upload_S01.find_StoredName_using_Username(Upload_View_M01.Input01, out data01[25]) == true)
                {

                    Upload_View_M01.StatusMessage01 = $"{data01[25]}\n";
                }
                else
                {

                    Upload_View_M01.StatusMessage01 = $"{data01[25]}\n";
                }
            }
            else
            {

                Upload_View_M01.StatusMessage01 = $"{data01[23]}\n";
            }

        }
        private void find_username_using_FilePath()
        {
            if (Security_Serv01.empty_string(Upload_View_M01.Input01, out data01[23]) == true)
            {

                if (Sql_Upload_S01.find_username_using_FilePath(Upload_View_M01.Input01, out data01[25]) == true)
                {

                    Upload_View_M01.StatusMessage01 = $"{data01[25]}\n";
                }
                else
                {

                    Upload_View_M01.StatusMessage01 = $"{data01[25]}\n";
                }
            }
            else
            {

                Upload_View_M01.StatusMessage01 = $"{data01[23]}\n";
            }

        }
        private void find_username_using_OriginalName()
        {
            if (Security_Serv01.empty_string(Upload_View_M01.Input01, out data01[23]) == true)
            {

                if (Sql_Upload_S01.find_username_using_OriginalName(Upload_View_M01.Input01, out data01[25]) == true)
                {

                    Upload_View_M01.StatusMessage01 = $"{data01[25]}\n";
                }
                else
                {

                    Upload_View_M01.StatusMessage01 = $"{data01[25]}\n";
                }
            }
            else
            {

                Upload_View_M01.StatusMessage01 = $"{data01[23]}\n";
            }

        }
        private void find_username_using_StoredName()
        {
            if (Security_Serv01.empty_string(Upload_View_M01.Input01, out data01[23]) == true)
            {

                if (Sql_Upload_S01.find_username_using_StoredName(Upload_View_M01.Input01, out data01[25]) == true)
                {

                    Upload_View_M01.StatusMessage01 = $"{data01[25]}\n";
                }
                else
                {

                    Upload_View_M01.StatusMessage01 = $"{data01[25]}\n";
                }
            }
            else
            {

                Upload_View_M01.StatusMessage01 = $"{data01[23]}\n";
            }

        }
        private void find_username_using_username()
        {
            if (Security_Serv01.empty_string(Upload_View_M01.Input01, out data01[23]) == true)
            {

                if (Sql_Upload_S01.find_username_using_username(Upload_View_M01.Input01, out data01[25]) == true)
                {

                    Upload_View_M01.StatusMessage01 = $"{data01[25]}\n";
                }
                else
                {

                    Upload_View_M01.StatusMessage01 = $"{data01[25]}\n";
                }
            }
            else
            {

                Upload_View_M01.StatusMessage01 = $"{data01[23]}\n";
            }

        }
        private void insert_data()
        {
            Upload_View_M01.StatusMessage01 = "not yet developed";
        }
        private void update_OriginalName_using_OriginalName()
        {
            if (Security_Serv01.empty_string(Upload_View_M01.Input01, out data01[23]) == true)
            {
                Upload_View_M01.StatusMessage01 = string.Empty;
                counter01++;
            }
            else
            {
                Upload_View_M01.StatusMessage01 = data01[23];
                counter01--;
            }
            if (Security_Serv01.empty_string(Upload_View_M01.Input01, out data01[23]) == true)
            {
                counter01++;
                Upload_View_M01.StatusMessage01 = string.Empty;
            }
            else
            {
                Upload_View_M01.StatusMessage02 = data01[23];
                counter01--;

            }
            if (counter01 == 2)
            {
                if (Sql_Upload_S01.update_OriginalName_using_OriginalName(Upload_View_M01.Input01, Upload_View_M01.Input02, out data01[25]) == true)
                {
                    Upload_View_M01.StatusMessage01 = data01[25];
                }
                else
                {
                    Upload_View_M01.StatusMessage02 = data01[25];
                }
            }
            else
            {
                Upload_View_M01.StatusMessage02 = "please check errors";
            }

        }
        private void update_StoredName_using_StoredName()
        {


            if (Security_Serv01.empty_string(Upload_View_M01.Input01, out data01[23]) == true)
            {
                Upload_View_M01.StatusMessage01 = string.Empty;
                counter01++;
            }
            else
            {
                Upload_View_M01.StatusMessage01 = data01[23];
                counter01--;
            }
            if (Security_Serv01.empty_string(Upload_View_M01.Input01, out data01[23]) == true)
            {
                counter01++;
                Upload_View_M01.StatusMessage01 = string.Empty;
            }
            else
            {
                Upload_View_M01.StatusMessage02 = data01[23];
                counter01--;

            }
            if (counter01 == 2)
            {
                if (Sql_Upload_S01.update_StoredName_using_StoredName(Upload_View_M01.Input01, Upload_View_M01.Input02, out data01[25]) == true)
                {
                    Upload_View_M01.StatusMessage01 = data01[25];
                }
                else
                {
                    Upload_View_M01.StatusMessage02 = data01[25];
                }
            }
            else
            {
                Upload_View_M01.StatusMessage02 = "please check errors";
            }

        }
        private void update_username_using_username()
        {


            if (Security_Serv01.empty_string(Upload_View_M01.Input01, out data01[23]) == true)
            {
                Upload_View_M01.StatusMessage01 = string.Empty;
                counter01++;
            }
            else
            {
                Upload_View_M01.StatusMessage01 = data01[23];
                counter01--;
            }
            if (Security_Serv01.empty_string(Upload_View_M01.Input01, out data01[23]) == true)
            {
                counter01++;
                Upload_View_M01.StatusMessage01 = string.Empty;
            }
            else
            {
                Upload_View_M01.StatusMessage02 = data01[23];
                counter01--;

            }
            if (counter01 == 2)
            {
                if (Sql_Upload_S01.update_username_using_username(Upload_View_M01.Input01, Upload_View_M01.Input02, out data01[25]) == true)
                {
                    Upload_View_M01.StatusMessage01 = data01[25];
                }
                else
                {
                    Upload_View_M01.StatusMessage02 = data01[25];
                }
            }
            else
            {
                Upload_View_M01.StatusMessage02 = "please check errors";
            }

        }


        private async Task load_Selection01()
        {

            string key = stored_procedure_array[int.Parse(Upload_View_M01.SelectedProject) - 1].Trim();
            load_Selection_data01();
            if (_commands.TryGetValue(key, out Func<Task> action))
            {
                await action();
                _commands.Clear();
            }
            else
            {
                Upload_View_M01.StatusMessage01 = $"{key} command not found";
            }

        }
        public async Task<IActionResult> OnPostOk()
        {
            LoadOptions();
            if (!Security_Serv01.isPicker_selected_web(
                Upload_View_M01.SelectedProject, stored_procedure_array, out data01[1]))
            {
                Upload_View_M01.StatusMessage01 = data01[1];
                return Page();
            }

            Picker01_SelectedIndexChanged();
            await load_Selection01();
            LoadOptions();
            return Page();
        }
        public IActionResult OnPostBack()
        {

            return RedirectToPage("UPLOAD_VIEW/UPLOAD_MAIN_VIEW/Upload_Main_View01");
        }
    }
}
