using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using EASY_CALLENDER01.MODEL.WEB_MODEL.USER_VIEW_MODEL;
using EASYPROJECT01.EASY_CALLENDER01.SERVICES.SECURITY_SERVICES;
using EASYPROJECT01.EASY_CALLENDER01.SERVICES.SQL.SQL_SERVICES.SQL_USER_SERVICES;
using EASYPROJECT01.EASY_CALLENDER01.SERVICES.LOCATION.LOCATION_HELPER;

namespace EASYPROJECT01.EASY_WEBB.Pages.USER_VIEW.USER_SELECTION_VIEW

{
    public class User_Selection_View01 : PageModel
    {
        [BindProperty]
        public User_View_Model01 User_View_M01 { get; set; } = new User_View_Model01();
        private static string[] data01 = new string[100];
        private static Security_Services01 Security_S01 = new Security_Services01();
        private static Sql_Services01 Sql_Serv01 = new Sql_Services01();
        private static Location_Helper01 Location_H01 = new Location_Helper01();

        public void OnGet()
        {
            LoadOptions();
            load_picker();
        }
        public IActionResult OnPost()
        {
            LoadOptions();
            load_picker();
            return Page();
        }
        private string load_Selection_View_String()
        {
            int count = 0;
            string stored = string.Empty;
            if (Sql_Serv01.view_user_database_storedprocedures(out data01[20]) == true)
            {
                foreach (var a in data01[20].Split("\n"))
                {
                    count++;
                    stored += $"{count}.) {a}\n";
                }
                return $"{stored}{count}";


            }
            else
            {
                return data01[20];
            }
        }

        private void LoadOptions()
        {
            string[] array01 = load_Selection_View_String().Split("\n");
            User_View_M01.ProjectOptions = new List<SelectListItem>();
            for (int i = 0; i < array01.Length; i++)
            {
                User_View_M01.ProjectOptions.Add(
                    new SelectListItem
                    {
                        Value = (i + 1).ToString(),
                        Text = array01[i].Trim()
                    });
            }
        }


        private void load_picker()
        {
            switch (User_View_M01.SelectedProject)
            {

                case "1":
                    User_View_M01.label01 = "username";
                    User_View_M01.ShowInput01 = true;
                    User_View_M01.ShowInput02 = false;
                    User_View_M01.ShowInput03 = false;
                    User_View_M01.ShowInput04 = false;
                    User_View_M01.ShowInput05 = false;
                    User_View_M01.ShowInput06 = false;
                    User_View_M01.ShowInput07 = false;
                    break;
                case "2":
                    User_View_M01.label01 = "emailaddress";
                    User_View_M01.ShowInput01 = true;
                    User_View_M01.ShowInput02 = false;
                    User_View_M01.ShowInput03 = false;
                    User_View_M01.ShowInput04 = false;
                    User_View_M01.ShowInput05 = false;
                    User_View_M01.ShowInput06 = false;
                    User_View_M01.ShowInput07 = false;
                    break;
                case "3":
                    User_View_M01.label01 = "username";
                    User_View_M01.ShowInput01 = true;
                    User_View_M01.ShowInput02 = false;
                    User_View_M01.ShowInput03 = false;
                    User_View_M01.ShowInput04 = false;
                    User_View_M01.ShowInput05 = false;
                    User_View_M01.ShowInput06 = false;
                    User_View_M01.ShowInput07 = false;
                    break;
                case "4":
                    User_View_M01.label01 = "emailaddress";
                    User_View_M01.ShowInput01 = true;
                    User_View_M01.ShowInput02 = false;
                    User_View_M01.ShowInput03 = false;
                    User_View_M01.ShowInput04 = false;
                    User_View_M01.ShowInput05 = false;
                    User_View_M01.ShowInput06 = false;
                    User_View_M01.ShowInput07 = false;
                    break;
                case "5":
                    User_View_M01.label01 = "username";
                    User_View_M01.ShowInput01 = true;
                    User_View_M01.ShowInput02 = false;
                    User_View_M01.ShowInput03 = false;
                    User_View_M01.ShowInput04 = false;
                    User_View_M01.ShowInput05 = false;
                    User_View_M01.ShowInput06 = false;
                    User_View_M01.ShowInput07 = false;
                    break;
                case "6":
                    User_View_M01.label01 = "emailaddress";
                    User_View_M01.ShowInput01 = true;
                    User_View_M01.ShowInput02 = false;
                    User_View_M01.ShowInput03 = false;
                    User_View_M01.ShowInput04 = false;
                    User_View_M01.ShowInput05 = false;
                    User_View_M01.ShowInput06 = false;
                    User_View_M01.ShowInput07 = false;
                    break;
                case "7":
                    User_View_M01.label01 = "emailaddress";
                    User_View_M01.ShowInput01 = true;
                    User_View_M01.ShowInput02 = false;
                    User_View_M01.ShowInput03 = false;
                    User_View_M01.ShowInput04 = false;
                    User_View_M01.ShowInput05 = false;
                    User_View_M01.ShowInput06 = false;
                    User_View_M01.ShowInput07 = false;
                    break;
                case "8":
                    User_View_M01.label01 = "username";
                    User_View_M01.ShowInput01 = true;
                    User_View_M01.ShowInput02 = false;
                    User_View_M01.ShowInput03 = false;
                    User_View_M01.ShowInput04 = false;
                    User_View_M01.ShowInput05 = false;
                    User_View_M01.ShowInput06 = false;
                    User_View_M01.ShowInput07 = false;
                    break;
                case "9":
                    User_View_M01.label01 = "emailaddress";
                    User_View_M01.ShowInput01 = true;
                    User_View_M01.ShowInput02 = false;
                    User_View_M01.ShowInput03 = false;
                    User_View_M01.ShowInput04 = false;
                    User_View_M01.ShowInput05 = false;
                    User_View_M01.ShowInput06 = false;
                    User_View_M01.ShowInput07 = false;
                    break;
                case "10":
                    User_View_M01.label01 = "username";
                    User_View_M01.ShowInput01 = true;
                    User_View_M01.ShowInput02 = false;
                    User_View_M01.ShowInput03 = false;
                    User_View_M01.ShowInput04 = false;
                    User_View_M01.ShowInput05 = false;
                    User_View_M01.ShowInput06 = false;
                    User_View_M01.ShowInput07 = false;
                    break;
                case "11":
                    User_View_M01.label01 = "username";
                    User_View_M01.ShowInput01 = true;
                    User_View_M01.ShowInput02 = false;
                    User_View_M01.ShowInput03 = false;
                    User_View_M01.ShowInput04 = false;
                    User_View_M01.ShowInput05 = false;
                    User_View_M01.ShowInput06 = false;
                    User_View_M01.ShowInput07 = false;
                    break;
                case "12":
                    User_View_M01.label01 = "emailaddress";
                    User_View_M01.ShowInput01 = true;
                    User_View_M01.ShowInput02 = false;
                    User_View_M01.ShowInput03 = false;
                    User_View_M01.ShowInput04 = false;
                    User_View_M01.ShowInput05 = false;
                    User_View_M01.ShowInput06 = false;
                    User_View_M01.ShowInput07 = false;
                    break;
                case "13":
                    User_View_M01.label01 = "username";
                    User_View_M01.ShowInput01 = true;
                    User_View_M01.ShowInput02 = false;
                    User_View_M01.ShowInput03 = false;
                    User_View_M01.ShowInput04 = false;
                    User_View_M01.ShowInput05 = false;
                    User_View_M01.ShowInput06 = false;
                    User_View_M01.ShowInput07 = false;
                    break;
                case "14":
                    User_View_M01.label01 = "username";
                    User_View_M01.ShowInput01 = true;
                    User_View_M01.ShowInput02 = false;
                    User_View_M01.ShowInput03 = false;
                    User_View_M01.ShowInput04 = false;
                    User_View_M01.ShowInput05 = false;
                    User_View_M01.ShowInput06 = false;
                    User_View_M01.ShowInput07 = false;
                    break;
                case "15":
                    User_View_M01.label01 = "needs work";
                    User_View_M01.ShowInput01 = true;
                    User_View_M01.ShowInput02 = false;
                    User_View_M01.ShowInput03 = false;
                    User_View_M01.ShowInput04 = false;
                    User_View_M01.ShowInput05 = false;
                    User_View_M01.ShowInput06 = false;
                    User_View_M01.ShowInput07 = false;
                    break;
                case "16":
                    User_View_M01.label01 = "username";
                    User_View_M01.label02 = "firstname";
                    User_View_M01.label03 = "lastname";
                    User_View_M01.label04 = "email address";
                    User_View_M01.label05 = "phonenumber";
                    User_View_M01.label06 = "password";
                    User_View_M01.label07 = "confirm password";
                    User_View_M01.ShowInput01 = true;
                    User_View_M01.ShowInput02 = true;
                    User_View_M01.ShowInput03 = true;
                    User_View_M01.ShowInput04 = true;
                    User_View_M01.ShowInput05 = true;
                    User_View_M01.ShowInput06 = true;
                    User_View_M01.ShowInput07 = true;
                    User_View_M01.ShowInput08 = true;
                    break;
                default:
                    User_View_M01.label01 = string.Empty;
                    User_View_M01.label02 = string.Empty;
                    User_View_M01.label03 = string.Empty;
                    User_View_M01.label04 = string.Empty;
                    User_View_M01.label05 = string.Empty;
                    User_View_M01.label06 = string.Empty;
                    User_View_M01.label06 = string.Empty;
                    User_View_M01.label07 = string.Empty;
                    User_View_M01.ShowInput01 = false;
                    User_View_M01.ShowInput02 = false;
                    User_View_M01.ShowInput03 = false;
                    User_View_M01.ShowInput04 = false;
                    User_View_M01.ShowInput05 = false;
                    User_View_M01.ShowInput06 = false;
                    User_View_M01.ShowInput07 = false;
                    User_View_M01.ShowInput08 = false;
                    User_View_M01.StatusMessage01 = string.Empty;
                    User_View_M01.StatusMessage02 = string.Empty;
                    User_View_M01.StatusMessage03 = string.Empty;
                    User_View_M01.StatusMessage04 = string.Empty;
                    User_View_M01.StatusMessage05 = string.Empty;
                    User_View_M01.StatusMessage06 = string.Empty;
                    User_View_M01.StatusMessage07 = string.Empty;
                    break;
            }
        }

        private void Page_Check()
        {
            string the_date = string.Empty;
            int user_option = 0;
            int counter = 0;
            if (string.IsNullOrEmpty(User_View_M01.SelectedProject) == false)
            {
                switch (User_View_M01.SelectedProject)
                {
                    case "1":
                        if (Security_S01.empty_string(User_View_M01.input01, out data01[23]) == true)
                        {
                            if (Sql_Serv01.delete_user_using_username(User_View_M01.input01, out data01[25]) == true)
                            {

                                User_View_M01.StatusMessage01 = data01[25];
                            }
                            else
                            {
                                User_View_M01.StatusMessage01 = data01[25];
                            }

                        }
                        else
                        {
                            User_View_M01.StatusMessage01 = data01[23];
                        }
                        break;

                    case "2":
                        if (Security_S01.empty_string(User_View_M01.input01, out data01[23]) == true)
                        {
                            if (Security_S01.email_check(User_View_M01.input01, out data01[24]) == true)
                            {
                                if (Sql_Serv01.find_email_using_email(User_View_M01.input01, out data01[25]) == true)
                                {

                                    User_View_M01.StatusMessage01 = data01[25];
                                }
                                else
                                {
                                    User_View_M01.StatusMessage01 = data01[25];
                                }
                            }
                            else
                            {
                                User_View_M01.StatusMessage01 = data01[24];
                            }


                        }
                        else
                        {
                            User_View_M01.StatusMessage01 = data01[23];
                        }
                        break;
                    case "3":
                        if (Security_S01.empty_string(User_View_M01.input01, out data01[23]) == true)
                        {
                            if (Sql_Serv01.find_email_using_username(User_View_M01.input01, out data01[25]) == true)
                            {

                                User_View_M01.StatusMessage01 = data01[25];
                            }
                            else
                            {
                                User_View_M01.StatusMessage01 = data01[25];
                            }

                        }
                        else
                        {
                            User_View_M01.StatusMessage01 = data01[23];
                        }
                        break;
                    case "4":
                        if (Security_S01.empty_string(User_View_M01.input01, out data01[23]) == true)
                        {
                            if (Security_S01.email_check(User_View_M01.input01, out data01[24]) == true)
                            {

                                if (Sql_Serv01.find_password_using_email(User_View_M01.input01, out data01[25]) == true)
                                {

                                    User_View_M01.StatusMessage01 = data01[25];
                                }
                                else
                                {
                                    User_View_M01.StatusMessage01 = data01[25];
                                }
                            }
                            else
                            {
                                User_View_M01.StatusMessage01 = data01[24];
                            }

                        }
                        else
                        {
                            User_View_M01.StatusMessage01 = data01[23];
                        }
                        break;
                    case "5":
                        if (Security_S01.empty_string(User_View_M01.input01, out data01[23]) == true)
                        {
                            if (Sql_Serv01.find_password_using_username(User_View_M01.input01, out data01[25]) == true)
                            {

                                User_View_M01.StatusMessage01 = data01[25];
                            }
                            else
                            {
                                User_View_M01.StatusMessage01 = data01[25];
                            }

                        }
                        else
                        {
                            User_View_M01.StatusMessage01 = data01[23];
                        }
                        break;
                    case "6":
                        if (Security_S01.empty_string(User_View_M01.input01, out data01[23]) == true)
                        {
                            if (Security_S01.email_check(User_View_M01.input01, out data01[24]) == true)
                            {
                                if (Sql_Serv01.find_phonenumber_using_email(User_View_M01.input01, out data01[25]) == true)
                                {

                                    User_View_M01.StatusMessage01 = data01[25];
                                }
                                else
                                {
                                    User_View_M01.StatusMessage01 = data01[25];
                                }
                            }
                            else
                            {
                                User_View_M01.StatusMessage01 = data01[24];
                            }

                        }
                        else
                        {
                            User_View_M01.StatusMessage01 = data01[23];
                        }
                        break;
                    case "7":
                        if (Security_S01.empty_string(User_View_M01.input01, out data01[23]) == true)
                        {
                            if (Security_S01.phone_check(User_View_M01.input01, out data01[24]) == true)
                            {
                                if (Sql_Serv01.find_phonenumber_using_phonenumber(User_View_M01.input01, out data01[25]) == true)
                                {

                                    User_View_M01.StatusMessage01 = data01[25];
                                }
                                else
                                {
                                    User_View_M01.StatusMessage01 = data01[25];
                                }
                            }
                            else
                            {
                                User_View_M01.StatusMessage01 = data01[24];
                            }

                        }
                        else
                        {
                            User_View_M01.StatusMessage01 = data01[23];
                        }
                        break;
                    case "8":
                        if (Security_S01.empty_string(User_View_M01.input01, out data01[23]) == true)
                        {
                            if (Sql_Serv01.find_phonenumber_using_username(User_View_M01.input01, out data01[25]) == true)
                            {

                                User_View_M01.StatusMessage01 = data01[25];
                            }
                            else
                            {
                                User_View_M01.StatusMessage01 = data01[25];
                            }

                        }
                        else
                        {
                            User_View_M01.StatusMessage01 = data01[23];
                        }
                        break;
                    case "9":
                        if (Security_S01.empty_string(User_View_M01.input01, out data01[23]) == true)
                        {
                            if (Security_S01.email_check(User_View_M01.input01, out data01[24]) == true)
                            {
                                if (Sql_Serv01.find_user_location_using_email(User_View_M01.input01, out data01[25]) == true)
                                {

                                    User_View_M01.StatusMessage01 = data01[25];
                                }
                                else
                                {
                                    User_View_M01.StatusMessage01 = data01[25];
                                }
                            }
                            else
                            {
                                User_View_M01.StatusMessage01 = data01[24];
                            }

                        }
                        else
                        {
                            User_View_M01.StatusMessage01 = data01[23];
                        }
                        break;
                    case "10":
                        if (Security_S01.empty_string(User_View_M01.input01, out data01[23]) == true)
                        {
                            if (Sql_Serv01.find_user_location_using_username(User_View_M01.input01, out data01[25]) == true)
                            {

                                User_View_M01.StatusMessage01 = data01[25];
                            }
                            else
                            {
                                User_View_M01.StatusMessage01 = data01[25];
                            }

                        }
                        else
                        {
                            User_View_M01.StatusMessage01 = data01[23];
                        }
                        break;
                    case "11":
                        if (Security_S01.empty_string(User_View_M01.input01, out data01[23]) == true)
                        {
                            if (Sql_Serv01.find_username_password(User_View_M01.input01, out data01[25]) == true)
                            {

                                User_View_M01.StatusMessage01 = data01[25];
                            }
                            else
                            {
                                User_View_M01.StatusMessage01 = data01[25];
                            }

                        }
                        else
                        {
                            User_View_M01.StatusMessage01 = data01[23];
                        }
                        break;
                    case "12":
                        if (Security_S01.empty_string(User_View_M01.input01, out data01[23]) == true)
                        {
                            if (Security_S01.email_check(User_View_M01.input01, out data01[24]) == true)
                            {
                                if (Sql_Serv01.find_username_using_email(User_View_M01.input01, out data01[25]) == true)
                                {

                                    User_View_M01.StatusMessage01 = data01[25];
                                }
                                else
                                {
                                    User_View_M01.StatusMessage01 = data01[25];
                                }
                            }
                            else
                            {
                                User_View_M01.StatusMessage01 = data01[24];
                            }

                        }
                        else
                        {
                            User_View_M01.StatusMessage01 = data01[23];
                        }
                        break;
                    case "13":
                        if (Security_S01.empty_string(User_View_M01.input01, out data01[23]) == true)
                        {
                            if (Sql_Serv01.find_username_using_username(User_View_M01.input01, out data01[25]) == true)
                            {

                                User_View_M01.StatusMessage01 = data01[25];
                            }
                            else
                            {
                                User_View_M01.StatusMessage01 = data01[25];
                            }

                        }
                        else
                        {
                            User_View_M01.StatusMessage01 = data01[23];
                        }
                        break;
                    case "14":
                        if (Security_S01.empty_string(User_View_M01.input01, out data01[23]) == true)
                        {
                            if (Sql_Serv01.find_username_using_username(User_View_M01.input01, out data01[25]) == true)
                            {

                                User_View_M01.StatusMessage01 = data01[25];
                            }
                            else
                            {
                                User_View_M01.StatusMessage01 = data01[24];
                            }

                        }
                        else
                        {
                            User_View_M01.StatusMessage01 = data01[23];
                        }
                        break;
                    case "15":
                        if (Security_S01.empty_string(User_View_M01.input01, out data01[25]) == true)
                        {

                            User_View_M01.StatusMessage01 = data01[25];
                        }
                        else
                        {
                            User_View_M01.StatusMessage01 = data01[25];
                        }
                        break;
                    case "16":
                        if (Security_S01.empty_string(User_View_M01.input01, out data01[25]) == true)
                        {

                            counter++;
                            User_View_M01.StatusMessage01 = data01[25];
                        }
                        else
                        {
                            counter--;
                            User_View_M01.StatusMessage01 = data01[25];
                        }
                        if (Security_S01.empty_string(User_View_M01.input02, out data01[25]) == true)
                        {

                            counter++;
                            User_View_M01.StatusMessage02 = data01[25];
                        }
                        else
                        {
                            counter--;
                            User_View_M01.StatusMessage02 = data01[25];
                        }
                        if (Security_S01.empty_string(User_View_M01.input04, out data01[23]) == true)
                        {
                            if (Security_S01.email_check(User_View_M01.input04, out data01[24]) == true)
                            {
                                counter++;
                                User_View_M01.StatusMessage05 = data01[24];
                            }
                            else
                            {
                                counter--;
                                User_View_M01.StatusMessage05 = data01[24];
                            }
                        }
                        else
                        {
                            counter--;
                            User_View_M01.StatusMessage05 = data01[23];
                        }

                        if (User_View_M01.SelectedDate.HasValue)
                        {
                            the_date = User_View_M01.SelectedDate.Value.ToString("yyyy-MM-dd").Trim();
                            if (Security_S01.age_check(the_date, out data01[24]) == true)
                            {

                                counter++;
                                User_View_M01.StatusMessage04 = data01[24];
                            }
                            else
                            {
                                counter--;
                                User_View_M01.StatusMessage04 = data01[24];
                            }
                        }
                        else
                        {
                            counter--;
                            User_View_M01.StatusMessage04 = "please select a date";
                        }
                        if (Security_S01.empty_string(User_View_M01.input05, out data01[23]) == true)
                        {
                            if (Security_S01.phone_check(User_View_M01.input05, out data01[24]) == true)
                            {

                                counter++;
                                User_View_M01.StatusMessage06 = data01[24];
                            }
                            else
                            {
                                counter--;
                                User_View_M01.StatusMessage06 = data01[24];
                            }
                        }
                        else
                        {
                            counter--;
                            User_View_M01.StatusMessage06 = data01[23];
                        }
                        if (Security_S01.empty_string(User_View_M01.input06, out data01[23]) == true)
                        {
                            if (Security_S01.password_check(User_View_M01.input06, out data01[24]) == true)
                            {

                                counter++;
                                User_View_M01.StatusMessage07 = data01[24];
                            }
                            else
                            {
                                counter--;
                                User_View_M01.StatusMessage07 = data01[24];
                            }
                        }
                        else
                        {
                            counter--;
                            User_View_M01.StatusMessage06 = data01[23];
                        }
                        if (User_View_M01.input06 == User_View_M01.input07)
                        {
                            counter++;
                        }
                        else
                        {
                            counter--;

                            User_View_M01.StatusMessage08 = "password does not match";
                        }

                        if (counter == 7)
                        {
                            if (Sql_Serv01.insert_user(User_View_M01.input01,
                                                       User_View_M01.input02,
                                                       User_View_M01.input03,
                                                       the_date,
                                                       User_View_M01.input04,
                                                       User_View_M01.input05,
                                                       User_View_M01.input06,
                                                       out data01[23]) == true)
                            {
                                User_View_M01.StatusMessage08 = data01[23];
                            }
                            else
                            {
                                User_View_M01.StatusMessage08 = data01[23];
                            }

                        }
                        else
                        {
                            User_View_M01.StatusMessage08 += "please fix errors";
                        }
                        break;
                }
            }
            else
            {
                User_View_M01.StatusMessage01 = "please select an option";
            }
        }
        public IActionResult OnPostOk()
        {
            Page_Check();
            LoadOptions();
            load_picker();
            return Page();
        }
        public IActionResult OnPostBack()
        {
            return RedirectToPage("/USER_VIEW/USER_MAIN_VIEW/User_Main_View01");
        }
    }
}
