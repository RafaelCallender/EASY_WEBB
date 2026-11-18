using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Threading.Tasks;
using EASYPROJECT01.EASY_CALLENDER01.MODEL.WEB_MODEL.SCIENCE_VIEW_MODEL;
using EASYPROJECT01.EASY_CALLENDER01.SERVICES.SECURITY_SERVICES;
using EASYPROJECT01.EASY_CALLENDER01.SERVICES.SQLITE.SQLITE_SERVICES.SQLITE_CHEMISTRY_SERVICES;
using EASYPROJECT01.EASY_CALLENDER01.TEMPLATE.WEB_TEMPLATE;
namespace EASYPROJECT01.EASY_WEBB.Pages.SCIENCE_VIEW.SCIENCE_SELECTION_VIEW
{
    public class Science_Selection_View03 : PageModel
    {
         public string css01 { get; set; } = Web_Template01.ccs01;
        [BindProperty]
        public Science_View_Model01 Science_View_M01 { get; set; } = new Science_View_Model01();
        private static string[] data01 = new string[100];
        private static Security_Services01 Security_Serv01 = new Security_Services01();

        private static Sqlite_Chemistry_Services01 Sqlite_Chemistry_S01 = new Sqlite_Chemistry_Services01();
        private static bool stored_procedure_bool = Sqlite_Chemistry_S01.view_chemistry_database_storedprocedures(out data01[50]);
        private static string stored_procedure_string = data01[50];
        private static string[] stored_procedure_array = stored_procedure_string.Split("\n");
        private Dictionary<string, Func<Task>> _commands =
            new Dictionary<string, Func<Task>>(StringComparer.OrdinalIgnoreCase);


        public void OnGet()
        {
            OnPost();

        }
        private void Picker01_SelectedIndexChanged()
        {
            switch (stored_procedure_array[int.Parse(Science_View_M01.SelectedProject) - 1].Trim())
            {
                case "find_Alkali_Metals":
                    load_default_view02();
                    break;
                case "Find_Actinides":
                    load_default_view02();
                    break;
                case "find_Alkaline_Earth_Metals":
                    load_default_view02();
                    break;
                case "find_Lanthanides_Rare_Earth_Metals":
                    load_default_view();
                    break;
                case "find_Noble_Gases":
                    load_default_view02();
                    break;
                case "find_Nonmetal_Gases_at_Room_Temperature":
                    load_default_view02();
                    break;
                case "find_Transition_Metals":
                    load_default_view02();
                    break;
                case "find_element_using_atomic_number":
                    load_default_view02();
                    break;
                case "find_element_using_symbol":
                    load_default_view02();
                    break;
                case "find_element_using_name":
                    load_default_view02();
                    break;
                case "view_all_elements":
                    load_default_view01();
                    break;

            }
        }

        private void load_default_view()
        {
            Science_View_M01.ShowInput01 = false;
            Science_View_M01.ShowInput02 = false;
            Science_View_M01.ShowInput03 = false;

        }
        private void load_default_view01()
        {
            Science_View_M01.ShowInput01 = true;
            Science_View_M01.ShowInput02 = false;
            Science_View_M01.ShowInput03 = false;

        }
        private void load_default_view02()
        {
            Science_View_M01.ShowInput01 = true;
            Science_View_M01.ShowInput02 = true;
            Science_View_M01.ShowInput03 = false;

        }
        private void load_default_view03()
        {
            Science_View_M01.ShowInput01 = true;
            Science_View_M01.ShowInput02 = false;
            Science_View_M01.ShowInput03 = true;

        }
        public IActionResult OnPost()
        {
        load_default_view01();
                   LoadOptions();

            if (Security_Serv01.isPicker_selected_web(Science_View_M01.SelectedProject,
            stored_procedure_array, out data01[1]) == true)
            {


                Picker01_SelectedIndexChanged();

            }
            else
            {

                Science_View_M01.StatusMessage01 = data01[1];

            }
     
            return Page();
        }


        private void LoadOptions()
        {
            Science_View_M01.ProjectOptions = new List<SelectListItem>();
            for (int i = 0; i < stored_procedure_array.Length; i++)
            {
                Science_View_M01.ProjectOptions.Add(
                    new SelectListItem
                    {
                        Value = (i + 1).ToString(),
                        Text = stored_procedure_array[i].Trim()

                    });
            }
        }


        private void load_Selection_data01()
        {
            string procedure = stored_procedure_array[int.Parse(Science_View_M01.SelectedProject) - 1].Trim();
            switch (procedure)
            {

                case "find_Alkali_Metals":
                    _commands.Add(procedure, () => { find_Alkali_Metals(); return Task.CompletedTask; });
                    break;
                case "Find_Actinides":
                    _commands.Add(procedure, () => { Find_Actinides(); return Task.CompletedTask; });
                    break;
                case "find_Alkaline_Earth_Metals":
                    _commands.Add(procedure, () => { find_Alkaline_Earth_Metals(); return Task.CompletedTask; });
                    break;
                case "find_Lanthanides_Rare_Earth_Metals":
                    _commands.Add(procedure, () => { find_Lanthanides_Rare_Earth_Metals(); return Task.CompletedTask; });
                    break;
                case "find_Noble_Gases":
                    _commands.Add(procedure, () => { find_Noble_Gases(); return Task.CompletedTask; });
                    break;
                case "find_Nonmetal_Gases_at_Room_Temperature":
                    _commands.Add(procedure, () => { find_Nonmetal_Gases_at_Room_Temperature(); return Task.CompletedTask; });
                    break;
                case "find_Transition_Metals":
                    _commands.Add(procedure, () => { find_Transition_Metals(); return Task.CompletedTask; });
                    break;
                case "find_element_using_atomic_number":
                    _commands.Add(procedure, () => { find_element_using_atomic_number(); return Task.CompletedTask; });
                    break;
                case "find_element_using_symbol":
                    _commands.Add(procedure, () => { find_element_using_symbol(); return Task.CompletedTask; });
                    break;
                case "find_element_using_name":
                    _commands.Add(procedure, () => { find_element_using_name(); return Task.CompletedTask; });
                    break;
                case "view_all_elements":
                    _commands.Add(procedure, () => { view_all_elements(); return Task.CompletedTask; });
                    break;
            }
        }
        private void find_Alkali_Metals()
        {

            if (Security_Serv01.empty_string(Science_View_M01.input01, out data01[23]) == true)
            {

                var res = Sqlite_Chemistry_S01.find_Alkali_Metals(Science_View_M01.input01).GetAwaiter().GetResult();
                if (res.success == true)
                {
                    Science_View_M01.StatusMessage01 = res.output;
                }
                else
                {
                    Science_View_M01.StatusMessage01 = res.output;
                }
            }
            else
            {
                Science_View_M01.StatusMessage01 = data01[23];
            }
        }
        private void Find_Actinides()
        {
            if (Security_Serv01.empty_string(Science_View_M01.input01, out data01[23]) == true)
            {

                var res = Sqlite_Chemistry_S01.Find_Actinides(Science_View_M01.input01).GetAwaiter().GetResult();
                if (res.success == true)
                {
                    Science_View_M01.StatusMessage01 = res.output;
                }
                else
                {
                    Science_View_M01.StatusMessage01 = res.output;
                }

            }
            else
            {
                Science_View_M01.StatusMessage01 = data01[23];
            }
        }
        private void find_Alkaline_Earth_Metals()
        {
            if (Security_Serv01.empty_string(Science_View_M01.input01, out data01[23]) == true)
            {

                var res = Sqlite_Chemistry_S01.find_Alkaline_Earth_Metals(Science_View_M01.input01).GetAwaiter().GetResult();
                if (res.success == true)
                {
                    Science_View_M01.StatusMessage01 = res.output;
                }
                else
                {
                    Science_View_M01.StatusMessage01 = res.output;
                }

            }
            else
            {
                Science_View_M01.StatusMessage01 = data01[23];
            }
        }
        private void find_Lanthanides_Rare_Earth_Metals()
        {
            if (Security_Serv01.empty_string(Science_View_M01.input01, out data01[23]) == true)
            {

                var res = Sqlite_Chemistry_S01.find_Lanthanides_Rare_Earth_Metals(Science_View_M01.input01).GetAwaiter().GetResult();
                if (res.success == true)
                {
                    Science_View_M01.StatusMessage01 = res.output;
                }
                else
                {
                    Science_View_M01.StatusMessage01 = res.output;
                }

            }
            else
            {
                Science_View_M01.StatusMessage01 = data01[23];
            }
        }
        private void find_Noble_Gases()
        {
            if (Security_Serv01.empty_string(Science_View_M01.input01, out data01[23]) == true)
            {

                var res = Sqlite_Chemistry_S01.find_Noble_Gases(Science_View_M01.input01).GetAwaiter().GetResult();
                if (res.success == true)
                {
                    Science_View_M01.StatusMessage01 = res.output;
                }
                else
                {
                    Science_View_M01.StatusMessage01 = res.output;
                }

            }
            else
            {
                Science_View_M01.StatusMessage01 = data01[23];
            }
        }
        private void find_Nonmetal_Gases_at_Room_Temperature()
        {
            if (Security_Serv01.empty_string(Science_View_M01.input01, out data01[23]) == true)
            {

                var res = Sqlite_Chemistry_S01.find_Nonmetal_Gases_at_Room_Temperature(Science_View_M01.input01).GetAwaiter().GetResult();
                if (res.success == true)
                {
                    Science_View_M01.StatusMessage01 = res.output;
                }
                else
                {
                    Science_View_M01.StatusMessage01 = res.output;
                }

            }
            else
            {
                Science_View_M01.StatusMessage01 = data01[23];
            }
        }
        private void find_Transition_Metals()
        {
            if (Security_Serv01.empty_string(Science_View_M01.input01, out data01[23]) == true)
            {
                var res = Sqlite_Chemistry_S01.find_Transition_Metals(Science_View_M01.input01).GetAwaiter().GetResult();
                if (res.success == true)
                {
                    Science_View_M01.StatusMessage01 = res.output;
                }
                else
                {
                    Science_View_M01.StatusMessage01 = res.output;
                }

            }
            else
            {
                Science_View_M01.StatusMessage01 = data01[23];
            }
        }

        private void find_element_using_atomic_number()
        {
            if (Security_Serv01.empty_string(Science_View_M01.input01, out data01[23]) == true)
            {

                var res = Sqlite_Chemistry_S01.find_element_using_atomic_number(int.Parse(Science_View_M01.input01)).GetAwaiter().GetResult();
                if (res.success == true)
                {
                    Science_View_M01.StatusMessage01 = res.output;
                }
                else
                {
                    Science_View_M01.StatusMessage01 = res.output;
                }

            }
            else
            {
                Science_View_M01.StatusMessage01 = data01[23];
            }
        }
        private void find_element_using_symbol()
        {
            if (Security_Serv01.empty_string(Science_View_M01.input01, out data01[23]) == true)
            {

                var res = Sqlite_Chemistry_S01.find_element_using_symbol(Science_View_M01.input01).GetAwaiter().GetResult();
                if (res.success == true)
                {
                    Science_View_M01.StatusMessage01 = res.output;
                }
                else
                {
                    Science_View_M01.StatusMessage01 = res.output;
                }

            }
            else
            {
                Science_View_M01.StatusMessage01 = data01[23];
            }
        }
        private void find_element_using_name()
        {
            if (Security_Serv01.empty_string(Science_View_M01.input01, out data01[23]) == true)
            {

                var res = Sqlite_Chemistry_S01.find_element_using_name(Science_View_M01.input01).GetAwaiter().GetResult();
                if (res.success == true)
                {
                    Science_View_M01.StatusMessage01 = res.output;
                }
                else
                {
                    Science_View_M01.StatusMessage01 = res.output;
                }

            }
            else
            {
                Science_View_M01.StatusMessage01 = data01[23];
            }
        }
        private void view_all_elements()
        {
            var res = Sqlite_Chemistry_S01.view_all_elements().GetAwaiter().GetResult();
            if (res.success == true)
            {
                Science_View_M01.StatusMessage01 = res.output;
            }
            else
            {
                Science_View_M01.StatusMessage01 = res.output;
            }

        }
        private async Task load_Selection01()
        {

            string key = stored_procedure_array[int.Parse(Science_View_M01.SelectedProject) - 1].Trim();
            load_Selection_data01();
            if (_commands.TryGetValue(key, out Func<Task> action))
            {
                await action();
                _commands.Clear();
            }
            else
            {
                Science_View_M01.StatusMessage01 = $"{key} command not found";
            }

        }

        public IActionResult OnPostOk()
        {
            LoadOptions();
            if (!Security_Serv01.isPicker_selected_web(
                Science_View_M01.SelectedProject, stored_procedure_array, out data01[1]))
            {
                Science_View_M01.StatusMessage01 = data01[1];
                return Page();
            }


                  Picker01_SelectedIndexChanged();

            LoadOptions();

            return Page();
        }

        public IActionResult OnPostBack()
        {
            return RedirectToPage("/SCIENCE_VIEW/SCIENCE_MAIN_VIEW/Science_Main_View01");
        }
    }
}
