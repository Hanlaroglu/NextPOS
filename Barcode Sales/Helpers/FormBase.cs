using DevExpress.XtraEditors;
using NextPOS.UserControls;

namespace Barcode_Sales.Helpers
{
    public class FormBase:XtraForm
    {
        public static void Message(string msg, fMessage.enmType type)
        {
            fMessage frm = new fMessage();
            frm.showAlert(msg, type);
        }

        public virtual void ReceiveData<T>(T data)
        {

        }
    }
}