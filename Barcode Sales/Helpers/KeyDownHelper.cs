using System.Windows.Forms;

namespace Barcode_Sales.Helpers
{
    public static class KeyDownHelper
    {

        public static void EnableFullScreenToggle(Form form)
        {
            form.KeyPreview = true;
            form.KeyDown += (sender, e) =>
            {
                if (e.KeyCode == Keys.F11)
                {
                    ToggleFullScreen(form);
                    e.Handled = true;
                }else if (e.KeyCode == Keys.Escape)
                {
                   form.Close();
                }
            };

            form.Focus();
        }

        private static void ToggleFullScreen(Form form)
        {
            if (form.FormBorderStyle == FormBorderStyle.None)
            {
                form.FormBorderStyle = FormBorderStyle.Sizable;
                form.WindowState = FormWindowState.Normal;
                form.KeyPreview = true;
            }
            else
            {
                form.FormBorderStyle = FormBorderStyle.None;
                form.WindowState = FormWindowState.Normal;
                form.WindowState = FormWindowState.Maximized;
                form.KeyPreview = true;
            }
        }
    }
}
