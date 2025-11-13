using Licence.Helpers;
using Licence.Models;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Licence.Services
{
    public class LicenseService
    {
        private static LicenseService _instance;
        private static readonly object _lock = new object();
        private System.Threading.Timer _timer;
        public static string path = @"XanTech\XanPOS";

        //private bool _isChecking = false;
        private readonly List<TimeSpan> _controlTimes = new List<TimeSpan>
        {
         new TimeSpan(15, 0, 0),
        };
        private TimeSpan _lastCheckedTime = TimeSpan.MinValue;
        private LicenseService() { }

        public static LicenseService Instance
        {
            get
            {
                lock (_lock)
                {
                    if (_instance == null)
                        _instance = new LicenseService();

                    return _instance;
                }
            }
        }

        public string GetLicenceKey()
        {
            string key = "Yoxdur";
            if (Registry.GetValue($@"HKEY_CURRENT_USER\{path}", "ProductID", null) == null)
            {
                Registry.CurrentUser.CreateSubKey(path).SetValue("ProductID", "Yoxdur");
            }
            else
            {
                key = Registry.CurrentUser.OpenSubKey(path).GetValue("ProductID").ToString();
            }
            return key;
        }

        public async Task<bool> Create(string json, string key)
        {
            ApiHandler api = new ApiHandler()
            {
                Url = $"https://xanpos-xantech-default-rtdb.firebaseio.com/Client/{key}.json",
                Method = HttpMethod.Put,
                Body = json
            };

            var response = await api.SendRequest();
            if (response.StatusCode is System.Net.HttpStatusCode.OK)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void Start()
        {
            _timer = new System.Threading.Timer(async _ => await CheckScheduledTimes(), null, 0, 60 * 1000);
        }

        public void Stop()
        {
            if (_timer != null)
                _timer.Dispose();
        }

        private async Task CheckScheduledTimes()
        {
            TimeSpan now = DateTime.Now.TimeOfDay;

            foreach (var target in _controlTimes)
            {
                if (now.Hours == target.Hours && now.Minutes == target.Minutes && _lastCheckedTime != target)
                {
                    _lastCheckedTime = target;

                    var user = await GetKeyControl(GetLicenceKey());
                    if (user != null)
                    {
                        if (!user.IsActive || !LicenceExpireDateControl(user))
                        {
                            AppService.mutex.Dispose();
                            Process.Start(Application.ExecutablePath);
                            await Task.Delay(500);
                            Environment.Exit(0);
                        }
                    }


                    break;
                }
            }
        }

        public async Task<Client> GetKeyControl(string key)
        {
            if (!FormHelpers.HasInternetConnection())
            {
                //   XtraMessageBox.Show("İnternet bağlantınız yoxdur.", "Xəta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }

            if (string.IsNullOrWhiteSpace(key) || key is "Yoxdur")
            {
                return null;
            }

            ApiHandler api = new ApiHandler()
            {
                Url = $"https://xanpos-xantech-default-rtdb.firebaseio.com/Client/{key}.json",
                Method = HttpMethod.Get,
            };


            var response = await api.SendRequest();
            if (response.StatusCode is System.Net.HttpStatusCode.OK)
            {
                string responseBody = await response.Content.ReadAsStringAsync();
                if (string.IsNullOrWhiteSpace(responseBody))
                    return null;
                else
                    return System.Text.Json.JsonSerializer.Deserialize<Client>(responseBody);
            }
            else
            {
                return null;
            }
        }

        public bool LicenceExpireDateControl(Client user)
        {
            if (user == null || user?.LicenceExpireDate == null)
                return false;

            DateTime currentDate = DateTime.Now.Date;
            return user.LicenceExpireDate.Date > currentDate;
        }

        private static void ShowDeactiveForm()
        {
            foreach (var form in Application.OpenForms.Cast<Form>().ToList())
            {
                if (form.Name != "fDeactive")
                {
                    if (form.IsHandleCreated)
                        form.Invoke((Action)(() => form.Close()));
                    else
                        form.Close();
                }
            }
        }
    }
}
