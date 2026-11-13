using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using EASYPROJECT01.EASY_CALLENDER01.SERVICES.SECURITY_SERVICES;
using EASYPROJECT01.EASY_CALLENDER01.MODEL.WEB_MODEL.ABOUT_VIEW_MODEL;
using EASYPROJECT01.EASY_CALLENDER01.SERVICES.FILES.FILE_MANAGER;
using EASYPROJECT01.EASY_CALLENDER01.SERVICES.EMAIL_SERVICES;
using EASYPROJECT01.EASY_CALLENDER01.TEMPLATE.WEB_TEMPLATE;
namespace EASYPROJECT01.EASY_WEBB.Pages.ABOUT_US_VIEW.ABOUT_US_SELECTION_VIEW
{
    public class aboutus02 : PageModel
    {
        private static string[] data01 = new string[100];
        public string css01 { get; set; } = Web_Template01.ccs01;
        private static Security_Services01 Security_Serv01 = new Security_Services01();
        public About_View_Model01 About_View_M01 { get; set; } = new About_View_Model01();

        private static Security_Services01 Security_S01 = new Security_Services01();
        private static File_Manger02 File_M02 = new File_Manger02();
        private static string menu_string01 = $"call\n" +
                                              $"text\n" +
                                              $"downloads\n" +
                                              $"email\n";
        private static string[] menu_array01 = menu_string01.Split("\n");
        private static Email_Services01 Email_S01 = new Email_Services01();
        private static Dictionary<string, Action> _commands = new Dictionary<string, Action>(StringComparer.OrdinalIgnoreCase);
        private static int counter = 0;
        public void OnGet()
        {
            OnPost();

        }
        private void load_Selection_data01()
        {
            string procedure = menu_array01[int.Parse(About_View_M01.SelectedProject) - 1].Trim();
            switch (procedure)
            {
                case "call":
                    _commands.Add(procedure, call);
                    break;
                case "text":
                    _commands.Add(procedure, text);
                    break;
                case "email":
                    _commands.Add(procedure, email);
                    break;
                    /* case "downnload":
                         _commands.Add(procedure, email);
                         break;*/
            }
        }

        private void call()
        {
            About_View_M01.StatusMessage04 = $"{File_Manger01.API03?.Trim()}";
        }
        private void text()
        {
            About_View_M01.StatusMessage04 = $"{File_Manger01.API03?.Trim()}";
        }
        private async void email()
        {
            counter = 0;
            if (Security_S01.empty_string(About_View_M01.input01, out data01[25]) == true)
            {

                counter++;
                About_View_M01.StatusMessage01 = string.Empty;
            }
            else
            {
                counter--;
                About_View_M01.StatusMessage01 = data01[25];
            }
            if (Security_S01.empty_string(About_View_M01.input02, out data01[25]) == true)
            {
                if (Security_S01.email_check(About_View_M01.input02, out data01[26]) == true)
                {

                    counter++;
                    About_View_M01.StatusMessage02 = string.Empty;

                }
                else
                {
                    counter--;

                    About_View_M01.StatusMessage02 = data01[26];
                }
            }
            else
            {
                counter--;
                About_View_M01.StatusMessage02 = data01[25];
            }
            if (Security_S01.empty_string(About_View_M01.input03, out data01[28]) == true)
            {
                if (Security_S01.phone_check(About_View_M01.input03, out data01[29]) == true)
                {
                    counter++;
                    About_View_M01.StatusMessage03 = string.Empty;
                }
                else
                {
                    counter--;
                    About_View_M01.StatusMessage03 = data01[29];
                }
            }
            else
            {
                counter--;
                About_View_M01.StatusMessage03 = data01[28];
            }

            if (Security_S01.empty_string(About_View_M01.input04, out data01[30]) == true)
            {
                counter++;
                About_View_M01.StatusMessage04 = string.Empty;
            }
            else
            {
                counter--;
                About_View_M01.StatusMessage04 = data01[30];
            }
            if (counter == 4)
            {
                var res = await Security_S01.is_connected_to_netwrok_linux();
                if (res.success == true)
                {
                    if (Email_S01.send_email(About_View_M01.input01, About_View_M01.input02, About_View_M01.input03, About_View_M01.input04, out data01[32]) == true)
                    {
                        About_View_M01.StatusMessage04 = $"{data01[31]}\n" +
                                       $"{data01[32]}\n";


                    }
                    else
                    {
                        About_View_M01.StatusMessage04 = data01[32];
                    }
                }
                else
                {
                    About_View_M01.StatusMessage04 = res.output;
                }

            }
            else
            {
                About_View_M01.StatusMessage04 = data01[31];

            }
        }
        public IActionResult OnPost()
        {

            LoadOptions();
            load_default_view();
            if (Security_Serv01.isPicker_selected_web(About_View_M01.SelectedProject,
            menu_array01, out data01[1]) == true)
            {

                About_View_M01.StatusMessage04 = string.Empty;

            }
            else
            {
                About_View_M01.StatusMessage04 = data01[1];

            }
            return Page();
        }


        private void LoadOptions()
        {

            About_View_M01.ProjectOptions = new List<SelectListItem>();
            for (int i = 0; i < menu_array01.Length; i++)
            {
                About_View_M01.ProjectOptions.Add(
                    new SelectListItem
                    {
                        Value = (i + 1).ToString(),
                        Text = menu_array01[i].Trim()
                    });
            }
        }

        private void Picker01_SelectedIndexChanged()
        {
            switch (menu_array01[int.Parse(About_View_M01.SelectedProject) - 1].Trim())
            {

                case "call":
                    load_default_view();
                    break;
                case "text":
                    load_default_view01();
                    break;
                case "email":
                    load_default_view02();
                    break;
                case "download":
                    load_default_view03();
                    break;
                default:
                    load_default_view();
                    break;
            }
        }
        private void load_default_view()
        {

            About_View_M01.ShowInput01 = true;
            About_View_M01.ShowInput02 = false;
            About_View_M01.ShowInput03 = false;
            About_View_M01.ShowInput04 = false;
            About_View_M01.ShowInput05 = false;

        }
        private void load_default_view01()
        {

            About_View_M01.ShowInput01 = true;
            About_View_M01.ShowInput02 = true;
            About_View_M01.ShowInput03 = false;
            About_View_M01.ShowInput04 = false;
            About_View_M01.ShowInput05 = false;

        }

        private void load_default_view02()
        {


            About_View_M01.ShowInput01 = true;
            About_View_M01.ShowInput02 = true;
            About_View_M01.ShowInput03 = true;
            About_View_M01.ShowInput04 = true;
            About_View_M01.ShowInput05 = false;

        }

        private void load_default_view03()
        {

            About_View_M01.ShowInput01 = false;
            About_View_M01.ShowInput02 = false;
            About_View_M01.ShowInput03 = false;
            About_View_M01.ShowInput04 = false;
            About_View_M01.ShowInput05 = true;

        }

        private void load_Selection01()
        {

            string key = menu_array01[int.Parse(About_View_M01.SelectedProject) - 1].Trim();
            load_Selection_data01();
            if (_commands.TryGetValue(key, out Action action))
            {
                action();
                _commands.Clear();
            }
            else
            {
                About_View_M01.StatusMessage04 = $"{key} command not found";
            }

        }
        public IActionResult OnPostOk()
        {
            Picker01_SelectedIndexChanged();
            load_Selection01();
            OnPost();
            if (Security_Serv01.isPicker_selected_web(About_View_M01.SelectedProject,
                menu_array01, out data01[22]) == true)
            {
                load_Selection01();
            }
            else
            {
                About_View_M01.StatusMessage01 = data01[22];
            }
            return Page();
        }

        public IActionResult OnPostBack()
        {

            return RedirectToPage("/ABOUT_US_VIEW/ABOUT_US_MAIN_VIEW/About_Main_View01");
        }
    }
}
