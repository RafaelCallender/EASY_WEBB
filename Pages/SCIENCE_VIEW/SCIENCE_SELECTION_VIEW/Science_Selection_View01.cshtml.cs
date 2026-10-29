using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using EASYPROJECT01.EASY_CALLENDER01.MODEL.WEB_MODEL.SCIENCE_VIEW_MODEL;
using EASYPROJECT01.EASY_CALLENDER01.SERVICES.SECURITY_SERVICES;
using EASYPROJECT01.EASY_CALLENDER01.SERVICES.FILES.FILE_HELPER;
using EASYPROJECT01.EASY_CALLENDER01.SERVICES.SCIENCE_SERVICES.CHEMISTRY.CHEMISTRY_SERVICES;
using EASYPROJECT01.EASY_CALLENDER01.SERVICES.SCIENCE_SERVICES.CHEMISTRY.CHEMISTRY_HELPER;


namespace EASYPROJECT01.EASY_WEBB.Pages.SCIENCE_VIEW.SCIENCE_SELECTION_VIEW
{
    public class Science_Selection_View01 : PageModel
    {
        [BindProperty]
        public Science_View_Model01 Science_View_M01 { get; set; } = new Science_View_Model01();
        private static string[] data01 = new string[100];
        private static Security_Services01 Security_Serv01 = new Security_Services01();
        private static string menu_string01 = $"find_element_using_textfile\n" +
            $"view_all_elements_using_textfile\n" +
            $"find_element_using_textfile_grid\n" +
            $"find_category_elements_using_textfile\n";
        private static string[] menu_array01 = menu_string01.Split("\n");
        private static Dictionary<string, Action> _commands = new Dictionary<string, Action>(StringComparer.OrdinalIgnoreCase);
        private static Chemistry_Services01 Chemistry_Serv01 = new Chemistry_Services01();
        private static Chemistry_Helper01 Chemistry_H01 = new Chemistry_Helper01();

        public void OnGet()
        {
            OnPost();

        }
        private void Picker01_SelectedIndexChanged()
        {
            switch (menu_array01[int.Parse(Science_View_M01.SelectedProject) - 1].Trim())
            {
                case "find_element_using_textfile":
                    load_default_view02();
                    break;
                case "view_all_elements_using_textfile":
                    load_default_view01();
                    break;
                case "find_category_elements_using_textfile":
                    load_default_view03();
                    break;
                case "find_element_using_textfile_grid":
                    load_default_view02();
                    break;
                default:
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
            if (Security_Serv01.isPicker_selected_web(Science_View_M01.SelectedProject,
            menu_array01, out data01[1]) == true)
            {
                Science_View_M01.StatusMessage01 = string.Empty;

                Picker01_SelectedIndexChanged();

            }
            else
            {

                Science_View_M01.StatusMessage01 = data01[1];

            }
            LoadOptions();
            LoadOptions01();
            return Page();
        }


        private void LoadOptions()
        {
            Science_View_M01.ProjectOptions = new List<SelectListItem>();
            for (int i = 0; i < menu_array01.Length; i++)
            {
                Science_View_M01.ProjectOptions.Add(
                    new SelectListItem
                    {
                        Value = (i + 1).ToString(),
                        Text = menu_array01[i].Trim()

                    });
            }
        }
        private void LoadOptions01()
        {
            Science_View_M01.ProjectOptions01 = new List<SelectListItem>();
            for (int i = 0; i < Chemistry_H01.data_array.Length; i++)
            {
                Science_View_M01.ProjectOptions01.Add(
                    new SelectListItem
                    {
                        Value = (i + 1).ToString(),
                        Text = Chemistry_H01.data_array[i].Trim()

                    });
            }
        }


        private void load_Selection_data01()
        {
            string procedure = menu_array01[int.Parse(Science_View_M01.SelectedProject) - 1].Trim();
            switch (procedure)
            {

                case "find_element_using_textfile":
                    _commands.Add(procedure, find_element_using_textfile);
                    break;
                case "view_all_elements_using_textfile":
                    _commands.Add(procedure, view_all_elements_using_textfile);
                    break;
                case "find_category_elements_using_textfile":
                    _commands.Add(procedure, find_category_elements_using_textfile);
                    break;
                case "find_element_using_textfile_grid":
                    _commands.Add(procedure, find_element_using_textfile_grid);
                    break;

            }
        }
        private void find_element_using_textfile()
        {
            if (Security_Serv01.empty_string(Science_View_M01.input01, out data01[23]) == true)
            {

                Science_View_M01.StatusMessage01 = Chemistry_Serv01.find_element_using_textfile(Science_View_M01.input01);

            }
            else
            {
                Science_View_M01.StatusMessage01 = data01[23];
            }

        }

        private void find_element_using_textfile_grid()
        {

            if (Security_Serv01.empty_string(Science_View_M01.input01, out data01[23]) == true)
            {
               Science_View_M01.StatusMessage01 ="not yet developed";
                /*   string[] res_array = Chemistry_Serv01.find_element_using_textfile(Science_View_M01.input01).Split("\n");
                     AtomicNumberLabel.Text = $"Atomic Number {res_array[0]}";
                     SymbolLabel.Text = res_array[2];
                     NameLabel.Text = res_array[1];
                     AtomicNumberValue.Text = res_array[3];
                     ElementNameValue.Text = res_array[1];
                     SymbolValue.Text = res_array[2];
                     AtomicMassValue.Text = res_array[3];
                     ElectronsValue.Text = res_array[4];
                     ProtonsValue.Text = res_array[5];
                     NeutronsValue.Text = res_array[6];
                 */
            }
            else
            {
            
                Science_View_M01.StatusMessage01 = data01[23];
            }


        }
        private void view_all_elements_using_textfile()
        {
            Science_View_M01.StatusMessage01 = Chemistry_Serv01.view_all_elements_using_textfile();

        }
        private void find_category_elements_using_textfile()
        {
            if (Security_Serv01.isPicker_selected_web(Science_View_M01.SelectedProject01,
                 Chemistry_H01.data_array, out data01[1]) == true)
            {
                Science_View_M01.StatusMessage01 = Chemistry_Serv01.find_category_elements_using_textfile(int.Parse(Science_View_M01.SelectedProject01));
            }
            else
            {
                Science_View_M01.StatusMessage01 = data01[24];
            }
        }
        private void load_Selection01()
        {

            string key = menu_array01[int.Parse(Science_View_M01.SelectedProject) - 1].Trim();
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
     menu_array01, out data01[1]) == true)
            {
                Science_View_M01.StatusMessage01 = string.Empty;
                Picker01_SelectedIndexChanged();
                load_Selection01();
            }
            else
            {
                Science_View_M01.StatusMessage01 = data01[1];

                Picker01_SelectedIndexChanged();
                load_Selection01();

            }

            LoadOptions();
            LoadOptions01();
            return Page();
        }

        public IActionResult OnPostBack()
        {
            return RedirectToPage("/SCIENCE_VIEW/SCIENCE_MAIN_VIEW/Science_Main_View01");
        }
    }
}
