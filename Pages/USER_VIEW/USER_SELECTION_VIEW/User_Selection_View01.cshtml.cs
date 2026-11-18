using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using EASY_CALLENDER01.MODEL.WEB_MODEL.USER_VIEW_MODEL;
using EASYPROJECT01.EASY_CALLENDER01.SERVICES.SECURITY_SERVICES;
using EASYPROJECT01.EASY_CALLENDER01.SERVICES.SQL.SQL_SERVICES.SQL_USER_SERVICES;
using EASYPROJECT01.EASY_CALLENDER01.SERVICES.LOCATION.LOCATION_HELPER;
using EASYPROJECT01.EASY_CALLENDER01.TEMPLATE.WEB_TEMPLATE;
using EASYPROJECT01.EASY_CALLENDER01.SERVICES.FILES.FILE_MANAGER;
using EASYPROJECT01.EASY_CALLENDER01.SERVICES.LOCATION.LOCATION_HELPER;
using EASYPROJECT01.EASY_CALLENDER01.SERVICES.SQL.SQL_SERVICES.SQL_USER_SERVICES;


namespace EASYPROJECT01.EASY_WEBB.Pages.USER_VIEW.USER_SELECTION_VIEW

{
    public class User_Selection_View01 : PageModel
    {
        public string css01 { get; set; } = Web_Template01.ccs01;
        [BindProperty]
        public User_View_Model01 User_View_M01 { get; set; } = new User_View_Model01();
        private static string[] data01 = new string[100];
        private static Security_Services01 Security_Serv01 = new Security_Services01();
        private static Sql_Services01 Sql_Serv01 = new Sql_Services01();
        private static Location_Helper01 Location_H01 = new Location_Helper01();
        private static File_Manger02 File_M02 = new File_Manger02();
        private static bool stored_procedure_bool = Sql_Serv01.view_user_database_storedprocedures(out data01[50]);
        public static string stored_procedure_string = data01[50];
        public static string[] stored_procedure_array = stored_procedure_string.Split("\n");
        private static int counter01 = 0;
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
            if (Security_Serv01.isPicker_selected_web(User_View_M01.SelectedProject,
            stored_procedure_array, out data01[1]) == true)
            {
                if (stored_procedure_bool == true)
                {
                    Picker01_SelectedIndexChanged();
                }
                else
                {

                    User_View_M01.StatusMessage01 = stored_procedure_string;
                }
            }
            else
            {

                User_View_M01.StatusMessage01 = data01[1];

            }
            return Page();
        }
        private void LoadOptions()
        {
            User_View_M01.ProjectOptions = new List<SelectListItem>();
            for (int i = 0; i < stored_procedure_array.Length; i++)
            {
                User_View_M01.ProjectOptions.Add(
                    new SelectListItem
                    {
                        Value = (i + 1).ToString(),
                        Text = stored_procedure_array[i].Trim()
                    });
            }
        }
        private void load_default_view()
        {
            User_View_M01.ShowInput01 = true;
            User_View_M01.ShowInput02 = false;
            User_View_M01.ShowInput03 = false;
            User_View_M01.ShowInput04 = false;
            User_View_M01.ShowInput05 = false;

        }

        private void load_Selection_data01()
        {
            string procedure = stored_procedure_array[int.Parse(User_View_M01.SelectedProject) - 1].Trim();
            switch (procedure)
            {
                case "delete_user_using_phonenumber":
                    _commands.Add(procedure, () => { delete_user_using_phonenumber(); return Task.CompletedTask; });
                    break;
                case "delete_user_using_username":
                    _commands.Add(procedure, () => { delete_user_using_username(); return Task.CompletedTask; });
                    break;
                case "find_email_using_email":
                    _commands.Add(procedure, () => { find_email_using_email(); return Task.CompletedTask; });
                    break;
                case "find_email_using_username":
                    _commands.Add(procedure, () => { find_email_using_username(); return Task.CompletedTask; });
                    break;
                case "find_password_using_email":
                    _commands.Add(procedure, () => { find_password_using_email(); return Task.CompletedTask; });
                    break;
                case "find_password_using_username":
                    _commands.Add(procedure, () => { find_password_using_username(); return Task.CompletedTask; });
                    break;
                case "find_phonenumber_using_email":
                    _commands.Add(procedure, () => { find_phonenumber_using_email(); return Task.CompletedTask; });
                    break;
                case "find_phonenumber_using_phonenumber":
                    _commands.Add(procedure, () => { find_phonenumber_using_phonenumber(); return Task.CompletedTask; });
                    break;
                case "find_phonenumber_using_username":
                    _commands.Add(procedure, () => { find_phonenumber_using_username(); return Task.CompletedTask; });
                    break;
                case "find_user_location_using_email":
                    _commands.Add(procedure, () => { find_user_location_using_email(); return Task.CompletedTask; });
                    break;
                case "find_user_location_using_username":
                    _commands.Add(procedure, () => { find_user_location_using_username(); return Task.CompletedTask; });
                    break;
                case "find_username_password":
                    _commands.Add(procedure, () => { find_username_password(); return Task.CompletedTask; });
                    break;
                case "find_username_using_email":
                    _commands.Add(procedure, () => { find_username_using_email(); return Task.CompletedTask; });
                    break;
                case "find_username_using_username":
                    _commands.Add(procedure, () => { find_username_using_username(); return Task.CompletedTask; });
                    break;

                case "insert_text_file_using_username":
                    _commands.Add(procedure, () => { insert_text_file_using_username(); return Task.CompletedTask; });
                    break;
                case "insert_user":
                    _commands.Add(procedure, () => { insert_user(); return Task.CompletedTask; });
                    break;
                case "insert_user_audio_file_using_username":
                    _commands.Add(procedure, () => { insert_user_audio_file_using_username(); return Task.CompletedTask; });
                    break;
                case "insert_user_text_file_using_username":
                    _commands.Add(procedure, () => { insert_user_text_file_using_username(); return Task.CompletedTask; });
                    break;
                case "update_email_using_email":
                    _commands.Add(procedure, () => { update_email_using_email(); return Task.CompletedTask; });
                    break;
                case "update_email_using_username":
                    _commands.Add(procedure, () => { update_email_using_username(); return Task.CompletedTask; });
                    break;
                case "update_password_using_email":
                    _commands.Add(procedure, () => { update_password_using_email(); return Task.CompletedTask; });
                    break;
                case "update_password_using_phonenumber":
                    _commands.Add(procedure, () => { update_password_using_phonenumber(); return Task.CompletedTask; });
                    break;
                case "update_password_using_username":
                    _commands.Add(procedure, () => { update_password_using_username(); return Task.CompletedTask; });
                    break;
                case "update_phonenumber_using_email":
                    _commands.Add(procedure, () => { update_phonenumber_using_email(); return Task.CompletedTask; });
                    break;
                case "update_phonenumber_using_username":
                    _commands.Add(procedure, () => { update_phonenumber_using_username(); return Task.CompletedTask; });
                    break;
                case "update_user_location_using_email":
                    _commands.Add(procedure, () => { update_user_location_using_email(); return Task.CompletedTask; });
                    break;
                case "update_user_location_using_name":
                    _commands.Add(procedure, () => { update_user_location_using_name(); return Task.CompletedTask; });
                    break;
                case "update_user_location_using_phonenumber":
                    _commands.Add(procedure, () => { update_user_location_using_phonenumber(); return Task.CompletedTask; });
                    break;
                case "update_user_location_using_username":
                    _commands.Add(procedure, () => { update_user_location_using_username(); return Task.CompletedTask; });
                    break;
                case "update_username_using_email":
                    _commands.Add(procedure, () => { update_username_using_email(); return Task.CompletedTask; });
                    break;
                case "update_username_using_phonenumber":
                    _commands.Add(procedure, () => { update_username_using_phonenumber(); return Task.CompletedTask; });
                    break;
                case "update_username_using_username":
                    _commands.Add(procedure, () => { update_username_using_username(); return Task.CompletedTask; });
                    break;
                case "user_login":
                    _commands.Add(procedure, () => { user_login(); return Task.CompletedTask; });
                    break;
                case "view_all_emails":
                    _commands.Add(procedure, () => { view_all_emails(); return Task.CompletedTask; });
                    break;
                case "view_all_passwords":
                    _commands.Add(procedure, () => { view_all_passwords(); return Task.CompletedTask; });
                    break;
                case "view_all_phonenumber":
                    _commands.Add(procedure, () => { view_all_phonenumber(); return Task.CompletedTask; });
                    break;
                case "view_all_username":
                    _commands.Add(procedure, () => { view_all_username(); return Task.CompletedTask; });
                    break;
                case "view_user_table":
                    _commands.Add(procedure, () => { view_user_table(); return Task.CompletedTask; });
                    break;

            }
        }



        private void delete_user_using_phonenumber()
        {
            if (Security_Serv01.empty_string(User_View_M01.Input01, out data01[23]) == true)
            {

                if (Sql_Serv01.delete_user_using_phonenumber(User_View_M01.Input01, out data01[25]) == true)
                {

                    User_View_M01.StatusMessage01 = $"{data01[25]}\n";
                }
                else
                {

                    User_View_M01.StatusMessage01 = $"{data01[25]}\n";
                }
            }
            else
            {

                User_View_M01.StatusMessage01 = $"{data01[23]}\n";
            }

        }
        private void delete_user_using_username()
        {
            if (Security_Serv01.empty_string(User_View_M01.Input01, out data01[23]) == true)
            {

                if (Sql_Serv01.delete_user_using_username(User_View_M01.Input01, out data01[25]) == true)
                {

                    User_View_M01.StatusMessage01 = $"{data01[25]}\n";
                }
                else
                {

                    User_View_M01.StatusMessage01 = $"{data01[25]}\n";
                }
            }
            else
            {

                User_View_M01.StatusMessage01 = $"{data01[23]}\n";
            }

        }
        private void find_email_using_email()
        {
            if (Security_Serv01.empty_string(User_View_M01.Input01, out data01[23]) == true)
            {

                if (Security_Serv01.email_check(User_View_M01.Input01, out data01[24]) == true)
                {

                    if (Sql_Serv01.find_email_using_email(User_View_M01.Input01, out data01[25]) == true)
                    {

                        User_View_M01.StatusMessage01 = $"{data01[25]}\n";
                    }
                    else
                    {

                        User_View_M01.StatusMessage01 = $"{data01[25]}\n";
                    }
                }
                else
                {

                    User_View_M01.StatusMessage01 = $"{data01[24]}\n";

                }
            }
            else
            {

                User_View_M01.StatusMessage01 = $"{data01[23]}\n";
            }

        }
        private void find_email_using_username()
        {
            if (Security_Serv01.empty_string(User_View_M01.Input01, out data01[23]) == true)
            {

                if (Sql_Serv01.find_email_using_username(User_View_M01.Input01, out data01[25]) == true)
                {

                    User_View_M01.StatusMessage01 = $"{data01[25]}\n";
                }
                else
                {

                    User_View_M01.StatusMessage01 = $"{data01[25]}\n";
                }
            }
            else
            {

                User_View_M01.StatusMessage01 = $"{data01[23]}\n";
            }

        }
        private void find_password_using_email()
        {
            if (Security_Serv01.empty_string(User_View_M01.Input01, out data01[23]) == true)
            {
                if (Security_Serv01.email_check(User_View_M01.Input01, out data01[24]) == true)
                {
                    if (Sql_Serv01.find_password_using_email(User_View_M01.Input01, out data01[25]) == true)
                    {

                        User_View_M01.StatusMessage01 = $"{data01[25]}\n";
                    }
                    else
                    {

                        User_View_M01.StatusMessage01 = $"{data01[25]}\n";
                    }
                }
                else
                {

                    User_View_M01.StatusMessage01 = $"{data01[24]}\n";
                }
            }
            else
            {

                User_View_M01.StatusMessage01 = $"{data01[23]}\n";
            }

        }
        private void find_password_using_username()
        {
            if (Security_Serv01.empty_string(User_View_M01.Input01, out data01[23]) == true)
            {

                if (Sql_Serv01.find_password_using_username(User_View_M01.Input01, out data01[25]) == true)
                {

                    User_View_M01.StatusMessage01 = $"{data01[25]}\n";
                }
                else
                {

                    User_View_M01.StatusMessage01 = $"{data01[25]}\n";
                }
            }
            else
            {

                User_View_M01.StatusMessage01 = $"{data01[23]}\n";
            }

        }
        private void find_phonenumber_using_email()
        {
            if (Security_Serv01.empty_string(User_View_M01.Input01, out data01[23]) == true)
            {
                if (Security_Serv01.email_check(User_View_M01.Input01, out data01[24]) == true)
                {

                    if (Sql_Serv01.find_phonenumber_using_email(User_View_M01.Input01, out data01[25]) == true)
                    {

                        User_View_M01.StatusMessage01 = $"{data01[25]}\n";
                    }
                    else
                    {

                        User_View_M01.StatusMessage01 = $"{data01[25]}\n";
                    }
                }
                else
                {

                    User_View_M01.StatusMessage01 = $"{data01[24]}\n";
                }
            }
            else
            {

                User_View_M01.StatusMessage01 = $"{data01[23]}\n";
            }

        }
        private void find_phonenumber_using_phonenumber()
        {
            if (Security_Serv01.empty_string(User_View_M01.Input01, out data01[23]) == true)
            {
                if (Security_Serv01.phone_check(User_View_M01.Input01, out data01[24]) == true)
                {

                    if (Sql_Serv01.find_user_location_using_username(User_View_M01.Input01, out data01[25]) == true)
                    {

                        User_View_M01.StatusMessage01 = $"{data01[25]}\n";
                    }
                    else
                    {

                        User_View_M01.StatusMessage01 = $"{data01[25]}\n";
                    }
                }
                else
                {

                    User_View_M01.StatusMessage01 = $"{data01[24]}\n";
                }
            }
            else
            {

                User_View_M01.StatusMessage01 = $"{data01[23]}\n";
            }

        }
        private void find_phonenumber_using_username()
        {
            if (Security_Serv01.empty_string(User_View_M01.Input01, out data01[23]) == true)
            {

                if (Sql_Serv01.find_phonenumber_using_username(User_View_M01.Input01, out data01[25]) == true)
                {

                    User_View_M01.StatusMessage01 = $"{data01[25]}\n";
                }
                else
                {

                    User_View_M01.StatusMessage01 = $"{data01[25]}\n";
                }
            }
            else
            {

                User_View_M01.StatusMessage01 = $"{data01[23]}\n";
            }

        }
        private void find_user_location_using_email()
        {
            if (Security_Serv01.empty_string(User_View_M01.Input01, out data01[23]) == true)
            {
                if (Security_Serv01.email_check(User_View_M01.Input01, out data01[24]) == true)
                {

                    if (Sql_Serv01.find_user_location_using_username(User_View_M01.Input01, out data01[25]) == true)
                    {

                        User_View_M01.StatusMessage01 = $"{data01[25]}\n";
                    }
                    else
                    {

                        User_View_M01.StatusMessage01 = $"{data01[25]}\n";
                    }
                }
                else
                {

                    User_View_M01.StatusMessage01 = $"{data01[24]}\n";
                }
            }
            else
            {

                User_View_M01.StatusMessage01 = $"{data01[23]}\n";
            }

        }
        private void find_user_location_using_username()
        {
            if (Security_Serv01.empty_string(User_View_M01.Input01, out data01[23]) == true)
            {

                if (Sql_Serv01.find_user_location_using_username(User_View_M01.Input01, out data01[25]) == true)
                {

                    User_View_M01.StatusMessage01 = $"{data01[25]}\n";
                }
                else
                {

                    User_View_M01.StatusMessage01 = $"{data01[25]}\n";
                }
            }
            else
            {

                User_View_M01.StatusMessage01 = $"{data01[23]}\n";
            }

        }
        private void find_username_password()
        {
            if (Security_Serv01.empty_string(User_View_M01.Input01, out data01[23]) == true)
            {

                if (Sql_Serv01.find_username_password(User_View_M01.Input01, out data01[25]) == true)
                {

                    User_View_M01.StatusMessage01 = $"{data01[25]}\n";
                }
                else
                {

                    User_View_M01.StatusMessage01 = $"{data01[25]}\n";
                }
            }
            else
            {

                User_View_M01.StatusMessage01 = $"{data01[23]}\n";
            }

        }
        private void find_username_using_email()
        {
            if (Security_Serv01.empty_string(User_View_M01.Input01, out data01[23]) == true)
            {
                if (Security_Serv01.empty_string(User_View_M01.Input01, out data01[24]) == true)
                {

                    if (Sql_Serv01.find_username_using_email(User_View_M01.Input01, out data01[25]) == true)
                    {

                        User_View_M01.StatusMessage01 = $"{data01[25]}\n";
                    }
                    else
                    {

                        User_View_M01.StatusMessage01 = $"{data01[25]}\n";
                    }
                }
                else
                {

                    User_View_M01.StatusMessage01 = $"{data01[24]}\n";
                }
            }
            else
            {

                User_View_M01.StatusMessage01 = $"{data01[23]}\n";
            }

        }
        private void find_username_using_username()
        {
            if (Security_Serv01.empty_string(User_View_M01.Input01, out data01[23]) == true)
            {

                if (Sql_Serv01.find_username_using_username(User_View_M01.Input01, out data01[25]) == true)
                {

                    User_View_M01.StatusMessage01 = $"{data01[25]}\n";
                }
                else
                {

                    User_View_M01.StatusMessage01 = $"{data01[25]}\n";
                }
            }
            else
            {

                User_View_M01.StatusMessage01 = $"{data01[23]}\n";
            }

        }
        private void insert_text_file_using_username()
        {
            User_View_M01.StatusMessage01 = $"not yet developed\n";
        }
        private void insert_user()
        {
            counter01 = 0;
            if (Security_Serv01.empty_string(User_View_M01.Input01, out data01[23]) == true)
            {
                if (Sql_Serv01.find_username_using_username(User_View_M01.Input01, out data01[25]) == false)
                {
                    counter01++;

                }
                else
                {

                    counter01--;
                    User_View_M01.StatusMessage01 = $"{data01[23]}\n";
                }

            }
            else
            {

                counter01--;
                User_View_M01.StatusMessage01 = $"{data01[23]}\n";

            }
            if (Security_Serv01.empty_string(User_View_M01.Input02, out data01[23]) == true)
            {

                counter01++;
            }
            else
            {

                counter01--;
                User_View_M01.StatusMessage02 = $"{data01[23]}\n";

            }

            if (Security_Serv01.empty_string(User_View_M01.Input03, out data01[23]) == true)
            {

                counter01++;
            }
            else
            {

                counter01--;
                User_View_M01.StatusMessage03 = $"{data01[23]}\n";

            }
            if (Security_Serv01.empty_string(User_View_M01.Input04, out data01[23]) == true)
            {

                counter01++;
            }
            else
            {

                counter01--;
                User_View_M01.StatusMessage02 = $"{data01[23]}\n";

            }
            if (Security_Serv01.empty_string(User_View_M01.Input03, out data01[23]) == true)
            {
                if (Security_Serv01.email_check(User_View_M01.Input03, out data01[24]) == true)
                {

                    counter01++;



                }
                else
                {

                    counter01--;
                    User_View_M01.StatusMessage05 = $"{data01[24]}\n";
                }

            }
            else
            {

                counter01--;
                User_View_M01.StatusMessage05 = $"{data01[23]}\n";

            }
            if (Security_Serv01.empty_string(User_View_M01.Input06, out data01[22]) == true)
            {
                if (Security_Serv01.phone_check(User_View_M01.Input06, out data01[23]) == true)
                {

                    counter01++;

                }
                else
                {

                    counter01--;
                    User_View_M01.StatusMessage06 = $"{data01[23]}\n";
                }
            }
            else
            {

                counter01--;
                User_View_M01.StatusMessage06 = $"{data01[22]}\n";

            }
            if (Security_Serv01.empty_string(User_View_M01.Input07, out data01[23]) == true)
            {

                counter01++;
            }
            else
            {

                counter01--;
                User_View_M01.StatusMessage07 = $"{data01[23]}\n";

            }
            if (Security_Serv01.empty_string(User_View_M01.Input08, out data01[23]) == true)
            {

                counter01++;
            }
            else
            {

                counter01--;
                User_View_M01.StatusMessage08 = $"{data01[23]}\n";

            }
            if (User_View_M01.Input08 == User_View_M01.Input08)
            {

                counter01++;

            }
            else
            {

                counter01--;
                User_View_M01.StatusMessage08 = $"password does not match\n";
            }
            if (counter01 == 10)
            {
                if (Sql_Serv01.insert_user(User_View_M01.Input01, User_View_M01.Input02, User_View_M01.Input03, User_View_M01.Input04, User_View_M01.Input05, User_View_M01.Input06, User_View_M01.Input07, out data01[1]) == true)
                {

                    User_View_M01.StatusMessage09 += $"{data01[1]}\n";

                }
                else
                {

                    User_View_M01.StatusMessage09 = $"{data01[1]}\n";
                }
            }
            else
            {

                User_View_M01.StatusMessage07 += $"please fix errors\n";
            }
        }
        private void insert_user_audio_file_using_username()
        {
            User_View_M01.StatusMessage01 = $"not yet developed\n";
        }
        private void insert_user_text_file_using_username()
        {
            User_View_M01.StatusMessage01 = $"not yet developed\n";
        }
        private void update_email_using_email()
        {
            if (Security_Serv01.empty_string(User_View_M01.Input01, out data01[23]) == true)
            {

                if (Security_Serv01.email_check(User_View_M01.Input01, out data01[23]) == true)
                {

                    counter01++;

                }

                else
                {
                    User_View_M01.StatusMessage01 = data01[23];
                    counter01--;
                }
            }
            else
            {
                User_View_M01.StatusMessage01 = data01[23];
                counter01--;
            }
            if (Security_Serv01.empty_string(User_View_M01.Input02, out data01[23]) == true)
            {
                counter01++;

            }
            else
            {
                User_View_M01.StatusMessage02 = data01[23];
                counter01--;

            }
            if (counter01 == 2)
            {
                if (Sql_Serv01.update_email_using_email(User_View_M01.Input01, User_View_M01.Input02, out data01[25]) == true)
                {
                    User_View_M01.StatusMessage02 = data01[25];
                }
                else
                {
                    User_View_M01.StatusMessage02 = data01[25];
                }
            }
            else
            {
                User_View_M01.StatusMessage02 = "please check errors";
            }
        }
        private void update_email_using_username()
        {
            if (Security_Serv01.empty_string(User_View_M01.Input01, out data01[23]) == true)
            {

                counter01++;
            }
            else
            {
                User_View_M01.StatusMessage01 = data01[23];
                counter01--;
            }
            if (Security_Serv01.empty_string(User_View_M01.Input01, out data01[23]) == true)
            {
                counter01++;

            }
            else
            {
                User_View_M01.StatusMessage02 = data01[23];
                counter01--;

            }
            if (counter01 == 2)
            {
                if (Sql_Serv01.update_email_using_username(User_View_M01.Input01, User_View_M01.Input02, out data01[25]) == true)
                {
                    User_View_M01.StatusMessage01 = data01[25];
                }
                else
                {
                    User_View_M01.StatusMessage02 = data01[25];
                }
            }
            else
            {
                User_View_M01.StatusMessage02 = "please check errors";
            }
        }
        private void update_password_using_email()
        {
            if (Security_Serv01.empty_string(User_View_M01.Input01, out data01[23]) == true)
            {

                if (Security_Serv01.empty_string(User_View_M01.Input01, out data01[24]) == true)
                {

                    counter01++;
                }
                else
                {
                    User_View_M01.StatusMessage01 = data01[23];
                    counter01--;
                }

            }
            else
            {
                User_View_M01.StatusMessage01 = data01[23];
                counter01--;
            }
            if (Security_Serv01.empty_string(User_View_M01.Input02, out data01[23]) == true)
            {
                counter01++;

            }
            else
            {
                User_View_M01.StatusMessage02 = data01[23];
                counter01--;

            }
            if (counter01 == 2)
            {
                if (Sql_Serv01.update_password_using_email(User_View_M01.Input01, User_View_M01.Input02, out data01[25]) == true)
                {
                    User_View_M01.StatusMessage02 = data01[25];
                }
                else
                {
                    User_View_M01.StatusMessage02 = data01[25];
                }
            }
            else
            {
                User_View_M01.StatusMessage02 = "please check errors";
            }
        }
        private void update_password_using_phonenumber()
        {
            if (Security_Serv01.empty_string(User_View_M01.Input01, out data01[23]) == true)
            {

                if (Security_Serv01.phone_check(User_View_M01.Input01, out data01[24]) == true)
                {


                    counter01++;
                }
                else
                {

                    User_View_M01.StatusMessage01 = data01[24];
                    counter01--;
                }
            }
            else
            {
                User_View_M01.StatusMessage01 = data01[23];
                counter01--;
            }
            if (Security_Serv01.empty_string(User_View_M01.Input02, out data01[23]) == true)
            {
                counter01++;

            }
            else
            {
                User_View_M01.StatusMessage02 = data01[23];
                counter01--;

            }
            if (counter01 == 2)
            {
                if (Sql_Serv01.update_password_using_phonenumber(User_View_M01.Input01, User_View_M01.Input02, out data01[25]) == true)
                {
                    User_View_M01.StatusMessage01 = data01[25];
                }
                else
                {
                    User_View_M01.StatusMessage02 = data01[25];
                }
            }
            else
            {
                User_View_M01.StatusMessage02 = "please check errors";
            }
        }
        private void update_password_using_username()
        {
            if (Security_Serv01.empty_string(User_View_M01.Input01, out data01[23]) == true)
            {

                counter01++;
            }
            else
            {
                User_View_M01.StatusMessage01 = data01[23];
                counter01--;
            }
            if (Security_Serv01.empty_string(User_View_M01.Input02, out data01[23]) == true)
            {
                counter01++;

            }
            else
            {
                User_View_M01.StatusMessage02 = data01[23];
                counter01--;

            }
            if (counter01 == 2)
            {
                if (Sql_Serv01.update_password_using_username(User_View_M01.Input01, User_View_M01.Input02, out data01[25]) == true)
                {
                    User_View_M01.StatusMessage02 = data01[25];
                }
                else
                {
                    User_View_M01.StatusMessage02 = data01[25];
                }
            }
            else
            {
                User_View_M01.StatusMessage02 = "please check errors";
            }
        }
        private void update_phonenumber_using_email()
        {
            if (Security_Serv01.empty_string(User_View_M01.Input01, out data01[23]) == true)
            {

                if (Security_Serv01.email_check(User_View_M01.Input01, out data01[24]) == true)
                {

                    counter01++;
                }
                else
                {
                    User_View_M01.StatusMessage01 = data01[24];
                    counter01--;
                }

            }
            else
            {
                User_View_M01.StatusMessage01 = data01[23];
                counter01--;
            }
            if (Security_Serv01.empty_string(User_View_M01.Input02, out data01[23]) == true)
            {

                if (Security_Serv01.phone_check(User_View_M01.Input02, out data01[24]) == true)
                {

                    counter01++;
                }
                else
                {
                    User_View_M01.StatusMessage02 = data01[24];
                    counter01--;
                }

            }
            else
            {
                User_View_M01.StatusMessage02 = data01[23];
                counter01--;
            }
            if (counter01 == 2)
            {
                if (Sql_Serv01.update_phonenumber_using_email(User_View_M01.Input01, User_View_M01.Input02, out data01[25]) == true)
                {
                    User_View_M01.StatusMessage02 = data01[25];
                }
                else
                {
                    User_View_M01.StatusMessage02 = data01[25];
                }
            }
            else
            {
                User_View_M01.StatusMessage02 = "please check errors";
            }
        }
        private void update_phonenumber_using_username()
        {
            if (Security_Serv01.empty_string(User_View_M01.Input01, out data01[23]) == true)
            {

                counter01++;
            }
            else
            {
                User_View_M01.StatusMessage01 = data01[23];
                counter01--;
            }
            if (Security_Serv01.empty_string(User_View_M01.Input01, out data01[23]) == true)
            {
                counter01++;

            }
            else
            {
                User_View_M01.StatusMessage02 = data01[23];
                counter01--;

            }
            if (counter01 == 2)
            {
                if (Sql_Serv01.update_phonenumber_using_username(User_View_M01.Input01, User_View_M01.Input02, out data01[25]) == true)
                {
                    User_View_M01.StatusMessage02 = data01[25];
                }
                else
                {
                    User_View_M01.StatusMessage02 = data01[25];
                }
            }
            else
            {
                User_View_M01.StatusMessage02 = "please check errors";
            }
        }
        private void update_user_location_using_email()
        {
            if (Security_Serv01.empty_string(User_View_M01.Input01, out data01[23]) == true)
            {
                if (Security_Serv01.empty_string(User_View_M01.Input01, out data01[24]) == true)
                {

                    counter01++;
                }
                else
                {
                    User_View_M01.StatusMessage01 = data01[24];
                    counter01--;
                }

            }
            else
            {
                User_View_M01.StatusMessage01 = data01[23];
                counter01--;
            }
            if (Security_Serv01.empty_string(User_View_M01.Input01, out data01[23]) == true)
            {
                counter01++;

            }
            else
            {
                User_View_M01.StatusMessage01 = data01[23];
                counter01--;

            }
            if (counter01 == 2)
            {
                if (Sql_Serv01.update_user_location_using_email(User_View_M01.Input01, User_View_M01.Input02, out data01[25]) == true)
                {
                    User_View_M01.StatusMessage02 = data01[25];
                }
                else
                {
                    User_View_M01.StatusMessage02 = data01[25];
                }
            }
            else
            {
                User_View_M01.StatusMessage02 = "please check errors";
            }
        }
        private void update_user_location_using_name()
        {
            if (Security_Serv01.empty_string(User_View_M01.Input01, out data01[23]) == true)
            {

                counter01++;
            }
            else
            {
                User_View_M01.StatusMessage01 = data01[23];
                counter01--;
            }
            if (Security_Serv01.empty_string(User_View_M01.Input02, out data01[23]) == true)
            {
                counter01++;

            }
            else
            {
                User_View_M01.StatusMessage02 = data01[23];
                counter01--;

            }
            if (counter01 == 2)
            {
                if (Sql_Serv01.update_user_location_using_name(User_View_M01.Input01, User_View_M01.Input02, out data01[25]) == true)
                {
                    User_View_M01.StatusMessage02 = data01[25];
                }
                else
                {
                    User_View_M01.StatusMessage02 = data01[25];
                }
            }
            else
            {
                User_View_M01.StatusMessage02 = "please check errors";
            }
        }
        private void update_user_location_using_phonenumber()
        {
            if (Security_Serv01.empty_string(User_View_M01.Input01, out data01[23]) == true)
            {
                if (Security_Serv01.phone_check(User_View_M01.Input01, out data01[24]) == true)
                {

                    counter01++;
                }
                else
                {
                    User_View_M01.StatusMessage01 = data01[24];
                    counter01--;
                }
            }
            else
            {
                User_View_M01.StatusMessage01 = data01[23];
                counter01--;
            }
            if (Security_Serv01.empty_string(User_View_M01.Input02, out data01[23]) == true)
            {
                counter01++;

            }
            else
            {
                User_View_M01.StatusMessage02 = data01[23];
                counter01--;

            }
            if (counter01 == 2)
            {
                if (Sql_Serv01.update_user_location_using_phonenumber(User_View_M01.Input01, User_View_M01.Input02, out data01[25]) == true)
                {
                    User_View_M01.StatusMessage02 = data01[25];
                }
                else
                {
                    User_View_M01.StatusMessage02 = data01[25];
                }
            }
            else
            {
                User_View_M01.StatusMessage02 = "please check errors";
            }
        }
        private void update_user_location_using_username()
        {
            if (Security_Serv01.empty_string(User_View_M01.Input01, out data01[23]) == true)
            {

                counter01++;
            }
            else
            {
                User_View_M01.StatusMessage01 = data01[23];
                counter01--;
            }
            if (Security_Serv01.empty_string(User_View_M01.Input01, out data01[23]) == true)
            {
                counter01++;

            }
            else
            {
                User_View_M01.StatusMessage02 = data01[23];
                counter01--;

            }
            if (counter01 == 2)
            {
                if (Sql_Serv01.update_user_location_using_username(User_View_M01.Input01, User_View_M01.Input02, out data01[25]) == true)
                {
                    User_View_M01.StatusMessage02 = data01[25];
                }
                else
                {
                    User_View_M01.StatusMessage02 = data01[25];
                }
            }
            else
            {
                User_View_M01.StatusMessage02 = "please check errors";
            }
        }
        private void update_username_using_email()
        {
            if (Security_Serv01.empty_string(User_View_M01.Input01, out data01[23]) == true)
            {
                if (Security_Serv01.email_check(User_View_M01.Input01, out data01[24]) == true)
                {


                    counter01++;
                }
                else
                {
                    User_View_M01.StatusMessage01 = data01[24];
                    counter01--;
                }

            }
            else
            {
                User_View_M01.StatusMessage01 = data01[23];
                counter01--;
            }
            if (Security_Serv01.empty_string(User_View_M01.Input01, out data01[23]) == true)
            {
                counter01++;

            }
            else
            {
                User_View_M01.StatusMessage02 = data01[23];
                counter01--;

            }
            if (counter01 == 2)
            {
                if (Sql_Serv01.update_username_using_email(User_View_M01.Input01, User_View_M01.Input02, out data01[25]) == true)
                {
                    User_View_M01.StatusMessage02 = data01[25];
                }
                else
                {
                    User_View_M01.StatusMessage02 = data01[25];
                }
            }
            else
            {
                User_View_M01.StatusMessage02 = "please check errors";
            }
        }
        private void update_username_using_phonenumber()
        {
            if (Security_Serv01.empty_string(User_View_M01.Input01, out data01[23]) == true)
            {

                if (Security_Serv01.phone_check(User_View_M01.Input01, out data01[23]) == true)
                {

                    counter01++;
                }
                else
                {
                    User_View_M01.StatusMessage01 = data01[23];
                    counter01--;
                }

            }
            else
            {
                User_View_M01.StatusMessage01 = data01[23];
                counter01--;
            }
            if (Security_Serv01.empty_string(User_View_M01.Input02, out data01[23]) == true)
            {
                counter01++;

            }
            else
            {
                User_View_M01.StatusMessage02 = data01[23];
                counter01--;

            }
            if (counter01 == 2)
            {
                if (Sql_Serv01.update_username_using_phonenumber(User_View_M01.Input01, User_View_M01.Input02, out data01[25]) == true)
                {
                    User_View_M01.StatusMessage01 = data01[25];
                }
                else
                {
                    User_View_M01.StatusMessage02 = data01[25];
                }
            }
            else
            {
                User_View_M01.StatusMessage02 = "please check errors";
            }
        }
        private void update_username_using_username()
        {
            if (Security_Serv01.empty_string(User_View_M01.Input01, out data01[23]) == true)
            {

                counter01++;
            }
            else
            {
                User_View_M01.StatusMessage01 = data01[23];
                counter01--;
            }
            if (Security_Serv01.empty_string(User_View_M01.Input02, out data01[23]) == true)
            {
                counter01++;

            }
            else
            {
                User_View_M01.StatusMessage02 = data01[23];
                counter01--;

            }
            if (counter01 == 2)
            {
                if (Sql_Serv01.update_username_using_username(User_View_M01.Input01, User_View_M01.Input02, out data01[25]) == true)
                {
                    User_View_M01.StatusMessage01 = data01[25];
                }
                else
                {
                    User_View_M01.StatusMessage02 = data01[25];
                }
            }
            else
            {
                User_View_M01.StatusMessage02 = "please check errors";
            }
        }
        private void user_login()
        {
            if (Security_Serv01.empty_string(User_View_M01.Input01, out data01[23]) == true)
            {

                counter01++;
            }
            else
            {
                User_View_M01.StatusMessage01 = data01[23];
                counter01--;
            }
            if (Security_Serv01.empty_string(User_View_M01.Input02, out data01[23]) == true)
            {
                counter01++;

            }
            else
            {
                User_View_M01.StatusMessage02 = data01[23];
                counter01--;

            }
            if (counter01 == 2)
            {
                if (Sql_Serv01.user_login(User_View_M01.Input01, User_View_M01.Input02, out data01[25]) == true)
                {
                    User_View_M01.StatusMessage01 = data01[25];
                }
                else
                {
                    User_View_M01.StatusMessage02 = data01[25];
                }
            }
            else
            {
                User_View_M01.StatusMessage02 = "please check errors";
            }
        }
        private void view_all_emails()
        {
            //  User_View_M01.StatusMessage01 = Sql_Serv01.view_all_emails();
            User_View_M01.StatusMessage01 = "not devekoped yet";
        }
        private void view_all_passwords()
        {
            User_View_M01.StatusMessage01 = Sql_Serv01.view_all_passwords();
        }
        private void view_all_phonenumber()
        {
            User_View_M01.StatusMessage01 = Sql_Serv01.view_all_phonenumber();
        }
        private void view_all_username()
        {
            User_View_M01.StatusMessage01 = Sql_Serv01.view_all_username();
        }
        private void view_user_table()
        {
            User_View_M01.StatusMessage01 = "not yet developed";
        }


        private void Picker01_SelectedIndexChanged()
        {
            switch (stored_procedure_array[int.Parse(User_View_M01.SelectedProject) - 1].Trim())
            {

                case "insert_email":
                    load_default_view();
                    break;
                case "delete_user_using_phonenumber":
                    load_default_view();
                    break;
                case "delete_user_using_username":
                    load_default_view();
                    break;
                case "find_email_using_email":
                    load_default_view();
                    break;
                case "find_email_using_username":
                    load_default_view();
                    break;
                case "find_password_using_email":
                    load_default_view();
                    break;
                case "find_password_using_username":
                    load_default_view();
                    break;
                case "find_phonenumber_using_email":
                    load_default_view();
                    break;
                case "find_phonenumber_using_phonenumber":
                    load_default_view();
                    break;
                case "find_phonenumber_using_username":
                    load_default_view();
                    break;
                case "find_user_location_using_email":
                    load_default_view();
                    break;
                case "find_user_location_using_username":
                    load_default_view();
                    break;
                case "find_username_password":
                    load_default_view();
                    break;
                case "find_username_using_email":
                    load_default_view();
                    break;
                case "find_username_using_username":
                    load_default_view();
                    break;

                case "insert_text_file_using_username":
                    load_default_view();
                    break;
                case "insert_user":
                    load_default_view();
                    break;
                case "insert_user_audio_file_using_username":
                    load_default_view();
                    break;
                case "insert_user_text_file_using_username":
                    load_default_view();
                    break;
                case "update_email_using_email":
                    load_default_view();
                    break;
                case "update_email_using_username":
                    load_default_view();
                    break;
                case "update_password_using_email":
                    load_default_view();
                    break;
                case "update_password_using_phonenumber":
                    load_default_view();
                    break;
                case "update_password_using_username":
                    load_default_view();
                    break;
                case "update_phonenumber_using_email":
                    load_default_view();
                    break;
                case "update_phonenumber_using_username":
                    load_default_view();
                    break;
                case "update_user_location_using_email":
                    load_default_view();
                    break;
                case "update_user_location_using_name":
                    load_default_view();
                    break;
                case "update_user_location_using_phonenumber":
                    load_default_view();
                    break;
                case "update_user_location_using_username":
                    load_default_view();
                    break;
                case "update_username_using_email":
                    load_default_view();
                    break;
                case "update_username_using_phonenumber":
                    load_default_view();
                    break;
                case "update_username_using_username":
                    load_default_view();
                    break;
                case "user_login":
                    load_default_view();
                    break;
                case "view_all_emails":
                    load_default_view();
                    break;
                case "view_all_passwords":
                    load_default_view();
                    break;
                case "view_all_phonenumber":
                    load_default_view();
                    break;
                case "view_all_username":
                    load_default_view();
                    break;
                case "view_user_table":
                    load_default_view();
                    break;

            }
        }
        private async Task load_Selection01()
        {

            string key = stored_procedure_array[int.Parse(User_View_M01.SelectedProject) - 1].Trim();
            load_Selection_data01();
            if (_commands.TryGetValue(key, out Func<Task> action))
            {
                await action();
                _commands.Clear();
            }
            else
            {
                User_View_M01.StatusMessage01 = $"{key} command not found";
            }

        }

        public async Task<IActionResult> OnPostOk()
        {
            LoadOptions();
            if (!Security_Serv01.isPicker_selected_web(
                User_View_M01.SelectedProject, stored_procedure_array, out data01[1]))
            {
                User_View_M01.StatusMessage01 = data01[1];
                return Page();
            }

            Picker01_SelectedIndexChanged();
            await load_Selection01();
            LoadOptions();
            return Page(); ;
        }
        public IActionResult OnPostBack()
        {
            return RedirectToPage("/USER_VIEW/USER_MAIN_VIEW/User_Main_View01");
        }
    }
}
