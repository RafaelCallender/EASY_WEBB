using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using EASYPROJECT01.EASY_CALLENDER01.MODEL.WEB_MODEL.SCIENCE_VIEW_MODEL;
using EASYPROJECT01.EASY_CALLENDER01.SERVICES.SECURITY_SERVICES;
using EASYPROJECT01.EASY_CALLENDER01.SERVICES.MYSQL.MYSQL_SERVICES.MYSQL_SCIENCE_SERVICES.MYSQL_CHEMISTRY_SERVICES;
using EASYPROJECT01.EASY_CALLENDER01.SERVICES.SCIENCE_SERVICES.CHEMISTRY.CHEMISTRY_SERVICES;
using EASYPROJECT01.EASY_CALLENDER01.SERVICES.SCIENCE_SERVICES.CHEMISTRY.CHEMISTRY_HELPER;

namespace EASYPROJECT01.EASY_WEBB.Pages.SCIENCE_VIEW.SCIENCE_SELECTION_VIEW
{
    public class Science_Selection_View04 : PageModel
    {
        [BindProperty]
        public Science_View_Model01 Science_View_M01 { get; set; } = new Science_View_Model01();
        private static string[] data01 = new string[100];
        private static Security_Services01 Security_Serv01 = new Security_Services01();
        private static MySql_Chemistry_Services01 MySql_Chemistry_Serv01 = new MySql_Chemistry_Services01();
        private static bool stored_procedure_bool = MySql_Chemistry_Serv01.view_chemistry_database_storedprocedures(out data01[50]);
        private static string stored_procedure_string = data01[50];
        private static string[] stored_procedure_array = stored_procedure_string.Split("\n");
        private static Dictionary<string, Action> _commands = new Dictionary<string, Action>(StringComparer.OrdinalIgnoreCase);

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

            if (stored_procedure_bool == true)
            {
                if (string.IsNullOrEmpty(Science_View_M01.SelectedProject))
                {
                    load_default_view01();
                }
                else
                {
                    Picker01_SelectedIndexChanged();
                }
            }
            else
            {
                load_default_view();
                Science_View_M01.StatusMessage01 = stored_procedure_string;
            }

            LoadOptions();
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
                    _commands.Add(procedure, find_Alkali_Metals);
                    break;
                case "Find_Actinides":
                    _commands.Add(procedure, Find_Actinides);
                    break;
                case "find_Alkaline_Earth_Metals":
                    _commands.Add(procedure, find_Alkaline_Earth_Metals);
                    break;
                case "find_Lanthanides_Rare_Earth_Metals":
                    _commands.Add(procedure, find_Lanthanides_Rare_Earth_Metals);
                    break;
                case "find_Noble_Gases":
                    _commands.Add(procedure, find_Noble_Gases);
                    break;
                case "find_Nonmetal_Gases_at_Room_Temperature":
                    _commands.Add(procedure, find_Nonmetal_Gases_at_Room_Temperature);
                    break;
                case "find_Transition_Metals":
                    _commands.Add(procedure, find_Transition_Metals);
                    break;
                case "find_element_using_atomic_number":
                    _commands.Add(procedure, find_element_using_atomic_number);
                    break;
                case "find_element_using_symbol":
                    _commands.Add(procedure, find_element_using_symbol);
                    break;
                case "find_element_using_name":
                    _commands.Add(procedure, find_element_using_name);
                    break;
                case "view_all_elements":
                    _commands.Add(procedure, view_all_elements);
                    break;
            }
        }
        private async void find_Alkali_Metals()
        {

            Science_View_M01.StatusMessage01 = await MySql_Chemistry_Serv01.find_Alkali_Metals();
        }
        private async void Find_Actinides()
        {
            Science_View_M01.StatusMessage01 =await MySql_Chemistry_Serv01.Find_Actinides();
        }
        private async void find_Alkaline_Earth_Metals()
        {

            Science_View_M01.StatusMessage01 = await MySql_Chemistry_Serv01.find_Alkaline_Earth_Metals();


        }
        private async void find_Lanthanides_Rare_Earth_Metals()
        {
            Science_View_M01.StatusMessage01 =await MySql_Chemistry_Serv01.find_Lanthanides_Rare_Earth_Metals();
        }
        private async void find_Noble_Gases()
        {
            Science_View_M01.StatusMessage01 =await MySql_Chemistry_Serv01.find_Noble_Gases();
        }
        private async void find_Nonmetal_Gases_at_Room_Temperature()
        {
            Science_View_M01.StatusMessage01 =await MySql_Chemistry_Serv01.find_Nonmetal_Gases_at_Room_Temperature();
        }
        private async void find_Transition_Metals()
        {
            Science_View_M01.StatusMessage01 =await MySql_Chemistry_Serv01.find_Transition_Metals();
        }

        private void find_element_using_atomic_number()
        {
            if (Security_Serv01.empty_string(Science_View_M01.input01, out data01[23]) == true)
            {

                var res = MySql_Chemistry_Serv01.find_element_using_atomic_number(Science_View_M01.input01, out data01[24]);
                if (res == true)
                {
                    Science_View_M01.StatusMessage01 = data01[24];
                }
                else
                {
                    Science_View_M01.StatusMessage01 = data01[24];
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

                var res = MySql_Chemistry_Serv01.find_element_using_symbol(Science_View_M01.input01, out data01[24]);
                if (res == true)
                {
                    Science_View_M01.StatusMessage01 = data01[24];
                }
                else
                {
                    Science_View_M01.StatusMessage01 = data01[24];
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

                var res = MySql_Chemistry_Serv01.find_element_using_name(Science_View_M01.input01, out data01[24]);
                if (res == true)
                {
                    Science_View_M01.StatusMessage01 = data01[24];
                }
                else
                {
                    Science_View_M01.StatusMessage01 = data01[24];
                }

            }
            else
            {
                Science_View_M01.StatusMessage01 = data01[23];
            }
        }
        private void view_all_elements()
        {
            Science_View_M01.StatusMessage01 = MySql_Chemistry_Serv01.view_all_elements();
        }
        private void load_Selection01()
        {

            string key = stored_procedure_array[int.Parse(Science_View_M01.SelectedProject) - 1].Trim();
            load_Selection_data01();
            if (_commands.TryGetValue(key, out Action action))
            {
                action();
                _commands.Clear();
            }
            else
            {
                Science_View_M01.StatusMessage01 = $"{key} command not found";
            }

        }

        public IActionResult OnPostOk()
        {

            if (Security_Serv01.isPicker_selected_web(Science_View_M01.SelectedProject,
     stored_procedure_array, out data01[1]) == true)
            {
                Science_View_M01.StatusMessage01 = string.Empty;
                Picker01_SelectedIndexChanged();
                load_Selection01();
            }
            else
            {
                Science_View_M01.StatusMessage01 = data01[1];


            }

            LoadOptions();
            return Page();
        }

        public IActionResult OnPostBack()
        {
            return RedirectToPage("/SCIENCE_VIEW/SCIENCE_MAIN_VIEW/Science_Main_View01");
        }
    }
}
