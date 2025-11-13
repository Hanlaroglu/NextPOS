using System;

namespace Licence.Helpers
{
    public class FormHelpers
    {
        public static bool HasInternetConnection()
        {
            try
            {
                using (var client = new System.Net.WebClient())
                using (client.OpenRead("http://clients3.google.com/generate_204"))
                {
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }

        public static bool IsValidDate(string text)
        {
            return DateTime.TryParse(text, out _);
        }
    }
}
