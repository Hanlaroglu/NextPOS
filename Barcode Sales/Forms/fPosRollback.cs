using Barcode_Sales.DTOs;
using Barcode_Sales.Helpers.Messages;
using Barcode_Sales.Operations.Abstract;
using Barcode_Sales.Operations.Concrete;
using Barcode_Sales.Tools;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Barcode_Sales.Forms
{
    public partial class fPosRollback : DevExpress.XtraEditors.XtraForm
    {
        private object _data = null;
        ISaleDataOperation saleDataOperation = new SalesDataManager();
        IReturnPosOperation returnPosOperation = new ReturnPosManager();
        NextposDBEntities db = new NextposDBEntities();
        public fPosRollback()
        {
            InitializeComponent();
            dateStart.DateTime = DateTime.Now;
            dateFinish.DateTime = DateTime.Now;
        }

        private enum CheckedType
        {
            Date,
            ReceiptNo,
            FiscalID
        }

        private void SelectedType(object sender, EventArgs e)
        {
            var type = (CheckEdit)sender;
            if (type.Checked)
            {
                switch (type.Tag)
                {
                    case nameof(CheckedType.Date):
                        navigationFrame1.SelectedPage = pageDate;
                        dateStart.DateTime = DateTime.Now;
                        dateFinish.DateTime = DateTime.Now;
                        break;
                    case nameof(CheckedType.ReceiptNo):
                        navigationFrame1.SelectedPage = pageReceiptNo;
                        tReceiptNo.Focus();
                        break;
                    case nameof(CheckedType.FiscalID):
                        navigationFrame1.SelectedPage = pageFıscal;
                        tFiscalId.Focus();
                        break;
                }
            }
        }

        private void bSearch_Click(object sender, EventArgs e)
        {
            string query = null;
            DateTime start = DateTime.Parse(dateStart.Text);
            DateTime finish = DateTime.Parse(dateFinish.Text);
            switch (navigationFrame1.SelectedPage)
            {
                case var page when page == pageDate:
                    query = $@"
SELECT 
	sd.Id,
	sd.SaleDateTime,
	u.NameSurname AS Cashier,
	c.NameSurname AS CustomerName,
    c.Id AS CustomerId,
	sd.Total,
	MAX(sd.Cash) AS Cash,
	MAX(sd.Card) AS Card,
	MAX(CASE 
        WHEN sd.Cash = 0 AND sd.Card > 0 THEN N'KART'
        WHEN sd.Cash > 0 AND sd.Card = 0 THEN N'NAĞD'
        WHEN sd.Cash > 0 AND sd.Card > 0 THEN N'NAĞD-KART'
        ELSE NULL
    END) AS PaymentType,
    sd.ReceiptNo,
    sd.ShortFiscalId,
    sd.LongFiscalId,
    sd.Rrn,
    COUNT(*) AS RemainingItemCount
FROM 
    SalesData sd
INNER JOIN 
    SalesDataDetail sdd ON sdd.SaleDataId = sd.Id
LEFT JOIN 
    ReturnPos rp ON rp.SaleDataId = sd.Id
INNER JOIN
	Users u ON u.Id = sd.UserId
LEFT JOIN
	Customers c ON c.Id = sd.CustomerId
LEFT JOIN 
    ReturnPosDetails rpd ON rpd.ReturnDataId = rp.Id AND rpd.ProductId = sdd.ProductId
WHERE 
    rpd.ProductId IS NULL
    AND EXISTS (
        SELECT 1
        FROM SalesDataDetail sdd2
        LEFT JOIN ReturnPos rp2 ON rp2.SaleDataId = sdd2.SaleDataId
        LEFT JOIN ReturnPosDetails rpd2 ON rpd2.ReturnDataId = rp2.Id AND rpd2.ProductId = sdd2.ProductId
        WHERE sdd2.SaleDataId = sd.Id
        AND rpd2.ProductId IS NULL
    )
    AND sd.SaleDate BETWEEN '{start.ToString("yyyy.MM.dd")}' AND '{finish.ToString("yyyy.MM.dd")}'
GROUP BY 
	sd.Id,
    sd.ReceiptNo,
	sd.SaleDateTime,
	u.NameSurname,
    c.Id,
	c.NameSurname,
	sd.Total,
    sd.Rrn,
    sd.ShortFiscalId,
    sd.LongFiscalId
HAVING 
    COUNT(*) > 0
";
                    break;
                case var page when page == pageReceiptNo:
                    query = $@"
SELECT 
	sd.Id,
	sd.SaleDateTime,
	u.NameSurname AS Cashier,
	c.NameSurname AS CustomerName,
	c.Id AS CustomerId,
	sd.Total,
	MAX(sd.Cash) AS Cash,
	MAX(sd.Card) AS Card,
	MAX(CASE 
        WHEN sd.Cash = 0 AND sd.Card > 0 THEN N'KART'
        WHEN sd.Cash > 0 AND sd.Card = 0 THEN N'NAĞD'
        WHEN sd.Cash > 0 AND sd.Card > 0 THEN N'NAĞD-KART'
        ELSE NULL
    END) AS PaymentType,
    sd.ReceiptNo,
    sd.ShortFiscalId,
    sd.LongFiscalId,
    sd.Rrn,
    COUNT(*) AS RemainingItemCount
FROM 
    SalesData sd
INNER JOIN 
    SalesDataDetail sdd ON sdd.SaleDataId = sd.Id
LEFT JOIN 
    ReturnPos rp ON rp.SaleDataId = sd.Id
INNER JOIN
	Users u ON u.Id = sd.UserId
LEFT JOIN
	Customers c ON c.Id = sd.CustomerId
LEFT JOIN 
    ReturnPosDetails rpd ON rpd.ReturnDataId = rp.Id AND rpd.ProductId = sdd.ProductId
WHERE 
    rpd.ProductId IS NULL
    AND EXISTS (
        SELECT 1
        FROM SalesDataDetail sdd2
        LEFT JOIN ReturnPos rp2 ON rp2.SaleDataId = sdd2.SaleDataId
        LEFT JOIN ReturnPosDetails rpd2 ON rpd2.ReturnDataId = rp2.Id AND rpd2.ProductId = sdd2.ProductId
        WHERE sdd2.SaleDataId = sd.Id
        AND rpd2.ProductId IS NULL
    )
    AND sd.ReceiptNo = N'{tReceiptNo.Text.Trim()}'
GROUP BY 
	sd.Id,
    sd.ReceiptNo,
	sd.SaleDateTime,
	u.NameSurname,
    c.Id,
	c.NameSurname,
	sd.Total,
    sd.Rrn,
    sd.ShortFiscalId,
    sd.LongFiscalId
HAVING 
    COUNT(*) > 0
";
                    break;
                case var page when page == pageFıscal:
                    query = $@"
SELECT 
	sd.Id,
	sd.SaleDateTime,
	u.NameSurname AS Cashier,
	c.NameSurname AS CustomerName,
	c.Id AS CustomerId,
	sd.Total,
	MAX(sd.Cash) AS Cash,
	MAX(sd.Card) AS Card,
	MAX(CASE 
        WHEN sd.Cash = 0 AND sd.Card > 0 THEN N'KART'
        WHEN sd.Cash > 0 AND sd.Card = 0 THEN N'NAĞD'
        WHEN sd.Cash > 0 AND sd.Card > 0 THEN N'NAĞD-KART'
        ELSE NULL
    END) AS PaymentType,
    sd.ReceiptNo,
    sd.ShortFiscalId,
    sd.LongFiscalId,
    sd.Rrn,
    COUNT(*) AS RemainingItemCount
FROM 
    SalesData sd
INNER JOIN 
    SalesDataDetail sdd ON sdd.SaleDataId = sd.Id
LEFT JOIN 
    ReturnPos rp ON rp.SaleDataId = sd.Id
INNER JOIN
	Users u ON u.Id = sd.UserId
LEFT JOIN
	Customers c ON c.Id = sd.CustomerId
LEFT JOIN 
    ReturnPosDetails rpd ON rpd.ReturnDataId = rp.Id AND rpd.ProductId = sdd.ProductId
WHERE 
    rpd.ProductId IS NULL
    AND EXISTS (
        SELECT 1
        FROM SalesDataDetail sdd2
        LEFT JOIN ReturnPos rp2 ON rp2.SaleDataId = sdd2.SaleDataId
        LEFT JOIN ReturnPosDetails rpd2 ON rpd2.ReturnDataId = rp2.Id AND rpd2.ProductId = sdd2.ProductId
        WHERE sdd2.SaleDataId = sd.Id
        AND rpd2.ProductId IS NULL
    )
    AND sd.ShortFiscalId = N'{tFiscalId.Text.Trim()}'
GROUP BY 
	sd.Id,
    sd.ReceiptNo,
	sd.SaleDateTime,
	u.NameSurname,
    c.Id,
	c.NameSurname,
	sd.Total,
    sd.Rrn,
    sd.ShortFiscalId,
    sd.LongFiscalId
HAVING 
    COUNT(*) > 0
";
                    break;
            }
            _data = db.Database.SqlQuery<SalesDataSummary>(query).ToList();
            gridControlSalesData.DataSource = _data;
        }

        private void tReceiptNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                bSearch_Click(null, null);
        }

        private void tFiscalId_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                bSearch_Click(null, null);
        }

        private void bReturnSale_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            Point mousePosition = Control.MousePosition;
            popupMenu1.ShowPopup(mousePosition);
        }

        private void barBtnCancel_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (gridSalesData.GetFocusedRow() == null)
            {
                OperationsControl.Message(CommonMessages.NOT_SELECTİON, NextPOS.UserControls.fMessage.enmType.Warning);
                return;
            }
            else
            {
                int rowHandle = gridSalesData.FocusedRowHandle;
                var data = gridSalesData.GetRow(rowHandle) as SalesDataSummary;
                fPosRollbackProduct f = new fPosRollbackProduct(Helpers.Enums.PosReturnType.Rollback, data);
                if (f.ShowDialog() is DialogResult.OK)
                {
                    DialogResult = DialogResult.OK;
                }
            }

        }

        private void barBtnReturn_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (gridSalesData.GetFocusedRow() == null)
            {
                OperationsControl.Message(CommonMessages.NOT_SELECTİON, NextPOS.UserControls.fMessage.enmType.Warning);
                return;
            }
            else
            {
                int rowHandle = gridSalesData.FocusedRowHandle;
                var data = gridSalesData.GetRow(rowHandle) as SalesDataSummary;
                fPosRollbackProduct f = new fPosRollbackProduct(Helpers.Enums.PosReturnType.MoneyBack, data);
                if (f.ShowDialog() is DialogResult.OK)
                {
                    DialogResult = DialogResult.OK;
                }
            }

        }
    }
}