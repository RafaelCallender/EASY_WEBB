using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.RazorPages;
using EASYPROJECT01.EASY_CALLENDER01.MODEL.WEB_MODEL.AI_VIEW_MODEL;
using EASYPROJECT01.EASY_CALLENDER01.SERVICES.AI_SERVICES.AI_TEXT_TO_TEXT;
using EASYPROJECT01.EASY_CALLENDER01.SERVICES.FILES.FILE_HELPER;
using EASYPROJECT01.EASY_CALLENDER01.SERVICES.SECURITY_SERVICES;
using EASYPROJECT01.EASY_CALLENDER01.SERVICES.FILES.FILE_MANAGER;
using System.Diagnostics;

namespace EASYPROJECT01.EASY_WEBB.Pages.AI_VIEW.AI_SELECTION_VIEW
{
    public class Ai_Selection_View02 : PageModel
    {
        [BindProperty]
        public Ai_View_Model02 Ai_View_M02 { get; set; } = new Ai_View_Model02();
        private string[] data01 = new string[100];
        private static Security_Services01 Security_Serv01 = new Security_Services01();
        private static Ai_Text_To_Text01? Ai_Text_To_T01;
        private static string menu_string = $"Ai text generation \n" +
                $"Ai text generation for developers \n" +
                $"Ai text generation for web developers \n";

        private static string[] menu_array = menu_string.Split("\n");
        private static Dictionary<string, Action> _commands = new Dictionary<string, Action>(StringComparer.OrdinalIgnoreCase);
        public void OnGet()
        {
            LoadOptions();
            load_default_view();
        }


        private void load_Selection_View()
        {
            //   Ai_View_M02.image01 = File_Manger02.data01[(int)File_Manger02.image_index.person01];
        }
        private void load_default_view()
        {

            Ai_View_M02.ShowInput01 = false;

        }
        private void load_default_view01()
        {

            Ai_View_M02.ShowInput01 = true;

        }
        public IActionResult OnPost()
        {
            load_default_view();
            if (Security_Serv01.isPicker_selected_web(Ai_View_M02.SelectedProject,
            menu_array, out data01[1]) == true)
            {
                Ai_View_M02.StatusMessage01 = string.Empty;
                Picker01_SelectedIndexChanged();

            }
            else
            {
                Ai_View_M02.StatusMessage01 = data01[1];

            }
            LoadOptions();
            return Page();
        }


        private void LoadOptions()
        {
            Ai_View_M02.ProjectOptions = new List<SelectListItem>();
            for (int i = 0; i < menu_array.Length; i++)
            {
                Ai_View_M02.ProjectOptions.Add(
                    new SelectListItem
                    {
                        Value = (i + 1).ToString(),
                        Text = menu_array[i].Trim()
                    });
            }
        }
        private void load_Selection_data01()
        {

            string procedure =menu_array[int.Parse(Ai_View_M02.SelectedProject) - 1].Trim();
            switch (procedure)
            {

                case "Ai text generation":
                    _commands[procedure] = Ai_text_generation;
                    break;
                case "Ai text generation for developers":
                    _commands[procedure] = Ai_text_generation_for_developers;
                    break;
                case "Ai text generation for web developers":
                    _commands[procedure] = Ai_text_generation_for_web_developers;
                    break;


            }
        }
        private void Ai_text_generation()
        {
            var runnerProjectPath = FindRunnerProjectPath();
            if (runnerProjectPath is null)
            {
                Ai_View_M02.StatusMessage01 = ("Could not locate the .NET 8 AI runner project.");
                Ai_View_M02.StatusMessage01 = ("Run EASYCONSOLE/AI_RUNNER/EASYAI_RUNNER.csproj directly.");
                return;
            }

            var projectRoot = Directory.GetParent(
                Path.GetDirectoryName(runnerProjectPath)!)!.Parent!.FullName;
            var startInfo = new ProcessStartInfo("dotnet")
            {
                WorkingDirectory = projectRoot,
                UseShellExecute = false
            };
            startInfo.ArgumentList.Add("run");
            startInfo.ArgumentList.Add("--project");
            startInfo.ArgumentList.Add(runnerProjectPath);
            startInfo.ArgumentList.Add("--");
            startInfo.ArgumentList.Add(File_Manger05.text_to_text_local01_gguf);

            try
            {
                using var runner = Process.Start(startInfo);
                if (runner is null)
                {
                    Ai_View_M02.StatusMessage01 = ("Failed to start the .NET 8 AI runner.");
                    return;
                }

                runner.WaitForExit();
                if (runner.ExitCode != 0)
                    Ai_View_M02.StatusMessage01 = ($"The AI runner exited with code {runner.ExitCode}.");
            }
            catch (Exception ex)
            {
                Ai_View_M02.StatusMessage01 = ("Failed to start the .NET 8 AI runner.") + (ex);
            }
        }

        private static string? FindRunnerProjectPath()
        {
            var directory = new DirectoryInfo(AppContext.BaseDirectory);
            while (directory is not null)
            {
                var projectPath = Path.Combine(
                    directory.FullName,
                    "EASYCONSOLE",
                    "AI_RUNNER",
                    "EASYAI_RUNNER.csproj");

                //   if (File.Exists(projectPath))
                //     return projectPath;

                directory = directory.Parent;
            }

            return null;
        }
        private void Ai_text_generation_for_developers()
        {
            Ai_View_M02.StatusMessage01 = ("not yet developed");
        }
        private void Ai_text_generation_for_web_developers()
        {
            Ai_View_M02.StatusMessage01 = ("not yet developed");
        }
        private void Picker01_SelectedIndexChanged()
        {
            switch (menu_array[int.Parse(Ai_View_M02.SelectedProject) - 1].Trim())
            {

                case "Ai text generation":
                    load_default_view01();
                    break;
                case "Ai text generation for developers":
                    load_default_view01();
                    break;
                case "Ai text generation for web developers":
                    load_default_view01();
                    break;
                default:
                    load_default_view();
                    break;
            }
        }
        private void load_Selection01()
        {

            string key = menu_array[int.Parse(Ai_View_M02.SelectedProject) - 1].Trim();
            load_Selection_data01();
            if (_commands.TryGetValue(key, out Action action))
            {
                action();
                _commands.Clear();
            }
            else
            {
                Ai_View_M02.StatusMessage01 = $"{key} command not found";
            }

        }
        public IActionResult OnPostOk()
        {

            if (Security_Serv01.isPicker_selected_web(Ai_View_M02.SelectedProject,
                menu_array, out data01[1]) == true)
            {
                Ai_View_M02.StatusMessage01 = string.Empty;
                Picker01_SelectedIndexChanged();
                load_Selection01();
            }
            else
            {
                Ai_View_M02.StatusMessage01 = data01[1];


            }

            LoadOptions();
            return Page();
        }



        public IActionResult OnPostBack()
        {
            return RedirectToPage("/AI_VIEW/AI_MAIN_VIEW/Ai_Main_View01");
        }
    }
}