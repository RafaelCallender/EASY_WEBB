using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using EASYPROJECT01.EASY_CALLENDER01.SERVICES.SECURITY_SERVICES;
using EASYPROJECT01.EASY_CALLENDER01.SERVICES.EMAIL_SERVICES;
using EASYPROJECT01.EASY_CALLENDER01.SERVICES.SQLITE.SQLITE_SERVICES.SQLITE_EMAIL_SERVICES;
using EASYPROJECT01.EASY_CALLENDER01.MODEL.WEB_MODEL.EMAIL_VIEW_MODEL;


namespace EASYPROJECT01.EASY_WEBB.Pages.EMAIL_VIEW.EMAIL_SELECTION_VIEW
{
    public class Email_Selection_View02 : PageModel
    {
        [BindProperty]
        public Email_View_Model01 Email_View_M01 { get; set; } = new Email_View_Model01();
        private static string[] data01 = new string[100];
        private static Security_Services01 Security_S01 = new Security_Services01();
        private static Email_Services01 Email_S01 = new Email_Services01();
        private static Sqlite_Email_Services01 Sqlite_Email_S01 = new Sqlite_Email_Services01();
        private static bool stored_procedure_bool = Sqlite_Email_S01.view_email_database_storedprocedures(out data01[50]);
        private static string stored_procedure_string = data01[50];
        private static string[] stored_procedure_array = stored_procedure_string.Split("\n");
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
        }
        private void load_default_view01()
        {
            Email_View_M01.ShowInput01 = true;
            Email_View_M01.ShowInput02 = false;
            Email_View_M01.ShowInput03 = false;
            Email_View_M01.ShowInput04 = false;
            Email_View_M01.ShowInput05 = false;
            Email_View_M01.ShowInput06 = true;
        }
        private void load_default_view02()
        {
            Email_View_M01.ShowInput01 = true;
            Email_View_M01.ShowInput02 = true;
            Email_View_M01.ShowInput03 = false;
            Email_View_M01.ShowInput04 = false;
            Email_View_M01.ShowInput05 = false;
            Email_View_M01.ShowInput06 = true;
        }
        private void load_default_view03()
        {
            Email_View_M01.ShowInput01 = true;
            Email_View_M01.ShowInput02 = true;
            Email_View_M01.ShowInput03 = true;
            Email_View_M01.ShowInput04 = true;
            Email_View_M01.ShowInput05 = true;
            Email_View_M01.ShowInput06 = true;
        }
        public IActionResult OnPost()
        {
            if (stored_procedure_bool == true)
            {
                if (string.IsNullOrEmpty(Email_View_M01.SelectedProject))
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
                Email_View_M01.StatusMessage01 = stored_procedure_string;
            }

            LoadOptions();
            return Page();
        }

        private void LoadOptions()
        {
            Email_View_M01.ProjectOptions = new List<SelectListItem>();
            for (int i = 0; i < stored_procedure_array.Length; i++)
            {
                Email_View_M01.ProjectOptions.Add(
                    new SelectListItem
                    {
                        Value = (i + 1).ToString(),
                        Text = stored_procedure_array[i].Trim()
                    });
            }
        }

        private void load_Selection_data01()
        {
            string procedure = stored_procedure_array[int.Parse(Email_View_M01.SelectedProject) - 1].Trim();
            switch (procedure)
            {
                case "insert_email":
                    _commands.Add(procedure, insert_email);
                    break;
                case "find_email_using_email":
                    _commands.Add(procedure, find_email_using_email);
                    break;
                case "find_email_using_name":
                    _commands.Add(procedure, find_email_using_name);
                    break;
                case "find_email_using_phonenumber":
                    _commands.Add(procedure, find_email_using_phonenumber);
                    break;
                case "find_full_name_using_email":
                    _commands.Add(procedure, find_full_name_using_email);
                    break;
                case "find_full_name_using_full_name":
                    _commands.Add(procedure, find_full_name_using_full_name);
                    break;
                case "find_full_name_using_phonenumber":
                    _commands.Add(procedure, find_full_name_using_phonenumber);
                    break;
                case "find_phonenumber_using_email":
                    _commands.Add(procedure, find_phonenumber_using_email);
                    break;
                case "find_phonenumber_using_fullname":
                    _commands.Add(procedure, find_phonenumber_using_fullname);
                    break;
                case "find_phonenumber_using_phonenumber":
                    _commands.Add(procedure, find_phonenumber_using_phonenumber);
                    break;


            }
        }
        private void Picker01_SelectedIndexChanged()
        {
            switch (stored_procedure_array[int.Parse(Email_View_M01.SelectedProject) - 1].Trim())
            {

                case "insert_email":
                    load_default_view03();
                    break;
                case "find_email_using_email":
                    load_default_view02();
                    break;
                case "find_email_using_name":
                    load_default_view02();
                    break;
                case "find_email_using_phonenumber":
                    load_default_view02();
                    break;
                case "find_full_name_using_email":
                    load_default_view02();
                    break;
                case "find_full_name_using_full_name":
                    load_default_view02();
                    break;
                case "find_full_name_using_phonenumber":
                    load_default_view02();
                    break;
                case "find_phonenumber_using_email":
                    load_default_view02();
                    break;
                case "find_phonenumber_using_fullname":
                    load_default_view02();
                    break;
                case "find_phonenumber_using_phonenumber":
                    load_default_view02();
                    break;
                default:
                    load_default_view01();
                    break;
            }
        }
        private void insert_email()
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
                    Email_View_M01.StatusMessage01 = string.Empty;

                }
                else
                {
                    counter--;

                    Email_View_M01.StatusMessage01 = data01[25];
                }
            }
            else
            {
                counter--;
                Email_View_M01.StatusMessage01 = $"full name is empty \n";
            }
            if (Security_S01.empty_string(Email_View_M01.input03, out data01[28]) == true)
            {
                if (Security_S01.phone_check(Email_View_M01.input03, out data01[29]) == true)
                {
                    counter++;
                    Email_View_M01.StatusMessage01 = string.Empty;
                }
                else
                {
                    counter--;
                    Email_View_M01.StatusMessage01 = data01[29];
                }
            }
            else
            {
                counter--;
                Email_View_M01.StatusMessage01 = data01[28];
            }

            if (Security_S01.empty_string(Email_View_M01.input04, out data01[30]) == true)
            {
                counter++;
                Email_View_M01.StatusMessage01 = string.Empty;
            }
            else
            {
                counter--;
                Email_View_M01.StatusMessage01 = data01[30];
            }
            if (counter == 4)
            {
                if (Email_S01.send_email(Email_View_M01.input01, Email_View_M01.input02, Email_View_M01.input03, Email_View_M01.input04, out data01[31]) == true)
                {

                    if (Sqlite_Email_S01.insert_email(Email_View_M01.input01, Email_View_M01.input02, Email_View_M01.input03, Email_View_M01.input04, out data01[32]) == true)
                    {
                        Email_View_M01.StatusMessage01 = $"{data01[31]}\n" +
                                       $"{data01[32]}\n";


                    }
                    else
                    {
                        Email_View_M01.StatusMessage01 = data01[32];
                    }

                }
                else
                {
                    Email_View_M01.StatusMessage01 = data01[31];

                }
            }
            else
            {
                Email_View_M01.StatusMessage01 = "something happened wrong please check the error message and try again";

            }

        }
        private void find_email_using_email()
        {
            if (Security_S01.empty_string(Email_View_M01.input01, out data01[23]) == true)
            {
                if (Security_S01.email_check(Email_View_M01.input01, out data01[24]) == true)
                {
                    if (Sqlite_Email_S01.find_email_using_email(Email_View_M01.input01, out data01[25]) == true)
                    {

                        Email_View_M01.StatusMessage01 = data01[25];
                    }
                    else
                    {

                        Email_View_M01.StatusMessage01 = data01[25];
                    }
                }
                else
                {

                    Email_View_M01.StatusMessage01 = data01[24];
                }
            }
            else
            {

                Email_View_M01.StatusMessage01 = data01[23];
            }


        }
        private void find_email_using_name()
        {
            if (Security_S01.empty_string(Email_View_M01.input01, out data01[23]) == true)
            {

                if (Sqlite_Email_S01.find_email_using_name(Email_View_M01.input01, out data01[25]) == true)
                {

                    Email_View_M01.StatusMessage01 = data01[25];
                }
                else
                {

                    Email_View_M01.StatusMessage01 = data01[25];
                }

            }
            else
            {

                Email_View_M01.StatusMessage01 = data01[23];
            }


        }
        private void find_email_using_phonenumber()
        {
            if (Security_S01.empty_string(Email_View_M01.input01, out data01[23]) == true)
            {
                if (Security_S01.phone_check(Email_View_M01.input01, out data01[24]) == true)
                {
                    if (Sqlite_Email_S01.find_email_using_phonenumber(Email_View_M01.input01, out data01[25]) == true)
                    {

                        Email_View_M01.StatusMessage01 = data01[25];
                    }
                    else
                    {

                        Email_View_M01.StatusMessage01 = data01[25];
                    }
                }
                else
                {

                    Email_View_M01.StatusMessage01 = data01[24];
                }
            }
            else
            {

                Email_View_M01.StatusMessage01 = data01[23];
            }


        }
        private void find_full_name_using_email()
        {
            if (Security_S01.empty_string(Email_View_M01.input01, out data01[23]) == true)
            {
                if (Security_S01.email_check(Email_View_M01.input01, out data01[24]) == true)
                {
                    if (Sqlite_Email_S01.find_full_name_using_email(Email_View_M01.input01, out data01[25]) == true)
                    {

                        Email_View_M01.StatusMessage01 = data01[25];
                    }
                    else
                    {

                        Email_View_M01.StatusMessage01 = data01[25];
                    }
                }
                else
                {

                    Email_View_M01.StatusMessage01 = data01[24];
                }
            }
            else
            {

                Email_View_M01.StatusMessage01 = data01[23];
            }

        }
        private void find_full_name_using_full_name()
        {
            if (Security_S01.empty_string(Email_View_M01.input01, out data01[23]) == true)
            {

                if (Sqlite_Email_S01.find_full_name_using_full_name(Email_View_M01.input01, out data01[25]) == true)
                {

                    Email_View_M01.StatusMessage01 = data01[25];
                }
                else
                {

                    Email_View_M01.StatusMessage01 = data01[25];
                }

            }
            else
            {

                Email_View_M01.StatusMessage01 = data01[23];
            }

        }
        private void find_full_name_using_phonenumber()
        {
            if (Security_S01.empty_string(Email_View_M01.input01, out data01[23]) == true)
            {
                if (Security_S01.phone_check(Email_View_M01.input01, out data01[24]) == true)
                {
                    if (Sqlite_Email_S01.find_full_name_using_phonenumber(Email_View_M01.input01, out data01[25]) == true)
                    {

                        Email_View_M01.StatusMessage01 = data01[25];
                    }
                    else
                    {

                        Email_View_M01.StatusMessage01 = data01[25];
                    }
                }
                else
                {

                    Email_View_M01.StatusMessage01 = data01[24];
                }
            }
            else
            {

                Email_View_M01.StatusMessage01 = data01[23];
            }


        }
        private void find_phonenumber_using_email()
        {
            if (Security_S01.empty_string(Email_View_M01.input01, out data01[23]) == true)
            {
                if (Security_S01.email_check(Email_View_M01.input01, out data01[24]) == true)
                {
                    if (Sqlite_Email_S01.find_phonenumber_using_email(Email_View_M01.input01, out data01[25]) == true)
                    {

                        Email_View_M01.StatusMessage01 = data01[25];
                    }
                    else
                    {

                        Email_View_M01.StatusMessage01 = data01[25];
                    }
                }
                else
                {

                    Email_View_M01.StatusMessage01 = data01[24];
                }
            }
            else
            {

                Email_View_M01.StatusMessage01 = data01[23];
            }

        }
        private void find_phonenumber_using_fullname()
        {
            if (Security_S01.empty_string(Email_View_M01.input01, out data01[23]) == true)
            {

                if (Sqlite_Email_S01.find_phonenumber_using_fullname(Email_View_M01.input01, out data01[25]) == true)
                {

                    Email_View_M01.StatusMessage01 = data01[25];
                }
                else
                {

                    Email_View_M01.StatusMessage01 = data01[25];
                }

            }
            else
            {

                Email_View_M01.StatusMessage01 = data01[23];
            }

        }
        private void find_phonenumber_using_phonenumber()
        {
            if (Security_S01.empty_string(Email_View_M01.input01, out data01[23]) == true)
            {
                if (Security_S01.phone_check(Email_View_M01.input01, out data01[24]) == true)
                {
                    if (Sqlite_Email_S01.find_phonenumber_using_phonenumber(Email_View_M01.input01, out data01[25]) == true)
                    {

                        Email_View_M01.StatusMessage01 = data01[25];
                    }
                    else
                    {

                        Email_View_M01.StatusMessage01 = data01[25];
                    }
                }
                else
                {

                    Email_View_M01.StatusMessage01 = data01[24];
                }
            }
            else
            {

                Email_View_M01.StatusMessage01 = data01[23];
            }

        }


        private void load_Selection01()
        {

            string key = stored_procedure_array[int.Parse(Email_View_M01.SelectedProject) - 1].Trim();
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
