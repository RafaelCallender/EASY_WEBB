using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.ObjectModel;
using EASYPROJECT01.EASY_CALLENDER01.MODEL.WEB_MODEL.LOCATION_VIEW_MODEL;
using EASYPROJECT01.EASY_CALLENDER01.SERVICES.SECURITY_SERVICES;
using EASYPROJECT01.EASY_CALLENDER01.SERVICES.DEVICES.DEVICE_SERVICES;
using EASYPROJECT01.EASY_CALLENDER01.SERVICES.LOCATION.LOCATION_HELPER;
using EASYPROJECT01.EASY_CALLENDER01.SERVICES.LOCATION.LOCATION_MANAGER;
using EASYPROJECT01.EASY_CALLENDER01.SERVICES.DEVICES.DEVICE_SERVICES;
using EASYPROJECT01.EASY_CALLENDER01.SERVICES.LOCATION.LOCATION_MANAGER;
using EASYPROJECT01.EASY_CALLENDER01.SERVICES.LOCATION.LOCATION_SERVICES;
using EASYPROJECT01.EASY_CALLENDER01.SERVICES.LOCATION.LOCATION_HELPER;
using EASYPROJECT01.EASY_CALLENDER01.MODEL.LOCATION_MODEL.LOCATION_SET_MODEL;

namespace EASYPROJECT01.EASY_WEBB.Pages.LOCATION_VIEW.LOCATION_SELECTION_VIEW
{
    public class Location_Selection_View01 : PageModel
    {
        [BindProperty]
        public Location_View_Model01 Location_View_M01 { get; set; } = new Location_View_Model01();
        private static string[] data01 = new string[100];
        private static Security_Services01 Security_Serv01 = new Security_Services01();
        private static Location_Services01 Location_Serv01 = new Location_Services01();
        private static Location_Services02 Location_Serv02 = new Location_Services02();
        private static Location_Services03 Location_Serv03 = new Location_Services03();
        private static string menu_string01 =
                 "get_city_mobile01\n" +
"get_state_mobile01\n" +
"get_country_mobile01\n" +
"get_longitude_mobile\n" +
"get_latitude_mobile\n" +
"get device full location mobile\n" +
"GetLocationDataAsync\n" +
"GetLocationDataAsync01\n" +
  "GetCoordinates\n" +
"show Map\n";
        private static string[] menu_array01 = menu_string01
            .Split('\n', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);
        private static Dictionary<string, Action> _commands = new Dictionary<string, Action>(StringComparer.OrdinalIgnoreCase);
        private static string[] location_array { get; set; }
        private static ObservableCollection<Location_Set_Model01> Items01 { get; set; } = new ObservableCollection<Location_Set_Model01>();
        private static Device_Services01 Device_S01 = new Device_Services01();
        public void OnGet()
        {
            OnPost();

        }
        private async void load_location01()
        {
            string result = await set_mobile_location();
            location_array = result.Split('\n');

        }
        private static async Task<string> set_mobile_location()
        {
            try
            {
                var res = await Device_S01.get_mobile_location01();
                if (res.success == true)
                {
                    data01[60] = res.output;
                }
                else
                {

                    data01[60] = $"{res.output}";
                }
            }
            catch (Exception ex)
            {

                data01[60] = $"Unable to get mobile location: {ex.Message}";
            }
            return data01[60];
        }


        private void Picker01_SelectedIndexChanged()
        {
            switch (menu_array01[int.Parse(Location_View_M01.SelectedProject) - 1].Trim())
            {
                case "get_city_mobile01":
                    load_default_view();
                    break;
                case "get_state_mobile01":
                    load_default_view();
                    break;
                case "get_country_mobile01":
                    load_default_view();
                    break;
                case "get_longitude_mobile":
                    load_default_view();
                    break;
                case "get_latitude_mobile":
                    load_default_view();
                    break;
                case "get device full location mobile":
                    load_default_view();
                    break;
                case "show Map":
                    load_default_view();
                    break;
                case "GetLocationDataAsync":
                    load_default_view03();
                    break;
                case "GetLocationDataAsync01":
                    load_default_view01();
                    break;
                case "GetCoordinates":
                    load_default_view03();
                    break;
                default:
                    load_default_view();
                    break;

            }
        }


        public IActionResult OnPost()
        {

            load_default_view();
            if (Security_Serv01.isPicker_selected_web(Location_View_M01.SelectedProject,
            menu_array01, out data01[1]) == true)
            {
                Location_View_M01.StatusMessage01 = string.Empty;
                Picker01_SelectedIndexChanged();

            }
            else
            {
                Location_View_M01.StatusMessage01 = data01[1];

            }
            LoadOptions();
            return Page();
        }


        private void LoadOptions()
        {
            Location_View_M01.ProjectOptions = new List<SelectListItem>();
            for (int i = 0; i < menu_array01.Length; i++)
            {
                Location_View_M01.ProjectOptions.Add(
                    new SelectListItem
                    {
                        Value = (i + 1).ToString(),
                        Text = menu_array01[i].Trim()

                    });
            }
        }


        private void load_Selection_data01()
        {
            string procedure = menu_array01[int.Parse(Location_View_M01.SelectedProject) - 1].Trim();
            switch (procedure)
            {


                case "get_city_mobile01":
                    _commands[procedure] = get_city_mobile01;
                    break;
                case "get_state_mobile01":
                    _commands[procedure] = get_state_mobile01;
                    break;
                case "get_country_mobile01":
                    _commands[procedure] = get_country_mobile01;
                    break;
                case "get_longitude_mobile":
                    _commands[procedure] = get_longitude_mobile;
                    break;
                case "get_latitude_mobile":
                    _commands[procedure] = get_latitude_mobile;
                    break;
                case "get device full location mobile":
                    _commands[procedure] = get_device_full_location_mobile;
                    break;
                case "show Map":
                    _commands[procedure] = show_Map;
                    break;
                case "GetLocationDataAsync":
                    _commands[procedure] = GetLocationDataAsync;
                    break;
                case "GetLocationDataAsync01":
                    _commands[procedure] = GetLocationDataAsync01;
                    break;
                case "GetCoordinates":
                    _commands[procedure] = GetCoordinates;
                    break;
            }
        }
        private async void show_Map()
        {
            var res = await Security_Serv01.is_connected_to_netwrok_linux();
            if (res.success == true)
            {
                load_default_view03();
                Location_View_M01.Latitude = double.Parse(location_array[4].Trim());
                Location_View_M01.Longitude = double.Parse(location_array[3].Trim());
                Location_View_M01.StatusMessage01 = $"{Location_View_M01.Latitude}\n" +
                                                    $"{Location_View_M01.Latitude}\n";
            }
            else
            {
                Location_View_M01.StatusMessage01 = res.output;
                load_default_view();

            }
        }

        private async void get_device_full_location_mobile()
        {
            var res = await Security_Serv01.is_connected_to_netwrok_linux();
            if (res.success == true)
            {
                for (int i = 0; i < location_array.Length; i++)
                {
                    Location_View_M01.StatusMessage01 += location_array[i];
                }
                var a = new Location_Set_Model01
                {
                    City = location_array[0],
                    State = location_array[1],
                    CountryName = location_array[2],
                    Longitude = location_array[3],
                    Latitude = location_array[4],

                };
                Items01.Add(a);
                // CollectionView01.ItemsSource = Items01;
            }
            else
            {
                Location_View_M01.StatusMessage01 = res.output;
            }
        }

        private async void get_city_mobile01()
        {
            var res = await Security_Serv01.is_connected_to_netwrok_linux();
            if (res.success == true)
            {
                Location_View_M01.StatusMessage01 = location_array[0];
            }
            else
            {
                Location_View_M01.StatusMessage01 = res.output;
            }

        }
        private async void GetLocationDataAsync()
        {

            if (Security_Serv01.empty_string(Location_View_M01.input01, out data01[23]) == true)
            {
                var res = await Security_Serv01.is_connected_to_netwrok_linux();
                if (res.success == true)
                {
                    try
                    {
                        data01[30] = await Location_Serv02.GetLocationDataAsync(Location_View_M01.input01);
                        string[] res01 = data01[30].Split("\n");
                        Location_View_M01.Latitude = double.Parse(res01[0].Trim());
                        Location_View_M01.Longitude = double.Parse(res01[1].Trim());
                        Location_View_M01.StatusMessage01 = $"{Location_View_M01.Latitude}\n" +
                                                            $"{Location_View_M01.Latitude}\n" +
                                                                $"{data01[30]}\n";


                    }
                    catch (Exception ex)
                    {
                        Location_View_M01.StatusMessage01 = $"Location lookup failed: {ex.Message}";
                    }
                }
                else
                {
                    Location_View_M01.StatusMessage01 = res.output;
                }
            }
            else
            {
                Location_View_M01.StatusMessage01 = data01[23];
            }
        }
        private async void GetLocationDataAsync01()
        {
            if (Security_Serv01.empty_string(Location_View_M01.input01, out data01[23]) == true)
            {
                var res = await Security_Serv01.is_connected_to_netwrok_linux();
                if (res.success == true)
                {
                    try
                    {
                        data01[30] = await Location_Serv01.GetLocationDataAsync01(Location_View_M01.input01);
                        Location_View_M01.StatusMessage01 = $"{data01[30]}\n";
                    }
                    catch (Exception ex)
                    {
                        Location_View_M01.StatusMessage01 = $"Location lookup failed: {ex.Message}";
                    }
                }
                else
                {
                    Location_View_M01.StatusMessage01 = res.output;
                }
            }
            else
            {
                Location_View_M01.StatusMessage01 = data01[23];
            }
        }
        private async void get_state_mobile01()
        {
            var res = await Security_Serv01.is_connected_to_netwrok_linux();
            if (res.success == true)
            {
                Location_View_M01.StatusMessage01 = location_array[1];
            }
            else
            {
                Location_View_M01.StatusMessage01 = res.output;
            }

        }
        private async void get_country_mobile01()
        {
            var res = await Security_Serv01.is_connected_to_netwrok_linux();
            if (res.success == true)
            {
                Location_View_M01.StatusMessage01 = location_array[2];
            }
            else
            {
                Location_View_M01.StatusMessage01 = res.output;
            }
        }
        private async void get_longitude_mobile()
        {
            var res = await Security_Serv01.is_connected_to_netwrok_linux();
            if (res.success == true)
            {
                Location_View_M01.StatusMessage01 = location_array[3];
            }
            else
            {
                Location_View_M01.StatusMessage01 = res.output;
            }
        }
        private async void get_latitude_mobile()
        {
            var res = await Security_Serv01.is_connected_to_netwrok_linux();
            if (res.success == true)
            {

                Location_View_M01.StatusMessage01 = location_array[4];
            }
            else
            {
                Location_View_M01.StatusMessage01 = res.output;
            }


        }
        private async void GetCoordinates()
        {
            
            if (Security_Serv01.empty_string(Location_View_M01.input01, out data01[23]) == true)
            {
                var res = await Security_Serv01.is_connected_to_netwrok_linux();
                if (res.success == true)
                {
                    try
                    {
                        data01[30] = await Location_Serv03.GetCoordinates(Location_View_M01.input01);
                        string[] array01 = data01[30].Split();
                        Location_View_M01.Latitude = double.Parse(array01[1].Trim());
                        Location_View_M01.Longitude = double.Parse(array01[2].Trim());
                        Location_View_M01.StatusMessage01 = $"{Location_View_M01.Latitude}\n" +
                                                            $"{Location_View_M01.Latitude}\n" +
                                                                $"{data01[30]}\n";

                    }
                    catch (Exception ex)
                    {
                        Location_View_M01.StatusMessage01 = $"Location lookup failed: {ex.Message}";
                    }
                }
                else
                {
                    Location_View_M01.StatusMessage01 = res.output;
                }
            }
            else
            {
                Location_View_M01.StatusMessage01 = data01[23];
            }


        }


        private void load_default_view()
        {
            Location_View_M01.ShowInput01 = false;
            Location_View_M01.ShowInput02 = false;

        }
        private void load_default_view01()
        {
            Location_View_M01.ShowInput01 = true;
            Location_View_M01.ShowInput02 = false;

        }
        private void load_default_view02()
        {
            Location_View_M01.ShowInput01 = false;
            Location_View_M01.ShowInput02 = true;

        }
        private void load_default_view03()
        {
            Location_View_M01.ShowInput01 = true;
            Location_View_M01.ShowInput02 = true;

        }
        private void load_Selection01()
        {

            string key = menu_array01[int.Parse(Location_View_M01.SelectedProject) - 1].Trim();
            load_Selection_data01();
            if (_commands.TryGetValue(key, out Action action))
            {
                action();
                _commands.Clear();
            }
            else
            {
                Location_View_M01.StatusMessage01 = $"{key} command not found";
            }

        }
        public IActionResult OnPostOk()
        {

            if (Security_Serv01.isPicker_selected_web(Location_View_M01.SelectedProject,
        menu_array01, out data01[1]) == true)
            {

                Picker01_SelectedIndexChanged();
                load_Selection01();
            }
            else
            {
                Location_View_M01.StatusMessage01 = data01[1];


            }

            LoadOptions();
            return Page();
        }

        public IActionResult OnPostBack()
        {
            return RedirectToPage("/LOCATION_VIEW/LOCATION_MAIN_VIEW/Location_Main_View01");
        }
    }
}
