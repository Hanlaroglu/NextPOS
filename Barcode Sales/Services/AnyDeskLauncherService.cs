using System;
using System.Diagnostics;
using System.IO;
using Microsoft.Win32;

namespace Barcode_Sales.Services
{
    public static class AnyDeskLauncherService
    {
        public static bool TryLaunch(out string errorMessage)
        {
            errorMessage = null;

            string path = FindAnyDeskPath();

            if (path == null)
            {
                errorMessage = "AnyDesk tapılmadı.";
                return false;
            }

            try
            {
                Process.Start(new ProcessStartInfo(path) { UseShellExecute = true });
                return true;
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;
                return false;
            }
        }

        private static string FindAnyDeskPath()
        {
            string[] defaultPaths =
            {
                Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), @"AnyDesk\AnyDesk.exe"),
                @"C:\Program Files (x86)\AnyDesk\AnyDesk.exe",
                @"C:\Program Files\AnyDesk\AnyDesk.exe"
            };

            string foundPath = Array.Find(defaultPaths, File.Exists);
            if (foundPath != null)
                return foundPath;

            try
            {
                using (var key = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall\AnyDesk"))
                {
                    var installLocation = key?.GetValue("InstallLocation") as string;

                    if (!string.IsNullOrWhiteSpace(installLocation))
                    {
                        installLocation = installLocation.Trim().Trim('"');
                        string regPath = Path.Combine(installLocation, "AnyDesk.exe");

                        if (File.Exists(regPath))
                            return regPath;
                    }
                }
            }
            catch
            {
                return null;
            }

            return null;
        }
    }
}
