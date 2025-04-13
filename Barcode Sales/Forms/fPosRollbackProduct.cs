using Barcode_Sales.Operations.Abstract;
using Barcode_Sales.Operations.Concrete;
using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Barcode_Sales.Helpers.Enums;

namespace Barcode_Sales.Forms
{
    public partial class fPosRollbackProduct : DevExpress.XtraEditors.XtraForm
    {
        ISalesDataDetailOperation salesDataDetailOperation = new SalesDataDetailManager();
        private readonly PosReturnType _type;
        private readonly SalesData _salesData;
        public fPosRollbackProduct(PosReturnType type, SalesData salesData)
        {
            InitializeComponent();
            _type = type;
            _salesData = salesData;
        }

        private void fPosRollbackProduct_Load(object sender, EventArgs e)
        {
            if (_salesData != null)
            {
                tSaleDatetime.Text = _salesData.SaleDatetime?.ToString("dd.MM.yyyy - HH:mm:ss");
                tCashier.Text = _salesData.User.NameSurname;
                tCustomer.Text = _salesData.Customer?.NameSurname;
                tReceiptNo.Text = _salesData.ReceiptNo;
                tTotal.EditValue = _salesData.Total;
                tPaymentType.Text = _salesData.PaymentType;
            }
            if (_type is PosReturnType.MoneyBack)
            {
                bSubmit.Text = "Qaytar";
                groupControl1.Text = $"{_salesData.ReceiptNo} Nömrəli satış çekinin geri qaytarılması";
            }
            else
            {
                bSubmit.Text = "Ləğv et";
                groupControl1.Text = $"{_salesData.ReceiptNo} Nömrəli satış çekinin ləğv edilməsi";
            }
            SaleDataLoad();
        }

        private void SaleDataLoad()
        {
            var data = salesDataDetailOperation.Where(x=> x.SaleDataId == _salesData.Id).ToList();
            gridControlSalesData.DataSource = data;
        }
    }
}