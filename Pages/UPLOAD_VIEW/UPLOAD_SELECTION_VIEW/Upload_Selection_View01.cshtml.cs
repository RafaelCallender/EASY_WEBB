using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using EASYPROJECT01.EASY_CALLENDER01.SERVICES.SECURITY_SERVICES;
using EASYPROJECT01.EASY_CALLENDER01.MODEL.WEB_MODEL.UPLOAD_VIEW_MODEL;
using EASYPROJECT01.EASY_CALLENDER01.SERVICES.SQL.SQL_SERVICES.SQL_UPLOAD_SERVICES;


namespace EASYPROJECT01.EASY_WEBB.Pages.UPLOAD_VIEW.UPLOAD_SELECTION_VIEW
{
    public class Upload_Selection_View01 : PageModel
    {
        [BindProperty]
        public Upload_View_Model01 Upload_View_M01 { get; set; } = new Upload_View_Model01();
        private static string[] data01 = new string[100];
        private static Security_Services01 Security_S01 = new Security_Services01();
        private static Sql_Upload_Services01 Sql_Upload_S01 = new Sql_Upload_Services01();
        private bool stored_proccedure_bool = Sql_Upload_S01.view_database_storedprocedures(out data01[50]);
        private static string stored_procedure_string = data01[50];
        private static string[] stored_procedure_array = stored_procedure_string.Split("\n");
        private int counter01 = 0;

        public void OnGet()
        {
            OnPost();
        }
        private void load_Selection_View()
        {
            Upload_View_M01.ShowInput01 = false;
            Upload_View_M01.ShowInput02 = false;
            Upload_View_M01.ShowInput03 = false;
            Upload_View_M01.ShowInput04 = false;
        }
        public IActionResult OnPost()
        {
            load_Selection_View();
            Upload_View_M01.ShowInput01 =
    !string.IsNullOrEmpty(Upload_View_M01.SelectedProject);
            LoadOptions();
            load_picker();
            return Page();
        }
        private string load_Upload_Selection_View01_string()
        {
            if (stored_proccedure_bool == true)
            {

                for (int i = 0; i < stored_procedure_array.Length; i++)
                {
                    data01[80] += $"{i}.){stored_procedure_array[i]}\n";
                    load_default_view01();

                }
            }
            else
            {
                load_default_view01();
                //     data01[80] = stored_proccedure_string;
            }
            return data01[80];
        }
        private void load_default_view()
        {
            if (stored_proccedure_bool == true)
            {
                load_default_view01();
            }
            else
            {
                Upload_View_M01.ShowInput01 = false;
                Upload_View_M01.ShowInput02 = false;
                Upload_View_M01.ShowInput03 = false;
                Upload_View_M01.ShowInput04 = false;
                Upload_View_M01.StatusMessage01 = stored_procedure_string;
            }

        }
        private void load_default_view01()
        {

        }
        private void load_default_view02()
        {

        }
        private void LoadOptions()
        {


            Upload_View_M01.ProjectOptions = new List<SelectListItem>();

            for (int i = 0; i < stored_procedure_array.Length; i++)
            {
                Upload_View_M01.ProjectOptions.Add(
                    new SelectListItem
                    {
                        Value = (i + 1).ToString(),
                        Text = stored_procedure_array[i].Trim()
                    });
            }
        }

        private void load_picker()
        {
            switch (Upload_View_M01.SelectedProject)
            {
                case "1":
                    Upload_View_M01.label01 = "full name";
                    Upload_View_M01.label02 = "Email Addresss";
                    Upload_View_M01.label03 = "Phonenumber";
                    Upload_View_M01.label04 = "Message";
                    Upload_View_M01.ShowInput01 = true;
                    Upload_View_M01.ShowInput02 = true;
                    Upload_View_M01.ShowInput03 = true;
                    Upload_View_M01.ShowInput04 = true;
                    break;
                default:
                    Upload_View_M01.label01 = string.Empty;
                    Upload_View_M01.ShowInput01 = false;
                    break;
            }
        }

        private void Page_Check()
        {
            if (!string.IsNullOrEmpty(Upload_View_M01.SelectedProject))
            {
                switch (Upload_View_M01.SelectedProject)
                {
                    case "1":
                        if (Security_S01.empty_string(Upload_View_M01.input01, out data01[10]) == true)
                        {
                            counter01++;

                        }
                        else
                        {
                            Upload_View_M01.StatusMessage01 = data01[10];
                            counter01--;
                        }
                        if (Security_S01.empty_string(Upload_View_M01.input02, out data01[10]) == true)
                        {
                            if (Security_S01.email_check(Upload_View_M01.input02, out data01[11]) == true)
                            {
                                counter01++;
                            }
                            else
                            {
                                Upload_View_M01.StatusMessage02 = data01[11];
                                counter01--;
                            }


                        }
                        else
                        {
                            Upload_View_M01.StatusMessage02 = data01[10];
                            counter01--;
                        }
                        if (Security_S01.empty_string(Upload_View_M01.input03, out data01[10]) == true)
                        {
                            if (Security_S01.phone_check(Upload_View_M01.input03, out data01[11]) == true)
                            {
                                counter01++;
                            }
                            else
                            {
                                Upload_View_M01.StatusMessage03 = data01[11];
                                counter01--;
                            }

                        }
                        else
                        {
                            Upload_View_M01.StatusMessage03 = data01[10];
                            counter01--;
                        }
                        if (Security_S01.empty_string(Upload_View_M01.input04, out data01[10]) == true)
                        {
                            counter01++;

                        }
                        else
                        {
                            Upload_View_M01.StatusMessage04 = data01[10];
                            counter01--;
                        }
                        if (counter01 == 4)
                        {


                            /*        if (Sql_Upload_S01.insert_email(Upload_View_M01.input01, Upload_View_M01.input02, Upload_View_M01.input03, Upload_View_M01.input04, out data01[11]) == true)
                                    {
                                        Upload_View_M01.StatusMessage01 = $"{data01[10]}\n" +
                                                                       $"{data01[11]}\n";

                                    }
                                    else
                                    {
                                        Upload_View_M01.StatusMessage01 = data01[11];
                                    }*/

                            Upload_View_M01.StatusMessage01 = "not yet developed";

                        }
                        else
                        {
                            Upload_View_M01.StatusMessage01 = "please check errors";

                        }
                        break;
                }
            }
            else
            {
                Upload_View_M01.StatusMessage01 = "please select an item";
            }

        }
        public IActionResult OnPostOk()
        {

            Page_Check();
            OnPost();
            return Page();
        }
        public IActionResult OnPostBack()
        {

            return RedirectToPage("UPLOAD_VIEW/UPLOAD_MAIN_VIEW/Upload_Main_View01");
        }
    }
}
