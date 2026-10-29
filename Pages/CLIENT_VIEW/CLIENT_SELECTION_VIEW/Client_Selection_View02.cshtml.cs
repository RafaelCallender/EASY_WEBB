using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using EASYPROJECT01.EASY_CALLENDER01.MODEL.WEB_MODEL.CLIENT_VIEW_MODEL;
using EASYPROJECT01.EASY_CALLENDER01.SERVICES.SECURITY_SERVICES;
using EASYPROJECT01.EASY_CALLENDER01.SERVICES.MYSQL.MYSQL_SERVICES.MYSQL_CLIENTS_SERVICES;

namespace EASYPROJECT01.EASY_WEBB.Pages.CLIENT_VIEW.CLIENT_SELECTION_VIEW
{
    public class Client_Selection_View02 : PageModel
    {
        [BindProperty]
        public Client_View_Model01 Client_View_M01 { get; set; } = new Client_View_Model01();
        private static string[] data01 = new string[100];
        private static Security_Services01 Security_Serv01 = new Security_Services01();
        private static MySql_Client_Services01 MySql_Client_S01 = new MySql_Client_Services01();
        private static bool stored_procedure_bool = MySql_Client_S01.view_client_database_storedprocedures(out data01[50]);
        private static string stored_procedure_string = data01[50];
        private static string[] stored_procedure_array = stored_procedure_string.Split("\n");
        private static Dictionary<string, Action> _commands = new Dictionary<string, Action>(StringComparer.OrdinalIgnoreCase);
        private int counter01 = 0;
        public void OnGet()
        {
            OnPost();
            if (stored_procedure_bool == true)
            {
                load_default_view();
            }
            else
            {
                load_default_view01();
                Client_View_M01.StatusMessage01 = stored_procedure_string;
            }
        }
        private void load_Selection_data01()
        {
            string procedure = stored_procedure_array[int.Parse(Client_View_M01.SelectedProject)].Trim();
            switch (stored_procedure_array[int.Parse(Client_View_M01.SelectedProject)])
            {
                case "delete_client_using_name":
                    _commands.Add(procedure, delete_client_using_name);
                    break;
                case "delete_client_using_phonenumber":
                    _commands.Add(procedure, delete_client_using_phonenumber);
                    break;
                case "find_client_api_key_by_emailaddress":
                    _commands.
                    Add(procedure, find_client_api_key_by_emailaddress);
                    break;
                case "find_client_api_key_by_name":
                    _commands.Add(procedure, find_client_api_key_by_name);
                    break;
                case "find_client_api_key_by_phonnumeber":
                    _commands.Add(procedure, find_client_api_key_by_phonnumeber);
                    break;
                case "find_client_apikey_by_apikey":
                    _commands.Add(procedure, find_client_apikey_by_apikey);
                    break;
                case "find_client_apikey_by_cashappdata01":
                    _commands.Add(procedure, find_client_apikey_by_cashappdata01);
                    break;
                case "find_client_apikey_by_venmoappdata01":
                    _commands.Add(procedure, find_client_apikey_by_venmoappdata01);
                    break;
                case "find_client_cashappdata01_by_apikey":
                    _commands.Add(procedure, find_client_cashappdata01_by_apikey);
                    break;
                case "find_client_cashappdata01_by_cashappdata01":
                    _commands.Add(procedure, find_client_cashappdata01_by_cashappdata01);
                    break;
                case "find_client_cashappdata01_by_emailaddress":
                    _commands.Add(procedure, find_client_cashappdata01_by_emailaddress);
                    break;
                case "find_client_cashappdata01_by_name":
                    _commands.Add(procedure, find_client_cashappdata01_by_name);
                    break;
                case "find_client_cashappdata01_by_paypalappdata01":
                    _commands.Add(procedure, find_client_cashappdata01_by_paypalappdata01);
                    break;
                case "find_client_cashappdata01_by_phonnumeber":
                    _commands.Add(procedure, find_client_cashappdata01_by_phonnumeber);
                    break;
                case "find_client_cashappdata01_by_venmoappdata01":
                    _commands.Add(procedure, find_client_cashappdata01_by_venmoappdata01);
                    break;
                case "find_client_colors_using_emailaddress":
                    _commands.Add(procedure, find_client_colors_using_emailaddress);
                    break;
                case "find_client_colors_using_name":
                    _commands.Add(procedure, find_client_colors_using_name);
                    break;
                case "find_client_colors_using_phonenumber":
                    _commands.Add(procedure, find_client_colors_using_phonenumber);
                    break;
                case "find_client_data_using_email":
                    _commands.Add(procedure, find_client_data_using_email);
                    break;
                case "find_client_data_using_latitude_and_longitude":
                    _commands.Add(procedure, find_client_data_using_latitude_and_longitude);
                    break;
                case "find_client_data_using_logo":
                    _commands.Add(procedure, find_client_data_using_logo);
                    break;
                case "find_client_data_using_name":
                    _commands.Add(procedure, find_client_data_using_name);
                    break;
                case "find_client_data_using_number":
                    _commands.Add(procedure, find_client_data_using_number);
                    break;
                case "find_client_emailaddress_by_apikey":
                    _commands.Add(procedure, find_client_emailaddress_by_apikey);
                    break;
                case "find_client_emailaddress_by_cashappdata01":
                    _commands.Add(procedure, find_client_emailaddress_by_cashappdata01);
                    break;
                case "find_client_emailaddress_by_emailaddress":
                    _commands.Add(procedure, find_client_emailaddress_by_emailaddress);
                    break;
                case "find_client_emailaddress_by_name":
                    _commands.Add(procedure, find_client_emailaddress_by_name);
                    break;
                case "find_client_emailaddress_by_paypalappdata01":
                    _commands.Add(procedure, find_client_emailaddress_by_paypalappdata01);
                    break;
                case "find_client_emailaddress_by_phonnumeber":
                    _commands.Add(procedure, find_client_emailaddress_by_phonnumeber);
                    break;
                case "find_client_emailaddress_by_venmoappdata01":
                    _commands.Add(procedure, find_client_emailaddress_by_venmoappdata01);
                    break;
                case "find_client_location_using_emailaddress":
                    _commands.Add(procedure, find_client_location_using_emailaddress);
                    break;
                case "find_client_location_using_name":
                    _commands.Add(procedure, find_client_location_using_name);
                    break;
                case "find_client_location_using_phonenumber":
                    _commands.Add(procedure, find_client_location_using_phonenumber);
                    break;
                case "find_client_logo_by_emailaddress":
                    _commands.Add(procedure, find_client_logo_by_emailaddress);
                    break;
                case "find_client_logo_by_logo":
                    _commands.Add(procedure, find_client_logo_by_logo);
                    break;
                case "find_client_logo_by_name":
                    _commands.Add(procedure, find_client_logo_by_name);
                    break;
                case "find_client_logo_by_phonenumber":
                    _commands.Add(procedure, find_client_logo_by_phonenumber);
                    break;
                case "find_client_name_by_cashappdata01":
                    _commands.Add(procedure, find_client_name_by_cashappdata01);
                    break;
                case "find_client_name_by_emailaddress":
                    _commands.Add(procedure, find_client_name_by_emailaddress);
                    break;
                case "find_client_name_by_name":
                    _commands.Add(procedure, find_client_name_by_name);
                    break;
                case "find_client_name_by_paypalappdata01":
                    _commands.Add(procedure, find_client_name_by_paypalappdata01);
                    break;
                case "find_client_name_by_phonnumeber":
                    _commands.Add(procedure, find_client_name_by_phonnumeber);
                    break;
                case "find_client_name_by_venmoappdata01":
                    _commands.Add(procedure, find_client_name_by_venmoappdata01);
                    break;
                case "find_client_paypalappdata01_by_apikey":
                    _commands.Add(procedure, find_client_paypalappdata01_by_apikey);
                    break;
                case "find_client_paypalappdata01_by_cashappdata01":
                    _commands.Add(procedure, find_client_paypalappdata01_by_cashappdata01);
                    break;
                case "find_client_paypalappdata01_by_emailaddress":
                    _commands.Add(procedure, find_client_paypalappdata01_by_emailaddress);
                    break;
                case "find_client_paypalappdata01_by_name":
                    _commands.Add(procedure, find_client_paypalappdata01_by_name);
                    break;
                case "find_client_paypalappdata01_by_paypalappdata01":
                    _commands.Add(procedure, find_client_paypalappdata01_by_paypalappdata01);
                    break;
                case "find_client_paypalappdata01_by_phonnumeber":
                    _commands.Add(procedure, find_client_paypalappdata01_by_phonnumeber);
                    break;
                case "find_client_paypalappdata01_by_venmoappdata01":
                    _commands.Add(procedure, find_client_paypalappdata01_by_venmoappdata01);
                    break;
                case "find_client_phonenumber_by_apikey":
                    _commands.Add(procedure, find_client_phonenumber_by_apikey);
                    break;
                case "find_client_phonenumber_by_cashappdata01":
                    _commands.Add(procedure, find_client_phonenumber_by_cashappdata01);
                    break;
                case "find_client_phonenumber_by_emailaddress":
                    _commands.Add(procedure, find_client_phonenumber_by_emailaddress);
                    break;
                case "find_client_phonenumber_by_name":
                    _commands.Add(procedure, find_client_phonenumber_by_name);
                    break;
                case "find_client_phonenumber_by_paypalappdata01":
                    _commands.Add(procedure, find_client_phonenumber_by_paypalappdata01);
                    break;
                case "find_client_phonenumber_by_phonnumeber":
                    _commands.Add(procedure, find_client_phonenumber_by_phonnumeber);
                    break;
                case "find_client_phonenumber_by_venmoappdata01":
                    _commands.Add(procedure, find_client_phonenumber_by_venmoappdata01);
                    break;
                case "find_client_venmoappdata01_by_apikey":
                    _commands.Add(procedure, find_client_venmoappdata01_by_apikey);
                    break;
                case "find_client_venmoappdata01_by_cashappdata01":
                    _commands.Add(procedure, find_client_venmoappdata01_by_cashappdata01);
                    break;
                case "find_client_venmoappdata01_by_emailaddress":
                    _commands.Add(procedure, find_client_venmoappdata01_by_emailaddress);
                    break;
                case "find_client_venmoappdata01_by_name":
                    _commands.Add(procedure, find_client_venmoappdata01_by_name);
                    break;
                case "find_client_venmoappdata01_by_paypalappdata01":
                    _commands.Add(procedure, find_client_venmoappdata01_by_paypalappdata01);
                    break;
                case "find_client_venmoappdata01_by_phonnumeber":
                    _commands.Add(procedure, find_client_venmoappdata01_by_phonnumeber);
                    break;
                case "find_client_venmoappdata01_by_venmoappdata01":
                    _commands.Add(procedure, find_client_venmoappdata01_by_venmoappdata01);
                    break;
                case "find_client_zellaappdata01_by_apikey":
                    _commands.Add(procedure, find_client_zellaappdata01_by_apikey);
                    break;
                case "find_client_zellaappdata01_by_zellaappdata01":
                    _commands.Add(procedure, find_client_zellaappdata01_by_zellaappdata01);
                    break;
                case "find_client_zelleappdata01_by_cashappdata01":
                    _commands.Add(procedure, find_client_zelleappdata01_by_cashappdata01);
                    break;
                case "find_client_zelleappdata01_by_emailaddress":
                    _commands.Add(procedure, find_client_zelleappdata01_by_emailaddress);
                    break;
                case "find_client_zelleappdata01_by_name":
                    _commands.Add(procedure, find_client_zelleappdata01_by_name);
                    break;
                case "find_client_zelleappdata01_by_phonnumeber":
                    _commands.Add(procedure, find_client_zelleappdata01_by_phonnumeber);
                    break;
                case "find_client_zelleappdata01_by_venmoappdata01":
                    _commands.Add(procedure, find_client_zelleappdata01_by_venmoappdata01);
                    break;
                case "insert_client_data":
                    _commands.Add(procedure, insert_client_data);
                    break;
                case "update_clients_apikey_using_apikey":
                    _commands.Add(procedure, update_clients_apikey_using_apikey);
                    break;
                case "update_clients_cashappdata01_using_cashappdata01":
                    _commands.Add(procedure, update_clients_cashappdata01_using_cashappdata01);
                    break;
                case "update_clients_email_using_email":
                    _commands.Add(procedure, update_clients_email_using_email);
                    break;
                case "update_clients_logo_using_logo":
                    _commands.Add(procedure, update_clients_logo_using_logo);
                    break;
                case "update_clients_name_using_name":
                    _commands.Add(procedure, update_clients_name_using_name);
                    break;
                case "update_clients_paypalappdata01_using_paypalappdata01":
                    _commands.Add(procedure, update_clients_paypalappdata01_using_paypalappdata01);
                    break;
                case "update_clients_phnenumber_using_phonenumbe":
                    _commands.Add(procedure, update_clients_phnenumber_using_phonenumber);
                    break;
                case "update_clients_venmoappdata01_using_venmoappdata01":
                    _commands.Add(procedure, update_clients_venmoappdata01_using_venmoappdata01);
                    break;
                case "update_clients_zelleappdata01_using_zellappdata01":
                    _commands.Add(procedure, update_clients_zelleappdata01_using_zellappdata01);
                    break;
                case "view_all_client_data":
                    _commands.Add(procedure, view_all_client_data);
                    break;
            }
        }




        public IActionResult OnPost()
        {
            Client_View_M01.ShowInput01 =
    !string.IsNullOrEmpty(Client_View_M01.SelectedProject);
            LoadOptions();
            Picker01_SelectedIndexChanged();
            return Page();
        }

        private string load_Selection_string()
        {
            string[] res = stored_procedure_string.Split("\n");
            for (int i = 0; i < res.Length; i++)
            {

                data01[60] += $"{i}.) {res[i]}\n";
            }

            return $"{data01[60]}\n client insert auto";
        }


        private void LoadOptions()
        {

            Client_View_M01.ProjectOptions = new List<SelectListItem>();
            for (int i = 0; i < stored_procedure_array.Length; i++)
            {
                Client_View_M01.ProjectOptions.Add(
                    new SelectListItem
                    {
                        Value = (i + 1).ToString(),
                        Text = stored_procedure_array[i].Trim()
                    });
            }
        }
        private void load_default_view()
        {
            Client_View_M01.label01 = string.Empty;
            Client_View_M01.label02 = string.Empty;
            Client_View_M01.label03 = string.Empty;
            Client_View_M01.label04 = string.Empty;
            Client_View_M01.StatusMessage05 = string.Empty;
            Client_View_M01.StatusMessage06 = string.Empty;
            Client_View_M01.StatusMessage07 = string.Empty;
            Client_View_M01.label08 = string.Empty;
            Client_View_M01.label09 = string.Empty;
            Client_View_M01.label10 = string.Empty;
            Client_View_M01.label11 = string.Empty;
            Client_View_M01.label12 = string.Empty;
            Client_View_M01.label13 = string.Empty;
            Client_View_M01.label14 = string.Empty;

            Client_View_M01.ShowInput01 = false;
            Client_View_M01.ShowInput02 = false;
            Client_View_M01.ShowInput03 = false;
            Client_View_M01.ShowInput04 = false;
            Client_View_M01.ShowInput05 = false;
            Client_View_M01.ShowInput06 = false;
            Client_View_M01.ShowInput07 = false;
            Client_View_M01.ShowInput08 = false;
            Client_View_M01.ShowInput09 = false;
            Client_View_M01.ShowInput10 = false;
            Client_View_M01.ShowInput11 = false;
            Client_View_M01.ShowInput12 = false;
            Client_View_M01.ShowInput13 = false;
            Client_View_M01.ShowInput14 = false;
        }
        private void load_default_view01()
        {

            Client_View_M01.ShowInput01 = true;
            Client_View_M01.ShowInput02 = false;
            Client_View_M01.ShowInput03 = false;
            Client_View_M01.ShowInput04 = false;
            Client_View_M01.ShowInput05 = false;
            Client_View_M01.ShowInput06 = false;
            Client_View_M01.ShowInput07 = false;
            Client_View_M01.ShowInput08 = false;
            Client_View_M01.ShowInput09 = false;
            Client_View_M01.ShowInput10 = false;
            Client_View_M01.ShowInput11 = false;
            Client_View_M01.ShowInput12 = false;
            Client_View_M01.ShowInput13 = false;
            Client_View_M01.ShowInput14 = false;

        }
        private void load_default_view02()
        {
            Client_View_M01.ShowInput01 = true;
            Client_View_M01.ShowInput02 = true;
            Client_View_M01.ShowInput03 = false;
            Client_View_M01.ShowInput04 = false;
            Client_View_M01.ShowInput05 = false;
            Client_View_M01.ShowInput06 = false;
            Client_View_M01.ShowInput07 = false;
            Client_View_M01.ShowInput08 = false;
            Client_View_M01.ShowInput09 = false;
            Client_View_M01.ShowInput10 = false;
            Client_View_M01.ShowInput11 = false;
            Client_View_M01.ShowInput12 = false;
            Client_View_M01.ShowInput13 = false;
            Client_View_M01.ShowInput14 = false;

        }
        private void load_default_view03()
        {
            Client_View_M01.label01 = "@client_name";
            Client_View_M01.label02 = "@client_emailaddress";
            Client_View_M01.label03 = "@client_phonenumber";
            Client_View_M01.label04 = "@client_api_key";
            Client_View_M01.StatusMessage05 = "@client_cashappdata01";
            Client_View_M01.StatusMessage06 = "@client_zelleappdata01";
            Client_View_M01.StatusMessage07 = "@client_venmoappdata01";
            Client_View_M01.label08 = "@client_paypalappdata01";
            Client_View_M01.label09 = "@client_logo";
            Client_View_M01.label10 = "@client_primary_color";
            Client_View_M01.label11 = "@client_secondary_color";
            Client_View_M01.label12 = "@client_tertiary_color";
            Client_View_M01.label13 = "@client_social_media";
            Client_View_M01.label14 = "@client_type";
            Client_View_M01.ShowInput01 = true;
            Client_View_M01.ShowInput02 = true;
            Client_View_M01.ShowInput03 = true;
            Client_View_M01.ShowInput04 = true;
            Client_View_M01.ShowInput05 = true;
            Client_View_M01.ShowInput06 = true;
            Client_View_M01.ShowInput07 = true;
            Client_View_M01.ShowInput08 = true;
            Client_View_M01.ShowInput09 = true;
            Client_View_M01.ShowInput10 = true;
            Client_View_M01.ShowInput11 = true;
            Client_View_M01.ShowInput12 = true;
            Client_View_M01.ShowInput13 = true;
            Client_View_M01.ShowInput14 = true;
        }
        private void delete_client_using_email()
        {
            if (Security_Serv01.empty_string(Client_View_M01.input01, out data01[23]) == true)
            {
                if (Security_Serv01.email_check(Client_View_M01.input01, out data01[24]) == true)
                {
                    if (MySql_Client_S01.delete_client_using_email(Client_View_M01.input01, out data01[25]) == true)
                    {

                        Client_View_M01.StatusMessage01 = data01[25];
                    }
                    else
                    {
                        Client_View_M01.StatusMessage01 = data01[25];
                    }
                }
                else
                {
                    Client_View_M01.StatusMessage01 = data01[24];

                }
            }
            else
            {
                Client_View_M01.StatusMessage01 = data01[23];

            }

        }
        private void delete_client_using_name()
        {

            if (Security_Serv01.empty_string(Client_View_M01.input01, out data01[23]) == true)
            {

                if (MySql_Client_S01.delete_client_using_name(Client_View_M01.input01, out data01[25]) == true)
                {
                    Client_View_M01.StatusMessage01 = data01[25];
                }
                else
                {
                    Client_View_M01.StatusMessage01 = data01[25];
                }
            }
            else
            {
                Client_View_M01.StatusMessage01 = data01[24];

            }

        }
        private void delete_client_using_phonenumber()
        {


            if (Security_Serv01.empty_string(Client_View_M01.input01, out data01[23]) == true)
            {
                if (Security_Serv01.phone_check(Client_View_M01.input01, out data01[24]) == true)
                {
                    if (MySql_Client_S01.delete_client_using_phonenumber(Client_View_M01.input01, out data01[25]) == true)
                    {
                        Client_View_M01.StatusMessage01 = data01[25];
                    }
                    else
                    {
                        Client_View_M01.StatusMessage01 = data01[25];
                    }
                }
                else
                {
                    Client_View_M01.StatusMessage01 = data01[24];

                }
            }
            else
            {
                Client_View_M01.StatusMessage01 = data01[23];

            }
        }
        private void find_client_api_key_by_emailaddress()
        {


            if (Security_Serv01.empty_string(Client_View_M01.input01, out data01[23]) == true)
            {
                if (Security_Serv01.email_check(Client_View_M01.input01, out data01[24]) == true)
                {

                    if (MySql_Client_S01.find_client_api_key_by_emailaddress(Client_View_M01.input01, out data01[25]) == true)
                    {
                        Client_View_M01.StatusMessage01 = data01[25];


                    }
                    else
                    {
                        Client_View_M01.StatusMessage01 = data01[25];
                    }
                }
                else
                {
                    Client_View_M01.StatusMessage01 = data01[24];

                }
            }
            else
            {
                Client_View_M01.StatusMessage01 = data01[23];

            }
        }
        private void find_client_api_key_by_name()
        {

            if (Security_Serv01.empty_string(Client_View_M01.input01, out data01[23]) == true)
            {
                if (MySql_Client_S01.find_client_api_key_by_name(Client_View_M01.input01, out data01[25]) == true)
                {
                    Client_View_M01.StatusMessage01 = data01[25];

                }
                else
                {
                    Client_View_M01.StatusMessage01 = data01[25];
                }
            }
            else
            {
                Client_View_M01.StatusMessage01 = data01[23];

            }
        }
        private void find_client_api_key_by_phonnumeber()
        {

            if (Security_Serv01.empty_string(Client_View_M01.input01, out data01[23]) == true)
            {
                if (Security_Serv01.phone_check(Client_View_M01.input01, out data01[24]) == true)
                {

                    if (MySql_Client_S01.find_client_api_key_by_phonnumeber(Client_View_M01.input01, out data01[25]) == true)
                    {
                        Client_View_M01.StatusMessage01 = data01[25];


                    }
                    else
                    {
                        Client_View_M01.StatusMessage01 = data01[25];
                    }
                }
                else
                {
                    Client_View_M01.StatusMessage01 = data01[24];

                }
            }
            else
            {
                Client_View_M01.StatusMessage01 = data01[23];

            }

        }
        private void find_client_apikey_by_apikey()
        {

            if (Security_Serv01.empty_string(Client_View_M01.input01, out data01[23]) == true)
            {
                if (MySql_Client_S01.find_client_apikey_by_apikey(Client_View_M01.input01, out data01[25]) == true)
                {
                    Client_View_M01.StatusMessage01 = data01[25];

                }
                else
                {
                    Client_View_M01.StatusMessage01 = data01[25];
                }
            }
            else
            {
                Client_View_M01.StatusMessage01 = data01[23];

            }
        }
        private void find_client_apikey_by_cashappdata01()
        {

            if (Security_Serv01.empty_string(Client_View_M01.input01, out data01[23]) == true)
            {
                if (MySql_Client_S01.find_client_apikey_by_cashappdata01(Client_View_M01.input01, out data01[25]) == true)
                {
                    Client_View_M01.StatusMessage01 = data01[25];

                }
                else
                {
                    Client_View_M01.StatusMessage01 = data01[25];
                }
            }
            else
            {
                Client_View_M01.StatusMessage01 = data01[23];

            }

        }
        private void find_client_apikey_by_paypalappdata01()
        {

            if (Security_Serv01.empty_string(Client_View_M01.input01, out data01[23]) == true)
            {
                if (MySql_Client_S01.find_client_apikey_by_paypalappdata01(Client_View_M01.input01, out data01[25]) == true)
                {
                    Client_View_M01.StatusMessage01 = data01[25];

                }
                else
                {
                    Client_View_M01.StatusMessage01 = data01[25];
                }
            }
            else
            {
                Client_View_M01.StatusMessage01 = data01[23];

            }
        }
        private void find_client_apikey_by_venmoappdata01()
        {

            if (Security_Serv01.empty_string(Client_View_M01.input01, out data01[23]) == true)
            {
                if (MySql_Client_S01.find_client_apikey_by_venmoappdata01(Client_View_M01.input01, out data01[25]) == true)
                {
                    Client_View_M01.StatusMessage01 = data01[25];

                }
                else
                {
                    Client_View_M01.StatusMessage01 = data01[25];
                }
            }
            else
            {
                Client_View_M01.StatusMessage01 = data01[23];

            }
        }
        private void find_client_cashappdata01_by_apikey()
        {

            if (Security_Serv01.empty_string(Client_View_M01.input01, out data01[23]) == true)
            {
                if (MySql_Client_S01.find_client_cashappdata01_by_apikey(Client_View_M01.input01, out data01[25]) == true)
                {
                    Client_View_M01.StatusMessage01 = data01[25];

                }
                else
                {
                    Client_View_M01.StatusMessage01 = data01[25];
                }
            }
            else
            {
                Client_View_M01.StatusMessage01 = data01[23];

            }

        }
        private void find_client_cashappdata01_by_cashappdata01()
        {

            if (Security_Serv01.empty_string(Client_View_M01.input01, out data01[23]) == true)
            {
                if (MySql_Client_S01.find_client_cashappdata01_by_cashappdata01(Client_View_M01.input01, out data01[25]) == true)
                {
                    Client_View_M01.StatusMessage01 = data01[25];

                }
                else
                {
                    Client_View_M01.StatusMessage01 = data01[25];
                }
            }
            else
            {
                Client_View_M01.StatusMessage01 = data01[23];

            }

        }
        private void find_client_cashappdata01_by_emailaddress()
        {


            if (Security_Serv01.empty_string(Client_View_M01.input01, out data01[23]) == true)
            {
                if (Security_Serv01.email_check(Client_View_M01.input01, out data01[24]) == true)
                {

                    if (MySql_Client_S01.find_client_cashappdata01_by_emailaddress(Client_View_M01.input01, out data01[25]) == true)
                    {
                        Client_View_M01.StatusMessage01 = data01[25];


                    }
                    else
                    {
                        Client_View_M01.StatusMessage01 = data01[25];
                    }
                }
                else
                {
                    Client_View_M01.StatusMessage01 = data01[24];

                }
            }
            else
            {
                Client_View_M01.StatusMessage01 = data01[23];

            }

        }
        private void find_client_cashappdata01_by_name()
        {

            if (Security_Serv01.empty_string(Client_View_M01.input01, out data01[23]) == true)
            {
                if (MySql_Client_S01.find_client_cashappdata01_by_name(Client_View_M01.input01, out data01[25]) == true)
                {
                    Client_View_M01.StatusMessage01 = data01[25];

                }
                else
                {
                    Client_View_M01.StatusMessage01 = data01[25];
                }
            }
            else
            {
                Client_View_M01.StatusMessage01 = data01[23];

            }

        }
        private void find_client_cashappdata01_by_paypalappdata01()
        {

            if (Security_Serv01.empty_string(Client_View_M01.input01, out data01[23]) == true)
            {
                if (MySql_Client_S01.find_client_cashappdata01_by_paypalappdata01(Client_View_M01.input01, out data01[25]) == true)
                {
                    Client_View_M01.StatusMessage01 = data01[25];

                }
                else
                {
                    Client_View_M01.StatusMessage01 = data01[25];
                }
            }
            else
            {
                Client_View_M01.StatusMessage01 = data01[23];

            }

        }
        private void find_client_cashappdata01_by_phonnumeber()
        {


            if (Security_Serv01.empty_string(Client_View_M01.input01, out data01[23]) == true)
            {
                if (Security_Serv01.phone_check(Client_View_M01.input01, out data01[24]) == true)
                {

                    if (MySql_Client_S01.find_client_cashappdata01_by_phonnumeber(Client_View_M01.input01, out data01[25]) == true)
                    {
                        Client_View_M01.StatusMessage01 = data01[25];


                    }
                    else
                    {
                        Client_View_M01.StatusMessage01 = data01[25];
                    }
                }
                else
                {
                    Client_View_M01.StatusMessage01 = data01[24];

                }
            }
            else
            {
                Client_View_M01.StatusMessage01 = data01[23];

            }

        }
        private void find_client_cashappdata01_by_venmoappdata01()
        {

            if (Security_Serv01.empty_string(Client_View_M01.input01, out data01[23]) == true)
            {
                if (MySql_Client_S01.find_client_cashappdata01_by_venmoappdata01(Client_View_M01.input01, out data01[25]) == true)
                {
                    Client_View_M01.StatusMessage01 = data01[25];

                }
                else
                {
                    Client_View_M01.StatusMessage01 = data01[25];
                }
            }
            else
            {
                Client_View_M01.StatusMessage01 = data01[23];

            }

        }
        private void find_client_colors_using_emailaddress()
        {


            if (Security_Serv01.empty_string(Client_View_M01.input01, out data01[23]) == true)
            {
                if (Security_Serv01.email_check(Client_View_M01.input01, out data01[24]) == true)
                {

                    if (MySql_Client_S01.find_client_colors_using_emailaddress(Client_View_M01.input01, out data01[25]) == true)
                    {
                        Client_View_M01.StatusMessage01 = data01[25];


                    }
                    else
                    {
                        Client_View_M01.StatusMessage01 = data01[25];
                    }
                }
                else
                {
                    Client_View_M01.StatusMessage01 = data01[24];

                }
            }
            else
            {
                Client_View_M01.StatusMessage01 = data01[23];

            }

        }
        private void find_client_colors_using_name()
        {

            if (Security_Serv01.empty_string(Client_View_M01.input01, out data01[23]) == true)
            {
                if (MySql_Client_S01.find_client_colors_using_name(Client_View_M01.input01, out data01[25]) == true)
                {
                    Client_View_M01.StatusMessage01 = data01[25];

                }
                else
                {
                    Client_View_M01.StatusMessage01 = data01[25];
                }
            }
            else
            {
                Client_View_M01.StatusMessage01 = data01[23];

            }

        }
        private void find_client_colors_using_phonenumber()
        {


            if (Security_Serv01.empty_string(Client_View_M01.input01, out data01[23]) == true)
            {
                if (Security_Serv01.phone_check(Client_View_M01.input01, out data01[24]) == true)
                {

                    if (MySql_Client_S01.find_client_colors_using_phonenumber(Client_View_M01.input01, out data01[25]) == true)
                    {
                        Client_View_M01.StatusMessage01 = data01[25];


                    }
                    else
                    {
                        Client_View_M01.StatusMessage01 = data01[25];
                    }
                }
                else
                {
                    Client_View_M01.StatusMessage01 = data01[24];

                }
            }
            else
            {
                Client_View_M01.StatusMessage01 = data01[23];

            }

        }
        private void find_client_data_using_email()
        {


            if (Security_Serv01.empty_string(Client_View_M01.input01, out data01[23]) == true)
            {
                if (Security_Serv01.email_check(Client_View_M01.input01, out data01[24]) == true)
                {

                    if (MySql_Client_S01.find_client_data_using_email(Client_View_M01.input01, out data01[25]) == true)
                    {
                        Client_View_M01.StatusMessage01 = data01[25];


                    }
                    else
                    {
                        Client_View_M01.StatusMessage01 = data01[25];
                    }
                }
                else
                {
                    Client_View_M01.StatusMessage01 = data01[24];

                }
            }
            else
            {
                Client_View_M01.StatusMessage01 = data01[23];

            }

        }
        private void find_client_data_using_latitude_and_longitude()
        {

            if (Security_Serv01.empty_string(Client_View_M01.input01, out data01[23]) == true)
            {

                counter01++;
            }
            else
            {
                counter01--;
                Client_View_M01.StatusMessage01 = data01[23];
            }
            if (Security_Serv01.empty_string(Client_View_M01.input02, out data01[23]) == true)
            {
                counter01++;

            }
            else
            {
                counter01--;
                Client_View_M01.StatusMessage02 = data01[23];
            }
            if (counter01 == 2)
            {
                if (MySql_Client_S01.find_client_data_using_latitude_and_longitude(Client_View_M01.input01, Client_View_M01.input02, out data01[25]) == true)
                {
                    Client_View_M01.StatusMessage02 = data01[25];

                }
                else
                {
                    Client_View_M01.StatusMessage02 = data01[25];
                }

            }
            else
            {
                Client_View_M01.StatusMessage02 = "please fix errors";
            }
        }
        private void find_client_data_using_logo()
        {

            if (Security_Serv01.empty_string(Client_View_M01.input01, out data01[23]) == true)
            {
                if (MySql_Client_S01.find_client_data_using_logo(Client_View_M01.input01, out data01[25]) == true)
                {
                    Client_View_M01.StatusMessage01 = data01[25];

                }
                else
                {
                    Client_View_M01.StatusMessage01 = data01[25];
                }
            }
            else
            {
                Client_View_M01.StatusMessage01 = data01[23];

            }


        }
        private void find_client_data_using_name()
        {

            if (Security_Serv01.empty_string(Client_View_M01.input01, out data01[23]) == true)
            {
                if (MySql_Client_S01.find_client_data_using_name(Client_View_M01.input01, out data01[25]) == true)
                {
                    Client_View_M01.StatusMessage01 = data01[25];

                }
                else
                {
                    Client_View_M01.StatusMessage01 = data01[25];
                }
            }
            else
            {
                Client_View_M01.StatusMessage01 = data01[23];

            }


        }
        private void find_client_data_using_number()
        {


            if (Security_Serv01.empty_string(Client_View_M01.input01, out data01[23]) == true)
            {
                if (Security_Serv01.phone_check(Client_View_M01.input01, out data01[24]) == true)
                {

                    if (MySql_Client_S01.find_client_data_using_number(Client_View_M01.input01, out data01[25]) == true)
                    {
                        Client_View_M01.StatusMessage01 = data01[25];

                    }
                    else
                    {
                        Client_View_M01.StatusMessage01 = data01[25];
                    }
                }
                else
                {
                    Client_View_M01.StatusMessage01 = data01[24];

                }
            }
            else
            {
                Client_View_M01.StatusMessage01 = data01[23];

            }
        }
        private void find_client_emailaddress_by_apikey()
        {

            if (Security_Serv01.empty_string(Client_View_M01.input01, out data01[23]) == true)
            {
                if (MySql_Client_S01.find_client_emailaddress_by_apikey(Client_View_M01.input01, out data01[25]) == true)
                {
                    Client_View_M01.StatusMessage01 = data01[25];

                }
                else
                {
                    Client_View_M01.StatusMessage01 = data01[25];
                }
            }
            else
            {
                Client_View_M01.StatusMessage01 = data01[23];

            }




        }
        private void find_client_emailaddress_by_cashappdata01()
        {

            if (Security_Serv01.empty_string(Client_View_M01.input01, out data01[23]) == true)
            {
                if (MySql_Client_S01.find_client_emailaddress_by_cashappdata01(Client_View_M01.input01, out data01[25]) == true)
                {
                    Client_View_M01.StatusMessage01 = data01[25];

                }
                else
                {
                    Client_View_M01.StatusMessage01 = data01[25];
                }
            }
            else
            {
                Client_View_M01.StatusMessage01 = data01[23];

            }
        }
        private void find_client_emailaddress_by_emailaddress()
        {

            if (Security_Serv01.empty_string(Client_View_M01.input01, out data01[23]) == true)
            {
                if (Security_Serv01.email_check(Client_View_M01.input01, out data01[24]) == true)
                {

                    if (MySql_Client_S01.find_client_emailaddress_by_emailaddress(Client_View_M01.input01, out data01[25]) == true)
                    {
                        Client_View_M01.StatusMessage01 = data01[25];
                    }
                    else
                    {
                        Client_View_M01.StatusMessage01 = data01[25];
                    }
                }
                else
                {
                    Client_View_M01.StatusMessage01 = data01[24];

                }
            }
            else
            {
                Client_View_M01.StatusMessage01 = data01[23];

            }



        }
        private void find_client_emailaddress_by_name()
        {

            if (Security_Serv01.empty_string(Client_View_M01.input01, out data01[23]) == true)
            {
                if (MySql_Client_S01.find_client_emailaddress_by_name(Client_View_M01.input01, out data01[25]) == true)
                {
                    Client_View_M01.StatusMessage01 = data01[25];

                }
                else
                {
                    Client_View_M01.StatusMessage01 = data01[25];
                }
            }
            else
            {
                Client_View_M01.StatusMessage01 = data01[23];

            }

        }
        private void find_client_emailaddress_by_paypalappdata01()
        {

            if (Security_Serv01.empty_string(Client_View_M01.input01, out data01[23]) == true)
            {
                if (MySql_Client_S01.find_client_emailaddress_by_paypalappdata01(Client_View_M01.input01, out data01[25]) == true)
                {
                    Client_View_M01.StatusMessage01 = data01[25];

                }
                else
                {
                    Client_View_M01.StatusMessage01 = data01[25];
                }
            }
            else
            {
                Client_View_M01.StatusMessage01 = data01[23];

            }

        }
        private void find_client_emailaddress_by_phonnumeber()
        {

            if (Security_Serv01.empty_string(Client_View_M01.input01, out data01[23]) == true)
            {
                if (Security_Serv01.phone_check(Client_View_M01.input01, out data01[24]) == true)
                {

                    if (MySql_Client_S01.find_client_emailaddress_by_phonnumeber(Client_View_M01.input01, out data01[25]) == true)
                    {
                        Client_View_M01.StatusMessage01 = data01[25];


                    }
                    else
                    {
                        Client_View_M01.StatusMessage01 = data01[25];
                    }
                }
                else
                {
                    Client_View_M01.StatusMessage01 = data01[24];

                }
            }
            else
            {
                Client_View_M01.StatusMessage01 = data01[23];

            }


        }
        private void find_client_emailaddress_by_venmoappdata01()
        {

            if (Security_Serv01.empty_string(Client_View_M01.input01, out data01[23]) == true)
            {
                if (MySql_Client_S01.find_client_emailaddress_by_venmoappdata01(Client_View_M01.input01, out data01[25]) == true)
                {
                    Client_View_M01.StatusMessage01 = data01[25];

                }
                else
                {
                    Client_View_M01.StatusMessage01 = data01[25];
                }
            }
            else
            {
                Client_View_M01.StatusMessage01 = data01[23];

            }


        }
        private void find_client_location_using_emailaddress()
        {

            if (Security_Serv01.empty_string(Client_View_M01.input01, out data01[23]) == true)
            {
                if (Security_Serv01.email_check(Client_View_M01.input01, out data01[24]) == true)
                {

                    if (MySql_Client_S01.find_client_location_using_emailaddress(Client_View_M01.input01, out data01[25]) == true)
                    {
                        Client_View_M01.StatusMessage01 = data01[25];


                    }
                    else
                    {
                        Client_View_M01.StatusMessage01 = data01[25];
                    }
                }
                else
                {
                    Client_View_M01.StatusMessage01 = data01[24];

                }
            }
            else
            {
                Client_View_M01.StatusMessage01 = data01[23];

            }



        }
        private void find_client_location_using_name()
        {

            if (Security_Serv01.empty_string(Client_View_M01.input01, out data01[23]) == true)
            {
                if (MySql_Client_S01.find_client_location_using_name(Client_View_M01.input01, out data01[25]) == true)
                {
                    Client_View_M01.StatusMessage01 = data01[25];

                }
                else
                {
                    Client_View_M01.StatusMessage01 = data01[25];
                }
            }
            else
            {
                Client_View_M01.StatusMessage01 = data01[23];

            }



        }
        private void find_client_location_using_phonenumber()
        {

            if (Security_Serv01.empty_string(Client_View_M01.input01, out data01[23]) == true)
            {
                if (Security_Serv01.phone_check(Client_View_M01.input01, out data01[24]) == true)
                {

                    if (MySql_Client_S01.find_client_location_using_phonenumber(Client_View_M01.input01, out data01[25]) == true)
                    {
                        Client_View_M01.StatusMessage01 = data01[25];


                    }
                    else
                    {
                        Client_View_M01.StatusMessage01 = data01[25];
                    }
                }
                else
                {
                    Client_View_M01.StatusMessage01 = data01[24];

                }
            }
            else
            {
                Client_View_M01.StatusMessage01 = data01[23];

            }


        }
        private void find_client_logo_by_emailaddress()
        {

            if (Security_Serv01.empty_string(Client_View_M01.input01, out data01[23]) == true)
            {
                if (Security_Serv01.email_check(Client_View_M01.input01, out data01[24]) == true)
                {

                    if (MySql_Client_S01.find_client_logo_by_emailaddress(Client_View_M01.input01, out data01[25]) == true)
                    {
                        Client_View_M01.StatusMessage01 = data01[25];


                    }
                    else
                    {
                        Client_View_M01.StatusMessage01 = data01[25];
                    }
                }
                else
                {
                    Client_View_M01.StatusMessage01 = data01[24];

                }
            }
            else
            {
                Client_View_M01.StatusMessage01 = data01[23];

            }

        }
        private void find_client_logo_by_logo()
        {

            if (Security_Serv01.empty_string(Client_View_M01.input01, out data01[23]) == true)
            {
                if (MySql_Client_S01.find_client_logo_by_logo(Client_View_M01.input01, out data01[25]) == true)
                {
                    Client_View_M01.StatusMessage01 = data01[25];

                }
                else
                {
                    Client_View_M01.StatusMessage01 = data01[25];
                }
            }
            else
            {
                Client_View_M01.StatusMessage01 = data01[23];

            }


        }
        private void find_client_logo_by_name()
        {

            if (Security_Serv01.empty_string(Client_View_M01.input01, out data01[23]) == true)
            {
                if (MySql_Client_S01.find_client_logo_by_name(Client_View_M01.input01, out data01[25]) == true)
                {
                    Client_View_M01.StatusMessage01 = data01[25];

                }
                else
                {
                    Client_View_M01.StatusMessage01 = data01[25];
                }
            }
            else
            {
                Client_View_M01.StatusMessage01 = data01[23];

            }


        }
        private void find_client_logo_by_phonenumber()
        {

            if (Security_Serv01.empty_string(Client_View_M01.input01, out data01[23]) == true)
            {
                if (Security_Serv01.phone_check(Client_View_M01.input01, out data01[24]) == true)
                {

                    if (MySql_Client_S01.find_client_logo_by_phonenumber(Client_View_M01.input01, out data01[25]) == true)
                    {
                        Client_View_M01.StatusMessage01 = data01[25];


                    }
                    else
                    {
                        Client_View_M01.StatusMessage01 = data01[25];
                    }
                }
                else
                {
                    Client_View_M01.StatusMessage01 = data01[24];

                }
            }
            else
            {
                Client_View_M01.StatusMessage01 = data01[23];

            }


        }
        private void find_client_name_by_cashappdata01()
        {
            if (Security_Serv01.empty_string(Client_View_M01.input01, out data01[23]) == true)
            {
                if (MySql_Client_S01.find_client_name_by_cashappdata01(Client_View_M01.input01, out data01[25]) == true)
                {
                    Client_View_M01.StatusMessage01 = data01[25];

                }
                else
                {
                    Client_View_M01.StatusMessage01 = data01[25];
                }
            }
            else
            {
                Client_View_M01.StatusMessage01 = data01[23];

            }



        }
        private void find_client_name_by_emailaddress()
        {

            if (Security_Serv01.empty_string(Client_View_M01.input01, out data01[23]) == true)
            {
                if (Security_Serv01.email_check(Client_View_M01.input01, out data01[24]) == true)
                {

                    if (MySql_Client_S01.find_client_name_by_emailaddress(Client_View_M01.input01, out data01[25]) == true)
                    {
                        Client_View_M01.StatusMessage01 = data01[25];


                    }
                    else
                    {
                        Client_View_M01.StatusMessage01 = data01[25];
                    }
                }
                else
                {
                    Client_View_M01.StatusMessage01 = data01[24];

                }
            }
            else
            {
                Client_View_M01.StatusMessage01 = data01[23];

            }






        }
        private void find_client_name_by_name()
        {

            if (Security_Serv01.empty_string(Client_View_M01.input01, out data01[23]) == true)
            {
                if (MySql_Client_S01.find_client_name_by_name(Client_View_M01.input01, out data01[25]) == true)
                {
                    Client_View_M01.StatusMessage01 = data01[25];

                }
                else
                {
                    Client_View_M01.StatusMessage01 = data01[25];
                }
            }
            else
            {
                Client_View_M01.StatusMessage01 = data01[23];

            }



        }
        private void find_client_name_by_paypalappdata01()
        {

            if (Security_Serv01.empty_string(Client_View_M01.input01, out data01[23]) == true)
            {
                if (MySql_Client_S01.find_client_name_by_paypalappdata01(Client_View_M01.input01, out data01[25]) == true)
                {
                    Client_View_M01.StatusMessage01 = data01[25];

                }
                else
                {
                    Client_View_M01.StatusMessage01 = data01[25];
                }
            }
            else
            {
                Client_View_M01.StatusMessage01 = data01[23];

            }



        }
        private void find_client_name_by_phonnumeber()
        {

            if (Security_Serv01.empty_string(Client_View_M01.input01, out data01[23]) == true)
            {
                if (Security_Serv01.email_check(Client_View_M01.input01, out data01[24]) == true)
                {

                    if (MySql_Client_S01.find_client_cashappdata01_by_emailaddress(Client_View_M01.input01, out data01[25]) == true)
                    {
                        Client_View_M01.StatusMessage01 = data01[25];


                    }
                    else
                    {
                        Client_View_M01.StatusMessage01 = data01[25];
                    }
                }
                else
                {
                    Client_View_M01.StatusMessage01 = data01[24];

                }
            }
            else
            {
                Client_View_M01.StatusMessage01 = data01[23];

            }

        }
        private void find_client_name_by_venmoappdata01()
        {


            if (Security_Serv01.empty_string(Client_View_M01.input01, out data01[23]) == true)
            {
                if (MySql_Client_S01.find_client_name_by_venmoappdata01(Client_View_M01.input01, out data01[25]) == true)
                {
                    Client_View_M01.StatusMessage01 = data01[25];

                }
                else
                {
                    Client_View_M01.StatusMessage01 = data01[25];
                }
            }
            else
            {
                Client_View_M01.StatusMessage01 = data01[23];

            }
        }
        private void find_client_paypalappdata01_by_apikey()
        {


            if (Security_Serv01.empty_string(Client_View_M01.input01, out data01[23]) == true)
            {
                if (MySql_Client_S01.find_client_paypalappdata01_by_apikey(Client_View_M01.input01, out data01[25]) == true)
                {
                    Client_View_M01.StatusMessage01 = data01[25];

                }
                else
                {
                    Client_View_M01.StatusMessage01 = data01[25];
                }
            }
            else
            {
                Client_View_M01.StatusMessage01 = data01[23];

            }



        }
        private void find_client_paypalappdata01_by_cashappdata01()
        {


            if (Security_Serv01.empty_string(Client_View_M01.input01, out data01[23]) == true)
            {
                if (MySql_Client_S01.find_client_paypalappdata01_by_cashappdata01(Client_View_M01.input01, out data01[25]) == true)
                {
                    Client_View_M01.StatusMessage01 = data01[25];

                }
                else
                {
                    Client_View_M01.StatusMessage01 = data01[25];
                }
            }
            else
            {
                Client_View_M01.StatusMessage01 = data01[23];

            }



        }
        private void find_client_paypalappdata01_by_emailaddress()
        {

            if (Security_Serv01.empty_string(Client_View_M01.input01, out data01[23]) == true)
            {
                if (Security_Serv01.email_check(Client_View_M01.input01, out data01[24]) == true)
                {

                    if (MySql_Client_S01.find_client_paypalappdata01_by_emailaddress(Client_View_M01.input01, out data01[25]) == true)
                    {
                        Client_View_M01.StatusMessage01 = data01[25];


                    }
                    else
                    {
                        Client_View_M01.StatusMessage01 = data01[25];
                    }
                }
                else
                {
                    Client_View_M01.StatusMessage01 = data01[24];

                }
            }
            else
            {
                Client_View_M01.StatusMessage01 = data01[23];

            }

        }
        private void find_client_paypalappdata01_by_name()
        {

            if (Security_Serv01.empty_string(Client_View_M01.input01, out data01[23]) == true)
            {
                if (MySql_Client_S01.find_client_paypalappdata01_by_name(Client_View_M01.input01, out data01[25]) == true)
                {
                    Client_View_M01.StatusMessage01 = data01[25];

                }
                else
                {
                    Client_View_M01.StatusMessage01 = data01[25];
                }
            }
            else
            {
                Client_View_M01.StatusMessage01 = data01[23];

            }

        }
        private void find_client_paypalappdata01_by_paypalappdata01()
        {

            if (Security_Serv01.empty_string(Client_View_M01.input01, out data01[23]) == true)
            {
                if (MySql_Client_S01.find_client_paypalappdata01_by_paypalappdata01(Client_View_M01.input01, out data01[25]) == true)
                {
                    Client_View_M01.StatusMessage01 = data01[25];

                }
                else
                {
                    Client_View_M01.StatusMessage01 = data01[25];
                }
            }
            else
            {
                Client_View_M01.StatusMessage01 = data01[23];

            }

        }
        private void find_client_paypalappdata01_by_phonnumeber()
        {

            if (Security_Serv01.empty_string(Client_View_M01.input01, out data01[23]) == true)
            {
                if (Security_Serv01.phone_check(Client_View_M01.input01, out data01[24]) == true)
                {

                    if (MySql_Client_S01.find_client_cashappdata01_by_emailaddress(Client_View_M01.input01, out data01[25]) == true)
                    {
                        Client_View_M01.StatusMessage01 = data01[25];
                    }
                    else
                    {
                        Client_View_M01.StatusMessage01 = data01[25];
                    }
                }
                else
                {
                    Client_View_M01.StatusMessage01 = data01[24];

                }
            }
            else
            {
                Client_View_M01.StatusMessage01 = data01[23];

            }


        }
        private void find_client_paypalappdata01_by_venmoappdata01()
        {

            if (Security_Serv01.empty_string(Client_View_M01.input01, out data01[23]) == true)
            {
                if (MySql_Client_S01.find_client_paypalappdata01_by_venmoappdata01(Client_View_M01.input01, out data01[25]) == true)
                {
                    Client_View_M01.StatusMessage01 = data01[25];

                }
                else
                {
                    Client_View_M01.StatusMessage01 = data01[25];
                }
            }
            else
            {
                Client_View_M01.StatusMessage01 = data01[23];

            }



        }
        private void find_client_phonenumber_by_apikey()
        {


            if (Security_Serv01.empty_string(Client_View_M01.input01, out data01[23]) == true)
            {
                if (MySql_Client_S01.find_client_phonenumber_by_apikey(Client_View_M01.input01, out data01[25]) == true)
                {
                    Client_View_M01.StatusMessage01 = data01[25];

                }
                else
                {
                    Client_View_M01.StatusMessage01 = data01[25];
                }
            }
            else
            {
                Client_View_M01.StatusMessage01 = data01[23];

            }



        }
        private void find_client_phonenumber_by_cashappdata01()
        {

            if (Security_Serv01.empty_string(Client_View_M01.input01, out data01[23]) == true)
            {
                if (MySql_Client_S01.find_client_phonenumber_by_cashappdata01(Client_View_M01.input01, out data01[25]) == true)
                {
                    Client_View_M01.StatusMessage01 = data01[25];

                }
                else
                {
                    Client_View_M01.StatusMessage01 = data01[25];
                }
            }
            else
            {
                Client_View_M01.StatusMessage01 = data01[23];

            }
        }
        private void find_client_phonenumber_by_emailaddress()
        {

            if (Security_Serv01.empty_string(Client_View_M01.input01, out data01[23]) == true)
            {
                if (Security_Serv01.email_check(Client_View_M01.input01, out data01[24]) == true)
                {

                    if (MySql_Client_S01.find_client_phonenumber_by_emailaddress(Client_View_M01.input01, out data01[25]) == true)
                    {
                        Client_View_M01.StatusMessage01 = data01[25];


                    }
                    else
                    {
                        Client_View_M01.StatusMessage01 = data01[25];
                    }
                }
                else
                {
                    Client_View_M01.StatusMessage01 = data01[24];

                }
            }
            else
            {
                Client_View_M01.StatusMessage01 = data01[23];

            }

        }
        private void find_client_phonenumber_by_name()
        {
            if (Security_Serv01.empty_string(Client_View_M01.input01, out data01[23]) == true)
            {
                if (MySql_Client_S01.find_client_phonenumber_by_name(Client_View_M01.input01, out data01[25]) == true)
                {
                    Client_View_M01.StatusMessage01 = data01[25];

                }
                else
                {
                    Client_View_M01.StatusMessage01 = data01[25];
                }
            }
            else
            {
                Client_View_M01.StatusMessage01 = data01[23];

            }

        }
        private void find_client_phonenumber_by_paypalappdata01()
        {

            if (Security_Serv01.empty_string(Client_View_M01.input01, out data01[23]) == true)
            {
                if (MySql_Client_S01.find_client_cashappdata01_by_name(Client_View_M01.input01, out data01[25]) == true)
                {
                    Client_View_M01.StatusMessage01 = data01[25];

                }
                else
                {
                    Client_View_M01.StatusMessage01 = data01[25];
                }
            }
            else
            {
                Client_View_M01.StatusMessage01 = data01[23];

            }



        }
        private void find_client_phonenumber_by_phonnumeber()
        {

            if (Security_Serv01.empty_string(Client_View_M01.input01, out data01[23]) == true)
            {
                if (Security_Serv01.phone_check(Client_View_M01.input01, out data01[24]) == true)
                {

                    if (MySql_Client_S01.find_client_phonenumber_by_phonnumeber(Client_View_M01.input01, out data01[25]) == true)
                    {
                        Client_View_M01.StatusMessage01 = data01[25];


                    }
                    else
                    {
                        Client_View_M01.StatusMessage01 = data01[25];
                    }
                }
                else
                {
                    Client_View_M01.StatusMessage01 = data01[24];

                }
            }
            else
            {
                Client_View_M01.StatusMessage01 = data01[23];

            }

        }
        private void find_client_phonenumber_by_venmoappdata01()
        {

            if (Security_Serv01.empty_string(Client_View_M01.input01, out data01[23]) == true)
            {
                if (MySql_Client_S01.find_client_phonenumber_by_venmoappdata01(Client_View_M01.input01, out data01[25]) == true)
                {
                    Client_View_M01.StatusMessage01 = data01[25];

                }
                else
                {
                    Client_View_M01.StatusMessage01 = data01[25];
                }
            }
            else
            {
                Client_View_M01.StatusMessage01 = data01[23];

            }



        }
        private void find_client_venmoappdata01_by_apikey()
        {

            if (Security_Serv01.empty_string(Client_View_M01.input01, out data01[23]) == true)
            {
                if (MySql_Client_S01.find_client_venmoappdata01_by_apikey(Client_View_M01.input01, out data01[25]) == true)
                {
                    Client_View_M01.StatusMessage01 = data01[25];

                }
                else
                {
                    Client_View_M01.StatusMessage01 = data01[25];
                }
            }
            else
            {
                Client_View_M01.StatusMessage01 = data01[23];

            }



        }
        private void find_client_venmoappdata01_by_cashappdata01()
        {

            if (Security_Serv01.empty_string(Client_View_M01.input01, out data01[23]) == true)
            {
                if (MySql_Client_S01.find_client_venmoappdata01_by_cashappdata01(Client_View_M01.input01, out data01[25]) == true)
                {
                    Client_View_M01.StatusMessage01 = data01[25];

                }
                else
                {
                    Client_View_M01.StatusMessage01 = data01[25];
                }
            }
            else
            {
                Client_View_M01.StatusMessage01 = data01[23];

            }



        }
        private void find_client_venmoappdata01_by_emailaddress()
        {

            if (Security_Serv01.empty_string(Client_View_M01.input01, out data01[23]) == true)
            {
                if (Security_Serv01.email_check(Client_View_M01.input01, out data01[24]) == true)
                {

                    if (MySql_Client_S01.find_client_venmoappdata01_by_emailaddress(Client_View_M01.input01, out data01[25]) == true)
                    {
                        Client_View_M01.StatusMessage01 = data01[25];
                    }
                    else
                    {
                        Client_View_M01.StatusMessage01 = data01[25];
                    }
                }
                else
                {
                    Client_View_M01.StatusMessage01 = data01[24];

                }
            }
            else
            {
                Client_View_M01.StatusMessage01 = data01[23];

            }

        }
        private void find_client_venmoappdata01_by_name()
        {

            if (Security_Serv01.empty_string(Client_View_M01.input01, out data01[23]) == true)
            {
                if (MySql_Client_S01.find_client_venmoappdata01_by_name(Client_View_M01.input01, out data01[25]) == true)
                {
                    Client_View_M01.StatusMessage01 = data01[25];

                }
                else
                {
                    Client_View_M01.StatusMessage01 = data01[25];
                }
            }
            else
            {
                Client_View_M01.StatusMessage01 = data01[23];

            }






        }
        private void find_client_venmoappdata01_by_paypalappdata01()
        {

            if (Security_Serv01.empty_string(Client_View_M01.input01, out data01[23]) == true)
            {
                if (MySql_Client_S01.find_client_venmoappdata01_by_paypalappdata01(Client_View_M01.input01, out data01[25]) == true)
                {
                    Client_View_M01.StatusMessage01 = data01[25];

                }
                else
                {
                    Client_View_M01.StatusMessage01 = data01[25];
                }
            }
            else
            {
                Client_View_M01.StatusMessage01 = data01[23];

            }






        }
        private void find_client_venmoappdata01_by_phonnumeber()
        {

            if (Security_Serv01.empty_string(Client_View_M01.input01, out data01[23]) == true)
            {
                if (Security_Serv01.phone_check(Client_View_M01.input01, out data01[24]) == true)
                {

                    if (MySql_Client_S01.find_client_venmoappdata01_by_phonnumeber(Client_View_M01.input01, out data01[25]) == true)
                    {
                        Client_View_M01.StatusMessage01 = data01[25];


                    }
                    else
                    {
                        Client_View_M01.StatusMessage01 = data01[25];
                    }
                }
                else
                {
                    Client_View_M01.StatusMessage01 = data01[24];

                }
            }
            else
            {
                Client_View_M01.StatusMessage01 = data01[23];

            }



        }
        private void find_client_venmoappdata01_by_venmoappdata01()
        {

            if (Security_Serv01.empty_string(Client_View_M01.input01, out data01[23]) == true)
            {
                if (MySql_Client_S01.find_client_venmoappdata01_by_venmoappdata01(Client_View_M01.input01, out data01[25]) == true)
                {
                    Client_View_M01.StatusMessage01 = data01[25];

                }
                else
                {
                    Client_View_M01.StatusMessage01 = data01[25];
                }
            }
            else
            {
                Client_View_M01.StatusMessage01 = data01[23];

            }



        }
        private void find_client_zellaappdata01_by_apikey()
        {

            if (Security_Serv01.empty_string(Client_View_M01.input01, out data01[23]) == true)
            {
                if (MySql_Client_S01.find_client_zellaappdata01_by_apikey(Client_View_M01.input01, out data01[25]) == true)
                {
                    Client_View_M01.StatusMessage01 = data01[25];

                }
                else
                {
                    Client_View_M01.StatusMessage01 = data01[25];
                }
            }
            else
            {
                Client_View_M01.StatusMessage01 = data01[23];

            }



        }
        private void find_client_zellaappdata01_by_zellaappdata01()
        {

            if (Security_Serv01.empty_string(Client_View_M01.input01, out data01[23]) == true)
            {
                if (MySql_Client_S01.find_client_zellaappdata01_by_zellaappdata01(Client_View_M01.input01, out data01[25]) == true)
                {
                    Client_View_M01.StatusMessage01 = data01[25];

                }
                else
                {
                    Client_View_M01.StatusMessage01 = data01[25];
                }
            }
            else
            {
                Client_View_M01.StatusMessage01 = data01[23];

            }



        }
        private void find_client_zelleappdata01_by_cashappdata01()
        {

            if (Security_Serv01.empty_string(Client_View_M01.input01, out data01[23]) == true)
            {
                if (MySql_Client_S01.find_client_zelleappdata01_by_cashappdata01(Client_View_M01.input01, out data01[25]) == true)
                {
                    Client_View_M01.StatusMessage01 = data01[25];

                }
                else
                {
                    Client_View_M01.StatusMessage01 = data01[25];
                }
            }
            else
            {
                Client_View_M01.StatusMessage01 = data01[23];

            }



        }
        private void find_client_zelleappdata01_by_emailaddress()
        {

            if (Security_Serv01.empty_string(Client_View_M01.input01, out data01[23]) == true)
            {
                if (Security_Serv01.email_check(Client_View_M01.input01, out data01[24]) == true)
                {

                    if (MySql_Client_S01.find_client_zelleappdata01_by_emailaddress(Client_View_M01.input01, out data01[25]) == true)
                    {
                        Client_View_M01.StatusMessage01 = data01[25];


                    }
                    else
                    {
                        Client_View_M01.StatusMessage01 = data01[25];
                    }
                }
                else
                {
                    Client_View_M01.StatusMessage01 = data01[24];

                }
            }
            else
            {
                Client_View_M01.StatusMessage01 = data01[23];

            }


        }
        private void find_client_zelleappdata01_by_name()
        {

            if (Security_Serv01.empty_string(Client_View_M01.input01, out data01[23]) == true)
            {
                if (MySql_Client_S01.find_client_zelleappdata01_by_name(Client_View_M01.input01, out data01[25]) == true)
                {
                    Client_View_M01.StatusMessage01 = data01[25];

                }
                else
                {
                    Client_View_M01.StatusMessage01 = data01[25];
                }
            }
            else
            {
                Client_View_M01.StatusMessage01 = data01[23];

            }


        }
        private void find_client_zelleappdata01_by_phonnumeber()
        {


            if (Security_Serv01.empty_string(Client_View_M01.input01, out data01[23]) == true)
            {
                if (Security_Serv01.phone_check(Client_View_M01.input01, out data01[24]) == true)
                {

                    if (MySql_Client_S01.find_client_zelleappdata01_by_phonnumeber(Client_View_M01.input01, out data01[25]) == true)
                    {
                        Client_View_M01.StatusMessage01 = data01[25];


                    }
                    else
                    {
                        Client_View_M01.StatusMessage01 = data01[25];
                    }
                }
                else
                {
                    Client_View_M01.StatusMessage01 = data01[24];

                }
            }
            else
            {
                Client_View_M01.StatusMessage01 = data01[23];

            }


        }
        private void find_client_zelleappdata01_by_venmoappdata01()
        {

            if (Security_Serv01.empty_string(Client_View_M01.input01, out data01[23]) == true)
            {
                if (MySql_Client_S01.find_client_zelleappdata01_by_venmoappdata01(Client_View_M01.input01, out data01[25]) == true)
                {
                    Client_View_M01.StatusMessage01 = data01[25];

                }
                else
                {
                    Client_View_M01.StatusMessage01 = data01[25];
                }
            }
            else
            {
                Client_View_M01.StatusMessage01 = data01[23];

            }
        }
        private void insert_client_data()
        {
            if (Security_Serv01.empty_string(Client_View_M01.input01, out data01[20]) == true)
            {

                counter01++;
                Client_View_M01.StatusMessage01 = data01[21];
            }
            else
            {
                counter01--;
                Client_View_M01.StatusMessage01 = data01[21];
            }

            if (Security_Serv01.empty_string(Client_View_M01.input02, out data01[23]) == true)
            {
                if (Security_Serv01.email_check(Client_View_M01.input02, out data01[24]) == true)
                {
                    counter01++;
                }
                else
                {
                    counter01--;
                    Client_View_M01.StatusMessage02 = data01[24];
                }
            }
            else
            {

                counter01--;
                Client_View_M01.StatusMessage02 = data01[23];
            }
            if (Security_Serv01.empty_string(Client_View_M01.input03, out data01[23]) == true)
            {
                if (Security_Serv01.phone_check(Client_View_M01.input03, out data01[24]) == true)
                {
                    counter01++;
                }
                else
                {
                    counter01--;
                    Client_View_M01.StatusMessage03 = data01[24];
                }
            }
            else
            {

                counter01--;
                Client_View_M01.StatusMessage03 = data01[23];
            }
            if (Security_Serv01.empty_string(Client_View_M01.input04, out data01[24]) == true)
            {
                counter01++;
            }
            else
            {

                counter01--;
                Client_View_M01.StatusMessage04 = data01[24];
            }
            if (Security_Serv01.empty_string(Client_View_M01.input05, out data01[24]) == true)
            {
                counter01++;
            }
            else
            {

                counter01--;
                Client_View_M01.StatusMessage06 = data01[24];
            }
            if (Security_Serv01.empty_string(Client_View_M01.input06, out data01[24]) == true)
            {
                counter01++;
            }
            else
            {

                counter01--;
                Client_View_M01.StatusMessage07 = data01[24];
            }

            if (Security_Serv01.empty_string(Client_View_M01.input07, out data01[24]) == true)
            {
                counter01++;
            }
            else
            {

                counter01--;
                Client_View_M01.StatusMessage07 = data01[24];
            }


            if (Security_Serv01.empty_string(Client_View_M01.input08, out data01[24]) == true)
            {
                counter01++;
            }
            else
            {

                counter01--;
                Client_View_M01.StatusMessage08 = data01[24];
            }

            if (Security_Serv01.empty_string(Client_View_M01.input09, out data01[24]) == true)
            {
                counter01++;
            }
            else
            {

                counter01--;
                Client_View_M01.StatusMessage09 = data01[24];
            }

            if (Security_Serv01.empty_string(Client_View_M01.input10, out data01[24]) == true)
            {
                counter01++;
            }
            else
            {

                counter01--;
                Client_View_M01.StatusMessage10 = data01[24];
            }

            if (Security_Serv01.empty_string(Client_View_M01.input11, out data01[24]) == true)
            {
                counter01++;
            }
            else
            {

                counter01--;
                Client_View_M01.StatusMessage11 = data01[24];
            }

            if (Security_Serv01.empty_string(Client_View_M01.input12, out data01[24]) == true)
            {
                counter01++;
            }
            else
            {

                counter01--;
                Client_View_M01.StatusMessage12 = data01[24];
            }

            if (Security_Serv01.empty_string(Client_View_M01.input13, out data01[24]) == true)
            {
                counter01++;
            }
            else
            {

                counter01--;
                Client_View_M01.StatusMessage13 = data01[24];
            }

            if (Security_Serv01.empty_string(Client_View_M01.input14, out data01[24]) == true)
            {
                counter01++;
            }
            else
            {

                counter01--;
                Client_View_M01.StatusMessage14 = data01[24];
            }


            if (counter01 == 14)
            {
                /*  if (MySql_Client_S01.insert_client_data(Client_View_M01.input01, Client_View_M01.input02, Client_View_M01.input03, Client_View_M01.input03,
                  Client_View_M01.input04, Client_View_M01.input05, Client_View_M01.input06, Client_View_M01.input07, Client_View_M01.input08,
                  Client_View_M01.input09, Client_View_M01.input10, Client_View_M01.input11, Client_View_M01.input12, Client_View_M01.input13, Client_View_M01.input14, out data01[25]) == true)
                  {
                      Client_View_M01.StatusMessage01 = data01[25];
                  }
                  else
                  {
                      Client_View_M01.StatusMessage01 = data01[25];
                  }*/
                Client_View_M01.StatusMessage01 = "needs more work";
            }
            else
            {
                Client_View_M01.StatusMessage01 = "please correct errors";
            }

        }
        private void update_clients_apikey_using_apikey()
        {


            if (Security_Serv01.empty_string(Client_View_M01.input01, out data01[23]) == true)
            {
                Client_View_M01.StatusMessage01 = string.Empty;
                counter01++;
            }
            else
            {
                Client_View_M01.StatusMessage01 = data01[23];
                counter01--;
            }
            if (Security_Serv01.empty_string(Client_View_M01.input02, out data01[23]) == true)
            {
                counter01++;
                Client_View_M01.StatusMessage02 = string.Empty;
            }
            else
            {
                Client_View_M01.StatusMessage02 = data01[23];
                counter01--;

            }
            if (counter01 == 2)
            {
                if (MySql_Client_S01.update_clients_apikey_using_apikey(Client_View_M01.input01, Client_View_M01.input02, out data01[25]) == true)
                {
                    Client_View_M01.StatusMessage01 = data01[25];
                }
                else
                {
                    Client_View_M01.StatusMessage02 = data01[25];
                }
            }
            else
            {
                Client_View_M01.StatusMessage02 = "please check errors";
            }
        }
        private void update_clients_cashappdata01_using_cashappdata01()
        {

            if (Security_Serv01.empty_string(Client_View_M01.input01, out data01[23]) == true)
            {
                Client_View_M01.StatusMessage01 = string.Empty;
                counter01++;
            }
            else
            {
                Client_View_M01.StatusMessage01 = data01[23];
                counter01--;
            }
            if (Security_Serv01.empty_string(Client_View_M01.input02, out data01[23]) == true)
            {
                counter01++;
                Client_View_M01.StatusMessage01 = string.Empty;
            }
            else
            {
                Client_View_M01.StatusMessage02 = data01[23];
                counter01--;

            }
            if (counter01 == 2)
            {
                if (MySql_Client_S01.update_clients_cashappdata01_using_cashappdata01(Client_View_M01.input01, Client_View_M01.input02, out data01[25]) == true)
                {
                    Client_View_M01.StatusMessage01 = data01[25];
                }
                else
                {
                    Client_View_M01.StatusMessage02 = data01[25];
                }
            }
            else
            {
                Client_View_M01.StatusMessage02 = "please check errors";
            }
        }
        private void update_clients_email_using_email()
        {

            if (Security_Serv01.empty_string(Client_View_M01.input01, out data01[23]) == true)
            {
                if (Security_Serv01.email_check(Client_View_M01.input01, out data01[24]) == true)
                {
                    Client_View_M01.StatusMessage01 = string.Empty;
                    counter01++;
                }
                else
                {
                    Client_View_M01.StatusMessage01 = data01[24];
                    counter01--;
                }
            }
            else
            {
                Client_View_M01.StatusMessage01 = data01[23];
                counter01--;
            }

            if (Security_Serv01.empty_string(Client_View_M01.input02, out data01[23]) == true)
            {
                if (Security_Serv01.email_check(Client_View_M01.input02, out data01[24]) == true)
                {
                    Client_View_M01.StatusMessage02 = string.Empty;
                    counter01++;
                }
                else
                {
                    Client_View_M01.StatusMessage02 = data01[24];
                    counter01--;
                }
            }
            else
            {
                Client_View_M01.StatusMessage02 = data01[23];
                counter01--;
            }
            if (counter01 == 2)
            {
                if (MySql_Client_S01.update_clients_email_using_email(Client_View_M01.input01, Client_View_M01.input02, out data01[25]) == true)
                {
                    Client_View_M01.StatusMessage01 = data01[25];
                }
                else
                {
                    Client_View_M01.StatusMessage02 = data01[25];
                }
            }
            else
            {
                Client_View_M01.StatusMessage02 = "please check errors";
            }
        }
        private void update_clients_logo_using_logo()
        {


            if (Security_Serv01.empty_string(Client_View_M01.input01, out data01[23]) == true)
            {
                Client_View_M01.StatusMessage01 = string.Empty;
                counter01++;
            }
            else
            {
                Client_View_M01.StatusMessage01 = data01[23];
                counter01--;
            }
            if (Security_Serv01.empty_string(Client_View_M01.input02, out data01[23]) == true)
            {
                counter01++;
                Client_View_M01.StatusMessage02 = string.Empty;
            }
            else
            {
                Client_View_M01.StatusMessage02 = data01[23];
                counter01--;

            }
            if (counter01 == 2)
            {
                if (MySql_Client_S01.update_clients_logo_using_logo(Client_View_M01.input01, Client_View_M01.input02, out data01[25]) == true)
                {
                    Client_View_M01.StatusMessage02 = data01[25];
                }
                else
                {
                    Client_View_M01.StatusMessage02 = data01[25];
                }
            }
            else
            {
                Client_View_M01.StatusMessage02 = "please check errors";
            }
        }
        private void update_clients_name_using_name()
        {


            if (Security_Serv01.empty_string(Client_View_M01.input01, out data01[23]) == true)
            {
                Client_View_M01.StatusMessage01 = string.Empty;
                counter01++;
            }
            else
            {
                Client_View_M01.StatusMessage01 = data01[23];
                counter01--;
            }
            if (Security_Serv01.empty_string(Client_View_M01.input02, out data01[23]) == true)
            {
                counter01++;
                Client_View_M01.StatusMessage02 = string.Empty;
            }
            else
            {
                Client_View_M01.StatusMessage02 = data01[23];
                counter01--;

            }
            if (counter01 == 2)
            {
                if (MySql_Client_S01.update_clients_logo_using_logo(Client_View_M01.input01, Client_View_M01.input02, out data01[25]) == true)
                {
                    Client_View_M01.StatusMessage02 = data01[25];
                }
                else
                {
                    Client_View_M01.StatusMessage02 = data01[25];
                }
            }
            else
            {
                Client_View_M01.StatusMessage02 = "please check errors";
            }

        }
        private void update_clients_paypalappdata01_using_paypalappdata01()
        {


            if (Security_Serv01.empty_string(Client_View_M01.input01, out data01[23]) == true)
            {
                Client_View_M01.StatusMessage01 = string.Empty;
                counter01++;
            }
            else
            {
                Client_View_M01.StatusMessage01 = data01[23];
                counter01--;
            }
            if (Security_Serv01.empty_string(Client_View_M01.input02, out data01[23]) == true)
            {
                counter01++;
                Client_View_M01.StatusMessage02 = string.Empty;
            }
            else
            {
                Client_View_M01.StatusMessage02 = data01[23];
                counter01--;

            }
            if (counter01 == 2)
            {
                if (MySql_Client_S01.update_clients_paypalappdata01_using_paypalappdata01(Client_View_M01.input01, Client_View_M01.input02, out data01[25]) == true)
                {
                    Client_View_M01.StatusMessage02 = data01[25];
                }
                else
                {
                    Client_View_M01.StatusMessage02 = data01[25];
                }
            }
            else
            {
                Client_View_M01.StatusMessage02 = "please check errors";

            }
        }
        private void update_clients_phnenumber_using_phonenumber()
        {


            if (Security_Serv01.empty_string(Client_View_M01.input01, out data01[23]) == true)
            {
                if (Security_Serv01.phone_check(Client_View_M01.input01, out data01[24]) == true)
                {
                    Client_View_M01.StatusMessage01 = string.Empty;
                    counter01++;
                }
                else
                {
                    Client_View_M01.StatusMessage01 = data01[24];
                    counter01--;
                }
            }
            else
            {
                Client_View_M01.StatusMessage01 = data01[23];
                counter01--;
            }

            if (Security_Serv01.empty_string(Client_View_M01.input02, out data01[23]) == true)
            {
                if (Security_Serv01.phone_check(Client_View_M01.input02, out data01[24]) == true)
                {
                    Client_View_M01.StatusMessage02 = string.Empty;
                    counter01++;
                }
                else
                {
                    Client_View_M01.StatusMessage02 = data01[24];
                    counter01--;
                }
            }
            else
            {
                Client_View_M01.StatusMessage02 = data01[23];
                counter01--;
            }
            if (counter01 == 2)
            {
                if (MySql_Client_S01.update_clients_phnenumber_using_phonenumber(Client_View_M01.input01, Client_View_M01.input02, out data01[25]) == true)
                {
                    Client_View_M01.StatusMessage01 = data01[25];
                }
                else
                {
                    Client_View_M01.StatusMessage02 = data01[25];
                }
            }
            else
            {
                Client_View_M01.StatusMessage02 = "please check errors";
            }
        }
        private void update_clients_venmoappdata01_using_venmoappdata01()
        {


            if (Security_Serv01.empty_string(Client_View_M01.input01, out data01[23]) == true)
            {
                Client_View_M01.StatusMessage01 = string.Empty;
                counter01++;
            }
            else
            {
                Client_View_M01.StatusMessage01 = data01[23];
                counter01--;
            }
            if (Security_Serv01.empty_string(Client_View_M01.input02, out data01[23]) == true)
            {
                counter01++;
                Client_View_M01.StatusMessage02 = string.Empty;
            }
            else
            {
                Client_View_M01.StatusMessage02 = data01[23];
                counter01--;

            }
            if (counter01 == 2)
            {
                if (MySql_Client_S01.update_clients_venmoappdata01_using_venmoappdata01(Client_View_M01.input01, Client_View_M01.input02, out data01[25]) == true)
                {
                    Client_View_M01.StatusMessage02 = data01[25];
                }
                else
                {
                    Client_View_M01.StatusMessage02 = data01[25];
                }
            }
            else
            {
                Client_View_M01.StatusMessage02 = "please check errors";

            }
        }
        private void update_clients_zelleappdata01_using_zellappdata01()
        {


            if (Security_Serv01.empty_string(Client_View_M01.input01, out data01[23]) == true)
            {
                Client_View_M01.StatusMessage01 = string.Empty;
                counter01++;
            }
            else
            {
                Client_View_M01.StatusMessage01 = data01[23];
                counter01--;
            }
            if (Security_Serv01.empty_string(Client_View_M01.input02, out data01[23]) == true)
            {
                counter01++;
                Client_View_M01.StatusMessage02 = string.Empty;
            }
            else
            {
                Client_View_M01.StatusMessage02 = data01[23];
                counter01--;

            }
            if (counter01 == 2)
            {
                if (MySql_Client_S01.update_clients_zelleappdata01_using_zellappdata01(Client_View_M01.input01, Client_View_M01.input02, out data01[25]) == true)
                {
                    Client_View_M01.StatusMessage02 = data01[25];
                }
                else
                {
                    Client_View_M01.StatusMessage02 = data01[25];
                }
            }
            else
            {
                Client_View_M01.StatusMessage02 = "please check errors";

            }

        }
        private void view_all_client_data()
        {
            if (MySql_Client_S01.view_all_client_data(out data01[23]) == true)
            {
                Client_View_M01.StatusMessage01 = data01[23];
            }
            else
            {
                Client_View_M01.StatusMessage01 = data01[23];
            }

        }
        private void Picker01_SelectedIndexChanged()
        {
            switch (stored_procedure_array[int.Parse(Client_View_M01.SelectedProject)])
            {
                case "delete_client_using_email":
                    load_default_view();
                    break;
                case "delete_client_using_name":
                    load_default_view();
                    break;
                case "delete_client_using_phonenumber":
                    load_default_view();
                    break;
                case "find_client_api_key_by_emailaddress":
                    load_default_view();
                    break;
                case "find_client_api_key_by_name":
                    load_default_view();
                    break;
                case "find_client_api_key_by_phonnumeber":
                    load_default_view();
                    break;
                case "find_client_apikey_by_apikey":
                    load_default_view();
                    break;
                case "find_client_apikey_by_cashappdata01":
                    load_default_view();
                    break;
                case "find_client_apikey_by_paypalappdata01":
                    load_default_view();
                    break;
                case "find_client_apikey_by_venmoappdata01":
                    load_default_view();
                    break;
                case "find_client_cashappdata01_by_apikey":
                    load_default_view();
                    break;
                case "find_client_cashappdata01_by_cashappdata01":
                    load_default_view();
                    break;
                case "find_client_cashappdata01_by_emailaddress":
                    load_default_view();
                    break;
                case "find_client_cashappdata01_by_name":
                    load_default_view();
                    break;
                case "find_client_cashappdata01_by_paypalappdata01":
                    load_default_view();
                    break;
                case "find_client_cashappdata01_by_phonnumeber":
                    load_default_view();
                    break;
                case "find_client_cashappdata01_by_venmoappdata01":
                    load_default_view();
                    break;
                case "find_client_colors_using_emailaddress":
                    load_default_view();
                    break;
                case "find_client_colors_using_name":
                    load_default_view();
                    break;
                case "find_client_colors_using_phonenumber":
                    load_default_view();
                    break;
                case "find_client_data_using_email":
                    load_default_view();
                    break;
                case "find_client_data_using_latitude_and_longitude":
                    load_default_view();
                    break;
                case "find_client_data_using_logo":
                    load_default_view();
                    break;
                case "find_client_data_using_name":
                    load_default_view();
                    break;
                case "find_client_data_using_number":
                    load_default_view();
                    break;
                case "find_client_emailaddress_by_apikey":
                    load_default_view();
                    break;
                case "find_client_emailaddress_by_cashappdata01":
                    load_default_view();
                    break;
                case "find_client_emailaddress_by_emailaddress":
                    load_default_view();
                    break;
                case "find_client_emailaddress_by_name":
                    load_default_view();
                    break;
                case "find_client_emailaddress_by_paypalappdata01":
                    load_default_view();
                    break;
                case "find_client_emailaddress_by_phonnumeber":
                    load_default_view();
                    break;
                case "find_client_emailaddress_by_venmoappdata01":
                    load_default_view();
                    break;
                case "find_client_location_using_emailaddress":
                    load_default_view();
                    break;
                case "find_client_location_using_name":
                    load_default_view();
                    break;
                case "find_client_location_using_phonenumber":
                    load_default_view();
                    break;
                case "find_client_logo_by_emailaddress":
                    load_default_view();
                    break;
                case "find_client_logo_by_logo":
                    load_default_view();
                    break;
                case "find_client_logo_by_name":
                    load_default_view();
                    break;
                case "find_client_logo_by_phonenumber":
                    load_default_view();
                    break;
                case "find_client_name_by_cashappdata01":
                    load_default_view();
                    break;
                case "find_client_name_by_emailaddress":
                    load_default_view();
                    break;
                case "find_client_name_by_name":
                    load_default_view();
                    break;
                case "find_client_name_by_paypalappdata01":
                    load_default_view();
                    break;
                case "find_client_name_by_phonnumeber":
                    load_default_view();
                    break;
                case "find_client_name_by_venmoappdata01":
                    load_default_view();
                    break;
                case "find_client_paypalappdata01_by_apikey":
                    load_default_view();
                    break;
                case "find_client_paypalappdata01_by_cashappdata01":
                    load_default_view();
                    break;
                case "find_client_paypalappdata01_by_emailaddress":
                    load_default_view();
                    break;
                case "find_client_paypalappdata01_by_name":
                    load_default_view();
                    break;
                case "find_client_paypalappdata01_by_paypalappdata01":
                    load_default_view();
                    break;
                case "find_client_paypalappdata01_by_phonnumeber":
                    load_default_view();
                    break;
                case "find_client_paypalappdata01_by_venmoappdata01":
                    load_default_view();
                    break;
                case "find_client_phonenumber_by_apikey":
                    load_default_view();
                    break;
                case "find_client_phonenumber_by_cashappdata01":
                    load_default_view();
                    break;
                case "find_client_phonenumber_by_emailaddress":
                    load_default_view();
                    break;
                case "find_client_phonenumber_by_name":
                    load_default_view();
                    break;
                case "find_client_phonenumber_by_paypalappdata01":
                    load_default_view();
                    break;
                case "find_client_phonenumber_by_phonnumeber":
                    load_default_view();
                    break;
                case "find_client_phonenumber_by_venmoappdata01":
                    load_default_view();
                    break;
                case "find_client_venmoappdata01_by_apikey":
                    load_default_view();
                    break;
                case "find_client_venmoappdata01_by_cashappdata01":
                    load_default_view();
                    break;
                case "find_client_venmoappdata01_by_emailaddress":
                    load_default_view();
                    break;
                case "find_client_venmoappdata01_by_name":
                    load_default_view();
                    break;
                case "find_client_venmoappdata01_by_paypalappdata01":
                    load_default_view();
                    break;
                case "find_client_venmoappdata01_by_phonnumeber":
                    load_default_view();
                    break;
                case "find_client_venmoappdata01_by_venmoappdata01":
                    load_default_view();
                    break;
                case "find_client_zellaappdata01_by_apikey":
                    load_default_view();
                    break;
                case "find_client_zellaappdata01_by_zellaappdata01":
                    load_default_view();
                    break;
                case "find_client_zelleappdata01_by_cashappdata01":
                    load_default_view();
                    break;
                case "find_client_zelleappdata01_by_emailaddress":
                    load_default_view();
                    break;
                case "find_client_zelleappdata01_by_name":
                    load_default_view();
                    break;
                case "find_client_zelleappdata01_by_phonnumeber":
                    load_default_view();
                    break;
                case "find_client_zelleappdata01_by_venmoappdata01":
                    load_default_view();
                    break;
                case "insert_client_data":
                    load_default_view();
                    break;
                case "update_clients_apikey_using_apikey":
                    load_default_view();
                    break;
                case "update_clients_cashappdata01_using_cashappdata01":
                    load_default_view();
                    break;
                case "update_clients_email_using_email":
                    load_default_view();
                    break;
                case "update_clients_logo_using_logo":
                    load_default_view();
                    break;
                case "update_clients_name_using_name":
                    load_default_view();
                    break;
                case "update_clients_paypalappdata01_using_paypalappdata01":
                    load_default_view();
                    break;
                case "update_clients_phnenumber_using_phonenumber":
                    load_default_view();
                    break;
                case "update_clients_venmoappdata01_using_venmoappdata01":
                    load_default_view();
                    break;
                case "update_clients_zelleappdata01_using_zellappdata01":
                    load_default_view();
                    break;
                case "view_all_client_data":
                    load_default_view();
                    break;
                default:
                    load_default_view01();

                    break;

            }
        }
        private void load_Selection01()
        {
            if (Security_Serv01.isPicker_selected_web(stored_procedure_array[int.Parse(Client_View_M01.SelectedProject)], out data01[23]) == true)
            {
                string key = stored_procedure_array[int.Parse(Client_View_M01.SelectedProject)].Trim();
                load_Selection_data01();
                if (_commands.TryGetValue(key, out Action action))
                {
                    action();
                    _commands.Clear();
                }
                else
                {
                    Client_View_M01.StatusMessage01 = $"{key} command not found";
                }
            }
            else
            {
                Client_View_M01.StatusMessage01 = data01[23];
            }
        }


        public async Task<IActionResult> OnPostOk()
        {

            load_Selection01();
            return Page();
        }
        public IActionResult OnPostBack()
        {

            return RedirectToPage("/CLIENT_VIEW/CLIENT_MAIN_VIEW/Client_Main_View01");
        }
    }
}