using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using EASYPROJECT01.EASY_CALLENDER01.MODEL.WEB_MODEL.NEWS_VIEW_MODEL;
using EASYPROJECT01.EASY_CALLENDER01.SERVICES.SECURITY_SERVICES;
using EASYPROJECT01.EASY_CALLENDER01.SERVICES.NEWS_SERVICES;
using EASYPROJECT01.EASY_CALLENDER01.MODEL.NEWS_MODEL.NEWS_SET_MODEL;


namespace EASYPROJECT01.EASY_WEBB.Pages.NEWS_VIEW.NEWS_SELECTION_VIEW
{
    public class News_Selection_View01 : PageModel
    {
        [BindProperty]
        public News_View_Model01 News_View_M01 { get; set; } = new News_View_Model01();
        private static string[] data01 = new string[100];
        private static Security_Services01 Security_Serv01 = new Security_Services01();
        private static string menu_string01 =
                                                "Real_Time_News_Data_GET_Search\n" +
    "Real_Time_News_Data_GET_Top_Headlines\n" +
    "Real_Time_News_Data_GET_Topic_Headlines\n" +
    "Real_Time_News_Data_GET_Topic_News_By_Section\n" +
    "Real_Time_News_Data_GET_Search_grid\n" +
    "Local_Headlines_Geo\n";
        private static string[] menu_array01 = menu_string01.Split("\n");
        private static News_Services01 News_Serv01 = new News_Services01();
        private static Dictionary<string, Action> _commands = new Dictionary<string, Action>(StringComparer.OrdinalIgnoreCase);

        public void OnGet()
        {
            OnPost();

        }
        private void Picker01_SelectedIndexChanged()
        {
            switch (menu_array01[int.Parse(News_View_M01.SelectedProject) - 1].Trim())
            {
                case "Real_Time_News_Data_GET_Search":
                    load_default_view();
                    break;
                case "Real_Time_News_Data_GET_Top_Headlines":
                    load_default_view();
                    break;
                case "Real_Time_News_Data_GET_Topic_Headlines":
                    load_default_view();
                    break;
                case "Real_Time_News_Data_GET_Topic_News_By_Section":
                    load_default_view();
                    break;
                case "Local_Headlines_Geo":
                    load_default_view();
                    break;
                case "Real_Time_News_Data_GET_Search_grid":
                    load_default_view();
                    break;
                default:
                    load_default_view();
                    break;



            }
        }

        private void load_default_view()
        {
            News_View_M01.ShowInput01 = false;

        }
        public IActionResult OnPost()
        {

            load_default_view();
            if (Security_Serv01.isPicker_selected_web(News_View_M01.SelectedProject,
            menu_array01, out data01[1]) == true)
            {
                News_View_M01.StatusMessage01 = string.Empty;
                Picker01_SelectedIndexChanged();

            }
            else
            {
                News_View_M01.StatusMessage01 = data01[1];

            }
            LoadOptions();
            return Page();
        }


        private void LoadOptions()
        {
            News_View_M01.ProjectOptions = new List<SelectListItem>();
            for (int i = 0; i < menu_array01.Length; i++)
            {
                News_View_M01.ProjectOptions.Add(
                    new SelectListItem
                    {
                        Value = (i + 1).ToString(),
                        Text = menu_array01[i].Trim()

                    });
            }
        }


        private void load_Selection_data01()
        {
            string procedure = menu_array01[int.Parse(News_View_M01.SelectedProject) - 1].Trim();
            switch (procedure)
            {

                case "Real_Time_News_Data_GET_Search":
                    _commands.Add(procedure, Real_Time_News_Data_GET_Search);
                    break;
                case "Real_Time_News_Data_GET_Top_Headlines":
                    _commands.Add(procedure, Real_Time_News_Data_GET_Top_Headlines);
                    break;
                case "Real_Time_News_Data_GET_Topic_Headlines":
                    _commands.Add(procedure, Real_Time_News_Data_GET_Topic_Headlines);
                    break;
                case "Real_Time_News_Data_GET_Topic_News_By_Section":
                    _commands.Add(procedure, Real_Time_News_Data_GET_Topic_News_By_Section);
                    break;
                case "Local_Headlines_Geo":
                    _commands.Add(procedure, Local_Headlines_Geo);
                    break;
                case "Real_Time_News_Data_GET_Search_grid":
                    _commands.Add(procedure, Real_Time_News_Data_GET_Search_grid);
                    break;

            }
        }
        private async void Real_Time_News_Data_GET_Search_grid()
        {
            if (Security_Serv01.empty_string(News_View_M01.input01, out data01[23]) == true)
            {
                var res = await Security_Serv01.is_connected_to_netwrok_linux();
                if (res.success == true)
                {
                    News_View_M01.StatusMessage01 = await News_Serv01.Real_Time_News_Data_GET_Search(News_View_M01.input01);
                    //  newsCollectionView01.ItemsSource  = News_Services01.NewsItems01;
                }
                else
                {
                    News_View_M01.StatusMessage01 = res.output;
                }
            }
            else
            {
                News_View_M01.StatusMessage01 = data01[23];
            }
        }
        private async void Real_Time_News_Data_GET_Search()
        {
            if (Security_Serv01.empty_string(News_View_M01.input01, out data01[23]) == true)
            {
                var res = await Security_Serv01.is_connected_to_netwrok_linux();
                if (res.success == true)
                {
                    News_View_M01.StatusMessage01 = await News_Serv01.Real_Time_News_Data_GET_Search(News_View_M01.input01);
                }
                else
                {
                    News_View_M01.StatusMessage01 = res.output;
                }
            }
            else
            {
                News_View_M01.StatusMessage01 = data01[23];
            }
        }
        private async void Real_Time_News_Data_GET_Top_Headlines()
        {
            var res = await Security_Serv01.is_connected_to_netwrok_linux();
            if (res.success == true)
            {
                News_View_M01.StatusMessage01 = await News_Serv01.Real_Time_News_Data_GET_Top_Headlines();
                //    newsCollectionView02.ItemsSource = News_Services01.NewsItems02;
            }
            else
            {
                News_View_M01.StatusMessage01 = res.output;
            }
        }
        private async void Real_Time_News_Data_GET_Topic_Headlines()
        {
            var res = await Security_Serv01.is_connected_to_netwrok_linux();
            if (res.success == true)
            {
                News_View_M01.StatusMessage01 = await News_Serv01.Real_Time_News_Data_GET_Topic_Headlines();
                //   newsCollectionView02.ItemsSource = News_Services01.NewsItems02;
            }
            else
            {
                News_View_M01.StatusMessage01 = res.output;
            }
        }
        private async void Real_Time_News_Data_GET_Topic_News_By_Section()
        {
            if (Security_Serv01.empty_string(News_View_M01.input01, out data01[23]) == true)
            {
                var res = await Security_Serv01.is_connected_to_netwrok_linux();
                if (res.success == true)
                {
                    News_View_M01.StatusMessage01 = await News_Serv01.Real_Time_News_Data_GET_Topic_News_By_Section(News_View_M01.input01);
                    //     newsCollectionView02.ItemsSource = News_Services01.NewsItems02;
                }
                else
                {
                    News_View_M01.StatusMessage01 = res.output;
                }

            }
            else
            {
                News_View_M01.StatusMessage01 = data01[23];
            }
        }
        private async void Local_Headlines_Geo()
        {
            if (Security_Serv01.empty_string(News_View_M01.input01, out data01[23]) == true)
            {
                var res = await Security_Serv01.is_connected_to_netwrok_linux();
                if (res.success == true)
                {
                    News_View_M01.StatusMessage01 = await News_Serv01.Local_Headlines_Geo(News_View_M01.input01);
                    //  newsCollectionView01.ItemsSource  = News_Services01.NewsItems01;
                }
                else
                {
                    News_View_M01.StatusMessage01 = res.output;
                }

            }
            else
            {
                News_View_M01.StatusMessage01 = data01[23];
            }

        }
        private void load_Selection01()
        {

            string key = menu_array01[int.Parse(News_View_M01.SelectedProject) - 1].Trim();
            load_Selection_data01();
            if (_commands.TryGetValue(key, out Action action))
            {
                action();
                _commands.Clear();
            }
            else
            {
                News_View_M01.StatusMessage01 = $"{key} command not found";
            }

        }

        public IActionResult OnPostOk()
        {

            if (Security_Serv01.isPicker_selected_web(News_View_M01.SelectedProject,
     menu_array01, out data01[1]) == true)
            {
                News_View_M01.StatusMessage01 = string.Empty;
                Picker01_SelectedIndexChanged();
                load_Selection01();
            }
            else
            {
                News_View_M01.StatusMessage01 = data01[1];


            }

            LoadOptions();
            return Page();
        }

        public IActionResult OnPostBack()
        {

            return RedirectToPage("/NEWS_VIEW/NEWS_MAIN_VIEW/News_Main_View01");
        }
    }
}
