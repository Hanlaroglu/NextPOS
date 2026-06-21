using Barcode_Sales.DTOs;
using Barcode_Sales.Helpers;
using Barcode_Sales.Helpers.Classes;
using Barcode_Sales.Operations.Abstract;
using Barcode_Sales.Operations.Concrete;
using Barcode_Sales.Services.CacheServices;
using Barcode_Sales.Terminals.Omnitech;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Views.Grid;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraLayout.Utils;
using static Barcode_Sales.Helpers.Enums;

namespace Barcode_Sales.Forms
{
    public partial class fPosRollbackProduct : DevExpress.XtraEditors.XtraForm
    {
        IPosSaleItemOperation posSaleItemOperation = new PosSaleItemManager();
        ICustomerOperation customerOperation = new CustomerManager();
        IProductOperation productOperation = new ProductManager();

        private readonly PosReturnType _type;

        RepositoryItemTextEdit repositoryN3;
        RepositoryItemTextEdit repositoryN0;

        private BindingList<PosSaleItemDto> dataList;
        BindingList<PosSaleItemDto> _items = new BindingList<PosSaleItemDto>();

        private RefundClassess.Data _refundData;
        private PosRefundDto _posRefundDto { get; set; }
        private Customer _customer;
        private readonly PosSaleSummaryDto _salesDataSummary;

        public fPosRollbackProduct(PosReturnType type, PosSaleSummaryDto items)
        {
            InitializeComponent();
            _type = type;
            _salesDataSummary = items;
        }

        private async void fPosRollbackProduct_Load(object sender, EventArgs e)
        {
            _customer = _salesDataSummary?.CustomerId is null ? null : await customerOperation.Get(x => x.Id == (int)_salesDataSummary.CustomerId);

            GridRepoAdd();
            SaleDataLoad();
            if (_salesDataSummary != null)
            {
                tSaleDatetime.Text = _salesDataSummary.SaleDateTime?.ToString("dd.MM.yyyy - HH:mm:ss");
                tCashier.Text = _salesDataSummary.Cashier;
                tCustomer.Text = _salesDataSummary.CustomerName;
                tReceiptNo.Text = $"#{_salesDataSummary.ReceiptNo}";
                tTotal.EditValue = _salesDataSummary.Total;
                tPaymentType.Text = _salesDataSummary.PaymentType;
            }
            if (_type is PosReturnType.MoneyBack)
            {
                bSubmit.Text = "Qaytar";
                layoutControlGroup1.Text = $"#{_salesDataSummary.ReceiptNo} Nömrəli satış çekinin geri qaytarılması";
            }
            else
            {
                bSubmit.Text = "Ləğv et";
                layoutControlGroup1.Text = $"{_salesDataSummary.ReceiptNo} Nömrəli satış çekinin ləğv edilməsi";
                gridSalesData.OptionsSelection.MultiSelect = false;
                layoutControlItem9.Visibility = LayoutVisibility.Always;
                lCancelMessage.Text = "Çekdə olan bütün məhsullar <b><u><color=red>ləğv ediləcəkdir!</color></u></b>";
                colReturnQuantity.Visible = false;
            }
        }

        private void SaleDataLoad()
        {
            //var data = posSaleItemOperation.Where(x => x.PosSaleId == _salesDataSummary.Id)
            //    .Select(x => new PosRefundItemDto
            //    {
            //        Id = x.Id,
            //        ProductId = x.ProductId,
            //        Barcode = x.Product.Barcode,
            //        ProductName = x.Product.ProductName,
            //        Quantity = x.Quantity,
            //        TaxId = x.Product.TaxId,
            //        UnitId = x.Product.UnitId,
            //        PurchasePrice = x.Product.PurchasePrice,
            //        SalePrice = x.SalePrice,
            //        DiscountAmount = x.Discount,
            //    }).ToList();

            var data = posSaleItemOperation.GetRemainingSaleData(_salesDataSummary.Id);


            if (_type is PosReturnType.Rollback)
                foreach (var item in data)
                    item.RefundQuantity = item.RemainingQuantity;

            dataList = new BindingList<PosSaleItemDto>(data);
            gridControlSalesData.DataSource = dataList;
        }

        private void gridSalesData_ShownEditor(object sender, EventArgs e)
        {
            var view = gridSalesData;
            if (view.FocusedColumn.FieldName is "RefundQuantity")
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

            gridControlSalesData.RepositoryItems.Add(repositoryN3);
            gridControlSalesData.RepositoryItems.Add(repositoryN0);
        }

        private void gridSalesData_CustomRowCellEdit(object sender, DevExpress.XtraGrid.Views.Grid.CustomRowCellEditEventArgs e)
        {
            if (e.Column.FieldName is "RefundQuantity")
            {
                var unitName = gridSalesData.GetRowCellValue(e.RowHandle, "UnitName")?.ToString();

                if (unitName is "Kq")
                    e.RepositoryItem = repositoryN3;
                else
                    e.RepositoryItem = repositoryN0;
            }
        }

        private void bSubmit_Click(object sender, EventArgs e)
        {
            if (_type is PosReturnType.Rollback)
                gridSalesData.SelectAll();

            if (gridSalesData.SelectedRowsCount > 0)
            {
                gridSalesData.CloseEditor();
                gridSalesData.UpdateCurrentRow();

                _items.Clear();

                if (_type is PosReturnType.Rollback)
                {
                    foreach (var item in dataList)
                        _items.Add(item);
                }
                else
                {
                    int[] selected = gridSalesData.GetSelectedRows();
                    foreach (var item in selected)
                    {
                        var rowData = gridSalesData.GetRow(item) as PosSaleItemDto;
                        if (rowData != null)
                        {
                            if (rowData.RefundQuantity <= 0)
                            {
                                NotificationHelpers.Messages.ErrorMessage(this, "Qaytarılacaq miqdar daxil edilmədi");
                                return;
                            }
                        }
                        _items.Add(rowData);
                    }
                }

                _posRefundDto = new PosRefundDto
                {
                    PosSaleId = _salesDataSummary.Id,
                    Items = _items,
                    Cashier = UserCacheService.User.NameSurname,
                    LongFiscalId = _salesDataSummary.LongFiscalId,
                    ShortFiscalId = _salesDataSummary.ShortFiscalId,
                    ReceiptNo = _salesDataSummary.ReceiptNo,
                    Note = tComment.Text.Trim(),
                    BankRrn = _salesDataSummary.BankRrn,
                    Customer = _customer,
                    Cash = tPaymentType.Text == "NAĞD" ? _salesDataSummary.Cash : 0,
                    Card = tPaymentType.Text == "KART" ? _salesDataSummary.Card : 0,
                    //Card = tPaymentType.Text == "NAĞD-KART" ? _salesDataSummary.Card : 0,
                };



                if (_type is PosReturnType.MoneyBack)
                    Refund();
                else
                    Rollback();
            }
            else
            {
                NotificationHelpers.Messages.WarningMessage(this, "Seçim edilmədi");
            }
        }

        private async void Refund()
        {
            if (TerminalCacheService.Terminal != null)
            {
                var kassa = (Helpers.Enums.Terminal)Enum.Parse(typeof(Helpers.Enums.Terminal), TerminalCacheService.Terminal.Name);
                switch (kassa)
                {
                    case Helpers.Enums.Terminal.Caspos:
                        if (NKA.Sunmi.Refund())
                            DialogResult = DialogResult.OK;
                        break;
                    case Helpers.Enums.Terminal.Omnitech:
                        OmnnitechTerminal omnitech = new OmnnitechTerminal(TerminalCacheService.Terminal.IpAddress);
                        var result = await omnitech.Refund(_posRefundDto);

                        fPosSales _form = Application.OpenForms.OfType<fPosSales>().FirstOrDefault();
                        if (result.Success)
                        {
                            UpdateProducts(_posRefundDto.Items);
                            NotificationHelpers.Messages.SuccessMessage(_form, result.Message);
                        }
                        else
                            NotificationHelpers.Messages.ErrorMessage(_form, result.Message);
                        DialogResult = DialogResult.OK;
                        break;
                    case Helpers.Enums.Terminal.AzSmart:
                        if (NKA.AzSmart.Refund(_refundData))
                            DialogResult = DialogResult.OK;
                        break;
                    case Helpers.Enums.Terminal.Nba:
                        break;
                    case Helpers.Enums.Terminal.DataPay:
                        break;
                    case Helpers.Enums.Terminal.OneClick:
                        break;
                }
                _items.Clear();
            }
        }

        private async void Rollback()
        {
            if (TerminalCacheService.Terminal != null)
            {
                var kassa = (Helpers.Enums.Terminal)Enum.Parse(typeof(Helpers.Enums.Terminal), TerminalCacheService.Terminal.Name);
                switch (kassa)
                {
                    case Helpers.Enums.Terminal.Caspos:
                        if (await NKA.Sunmi.Sale(null))
                        {
                            DialogResult = DialogResult.OK;
                        }
                        break;
                    case Helpers.Enums.Terminal.Omnitech:
                        OmnnitechTerminal omnitech = new OmnnitechTerminal(TerminalCacheService.Terminal.IpAddress);
                        var result = await omnitech.Rollback(_posRefundDto);

                        fPosSales _form = Application.OpenForms.OfType<fPosSales>().FirstOrDefault();
                        if (result.Success)
                        {
                            UpdateProducts(_posRefundDto.Items);
                            NotificationHelpers.Messages.SuccessMessage(_form, result.Message);
                        }
                        else
                            NotificationHelpers.Messages.ErrorMessage(_form, result.Message);
                        DialogResult = DialogResult.OK;
                        break;
                    case Helpers.Enums.Terminal.AzSmart:
                        break;
                    case Helpers.Enums.Terminal.Nba:
                        break;
                    case Helpers.Enums.Terminal.DataPay:
                        break;
                    case Helpers.Enums.Terminal.OneClick:
                        break;
                }
            }
        }

        private async void UpdateProducts(BindingList<PosSaleItemDto> items)
        {
            List<Products> products = new List<Products>();
            foreach (var item in items)
            {
                var product = await productOperation.Get(x => x.Id == item.ProductId);
                product.Quantity += item.RefundQuantity;
                products.Add(product);
            }

            var result = await productOperation.Update(products, x => x.Quantity);
        }

        private void fPosRollbackProduct_FormClosed(object sender, FormClosedEventArgs e)
        {

        }

        private void gridSalesData_RowStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs e)
        {
            var view = sender as GridView;
            if (view == null || e.RowHandle < 0)
                return;

            //var row = view.GetRow(e.RowHandle) as Person;
            //if (row != null && row.IsLocked)
            //{
            //    e.Appearance.BackColor = Color.Red;
            //    e.Appearance.ForeColor = Color.White;
            //}
        }
    }
}