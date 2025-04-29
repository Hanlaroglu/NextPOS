using Barcode_Sales.Helpers.Classes;
using Barcode_Sales.Operations.Abstract;
using Barcode_Sales.Operations.Concrete;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Repository;
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
using static DevExpress.Utils.Diagnostics.GUIResources;

namespace Barcode_Sales.Forms
{
    public partial class fPosRollbackProduct : DevExpress.XtraEditors.XtraForm
    {
        static ITerminalOperation terminalOperation = new TerminalManager();
        public static readonly Terminals _terminals = terminalOperation.GetIpAddress();
        ISalesDataDetailOperation salesDataDetailOperation = new SalesDataDetailManager();
        private readonly PosReturnType _type;
        private readonly SalesData _salesData;
        RepositoryItemTextEdit repositoryN3;
        RepositoryItemTextEdit repositoryN0;
        private BindingList<SalesDataWrapper> dataList;
        private BindingList<RefundClassess.DataItem> RefundDataItem = new BindingList<RefundClassess.DataItem>();
        private RefundClassess.Data _refundData;

        public fPosRollbackProduct(PosReturnType type, SalesData salesData)
        {
            InitializeComponent();
            _type = type;
            _salesData = salesData;
        }

        private void fPosRollbackProduct_Load(object sender, EventArgs e)
        {
            GridRepoAdd();
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
            var data = salesDataDetailOperation
                      .Where(x => x.SaleDataId == _salesData.Id)
                      .Select(x => new SalesDataWrapper
                      {
                          Detail = x,
                          ReturnQuantity = 1
                      })
                      .ToList();

            dataList = new BindingList<SalesDataWrapper>(data);
            gridControlSalesData.DataSource = dataList;
        }

        public class SalesDataWrapper
        {
            public SalesDataDetail Detail { get; set; }
            public double ReturnQuantity { get; set; }
        }

        private void gridSalesData_ShownEditor(object sender, EventArgs e)
        {
            var view = gridSalesData;
            if (view.FocusedColumn.FieldName is "ReturnQuantity")
            {
                int rowHandle = view.FocusedRowHandle;

                if (!view.IsRowSelected(rowHandle))
                {
                    view.CloseEditor();
                }
                else
                {
                    BeginInvoke(new Action(() =>
                    {
                        var editor = view.ActiveEditor as TextEdit;
                        editor?.SelectAll();
                    }));
                }
            }
        }

        private void GridRepoAdd()
        {
            repositoryN3 = new RepositoryItemTextEdit();
            repositoryN3.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            repositoryN3.Mask.EditMask = "n3";
            repositoryN3.Mask.UseMaskAsDisplayFormat = true;

            repositoryN0 = new RepositoryItemTextEdit();
            repositoryN0.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            repositoryN0.Mask.EditMask = "n0";
            repositoryN0.Mask.UseMaskAsDisplayFormat = true;

            // Gride eklemeyi unutma
            gridControlSalesData.RepositoryItems.Add(repositoryN3);
            gridControlSalesData.RepositoryItems.Add(repositoryN0);
        }

        private void gridSalesData_CustomRowCellEdit(object sender, DevExpress.XtraGrid.Views.Grid.CustomRowCellEditEventArgs e)
        {
            if (e.Column.FieldName is "ReturnQuantity")
            {
                var unitName = gridSalesData.GetRowCellValue(e.RowHandle, "Detail.Product.Unit")?.ToString();

                if (unitName is "Kq")
                    e.RepositoryItem = repositoryN3;
                else
                    e.RepositoryItem = repositoryN0;
            }
        }

        private void bSubmit_Click(object sender, EventArgs e)
        {
            if (gridSalesData.SelectedRowsCount > 0)
            {
                gridSalesData.CloseEditor();
                gridSalesData.UpdateCurrentRow();

                int[] selected = gridSalesData.GetSelectedRows();

                foreach (var item in selected)
                {
                    SalesDataWrapper rowData = gridSalesData.GetRow(item) as SalesDataWrapper;
                    if (rowData != null)
                    {
                        var amount = (double)rowData.ReturnQuantity;
                        RefundClassess.DataItem dataItem = new RefundClassess.DataItem()
                        {
                            Id = (int)rowData.Detail.ProductId,
                            ProductName = rowData.Detail.Product.ProductName,
                            Barcode = rowData.Detail.Product.Barcode,
                            Amount = (double)rowData.ReturnQuantity,
                            PurchasePrice = (double)rowData.Detail.Product.PurchasePrice,
                            SalePrice = (double)rowData.Detail.SalePrice,
                            Discount = (double)rowData.Detail.Discount,
                            Unit = rowData.Detail.Product.Unit,
                            Tax = rowData.Detail.Product.Tax,
                        };
                        RefundDataItem.Add(dataItem);
                    }
                }

                _refundData = new RefundClassess.Data()
                {
                    IpAddress = _terminals.IpAddress,
                    Items = RefundDataItem,
                    Cashier = tCashier.Text,
                    Cash = (double)_salesData.Cash,
                    Card = (double)_salesData.Card,
                    LongFiskalId = _salesData.LongFiscalId,
                    ShortFiskalId = _salesData.ShortFiscalId,
                    document_number = _salesData.ReceiptNo,
                    Note = tComment.Text.Trim(),
                    RRN = _salesData.Rrn,
                    Customer = _salesData.Customer,
                    SaleDataId = _salesData.Id,
                };
                if (_type is PosReturnType.MoneyBack)
                {
                    SaleRefund();
                }
            }
        }

        private void SaleRefund()
        {
            if (_terminals != null)
            {
                KassaOperator kassa = (KassaOperator)Enum.Parse(typeof(KassaOperator), _terminals.Name);
                switch (kassa)
                {
                    case KassaOperator.SUNMI:
                    case KassaOperator.TIANYU:
                        if (NKA.Sunmi.Sale(null))
                        {
                            DialogResult = DialogResult.OK;
                        }
                        break;
                    case KassaOperator.OMNITECH:
                        if (NKA.Omnitech.Refund(_refundData))
                        {
                            RefundDataItem.Clear();
                            DialogResult = DialogResult.OK;
                        }
                        break;
                    case KassaOperator.AZSMART:
                        break;
                    case KassaOperator.NBA:
                        break;
                    case KassaOperator.DATAPAY:
                        break;
                    case KassaOperator.ONECLICK:
                        break;
                }
            }
        }
    }
}