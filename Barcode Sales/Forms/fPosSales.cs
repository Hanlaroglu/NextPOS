using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Barcode_Sales.Helpers;
using Barcode_Sales.Operations.Abstract;
using Barcode_Sales.Operations.Concrete;
using Barcode_Sales.Services.CacheServices;
using Barcode_Sales.Terminals.DTOs;
using DevExpress.XtraBars.Navigation;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;

namespace Barcode_Sales.Forms
{
    public partial class fPosSales : FormBase
    {
        public Customer _customer { get; set; }

        IPosSaleOperation posSaleOperation = new PosSaleManager();
        IProductOperation productOperation = new ProductManager();
        IPosBasketOperation posBasketOperation = new PosBasketManager();
        IPosBasketItemOperation posBasketItemOperation = new PosBasketItemManager();

        private BindingList<PosSaleItemDto> dataList = new BindingList<PosSaleItemDto>();
        private List<Product> _productsList = new List<Product>();

        short rowNo = 1;

        public fPosSales()
        {
            InitializeComponent();
            KeyDownHelper.EnableFullScreenToggle(this);
            gridControlBasket.DataSource = dataList;
        }

        private class ProductSearchData : Product
        {
            public int Id { get; set; }
            public string ProductName { get; set; }
            public decimal? PurchasePrice { get; set; }
            public decimal SalePrice { get; set; } = 0;
            public decimal Discount { get; set; } = 0;
            public string Barcode { get; set; }
            public int UnitId { get; set; }
            public int TaxId { get; set; }
            public decimal Amount { get; set; }
        }

        private async void fPosSales_Shown(object sender, EventArgs e)
        {
            GridRepoAdd();

            if (TerminalCacheService.Terminal is null)
                await TerminalCacheService.RefreshTerminal();

            var saleCount = await posSaleOperation.CurrentSaleCount();
            tSaleCount.Text = saleCount.ToString();
            tToday.Properties.Buttons[1].Caption = DatetimeService.CurrentDateString;
            tCashier.Properties.Buttons[1].Caption = UserCacheService.User?.NameSurname;
            await RefreshProductList();
            await SearchProductList();
            HotSaleProducts();
        }

        private async Task SearchProductList()
        {
            var products = _productsList.Select(x => new ProductSearchData
            {
                Id = x.Id,
                ProductName = x.ProductName,
                SalePrice = x.SalePrice,
                PurchasePrice = x.PurchasePrice,
                Barcode = x.Barcode,
                UnitId = x.UnitId,
                TaxId = x.TaxId
            }).ToList();

            tSearch.Properties.DataSource = products;
            tSearch.Properties.DisplayMember = "ProductName";
            tSearch.Properties.ValueMember = "Id";
        }

        private async Task RefreshProductList()
        {
            var data = await productOperation.ToListAsync(x => x.IsDeleted == false && x.IsActive == true);

            if (data != null)
                _productsList = data;
        }

        private void bHelp_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Test");
        }

        private void bPay_Click(object sender, EventArgs e)
        {
            if (dataList.Count > 0)
            {
                fPosPay f = new fPosPay(new PosSaleDto
                {
                    Cashier = tCashier.Properties.Buttons[1].Caption,
                    Items = dataList,
                    CustomerName = tCustomer.Text,
                    Customer = _customer,
                    Note = tComment.Text,
                });
                if (f.ShowDialog() is DialogResult.OK)
                    Clear();
            }
        }

        private async void Clear()
        {
            dataList.Clear();
            tTotal.Text = 0.ToString("0.00");
            tCustomer.Text = "-";
            tComment.Clear();
            tProductCount.Text = "0";
            var saleCount = await posSaleOperation.CurrentSaleCount();
            tSaleCount.Text = saleCount.ToString();
        }

        private void buttonEdit4_SizeChanged(object sender, EventArgs e)
        {
            tCashier.Size = tSaleCount.Size;
        }

        private void bExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void chBarcode_CheckedChanged(object sender, EventArgs e)
        {
            navigationSearchMode.SelectedPage = pageBarcodeSearch;
        }

        private void chName_CheckedChanged(object sender, EventArgs e)
        {
            navigationSearchMode.SelectedPage = pageNameSearch;
        }

        private void tSearch_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                tSearch.EditValueChanged -= tSearch_EditValueChanged;

                var selectedRow = tSearch.Properties.View.GetFocusedRow() as ProductSearchData;
                if (selectedRow == null) return;

                var existingProduct = dataList.FirstOrDefault(x => x.Id == selectedRow.Id);

                if (existingProduct != null)
                {
                    existingProduct.Quantity += 1;
                }
                else
                {
                    PosSaleItemDto grid = new PosSaleItemDto
                    {
                        ProductName = selectedRow.ProductName,
                        PurchasePrice = selectedRow.PurchasePrice.Value,
                        SalePrice = selectedRow.SalePrice,
                        Discount = selectedRow.Discount,
                        Id = selectedRow.Id,
                        Quantity = 1,
                        No = rowNo,
                        Barcode = selectedRow.Barcode,
                        UnitId = selectedRow.UnitId,
                        TaxId = selectedRow.TaxId,
                    };
                    dataList.Add(grid);
                    rowNo++;
                }
                gridControlBasket.RefreshDataSource();

                tSearch.EditValue = null;
            }
            finally
            {
                TotalAmountCalculation();
                tSearch.EditValueChanged += tSearch_EditValueChanged;
            }
        }

        private async void tBarcodeSearch_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode is Keys.Enter)
            {
                try
                {
                    tSearch.EditValueChanged -= tSearch_EditValueChanged;

                    var product = await productOperation.Get(x => x.Barcode == tBarcodeSearch.Text.Trim());

                    if (product is null)
                    {
                        NotificationHelpers.Messages.WarningMessage(this, "Məhsul tapılmadı");
                        tBarcodeSearch.Clear();
                        return;
                    }


                    var existingProduct = dataList.FirstOrDefault(x => x.Id == product.Id);

                    if (existingProduct != null)
                        existingProduct.Quantity += 1;
                    else
                    {
                        PosSaleItemDto grid = new PosSaleItemDto
                        {
                            Id = product.Id,
                            ProductName = product.ProductName,
                            SalePrice = product.SalePrice,
                            Quantity = 1,
                            No = rowNo,
                            Barcode = product.Barcode,
                            UnitId = product.UnitId,
                            TaxId = product.TaxId,
                            PurchasePrice = product.PurchasePrice
                        };
                        dataList.Add(grid);
                        rowNo++;
                    }
                    gridControlBasket.RefreshDataSource();

                    tBarcodeSearch.EditValue = null;
                }
                finally
                {
                    TotalAmountCalculation();
                    tSearch.EditValueChanged += tSearch_EditValueChanged;
                }
            }
        }

        private void TotalAmountCalculation()
        {
            gridBasket.RefreshData();
            tProductCount.Text = dataList == null ? 0.ToString() : dataList.Count.ToString();
            tTotal.Text = dataList == null ? 0.ToString("N2") : dataList.Sum(x => x.Sum).ToString("0.00");
        }

        private void bProductDelete_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            gridBasket.DeleteRow(gridBasket.FocusedRowHandle);
            TotalAmountCalculation();
        }

        private void bDiscount_Click(object sender, EventArgs e)
        {
            if (gridBasket.GetFocusedRow() != null)
            {
                int focusedRow = Int32.Parse(gridBasket.GetFocusedRowCellValue(colId).ToString());

                var selectedProduct = dataList.FirstOrDefault(x => x.Id == focusedRow);
                fPriceChange f = new fPriceChange(new DTOs.PosChangeType
                {
                    ChangeType = Enums.PosChangeType.Discount,
                    Amount = selectedProduct.SalePrice,
                });
                if (f.ShowDialog() is DialogResult.OK)
                {
                    selectedProduct.Discount = f.Amount;
                    TotalAmountCalculation();
                }
            }
        }

        private void bManagement_Click(object sender, EventArgs e)
        {
            fPosSalesControlPanel f = new fPosSalesControlPanel();
            f.ShowDialog();
        }

        private void gridBasket_decimalClick(object sender, EventArgs e)
        {
            Point pt = gridBasket.GridControl.PointToClient(Control.MousePosition);
            GridHitInfo info = gridBasket.CalcHitInfo(pt);
            var value = gridBasket.GetFocusedRowCellValue(colId);
            if (value == null || !Int32.TryParse(value.ToString(), out int focusedRow))
                return;

            var selectedProduct = dataList.FirstOrDefault(x => x.Id == focusedRow);
            if (info.InRowCell)
            {

                switch (info.Column.FieldName)
                {
                    case "Quantity":
                        fPriceChange quantity = new fPriceChange(new DTOs.PosChangeType
                        {
                            ChangeType = Enums.PosChangeType.Quantity,
                            UnitName = selectedProduct.UnitName
                        });
                        if (quantity.ShowDialog() is DialogResult.OK)
                        {
                            selectedProduct.Quantity = quantity.Amount;
                            TotalAmountCalculation();
                        }
                        break;
                    case "SalePrice":
                        fPriceChange price = new fPriceChange(new DTOs.PosChangeType
                        {
                            ChangeType = Enums.PosChangeType.PriceChange,
                            Amount = selectedProduct.SalePrice,
                        });
                        if (price.ShowDialog() is DialogResult.OK)
                        {
                            focusedRow = Int32.Parse(gridBasket.GetFocusedRowCellValue(colId).ToString());

                            selectedProduct = dataList.FirstOrDefault(x => x.Id == focusedRow);
                            selectedProduct.SalePrice = price.Amount;
                            TotalAmountCalculation();
                        }
                        break;
                    case "Discount":
                        focusedRow = Int32.Parse(gridBasket.GetFocusedRowCellValue(colId).ToString());

                        selectedProduct = dataList.FirstOrDefault(x => x.Id == focusedRow);

                        fPriceChange discount = new fPriceChange(new DTOs.PosChangeType
                        {
                            ChangeType = Enums.PosChangeType.Discount,
                            Amount = selectedProduct.SalePrice,
                        });
                        if (discount.ShowDialog() is DialogResult.OK)
                        {

                            selectedProduct.Discount = discount.Amount;
                            TotalAmountCalculation();
                        }
                        break;
                }
            }
        }

        private void fPosSales_FormClosed(object sender, FormClosedEventArgs e)
        {
            //Application.Exit();
        }

        private void bCustomers_Click(object sender, EventArgs e)
        {
            fSelectCustomer<fPosSales> ff = new fSelectCustomer<fPosSales>(this);
            ff.ShowDialog();
        }

        public override void ReceiveData<T>(T data)
        {
            if (data is Customer customer)
            {
                tCustomer.Text = $"{customer.NameSurname} ({customer.CustomerGroup.Name})";
                _customer = customer;
            }
        }

        private async void HotSaleProducts()
        {
            var products = await productOperation.HotSaleProducts();
            tileControlProducts.Groups.Clear();
            tileControlProducts.ItemSize = 150;
            tileControlProducts.ItemPadding = new Padding(5);
            TileBarGroup group1 = new TileBarGroup();
            foreach (var item in products)
            {
                string productName = item.ProductName;
                decimal price = item.SalePrice;

                TileItem tile = new TileItem();
                tile.ItemSize = TileItemSize.Default;
                tile.AppearanceItem.Normal.BackColor = Color.FromArgb(0, 120, 212);
                tile.AppearanceItem.Normal.ForeColor = Color.White;

                //productName
                TileItemElement productElement = new TileItemElement();
                productElement.Text = productName;
                productElement.TextAlignment = TileItemContentAlignment.TopLeft;
                productElement.MaxWidth = 120;
                productElement.Appearance.Normal.Font = new Font("Poppins", 11);

                //price
                TileItemElement priceElement = new TileItemElement();
                priceElement.Text = price.ToString("N2") + " AZN";
                priceElement.TextAlignment = TileItemContentAlignment.BottomRight;
                priceElement.Appearance.Normal.Font = new Font("Nunito", 12, FontStyle.Bold);

                tile.Elements.Add(productElement);
                tile.Elements.Add(priceElement);

                group1.Items.Add(tile);
                tileControlProducts.Groups.Add(group1);
            }
        }

        private void tileControlProducts_ItemClick(object sender, TileItemEventArgs e)
        {
            try
            {
                string productName = e.Item.Elements[0].Text;

                var product = _productsList.Find(x => x.ProductName == productName);

                if (product is null)
                {
                    NotificationHelpers.Messages.WarningMessage(this, "Məhsul tapılmadı");
                    return;
                }

                var existingProduct = dataList.FirstOrDefault(x => x.Id == product.Id);

                if (existingProduct != null)
                    existingProduct.Quantity += 1;
                else
                {
                    PosSaleItemDto grid = new PosSaleItemDto
                    {
                        Id = product.Id,
                        ProductName = product.ProductName,
                        SalePrice = product.SalePrice,
                        Quantity = 1,
                        No = rowNo,
                        Barcode = product.Barcode,
                        UnitId = product.UnitId,
                        TaxId = product.TaxId,
                        PurchasePrice = product.PurchasePrice
                    };
                    dataList.Add(grid);
                    rowNo++;
                }
                gridControlBasket.RefreshDataSource();

            }
            finally
            {
                TotalAmountCalculation();
            }
        }

        private void bHotSales_Click(object sender, EventArgs e)
        {
            navigationFrameRight.SelectedPage = pageHotProducts;
        }

        private void bBaskets_Click(object sender, EventArgs e)
        {
            if (dataList.Count > 0)
                AddBasket();
            else
                navigationFrameRight.SelectedPage = pageBaskets;

            BasketLoad();
        }

        private void bNumberKeyboard_Click(object sender, EventArgs e)
        {
            navigationFrameRight.SelectedPage = pageKeyboard;
        }

        private async void AddBasket()
        {
            var basketName = posBasketOperation.LastBasketNumber();
            var basket = new PosBasket
            {
                BasketName = basketName,
                CustomerId = _customer != null ? _customer?.Id : null,
                CreatedDatetime = DatetimeService.CurrentDateTime,
                CreatedUserId = UserCacheService.User.Id,
            };

            List<PosBasketItem> baskets = new List<PosBasketItem>();
            foreach (var item in dataList)
            {
                var data = new PosBasketItem
                {
                    PosBasket = basket,
                    ProductId = item.Id,
                    Quantity = item.Quantity,
                    PurchasePrice = item.PurchasePrice,
                    SalePrice = item.SalePrice,
                    DiscountAmount = item.Discount,
                    TotalAmount = item.Quantity * item.SalePrice - item.Discount
                };
                baskets.Add(data);
            }

            if (await posBasketItemOperation.Add(baskets))
                Clear();
        }

        private async void BasketLoad()
        {
            var baskets = await posBasketOperation.GetBaskets();
            tileControlBaskets.Groups.Clear();
            tileControlBaskets.ItemSize = 150;
            tileControlBaskets.ItemPadding = new Padding(5);
            TileBarGroup group1 = new TileBarGroup();
            foreach (var item in baskets)
            {
                string name = item.BasketName;
                string Id = $"#{item.Id}";
                string customerName = item.CustomerName;
                decimal totalAmount = item.TotalAmount;

                TileItem tile = new TileItem();
                tile.ItemSize = TileItemSize.Default;
                tile.AppearanceItem.Normal.BackColor = Color.FromArgb(231, 72, 86);
                tile.AppearanceItem.Normal.ForeColor = Color.White;

                //basketName
                TileItemElement basketElement = new TileItemElement();
                basketElement.Text = name;
                basketElement.TextAlignment = TileItemContentAlignment.TopLeft;
                basketElement.MaxWidth = 100;
                basketElement.Appearance.Normal.Font = new Font("Poppins", 11);

                //Id
                TileItemElement IdElement = new TileItemElement();
                IdElement.Text = Id;
                IdElement.TextAlignment = TileItemContentAlignment.TopRight;
                IdElement.MaxWidth = 100;
                IdElement.Appearance.Normal.Font = new Font("Poppins", 9);

                //customerName
                TileItemElement customerElement = new TileItemElement();
                customerElement.Text = customerName;
                customerElement.TextAlignment = TileItemContentAlignment.MiddleCenter;
                customerElement.Appearance.Normal.Font = new Font("Poppins", 10);

                TileItemElement priceElement = new TileItemElement();
                priceElement.Text = totalAmount.ToString("N2") + " AZN";
                priceElement.TextAlignment = TileItemContentAlignment.BottomRight;
                priceElement.Appearance.Normal.Font = new Font("Nunito", 12, FontStyle.Bold);

                tile.Elements.Add(basketElement);
                tile.Elements.Add(IdElement);
                tile.Elements.Add(customerElement);
                tile.Elements.Add(priceElement);

                group1.Items.Add(tile);
                tileControlBaskets.Groups.Add(group1);
            }
        }

        private async void tileControlBaskets_ItemClick(object sender, TileItemEventArgs e)
        {
            try
            {
                if (gridBasket.RowCount > 0)
                    return;

                string basketName = e.Item.Elements[0].Text;

                var basket = await posBasketOperation.Get(x => x.BasketName == basketName);
                var items = await posBasketItemOperation.ToListAsync(x => x.PosBasketId == basket.Id);

                _customer = basket?.Customer;
                tCustomer.Text = basket?.Customer?.NameSurname;

                foreach (var item in items)
                {
                    var product = _productsList.Find(x => x.Id == item.ProductId);

                    PosSaleItemDto grid = new PosSaleItemDto
                    {
                        Id = item.ProductId,
                        ProductName = product.ProductName,
                        PurchasePrice = item.PurchasePrice,
                        SalePrice = item.SalePrice,
                        Discount = item.DiscountAmount,
                        Quantity = item.Quantity,
                        Barcode = product.Barcode,
                        UnitId = product.UnitId,
                        TaxId = product.TaxId,
                        No = rowNo,
                    };
                    dataList.Add(grid);
                    rowNo++;
                }
                gridControlBasket.RefreshDataSource();
                await posBasketOperation.Remove(basket);
                navigationFrameRight.SelectedPage = pageHotProducts;
            }
            finally
            {
                TotalAmountCalculation();
            }
        }

        RepositoryItemTextEdit repositoryN3;
        RepositoryItemTextEdit repositoryN0;

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

            gridControlBasket.RepositoryItems.Add(repositoryN3);
            gridControlBasket.RepositoryItems.Add(repositoryN0);
        }

        private void gridBasket_CustomRowCellEdit(object sender, DevExpress.XtraGrid.Views.Grid.CustomRowCellEditEventArgs e)
        {
            if (e.Column.FieldName is "Quantity")
            {
                var unitName = gridBasket.GetRowCellValue(e.RowHandle, "UnitName")?.ToString();

                if (unitName is "Kq")
                    e.RepositoryItem = repositoryN3;
                else
                    e.RepositoryItem = repositoryN0;
            }
        }
    }
}