using DevExpress.XtraEditors;
using NextPOS.UserControls;
using System.Windows.Forms;

namespace Barcode_Sales.Helpers.Messages
{
    public static class CommonMessageBox
    {
        static CommonMessageBox()
        {
            MessageBoxManager.Yes = "Bəli";
            MessageBoxManager.No = "Xeyr";
            MessageBoxManager.OK = "OK";
            MessageBoxManager.Retry = "Yenidən yoxla";
            MessageBoxManager.Cancel = "Ləğv et";
        }

        public static void InformationMessageBox(string _message, string _title = nameof(Enums.MessageTitle.Mesaj), MessageBoxButtons _button = MessageBoxButtons.OK, MessageBoxIcon _icon = MessageBoxIcon.Information)
        {
            MessageBoxManager.Register();
            MessageBox.Show(_message, _title, _button, _icon);
            MessageBoxManager.Unregister();
        }

        public static void QuestionMessageBox(string _message, string _title = nameof(Enums.MessageTitle.Mesaj), MessageBoxButtons _button = MessageBoxButtons.OK, MessageBoxIcon _icon = MessageBoxIcon.Question)
        {
            MessageBoxManager.Register();
            MessageBox.Show(_message, _title, _button, _icon);
            MessageBoxManager.Unregister();
        }

        public static void WarningMessageBox(string _message, string _title = nameof(Enums.MessageTitle.Xəbərdarlıq), MessageBoxButtons _button = MessageBoxButtons.OK, MessageBoxIcon _icon = MessageBoxIcon.Warning)
        {
            MessageBoxManager.Register();
            MessageBox.Show(_message, _title, _button, _icon);
            MessageBoxManager.Unregister();
        }

        public static void ErrorMessageBox(string _message, string _title = nameof(Enums.MessageTitle.Xəta), MessageBoxButtons _button = MessageBoxButtons.OK, MessageBoxIcon _icon = MessageBoxIcon.Error)
        {
            MessageBoxManager.Register();
           MessageBox.Show(_message, _title, _button, _icon);
            MessageBoxManager.Unregister();
        }

        public static bool QuestionDialogResult(string _message, string _title = nameof(Enums.MessageTitle.Mesaj))
        {
            MessageBoxManager.Register();
            if (MessageBox.Show(_message, _title, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                MessageBoxManager.Unregister();
                return true;
            }
            MessageBoxManager.Unregister();
            return false;
        }

        public static void Message(string msg, fMessage.enmType type)
        {
            fMessage frm = new fMessage();
            frm.showAlert(msg, type);
        }
    }
}