using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using EASYPROJECT01.EASY_CALLENDER01.MODEL.WEB_MODEL.SPORTS_VIEW_MODEL.NBA_VIEW_MODEL;
using EASYPROJECT01.EASY_CALLENDER01.SERVICES.SECURITY_SERVICES;
using EASYPROJECT01.EASY_CALLENDER01.SERVICES.COLORS.COLORS_HELPER;
using EASYPROJECT01.EASY_CALLENDER01.TEMPLATE.WEB_TEMPLATE;
namespace EASYPROJECT01.EASY_WEBB.Pages.SPORTS_VIEW.SPORTS_SELECTION_VIEW.SPORTS_SELECCTION_NBA_VIEW
{
    public class Sports_Selection_nba_View01 : PageModel
    {
        public string css01 { get; set; } = Web_Template01.ccs01;
        [BindProperty]
        public Nba_View_Model01 Nba_View_M01 { get; set; } = new Nba_View_Model01();
        private string[] data01 = new string[100];
        private static Security_Services01 Security_Serv01 = new Security_Services01();
        private static string menu_string01 = $"data 01\n";
        private static string[] menu_array01 = menu_string01.Split("\n", StringSplitOptions.RemoveEmptyEntries);
        private Dictionary<string, Func<Task>> _commands =
            new Dictionary<string, Func<Task>>(StringComparer.OrdinalIgnoreCase);

        public void OnGet()
        {
            OnPost();
        }

        public IActionResult OnPost()
        {
                    LoadOptions();
            load_default_view();
            if (Security_Serv01.isPicker_selected_web(Nba_View_M01.SelectedProject,
            menu_array01, out data01[1]) == true)
            {
               
         Picker01_SelectedIndexChanged();
                
            }
            else
            {
              
                Nba_View_M01.StatusMessage01 = data01[1];

            }
            return Page();
        }


        private void LoadOptions()
        {

            Nba_View_M01.ProjectOptions = new List<SelectListItem>();
            for (int i = 0; i < menu_array01.Length; i++)
            {
                Nba_View_M01.ProjectOptions.Add(
                    new SelectListItem
                    {
                        Value = (i + 1).ToString(),
                        Text = menu_array01[i].Trim()
                    });
            }
        }
        private void load_Selection_data01()
        {

            string procedure = menu_array01[int.Parse(Nba_View_M01.SelectedProject) - 1].Trim();
            switch (procedure)
            {
                case "data 01":
                    _commands.Add(procedure, () => { data_01(); return Task.CompletedTask; });
                    break;
            }
        }
        private void data_01()
        {
    
            Nba_View_M01.StatusMessage01 = "not yet developed";
        }
        private void Picker01_SelectedIndexChanged()
        {
            switch (menu_array01[int.Parse(Nba_View_M01.SelectedProject) - 1].Trim())
            {
                case "data 01":
                    load_default_view();
                    break;
                default:
                    load_default_view();
                    break;
            }
        }

        private void load_default_view()
        {
            Nba_View_M01.ShowInput01 = false;
        }

        private async Task load_Selection01()
        {

            string key = menu_array01[int.Parse(Nba_View_M01.SelectedProject) - 1].Trim();
            load_Selection_data01();
            if (_commands.TryGetValue(key, out Func<Task> action))
            {
                await action();
                _commands.Clear();
            }
            else
            {
                Nba_View_M01.StatusMessage01 = $"{key} command not found";
            }

        }
        public async Task<IActionResult> OnPostOk()
        {
              LoadOptions();
            if (Security_Serv01.isPicker_selected_web(Nba_View_M01.SelectedProject, menu_array01, out data01[1]) == true)
            {

                Picker01_SelectedIndexChanged();
                await load_Selection01();

            }
            else
            {
                Nba_View_M01.StatusMessage01 = data01[1];
            }
            return Page();
        }
        public IActionResult OnPostBack()
        {

            return RedirectToPage("/COLORS_VIEW/COLORS_MAIN_VIEW/Colors_Main_View01");
        }
    }
}
