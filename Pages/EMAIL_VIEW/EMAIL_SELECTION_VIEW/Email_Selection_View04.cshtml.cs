using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using EASYPROJECT01.EASY_CALLENDER01.SERVICES.SECURITY_SERVICES;
using EASYPROJECT01.EASY_CALLENDER01.SERVICES.EMAIL_SERVICES;
using EASYPROJECT01.EASY_CALLENDER01.MODEL.WEB_MODEL.EMAIL_VIEW_MODEL;


namespace EASYPROJECT01.EASY_WEBB.Pages.EMAIL_VIEW.EMAIL_SELECTION_VIEW
{
    public class Email_Selection_View04 : PageModel
    {
        [BindProperty]
        public Email_View_Model01 Email_View_M01 { get; set; } = new Email_View_Model01();
        private static string[] data01 = new string[100];
        private static Security_Services01 Security_S01 = new Security_Services01();
        private static Email_Services01 Email_S01 = new Email_Services01();
        private static string menu_string = "send email\n";
        private static string[] menu_array = menu_string.Split("\n");
        private static Dictionary<string, Action> _commands = new Dictionary<string, Action>(StringComparer.OrdinalIgnoreCase);

        private static int counter = 0;

        public void OnGet()
        {
            OnPost();
        }
        private void load_default_view()
        {
            Email_View_M01.ShowInput01 = false;
            Email_View_M01.ShowInput02 = false;
            Email_View_M01.ShowInput03 = false;
            Email_View_M01.ShowInput04 = false;
            Email_View_M01.ShowInput05 = false;
            Email_View_M01.ShowInput06 = false;
            Email_View_M01.label01 = string.Empty;
            Email_View_M01.label02 = string.Empty;
            Email_View_M01.label03 = string.Empty;
            Email_View_M01.label04 = string.Empty;
        }
        private void load_default_view01()
        {
            Email_View_M01.ShowInput01 = true;
            Email_View_M01.ShowInput02 = false;
            Email_View_M01.ShowInput03 = false;
            Email_View_M01.ShowInput04 = false;
            Email_View_M01.ShowInput05 = false;
            Email_View_M01.ShowInput06 = true;
            Email_View_M01.label01 = string.Empty;
            Email_View_M01.label02 = string.Empty;
            Email_View_M01.label03 = string.Empty;
            Email_View_M01.label04 = string.Empty;

        }
        private void load_default_view02()
        {
            Email_View_M01.ShowInput01 = true;
            Email_View_M01.ShowInput02 = true;
            Email_View_M01.ShowInput03 = false;
            Email_View_M01.ShowInput04 = false;
            Email_View_M01.ShowInput05 = false;
            Email_View_M01.ShowInput06 = true;
            Email_View_M01.label01 = string.Empty;
            Email_View_M01.label02 = string.Empty;
            Email_View_M01.label03 = string.Empty;
            Email_View_M01.label04 = string.Empty;
        }
        private void load_default_view03()
        {
            Email_View_M01.ShowInput01 = true;
            Email_View_M01.ShowInput02 = true;
            Email_View_M01.ShowInput03 = true;
            Email_View_M01.ShowInput04 = true;
            Email_View_M01.ShowInput05 = true;
            Email_View_M01.ShowInput06 = true;
            Email_View_M01.label01 = "Name";
            Email_View_M01.label02 = "Phonenumber";
            Email_View_M01.label03 = "Email";
            Email_View_M01.label04 = "Messsage";
        }
        public IActionResult OnPost()
        {

            if (string.IsNullOrEmpty(Email_View_M01.SelectedProject))
            {
                load_default_view01();
            }
            else
            {
                Picker01_SelectedIndexChanged();
            }



            LoadOptions();
            return Page();
        }

        private void LoadOptions()
        {
            Email_View_M01.ProjectOptions = new List<SelectListItem>();
            for (int i = 0; i < menu_array.Length; i++)
            {
                Email_View_M01.ProjectOptions.Add(
                    new SelectListItem
                    {
                        Value = (i + 1).ToString(),
                        Text = menu_array[i].Trim()
                    });
            }
        }

        private void load_Selection_data01()
        {
            string procedure = menu_array[int.Parse(Email_View_M01.SelectedProject) - 1].Trim();
            switch (procedure)
            {
                case "send email":
                    _commands.Add(procedure, send_email);
                    break;
            }
        }
        private void Picker01_SelectedIndexChanged()
        {
            switch (menu_array[int.Parse(Email_View_M01.SelectedProject) - 1].Trim())
            {

                case "send email":
                    load_default_view03();
                    break;

                default:
                    load_default_view01();
                    break;
            }
        }
        private async void send_email()
        {
            counter = 0;
            if (Security_S01.empty_string(Email_View_M01.input01, out data01[25]) == true)
            {

                counter++;
                Email_View_M01.StatusMessage01 = string.Empty;
            }
            else
            {
                counter--;
                Email_View_M01.StatusMessage01 = data01[25];
            }
            if (Security_S01.empty_string(Email_View_M01.input02, out data01[25]) == true)
            {
                if (Security_S01.email_check(Email_View_M01.input02, out data01[26]) == true)
                {

                    counter++;
                    Email_View_M01.StatusMessage02= string.Empty;

                }
                else
                {
                    counter--;

                    Email_View_M01.StatusMessage02 = data01[25];
                }
            }
            else
            {
                counter--;
                Email_View_M01.StatusMessage02 = $"full name is empty \n";
            }
            if (Security_S01.empty_string(Email_View_M01.input03, out data01[28]) == true)
            {
                if (Security_S01.phone_check(Email_View_M01.input03, out data01[29]) == true)
                {
                    counter++;
                    Email_View_M01.StatusMessage03 = string.Empty;
                }
                else
                {
                    counter--;
                    Email_View_M01.StatusMessage03 = data01[29];
                }
            }
            else
            {
                counter--;
                Email_View_M01.StatusMessage03 = data01[28];
            }

            if (Security_S01.empty_string(Email_View_M01.input04, out data01[30]) == true)
            {
                counter++;
                Email_View_M01.StatusMessage04 = string.Empty;
            }
            else
            {
                counter--;
                Email_View_M01.StatusMessage04 = data01[30];
            }
            if (counter == 4)
            {
                var res = await Security_S01.is_connected_to_netwrok_linux();
                if (res.success == true)
                {
                    if (Email_S01.send_email(Email_View_M01.input01, Email_View_M01.input02, Email_View_M01.input03, Email_View_M01.input04, out data01[32]) == true)
                    {
                        Email_View_M01.StatusMessage05 = $"{data01[31]}\n" +
                                       $"{data01[32]}\n";


                    }
                    else
                    {
                        Email_View_M01.StatusMessage05 = data01[32];
                    }
                }
                else
                {
                    Email_View_M01.StatusMessage05 = res.output;
                }

            }
            else
            {
                Email_View_M01.StatusMessage05 = data01[31];

            }


        }
        private void load_Selection01()
        {

            string key = menu_array[int.Parse(Email_View_M01.SelectedProject) - 1].Trim();
            load_Selection_data01();
            if (_commands.TryGetValue(key, out Action action))
            {
                action();
                _commands.Clear();
            }
            else
            {
                Email_View_M01.StatusMessage01 = $"{key} command not found";
            }

        }
        public IActionResult OnPostOk()
        {
            Picker01_SelectedIndexChanged();
            load_Selection01();
            LoadOptions();
            return Page();
        }
        public IActionResult OnPostBack()
        {
            return RedirectToPage("/EMAIL_VIEW/EMAIL_MAIN_VIEW/Email_Main_View01");
        }
    }
}
