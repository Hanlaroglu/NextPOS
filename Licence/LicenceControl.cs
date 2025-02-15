using System.Net;

namespace Licence
{
    public static class LicenceControl
    {
        public static bool LicControl(string Key)
        {
            try
            {
                WebClient web = new WebClient();

                if (web.DownloadString("http://e-kassa.000webhostapp.com/NGT/Next.Market/Controller/BlockLicence").Contains(Key))
                    return false;
                else
                    return true;
            }
            catch (System.Exception e)
            {
                System.Windows.Forms.MessageBox.Show(e.Message,"Uzaq serverə qoşulabilmədi",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Error);
                return false;
            }

        }
    }
}
