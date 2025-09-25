using Barcode_Sales.Forms;
using Barcode_Sales.Helpers;
using Barcode_Sales.Helpers.Messages;
using Barcode_Sales.Operations.Abstract;
using Barcode_Sales.Operations.Concrete;
using Barcode_Sales.Tools;
using Barcode_Sales.Validations;
using DevExpress.XtraBars.Navigation;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Localization;
using Microsoft.Win32;
using NextPOS.UserControls;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Barcode_Sales.Helpers.FormHelpers;
using static Barcode_Sales.Tools.OperationsControl;

namespace Barcode_Sales.Barcode.Sales.Admin
{
    public partial class fDashboard : DevExpress.XtraBars.FluentDesignSystem.FluentDesignForm
    {
        NextposDBEntities db = new NextposDBEntities();

        ICustomerOperation customerOperation = new CustomerManager();
        IProductOperation productOperation = new ProductManager();
        IAqtaProductsOperation aqtaProductsOperation = new AqtaProductsManager();
        ICategoryOperation categoryOperation = new CategoryManager();
        ISupplierOperation supplierOperation = new SupplierManager();
        ISupplierDebtOperation supplierDebtOperation = new SupplierDebtManager();
        IUserOperation userOperation = new UserManager();
        IRoleOperation roleOperation = new RoleManager();
        ICustomerDebtOperation customerDebtOperation = new CustomerDebtManager();
        IReturnPosOperation returnPosOperation = new ReturnPosManager();

        private readonly Users CurrentUser;
        public fDashboard(Users _user)
        {
            InitializeComponent();
            CurrentUser = _user;
            GridLocalizer.Active = new MyGridLocalizer();
            AllGridPanelText();
        }

        private void fDashboard_Load(object sender, EventArgs e)
        {
            AuthorizationControl();
            ProductStockLoad();
        }

        void AuthorizationControl()
        {
            if (UserValidation.AuthorizationControl(CurrentUser, role => role.Bank))
            {
                bBankSalesGroup.Enabled = true;
            }
            if (UserValidation.AuthorizationControl(CurrentUser, role => role.Reports))
            {
                bReports.Enabled = true;
            }
            if (UserValidation.AuthorizationControl(CurrentUser, role => role.Settings))
            {
                bSettings.Enabled = true;
            }
            if (UserValidation.AuthorizationControl(CurrentUser, role => role.User))
            {
                bUserGroup.Enabled = true;
            }
        }

        void AllGridPanelText()
        {
            GridPanelText(gridProducts);
            GridPanelText(gridCustomers);
            GridPanelText(gridSalesProduct);
            GridPanelText(gridSupplier);
            GridPanelText(gridSupplierDebt);
            GridPanelText(gridRole);
            GridPanelText(gridUsers);
        }

        void FormNavigation(Action action, string caption, NavigationPage page)
        {
            Cursor.Current = Cursors.WaitCursor;
            HeaderStaticText.Caption = caption;
            navigationMenu.SelectedPage = page;
            action();
            Cursor.Current = Cursors.Default;
        }

        private void bMehsulAlis_Click(object sender, EventArgs e)
        {

        }


        #region [...Dashboard...]

        private void bPanel_Click(object sender, EventArgs e)
        {
            navigationMenu.SelectedPage = pageMain;
        }

        private async void ProductStockLoad()
        {
            var data =await productOperation.WhereAsync(x => x.IsDeleted == 0);
            gridControlDashboardStock.DataSource = data;
        }

        #endregion [...Dashboard...]



        #region [...Products...]

        private void AqtaProductFill()
        {
            if (db.AqtaProducts.AsNoTracking().Any())
            {
                var data = aqtaProductsOperation.WhereAsync(x => x.IsDeleted == 0).Result;

                FormHelpers.ControlLoad(data, gridControlProducts);

            }
            gridProducts.RefreshData();
            FormHelpers.GridCustomRowNumber(gridProducts);
            tablePanelProductCount.Visible = false;
        }

        private async void ProductFill()
        {
            var data = await productOperation.WhereAsync(x => x.IsDeleted == 0);
            FormHelpers.ControlLoad(data, gridControlProducts);
            gridProducts.RefreshData();
            lPlusProduct_Count.Text = data.Count(x => x.Amount > 0).ToString();
            lNegativeProduct_Count.Text = data.Count(x => x.Amount < 0).ToString();
            lZeroProduct_Count.Text = data.Count(x => x.Amount == 0).ToString();
            FormHelpers.GridCustomRowNumber(gridProducts);
        }

        private void bProductList_Click(object sender, EventArgs e)
        {
            FormNavigation(ProductFill, "Məhsullar", pageProduct);
            //FormNavigation(AqtaProductFill, "Məhsullar", pageProduct);
        }

        private void bStatusProduct_CheckedChanged(object sender, EventArgs e)
        {
            if (true)
            {

            }

            if (gridProducts.GetFocusedRow() == null)
            {
                OperationsControl.Message(CommonMessages.NOT_SELECTİON, NextPOS.UserControls.fMessage.enmType.Warning);
                return;
            }
            var edit = (CheckEdit)sender;
            Products products = (Products)gridProducts.GetFocusedRow();
            products.Status = (bool)edit.EditValue;
            //todo status codunu yaz
            //productOperation.StatusUpdate(products, (bool)edit.EditValue);
        }

        private void bAddProduct_Click(object sender, EventArgs e)
        {
            FormHelpers.OpenForm<fAddProduct>(Enums.Operation.Add, null);
            // FormHelpers.OpenForm<fAqtaAddProfuct>(Enums.Operation.Add, null);
        }

        private void bEditProduct_Click(object sender, EventArgs e)
        {
            if (gridProducts.GetFocusedRow() == null)
            {
                OperationsControl.Message(CommonMessages.NOT_SELECTİON, NextPOS.UserControls.fMessage.enmType.Warning);
                return;
            }
            else
            {
                int productId = Convert.ToInt32(gridProducts.GetFocusedRowCellValue("Id").ToString());
                Products data = productOperation.GetById(productId);
                fAddProduct f = new fAddProduct(Enums.Operation.Edit, data);
                if (f.ShowDialog() is DialogResult.OK)
                {
                    ProductFill();
                }
            }
        }

        private void bDeleteProduct_Click(object sender, EventArgs e)
        {
            if (gridProducts.GetFocusedRow() == null)
            {
                OperationsControl.Message(CommonMessages.NOT_SELECTİON, NextPOS.UserControls.fMessage.enmType.Warning);
                return;
            }
            else
            {
                int productId = Convert.ToInt32(gridProducts.GetFocusedRowCellValue("Id").ToString());
                var product = productOperation.GetById(productId);
                productOperation.Remove(product);
                ProductFill();
            }
        }

        private void bExportProduct_Click(object sender, EventArgs e)
        {
            //Todo Products export kodlarını əlavə et. Çap etə vurduqda çap etmə seçənəklərini göstərsin (pdf,xlsx,word)
        }

        private void bProductRefresh_Click(object sender, EventArgs e)
        {
            ProductFill();
        }

        private void gridProducts_DoubleClick(object sender, EventArgs e)
        {
            if (gridProducts.GetFocusedRow() == null)
            {
                OperationsControl.Message(CommonMessages.NOT_SELECTİON, NextPOS.UserControls.fMessage.enmType.Warning);
                return;
            }
            else
            {
                int productId = Convert.ToInt32(gridProducts.GetFocusedRowCellValue("Id").ToString());
                var product = productOperation.GetById(productId);
                FormHelpers.OpenForm<fAddProduct>(Enums.Operation.Show, product);
            }
        }

        #endregion [...Products...]



        #region [...Categories...]

        private async void CategoryFill()
        {
            var data = await categoryOperation.WhereAsync(x => x.IsDeleted == 0);
            FormHelpers.ControlLoad(data, gridControlCategory);
            gridCategory.GroupPanelText = $"Kateqoriya sayı: {data.Count()}";
            gridCategory.RefreshData();
            GridCustomRowNumber(gridCategory);
        }

        private void bCategory_Click(object sender, EventArgs e)
        {
            FormNavigation(CategoryFill, "Kateqoriyalar", pageCategory);
        }

        private void bCategoryAdd_Click(object sender, EventArgs e)
        {
            string value = "";
            DialogResult result = InputBox.Show("Yeni kateqoriya",
                                                "Kateqoriyanın adını daxil edin:",
                                                Enums.GetEnumDescription(Enums.Operation.Add),
                                                ref value);


            bool uniqueData = categoryOperation.Where(x => x.CategoryName == value).Any();

            if (uniqueData is true && result == DialogResult.OK)
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    CommonMessageBox.WarningMessageBox("Kateqoriya adı boş olabilməz");
                    return;
                }

                Categories category = new Categories
                {
                    CategoryName = value,
                    IsDeleted = 0,
                    Status = true,
                };

                categoryOperation.Add(category);
                OperationsControl.Message(value + " kateqoriyası yaradıldı", fMessage.enmType.Success);
                CategoryFill();
            }
            else
            {
                OperationsControl.Message("Daxil edilən kateqoriya adı sistemdə mövcuddur: " + value, fMessage.enmType.Error);
                return;
            }
        }

        private void bEditCategory_Click(object sender, EventArgs e)
        {
            if (gridCategory.GetFocusedRow() == null)
            {
                OperationsControl.Message(CommonMessages.NOT_SELECTİON, NextPOS.UserControls.fMessage.enmType.Warning);
                return;
            }
            int Id = Convert.ToInt32(gridCategory.GetFocusedRowCellValue("Id").ToString());
            var data = categoryOperation.GetById(Id);
            string value = "";
            DialogResult result = InputBox.Show($"{data.CategoryName} / kateqoriya düzəlişi",
                                                "Kateqoriyanın adını daxil edin:",
                                                Enums.GetEnumDescription(Enums.Operation.Edit),
                                                ref value);



            if (result == DialogResult.OK)
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    CommonMessageBox.WarningMessageBox("Kateqoriya adı boş olabilməz");
                    return;
                }
                if (db.Categories.Any(x => x.CategoryName.ToLower() == value.ToLower()))
                {
                    OperationsControl.Message("Daxil edilən kateqoriya adı sistemdə mövcuddur: " + value, fMessage.enmType.Error);
                    return;
                }

                data.CategoryName = value;
                categoryOperation.Update(data);
                OperationsControl.Message(value + " kateqoriyasında düzəliş edildi", fMessage.enmType.Success);
                CategoryFill();
            }
        }

        private void bDeleteCategory_Click(object sender, EventArgs e)
        {
            if (gridCategory.GetFocusedRow() == null)
            {
                OperationsControl.Message(CommonMessages.NOT_SELECTİON, NextPOS.UserControls.fMessage.enmType.Warning);
                return;
            }
            else
            {
                int CategorytId = Convert.ToInt32(gridCategory.GetFocusedRowCellValue("Id").ToString());
                var data = categoryOperation.GetById(CategorytId);
                categoryOperation.Remove(data);
                CategoryFill();
            }
        }

        private void bCategoryRefresh_Click(object sender, EventArgs e)
        {
            CategoryFill();
        }

        private void bExportCategory_Click(object sender, EventArgs e)
        {

        }

        private void bCategoryStatus_CheckedChanged(object sender, EventArgs e)
        {
            if (gridCategory.GetFocusedRow() == null)
            {
                OperationsControl.Message(CommonMessages.NOT_SELECTİON, fMessage.enmType.Warning);
                return;
            }
            var edit = (CheckEdit)sender;
            Categories data = (Categories)gridCategory.GetFocusedRow();
            data.Status = (bool)edit.EditValue;
            categoryOperation.StatusUpdate(data);
        }

        #endregion [...Categories...]



        #region [...Suppliers...] 

        private async void SupplierDataLoad()
        {
            var data = await supplierOperation.WhereAsync(x => x.IsDeleted == 0);
            FormHelpers.ControlLoad(data, gridControlSupplier);
            gridSupplier.GroupPanelText = $"Təchizatçı sayı: {gridSupplier.RowCount}";
            gridSupplier.RefreshData();
            GridCustomRowNumber(gridSupplier);
        }

        private void bSupplier_Click(object sender, EventArgs e)
        {
            FormNavigation(SupplierDataLoad, "Təchizatçı", pageSupplier);
        }

        private void gridSupplier_DoubleClick(object sender, EventArgs e)
        {
            if (gridSupplier.GetFocusedRow() == null)
            {
                NoticationHelpers.Messages.WarningMessage(this, CommonMessages.NOT_SELECTİON);
                return;
            }
            else
            {
                int Id = Convert.ToInt32(gridSupplier.GetFocusedRowCellValue("Id").ToString());
                var data = supplierOperation.GetById(Id);
                fSupplier f = new fSupplier(Enums.Operation.Show, data);
                if (f.ShowDialog() is DialogResult.OK)
                {
                    SupplierDataLoad();
                }
            }
        }

        private void bSupplier_Add_Click(object sender, EventArgs e)
        {
            OpenForm<fSupplier>(Enums.Operation.Add, null);
        }

        private void chSupplierStatus_CheckedChanged(object sender, EventArgs e)
        {
            if (gridSupplier.GetFocusedRow() == null)
            {
                NoticationHelpers.Messages.WarningMessage(this, CommonMessages.NOT_SELECTİON);
                return;
            }

            bool status = Convert.ToBoolean(gridSupplier.GetFocusedRowCellValue("Status").ToString());
            if (status)
            {
                SelectedSupplierBlocked();
            }
            else
            {
                SelectedSupplierActived();
            }
        }

        private void bSupplier_Edit_Click(object sender, EventArgs e)
        {
            if (gridSupplier.GetFocusedRow() == null)
            {
                NoticationHelpers.Messages.WarningMessage(this, CommonMessages.NOT_SELECTİON);
                return;
            }
            else
            {
                int Id = Convert.ToInt32(gridSupplier.GetFocusedRowCellValue("Id").ToString());
                var data = supplierOperation.GetById(Id);
                fSupplier f = new fSupplier(Enums.Operation.Edit, data);
                if (f.ShowDialog() is DialogResult.OK)
                {
                    SupplierDataLoad();
                }
            }
        }

        private void bSupplier_Delete_Click(object sender, EventArgs e)
        {
            if (chCategorySelected.Checked)
            {
                int[] selectedRows = gridSupplier.GetSelectedRows();


                var args = NoticationHelpers.Dialogs.DialogResultYesNo($"{selectedRows.Count()} təchizatçını silmək istədiyinizə əminsiniz ?");
                var result = XtraMessageBox.Show(args);
                if (result is DialogResult.Yes)
                {
                    foreach (var item in selectedRows)
                    {
                        Suppliers suppliers = gridSupplier.GetRow(item) as Suppliers;
                        supplierOperation.RemoveAsync(suppliers);
                    }
                    SupplierDataLoad();
                }
            }
            else
            {
                if (gridSupplier.GetFocusedRow() == null)
                {
                    NoticationHelpers.Messages.WarningMessage(this, CommonMessages.NOT_SELECTİON);
                    return;
                }
                else
                {
                    int Id = Convert.ToInt32(gridSupplier.GetFocusedRowCellValue("Id").ToString());
                    var data = supplierOperation.GetById(Id);
                    supplierOperation.Remove(data);
                    SupplierDataLoad();
                }
            }
        }

        private void bSupplier_Refresh_Click(object sender, EventArgs e)
        {
            SupplierDataLoad();
        }

        private void bSupplier_Block_Click(object sender, EventArgs e)
        {
            if (chCategorySelected.Checked)
            {
                MultiSelectedSupplierBlocked();
            }
            else
            {
                SelectedSupplierBlocked();
            }
        }

        private void bActive_Supplier_Click(object sender, EventArgs e)
        {
            if (chCategorySelected.Checked)
            {
                MultiSelectedSupplierActive();
            }
            else
            {
                SelectedSupplierActived();
            }
        }

        private async void MultiSelectedSupplierBlocked()
        {
            int[] selectedRows = gridSupplier.GetSelectedRows();


            var args = NoticationHelpers.Dialogs.DialogResultYesNo($"{selectedRows.Count()} təchizatçını bloklamaq istədiyinizə əminsiniz ?");
            var result = XtraMessageBox.Show(args);
            if (result is DialogResult.Yes)
            {
                List<Suppliers> suppliers = selectedRows
                                            .Select(x => gridSupplier.GetRow(x) as Suppliers)
                                            .Where(supplier => supplier != null)
                                            .ToList();

                await supplierOperation.BlockedAsync(suppliers);


                SupplierDataLoad();
            }
        }

        private void SelectedSupplierBlocked()
        {
            int? Id = Convert.ToInt32(gridSupplier.GetFocusedRowCellValue("Id").ToString());
            var data = supplierOperation.GetById((int)Id);
            string result = supplierOperation.Blocked(data);
            if (result is null)
            {
                NoticationHelpers.Messages.ErrorMessage(this, $"{data.SupplierName} təchizatçısında edilən əməliyyat uğursuz oldu");
            }
            else
            {
                NoticationHelpers.Messages.SuccessMessage(this, result);
                SupplierDataLoad();
            }
        }

        private async void MultiSelectedSupplierActive()
        {
            int[] selectedRows = gridSupplier.GetSelectedRows();


            var args = NoticationHelpers.Dialogs.DialogResultYesNo($"{selectedRows.Count()} təchizatçını aktiv etmək istədiyinizə əminsiniz ?");
            var result = XtraMessageBox.Show(args);
            if (result is DialogResult.Yes)
            {
                List<Suppliers> suppliers = selectedRows
                                            .Select(x => gridSupplier.GetRow(x) as Suppliers)
                                            .Where(supplier => supplier != null)
                                            .ToList();

                await supplierOperation.ActiveAsync(suppliers);


                SupplierDataLoad();
            }
        }

        private void SelectedSupplierActived()
        {
            int? Id = Convert.ToInt32(gridSupplier.GetFocusedRowCellValue("Id").ToString());
            var data = supplierOperation.GetById((int)Id);
            string result = supplierOperation.Active(data);
            if (result is null)
            {
                NoticationHelpers.Messages.ErrorMessage(this, $"{data.SupplierName} təchizatçısında edilən əməliyyat uğursuz oldu");
            }
            else
            {
                NoticationHelpers.Messages.SuccessMessage(this, result);
                SupplierDataLoad();
            }
        }

        private void chSupplierSelected_CheckedChanged(object sender, EventArgs e)
        {
            if (chCategorySelected.Checked)
            {
                gridSupplier.OptionsSelection.MultiSelect = true;
                gridSupplier.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect;
            }
            else
            {
                gridSupplier.OptionsSelection.MultiSelect = false;
                gridSupplier.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.RowSelect;
            }
        }


        #region [..Supplier Debt..]

        private void bSupplierDebt_Click(object sender, EventArgs e)
        {
            FormNavigation(SuppliersDebtsLoad, "Təchizatçı borcları", pageSupplierDebt);
        }

        private async void SuppliersDebtsLoad()
        {
            var data = await supplierDebtOperation.WhereAsync(x => x.Debt > 0 || x.TaxDebt > 0);
            FormHelpers.ControlLoad(data, gridControlSupplierDebt);
            gridSupplierDebt.GroupPanelText = $"Təchizatçı sayı: {gridSupplierDebt.RowCount}";
            gridSupplierDebt.RefreshData();
            GridCustomRowNumber(gridSupplierDebt);
        }

        private void bSupplierDebt_Refresh_Click(object sender, EventArgs e)
        {
            SuppliersDebtsLoad();
        }

        private void chSupplierDebt_Select_CheckedChanged(object sender, EventArgs e)
        {
            if (chSupplierDebt_Select.Checked)
            {
                gridSupplierDebt.OptionsSelection.MultiSelect = true;
                gridSupplierDebt.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect;
            }
            else
            {
                gridSupplierDebt.OptionsSelection.MultiSelect = false;
                gridSupplierDebt.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.RowSelect;
            }
        }

        private void bPaySuppliersDebt_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (gridSupplierDebt.GetFocusedRow() == null)
            {
                NoticationHelpers.Messages.WarningMessage(this, CommonMessages.NOT_SELECTİON);
                return;
            }
            else
            {
                int Id = Convert.ToInt32(gridSupplierDebt.GetFocusedRowCellValue("Id").ToString());
                var data = supplierDebtOperation.GetById(Id);
                fSupplierPay fSupplierPay = new fSupplierPay(Enums.Operation.Pay, data);
                if (fSupplierPay.ShowDialog() is DialogResult.OK)
                {
                    SuppliersDebtsLoad();
                }
            }
        }

        private void bSupplierDebt_Add_Click(object sender, EventArgs e)
        {
            fAddSupplierDebt f = new fAddSupplierDebt(Enums.Operation.Add);
            if (f.ShowDialog() is DialogResult.OK)
            {
                SuppliersDebtsLoad();
            }
        }

        private void bSupplierDebt_Edit_Click(object sender, EventArgs e)
        {
            int? Id = Convert.ToInt32(gridSupplierDebt.GetFocusedRowCellValue("Id").ToString());
            var data = supplierDebtOperation.GetById((int)Id);

            fAddSupplierDebt f = new fAddSupplierDebt(Enums.Operation.Edit, data);
            if (f.ShowDialog() is DialogResult.OK)
            {
                SuppliersDebtsLoad();
            }
        }

        private async void bSupplierDebt_Delete_Click(object sender, EventArgs e)
        {
            if (gridSupplierDebt.GetFocusedRow() == null)
            {
                NoticationHelpers.Messages.WarningMessage(this, CommonMessages.NOT_SELECTİON);
                return;
            }

            if (chSupplierDebt_Select.Checked)
            {
                int[] selectedRows = gridSupplierDebt.GetSelectedRows();


                var args = NoticationHelpers.Dialogs.DialogResultYesNo($"{selectedRows.Count()} təchizatçının borcunu silmək istədiyinizə əminsiniz ?");
                var result = XtraMessageBox.Show(args);
                if (result is DialogResult.Yes)
                {
                    foreach (var item in selectedRows)
                    {
                        SuppliersDebt debt = gridSupplierDebt.GetRow(item) as SuppliersDebt;
                        await supplierDebtOperation.RemoveAsync(debt);
                    }
                    await Task.Delay(1500);
                    SuppliersDebtsLoad();
                }
            }
            else
            {
                int Id = Convert.ToInt32(gridSupplierDebt.GetFocusedRowCellValue("Id").ToString());
                var data = supplierDebtOperation.GetById(Id);
                supplierDebtOperation.Remove(data);
                SuppliersDebtsLoad();
            }
        }

        private void bSupplierDebt_Pay_Click(object sender, EventArgs e)
        {
            //todo Toplu ödənişlərin kodunu yaz
        }

        private void bListPayments_Click(object sender, EventArgs e)
        {
            FormHelpers.OpenForm<fSupplierPaidData>();
        }

        #endregion [..Supplier Debt..]


        #endregion [...Suppliers...] 



        #region [...Customers...]

        private async void CustomerLoadData()
        {
            var data = await customerOperation.WhereAsync(x => x.IsDeleted == 0);
            ControlLoad(data, gridControlCustomers);
            gridCustomers.GroupPanelText = $"Müştəri sayı : {data.Count()}";
            GridCustomRowNumber(gridCustomers);
        }

        private void bCustomerList_Click(object sender, EventArgs e)
        {
            FormNavigation(CustomerLoadData, "Müştərilər", pageCustomers);
        }

        private void bAddCustomer_Click(object sender, EventArgs e)
        {
            OpenForm<fAddCustomer>(Enums.Operation.Add);
        }

        private void bEditCustomer_Click(object sender, EventArgs e)
        {
            if (gridCustomers.GetFocusedRow() is null) { CommonMessageBox.InformationMessageBox(CommonMessages.NOT_SELECTİON); return; }

            int id = Convert.ToInt32(gridCustomers.GetFocusedRowCellValue("Id").ToString());
            Customer customer = customerOperation.GetById(id);
            fAddCustomer f = new fAddCustomer(Enums.Operation.Edit);
            if (f.ShowDialog() is DialogResult.OK)
            {
                NoticationHelpers.Messages.SuccessMessage(this, $"{customer.NameSurname} müştərisində düzəliş edildi");
                CustomerLoadData();
            }
        }

        private void bDeleteCustomer_Click(object sender, EventArgs e)
        {
            if (gridCustomers.GetFocusedRow() is null) { CommonMessageBox.InformationMessageBox(CommonMessages.NOT_SELECTİON); return; }
            int id = Convert.ToInt32(gridCustomers.GetFocusedRowCellValue("Id").ToString());
            var data = customerOperation.GetById(id);
            customerOperation.Remove(data);
            CustomerLoadData();
        }

        private void bRefreshCustomer_Click(object sender, EventArgs e)
        {
            CustomerLoadData();
        }

        private void chCustomerStatus_CheckedChanged(object sender, EventArgs e)
        {
            if (gridCustomers.GetFocusedRow() == null)
            {
                NoticationHelpers.Messages.WarningMessage(this, CommonMessages.NOT_SELECTİON);
                return;
            }

            bool status = Convert.ToBoolean(gridCustomers.GetFocusedRowCellValue("Status").ToString());
            if (status)
            {
                SelectedCustomerBlocked();
            }
            else
            {
                SelectedCustomerActived();
            }
        }

        private void bCustomerActive_Click(object sender, EventArgs e)
        {
            if (chCustomerSelected.Checked)
            {
                MultiSelectedCustomerActive();
            }
            else
            {
                SelectedCustomerActived();
            }
        }

        private void bCustomerDeactive_Click(object sender, EventArgs e)
        {
            if (chCustomerSelected.Checked)
            {
                MultiSelectedCustomerBlocked();
            }
            else
            {
                SelectedCustomerBlocked();
            }
        }

        private void chCustomerSelected_CheckedChanged(object sender, EventArgs e)
        {
            if (chCustomerSelected.Checked)
            {
                gridCustomers.OptionsSelection.MultiSelect = true;
                gridCustomers.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect;
            }
            else
            {
                gridCustomers.OptionsSelection.MultiSelect = false;
                gridCustomers.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.RowSelect;
            }
        }

        private void SelectedCustomerActived()
        {
            int? Id = Convert.ToInt32(gridCustomers.GetFocusedRowCellValue("Id").ToString());
            var data = customerOperation.GetById((int)Id);
            string result = customerOperation.Active(data);
            if (result is null)
            {
                NoticationHelpers.Messages.ErrorMessage(this, $"{data.NameSurname} müştərisində edilən əməliyyat uğursuz oldu");
            }
            else
            {
                NoticationHelpers.Messages.SuccessMessage(this, result);
                SupplierDataLoad();
            }
        }

        private void SelectedCustomerBlocked()
        {
            int? Id = Convert.ToInt32(gridCustomers.GetFocusedRowCellValue("Id").ToString());
            var data = customerOperation.GetById((int)Id);
            string result = customerOperation.Blocked(data);
            if (result is null)
            {
                NoticationHelpers.Messages.ErrorMessage(this, $"{data.NameSurname} müştərisində edilən əməliyyat uğursuz oldu");
            }
            else
            {
                NoticationHelpers.Messages.SuccessMessage(this, result);
                SupplierDataLoad();
            }
        }

        private async void MultiSelectedCustomerActive()
        {
            int[] selectedRows = gridCustomers.GetSelectedRows();

            if (selectedRows.Count() is 0)
            {
                NoticationHelpers.Messages.WarningMessage(this, CommonMessages.NOT_SELECTİON);
                return;
            }
            var args = NoticationHelpers.Dialogs.DialogResultYesNo($"{selectedRows.Count()} müştərini aktiv etmək istədiyinizə əminsiniz ?");
            var result = XtraMessageBox.Show(args);
            if (result is DialogResult.Yes)
            {
                List<Customer> customer = selectedRows
                                            .Select(x => gridCustomers.GetRow(x) as Customer)
                                            .Where(c => c != null)
                                            .ToList();

                await customerOperation.ActiveAsync(customer);


                CustomerLoadData();
            }
        }

        private async void MultiSelectedCustomerBlocked()
        {
            int[] selectedRows = gridCustomers.GetSelectedRows();

            if (selectedRows.Count() is 0)
            {
                NoticationHelpers.Messages.WarningMessage(this, CommonMessages.NOT_SELECTİON);
                return;
            }
            var args = NoticationHelpers.Dialogs.DialogResultYesNo($"{selectedRows.Count()} müştərini bloklamaq istədiyinizə əminsiniz ?");
            var result = XtraMessageBox.Show(args);
            if (result is DialogResult.Yes)
            {
                List<Customer> customer = selectedRows
                                            .Select(x => gridCustomers.GetRow(x) as Customer)
                                            .Where(c => c != null)
                                            .ToList();

                await customerOperation.BlockedAsync(customer);


                CustomerLoadData();
            }
        }

        #region [...Customers Debt...]

        private async void CustomerDebtLoadData()
        {
            var data = await customerDebtOperation.WhereAsync(x => x.IsDeleted == 0);
            ControlLoad(data, gridControlCustomerDebts);
            gridCustomerDebts.GroupPanelText = $"Borclu müştəri sayı : {data.Count()}";
            GridCustomRowNumber(gridCustomers);
        }

        private void bDebtCustomerList_Click(object sender, EventArgs e)
        {
            FormNavigation(CustomerDebtLoadData, "Borclu müştərilər", pageCustomerDebt);
        }

        #endregion [...Customers Debt...]

        #endregion [...Customers...]



        #region [...Users...]

        void UsersDataLoad()
        {
            if (db.Users.AsNoTracking().Any())
            {
                var data = userOperation.WhereAsync(x => x.IsDeleted == x.Id);
                FormHelpers.ControlLoad(data.Result, gridControlUsers);
                GridCustomRowNumber(gridUsers);
                lUserCount.Text = $"İstifadəçi sayı : {data.Result.Count()}";
            }
            gridUsers.RefreshData();
        }

        private void bUsers_Click(object sender, EventArgs e)
        {
            FormNavigation(UsersDataLoad, "İstifadəçilər", pageUsers);
        }

        private void bNewUser_Click(object sender, EventArgs e)
        {
            FormHelpers.OpenForm<fUsers>(Enums.Operation.Add, null);
        }

        private void bEditUser_Click(object sender, EventArgs e)
        {
            if (gridUsers.GetFocusedRow() == null)
            {
                OperationsControl.Message(CommonMessages.NOT_SELECTİON, fMessage.enmType.Warning);
                return;
            }
            else
            {
                int Id = Convert.ToInt32(gridUsers.GetFocusedRowCellValue("Id").ToString());
                var data = userOperation.GetById(Id);
                fUsers f = new fUsers(Enums.Operation.Edit, data);
                if (f.ShowDialog() is DialogResult.OK)
                {
                    UsersDataLoad();
                }
            }
        }

        private void bDeleteUser_Click(object sender, EventArgs e)
        {
            if (gridUsers.GetFocusedRow() == null)
            {
                OperationsControl.Message(CommonMessages.NOT_SELECTİON, fMessage.enmType.Warning);
                return;
            }
            else
            {
                int Id = Convert.ToInt32(gridUsers.GetFocusedRowCellValue("Id").ToString());
                var data = userOperation.GetById(Id);
                userOperation.Remove(data);
                UsersDataLoad();
            }
        }

        private void bUserRefresh_Click(object sender, EventArgs e)
        {
            UsersDataLoad();
        }

        private void bUserExport_Click(object sender, EventArgs e)
        {

        }

        private void chUserStatus_CheckedChanged(object sender, EventArgs e)
        {
            if (gridUsers.GetFocusedRow() == null)
            {
                OperationsControl.Message(CommonMessages.NOT_SELECTİON, fMessage.enmType.Warning);
                return;
            }
            var edit = (CheckEdit)sender;
            Users data = (Users)gridUsers.GetFocusedRow();
            data.Status = (bool)edit.EditValue;
            //userOperation.StatusUpdate(data);
        }

        #endregion [...Users...]



        #region [...Roles...]

        private void bRoles_Click(object sender, EventArgs e)
        {
            FormNavigation(RolesDataLoad, "Rol və İcazələr", pageRole);
        }

        void RolesDataLoad()
        {
            if (db.Roles.AsNoTracking().Any())
            {
                var data = roleOperation.WhereAsync(x => x.IsDeleted == 0).Result;
                FormHelpers.ControlLoad(data, gridControlRole);
                GridCustomRowNumber(gridRole);
            }
            gridRole.RefreshData();
        }

        private void bRoleAdd_Click(object sender, EventArgs e)
        {
            FormHelpers.OpenForm<fRole>(Enums.Operation.Add, null);
        }

        private void bRoleEdit_Click(object sender, EventArgs e)
        {
            if (gridRole.GetFocusedRow() == null)
            {
                OperationsControl.Message(CommonMessages.NOT_SELECTİON, fMessage.enmType.Warning);
                return;
            }
            else
            {
                int Id = Convert.ToInt32(gridRole.GetFocusedRowCellValue("Id").ToString());
                var data = roleOperation.GetById(Id);
                fRole f = new fRole(Enums.Operation.Edit, data);
                if (f.ShowDialog() is DialogResult.OK)
                {
                    RolesDataLoad();
                }
            }
        }

        private void bRoleRemove_Click(object sender, EventArgs e)
        {
            if (gridRole.GetFocusedRow() == null)
            {
                OperationsControl.Message(CommonMessages.NOT_SELECTİON, fMessage.enmType.Warning);
                return;
            }
            else
            {
                int Id = Convert.ToInt32(gridRole.GetFocusedRowCellValue("Id").ToString());
                var data = roleOperation.GetById(Id);
                roleOperation.Remove(data);
                RolesDataLoad();
            }
        }

        private void bRoleRefresh_Click(object sender, EventArgs e)
        {
            RolesDataLoad();
        }

        #endregion [...Roles...]



        #region [...Settings...]

        private void bSettins_Click(object sender, EventArgs e)
        {
            navigationMenu.SelectedPage = pageSettings;
            HeaderStaticText.Caption = "Sazlamalar";
            ProductLimit_UpDown.Value = Properties.Settings.Default.Panel_ProductMinLimit;
        }

        private void bKassalar_Click(object sender, EventArgs e)
        {
            FormHelpers.OpenForm<fKassalar>();
            //TabControlSettings.SelectedTabPage = tabPageKassalar;
            //if (db.Company.Any())
            //{
            //    var print = db.Company.FirstOrDefault();
            //    chPrinter.Checked = (bool)print.Printer;
            //}
            //else
            //{
            //    chPrinter.Enabled = false;
            //    OperationsControl.Message("Şirkət haqqında məlumatlar doldurulduqdan sonra aktiv ediləbilər", fMessage.enmType.Error);
            //    return;
            //}
        }

        private void chPrinter_CheckedChanged(object sender, EventArgs e)
        {
            //using (var db = new NextposDBEntities())
            //{
            //    if (db.Company.Any())
            //    {
            //        if (chPrinter.Checked)
            //        {
            //            //Islemler.SabitVarsayilan();
            //            var on = db.Company.FirstOrDefault();
            //            on.Printer = true;
            //            db.SaveChanges();
            //            //chYazmaDurumu.BackColor = System.Drawing.Color.FromArgb(46, 204, 113);
            //        }
            //        else
            //        {
            //            //Islemler.SabitVarsayilan();
            //            var off = db.Company.FirstOrDefault();
            //            off.Printer = false;
            //            db.SaveChanges();
            //            //chYazmaDurumu.BackColor = System.Drawing.Color.FromArgb(192, 57, 43);
            //        }
            //    }
            //    else
            //    {
            //        OperationsControl.Message("Şirkət haqqında məlumatlar doldurulduqdan sonra aktiv ediləbilər", fMessage.enmType.Error);
            //        return;
            //    }
            //}
        }

        private void bAllSettings_Click(object sender, EventArgs e)
        {
            navigationMenu.SelectedPage = pageSettings;
            TabControlSettings.SelectedTabPage = tabPageSettings;
            ProductLimit_UpDown.Value = Properties.Settings.Default.Panel_ProductMinLimit;
        }

        private void panelProductLimit_UpDown_ValueChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(ProductLimit_UpDown.Value.ToString()))
            {
                Properties.Settings.Default.Panel_ProductMinLimit = Convert.ToInt16(ProductLimit_UpDown.Value);
                Properties.Settings.Default.Save();
            }
        }

        private void bBackup_Click(object sender, EventArgs e)
        {

        }

        private void bLog_Click(object sender, EventArgs e)
        {

        }

        private void bExcel_Click(object sender, EventArgs e)
        {

        }


        #endregion [...Settings...]



        #region [...Reports...]

        #region Səhifələr
        private void bAlisHesabatList_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            PageControl();
            TabControlReport.SelectedTabPage = tableMehsulAlis;
            HeaderStaticText.Caption = "Məhsul alış hesabatı";
            dateStartAlis.DateTime = DateTime.Now;
            dateFinishAlis.DateTime = DateTime.Now;
            AlisHesabatiGet();
            Cursor.Current = Cursors.Default;
        }

        private void bMenfeetHesabatList_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            PageControl();
            TabControlReport.SelectedTabPage = tableMenfeet;
            HeaderStaticText.Caption = "Mənfəət hesabatı";
            Cursor.Current = Cursors.Default;
        }

        private void bObyektHesabatList_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            PageControl();
            TabControlReport.SelectedTabPage = tableObyekt;
            HeaderStaticText.Caption = "Obyekt və Kassir üzrə hesabat";
            Cursor.Current = Cursors.Default;
        }

        private void bKassirHesabatList_Click(object sender, EventArgs e)
        {
            //   Cursor.Current = Cursors.WaitCursor;
            //PageControl();
            //   TabControlReport.SelectedTabPage = tableKassir;
            //   HeaderStaticText.Caption = "Kassir üzrə satış hesabatı hesabatı";
            //   Cursor.Current = Cursors.Default;
        }

        private void bUmumiHesabatList_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            PageControl();
            TabControlReport.SelectedTabPage = tableUmumiSatis;
            HeaderStaticText.Caption = "Ümumi satış hesabatı";
            Cursor.Current = Cursors.Default;
        }

        private void bSatisNovHesabatList_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            PageControl();
            TabControlReport.SelectedTabPage = tableSatisNovHesabat;
            HeaderStaticText.Caption = "Satış növ hesabatı";
            SalesTypeFill();
            Cursor.Current = Cursors.Default;
        }

        private void bSatilanMehsullarHesabatList_Click(object sender, EventArgs e)
        {

            Cursor.Current = Cursors.WaitCursor;
            PageControl();
            TabControlReport.SelectedTabPage = tableSatilanMehsullar;
            HeaderStaticText.Caption = "Satılan məhsulların hesabatı";
            SalesProductFill();
            Cursor.Current = Cursors.Default;
        }

        private void bQaytarilanMehsullarHesabatList_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            PageControl();
            TabControlReport.SelectedTabPage = tableQaytarilanMehsullar;
            HeaderStaticText.Caption = "Qaytarılan məhsulların hesabatı";
            ReturnProducts();
            Cursor.Current = Cursors.Default;
        }

        #endregion 


        #region [...] Məhsul alış hesabatı

        private void AlisHesabatiGet()
        {
            //if (db.Invoice_Product.Any())
            //{
            //    var control = db.Invoice_Product.AsNoTracking().Select(x => new
            //    {
            //        x.InvoiceNo,
            //        x.Branchs,
            //        x.Users,
            //        x.Products,
            //        x.Supplier,
            //        x.Date,
            //        x.Branch_ID,
            //        x.Product_ID,
            //        x.Amount,
            //        x.Price,
            //        x.Total,
            //        x.SupplierID,
            //        x.User_ID
            //    });
            //    gridControlMehsulAlis.DataSource = control.OrderBy(x => x.InvoiceNo).ToList();
            //    lAlisMeblegi_Total.Text = control.Sum(x => x.Total).ToString() + " AZN";
            //    lAmount_Total.Text = control.Sum(x => x.Amount).ToString();
            //}
        }

        private void bAlisLoad_Click(object sender, EventArgs e)
        {
            //if (db.Invoice_Product.Any())
            //{
            //    var control = db.Invoice_Product.AsNoTracking().Select(x => new
            //    {
            //        x.InvoiceNo,
            //        x.Branchs,
            //        x.Users,
            //        x.Products,
            //        x.Supplier,
            //        x.Date,
            //        x.Branch_ID,
            //        x.Product_ID,
            //        x.Amount,
            //        x.Price,
            //        x.Total,
            //        x.SupplierID,
            //        x.User_ID
            //    }).Where(x => x.Date >= dateStartAlis.DateTime && x.Date <= dateFinishAlis.DateTime);

            //    gridControlMehsulAlis.DataSource = control.OrderBy(x => x.InvoiceNo).ToList();
            //    lAlisMeblegi_Total.Text = control.Sum(x => x.Total).ToString() + " AZN";
            //    lAmount_Total.Text = control.Sum(x => x.Amount).ToString();
            //}
        }
        #endregion

        void PageControl()
        {
            if (navigationMenu.SelectedPage != pageReport)
                navigationMenu.SelectedPage = pageReport;
        }

        void SalesProductFill()
        {
            ////Grid
            //dateStart_SalesProduct.DateTime = DateTime.Now;
            //dateFinish_SalesProduct.DateTime = DateTime.Now;
            //gridControlSalesProduct.DataSource = db.Sales_Product.AsNoTracking().ToList();
            ////Fliallar
            //cmbBranch_SalesProduct.DataSource = db.Branchs.OrderBy(x => x.Id).ToList();
            //cmbBranch_SalesProduct.DisplayMember = "FlialAdi";
            //cmbBranch_SalesProduct.ValueMember = "Id";
            ////Kassirler
            //cmbKassir_SalesProduct.DataSource = db.Users.OrderBy(x => x.Status == true && x.Type == false).ToList();
            //cmbKassir_SalesProduct.DisplayMember = "NameSurname";
            //cmbKassir_SalesProduct.ValueMember = "Id";
            ////Total
            //lSatilanMehsullarToplam.Text = db.Sales_Product.AsNoTracking().ToList().Sum(x => x.Total).Value.ToString("C2");
        }

        void SalesTypeFill()
        {
            ////Fliallar
            //cmbBranch_SalesType.DataSource = db.Branchs.OrderBy(x => x.Id).ToList();
            //cmbBranch_SalesType.DisplayMember = "FlialAdi";
            //cmbBranch_SalesType.ValueMember = "Id";

            //dateStart_SalesType.DateTime = DateTime.Now;
            //dateFinish_SalesType.DateTime = DateTime.Now;
            //gridControlSalesType.DataSource = db.Transaction_Report.AsNoTracking().Where(x => x.ProccesType == "Satış" && x.Branchs.FlialAdi == cmbBranch_SalesType.Text).ToList();

            ////Total
            //lCash_SalesType.Text = db.Transaction_Report.AsNoTracking().Where(x => x.ProccesType == "Satış" && x.Branchs.FlialAdi == cmbBranch_SalesType.Text).ToList().Sum(x => x.Cash).Value.ToString("C2");
            //lCard_SalesType.Text = db.Transaction_Report.AsNoTracking().Where(x => x.ProccesType == "Satış" && x.Branchs.FlialAdi == cmbBranch_SalesType.Text).ToList().Sum(x => x.Card).Value.ToString("C2");
        }

        void ReturnProducts()
        {
            ////Grid
            //dateStart_ReturnProduct.DateTime = DateTime.Now;
            //dateFinish_ReturnProduct.DateTime = DateTime.Now;
            //gridControlReturnProduct.DataSource = db.Return_Sales.AsNoTracking().OrderBy(x => x.Id).ToList();
            ////Fliallar
            //cmbBranch_ReturnProduct.DataSource = db.Branchs.OrderBy(x => x.Id).ToList();
            //cmbBranch_ReturnProduct.DisplayMember = "FlialAdi";
            //cmbBranch_ReturnProduct.ValueMember = "Id";
            ////Kassirler
            ////cmbKassir_ReturnProduct.DataSource = db.Users.OrderBy(x => x.Status == true && x.Type == false).ToList();
            ////cmbKassir_ReturnProduct.DisplayMember = "NameSurname";
            ////cmbKassir_ReturnProduct.ValueMember = "Id";
            ////Total
            //lReturnProductTotal.Text = db.Return_Sales.AsNoTracking().ToList().Sum(x => x.Total).ToString() + " AZN";
        }

        private void bLoad_SalesType_Click(object sender, EventArgs e)
        {
            SalesTypeFill();
        }

        #endregion [...Reports...]



        #region [...Company...]

        private string CompanyValidation()
        {
            if (String.IsNullOrEmpty(tCompanyName.Text))
                return "Şirkətin adı əlavə edilmədi";
            if (String.IsNullOrEmpty(tVoen.Text))
                return "Şirkətin vöeni əlavə edilmədi";
            if (String.IsNullOrEmpty(tAddress.Text))
                return "Şirkətin ünvanı əlavə edilmədi";
            if (String.IsNullOrEmpty(tPhone.Text))
                return "Telefon nömrəsi əlavə edilmədi";
            if (String.IsNullOrEmpty(tPersonel.Text))
                return "Məsul şəxs əlavə edilmədi";
            if (String.IsNullOrEmpty(dateRegistration.Text))
                return "Qeydiyyat tarixi əlavə edilmədi";
            return null;
        }

        void CompanyClear()
        {
            tCompanyName.Text = null;
            tVoen.Text = null;
            tPersonel.Text = null;
            tPhone.Text = null;
            tAddress.Text = null;
            dateRegistration.DateTime = DateTime.Now;
            tLogoPath.Text = null;
            tCompanyName.Focus();
        }

        void CompanyInfoFill()
        {
            //if (db.Company.Any())
            //{
            //    var info = db.Company.First();
            //    tCompanyName.Text = info.CompanyName;
            //    tVoen.Text = info.Voen;
            //    tAddress.Text = info.Adress;
            //    tPhone.Text = info.Phone;
            //    tPersonel.Text = info.Personel;
            //    dateRegistration.EditValue = info.RegisterDate;
            //    switch (info.Type)
            //    {
            //        case "Market": radioMarket.Checked = true; break;
            //        case "Restoran": radioRestoran.Checked = true; break;
            //        case "Geyim": radioGeyim.Checked = true; break;
            //        case "Digər": radioDiger.Checked = true; break;
            //    }
            //    lCompanyMessage.Visible = false;
            //    //Enabled false
            //    groupControl2.Enabled = false;
            //    //tCompanyName.Enabled = false;
            //    //tVoen.Enabled = false;
            //    //tPhone.Enabled = false;
            //    //tAddress.Enabled = false;
            //    //tPersonel.Enabled = false;
            //    //dateRegistration.Enabled = false;
            //    //CompanyFooter.Visible = false;
            //    groupControl4.Enabled = false;
            //}
            //else
            //{
            //    lCompanyMessage.Visible = true;
            //    dateRegistration.DateTime = DateTime.Now;
            //}
        }

        private void CompanyFooter_SaveClick(object sender, EventArgs e)
        {
            //if (CompanyValidation() != null) { OperationsControl.Message(CompanyValidation(), fMessage.enmType.Error); return; }
            //Company company = new Company();
            //company.Printer = false;
            //company.CompanyName = tCompanyName.Text.Trim();
            //company.Voen = tVoen.Text;
            //company.Adress = tAddress.Text.Trim();
            //company.Phone = tPhone.Text;
            //company.Personel = tPersonel.Text.Trim();
            //company.RegisterDate = dateRegistration.DateTime;
            //if (radioMarket.Checked) { company.Type = "Market"; }
            //if (radioRestoran.Checked) { company.Type = "Restoran"; }
            //if (radioGeyim.Checked) { company.Type = "Geyim"; }
            //if (picLogo.Image == null) { company.CompanyLogo = null; }
            //db.Company.Add(company);
            //db.SaveChanges();
            //OperationsControl.Message("Şirkət məlumatları əlavə edildi", fMessage.enmType.Success);
            //CompanyInfoFill();
        }

        private void bAddLogo_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Title = "Şirkət logosunu seçin";
            open.ShowDialog();
        }

        private void bLogoDelete_Click(object sender, EventArgs e)
        {
            picLogo.Image = null;
        }

        #endregion [...Company...]



        #region [...About...]

        private void bAbout_Click(object sender, EventArgs e)
        {
            FormNavigation(null, "Haqqımızda", pageAbout);
        }

        #endregion [...About...]



        #region [...Update...]

        WebClient web = new WebClient();

        private void bUpdate_Click(object sender, EventArgs e)
        {
            HeaderStaticText.Caption = "Yeniləmələr";
            navigationMenu.SelectedPage = pageUpdate;
            UpdatePage();
        }

        void UpdatePage()
        {
            CommonData.RegeditControl();
            bool autoUpdate = Convert.ToBoolean(Registry.CurrentUser.OpenSubKey("NGT").OpenSubKey("Next Market").OpenSubKey("Update").GetValue("StartUpdate"));
            lVersion.Text = Application.ProductVersion;
            if (Registry.CurrentUser.OpenSubKey("NGT").OpenSubKey("Next Market").OpenSubKey("Settings").GetValue("ProductID").ToString() == "N/A")
                OperationsControl.Message("Lisenziya açarınız yoxdur. Texniki şöbə ilə əlaqə saxlayın", fMessage.enmType.Error);
            lProductID.Text = Registry.CurrentUser.OpenSubKey("NGT").OpenSubKey("Next Market").OpenSubKey("Settings").GetValue("ProductID").ToString();
            toogleAutoUpdate.IsOn = autoUpdate;
        }

        private void toogleAutoUpdate_Toggled(object sender, EventArgs e)
        {
            bool control = Convert.ToBoolean(Registry.CurrentUser.OpenSubKey("NGT").OpenSubKey("Next Market").OpenSubKey("Update").GetValue("StartUpdate"));
            if (toogleAutoUpdate.IsOn == true)
                Registry.CurrentUser.CreateSubKey("NGT").CreateSubKey("Next Market").CreateSubKey("Update").SetValue("StartUpdate", true);
            else
                Registry.CurrentUser.CreateSubKey("NGT").CreateSubKey("Next Market").CreateSubKey("Update").SetValue("StartUpdate", false);
        }

        public void UpdateControl()
        {
            Cursor.Current = Cursors.WaitCursor;
            if (System.Net.NetworkInformation.NetworkInterface.GetIsNetworkAvailable() == true)
            {
                if (web.DownloadString("https://e-kassa.000webhostapp.com/NGT/Next.Market/Version.txt").Contains(Application.ProductVersion))
                    OperationsControl.Message("Yeni versiya mövcud deyil", fMessage.enmType.Info);
                else
                {
                    if (MessageBox.Show("Yeni versiyamız mövcuddur. 😍\nYükləmək istəyirsiniz ?", "Mesaj", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        Process.Start($"{Application.StartupPath}\\Update.exe");
                    else
                        return;
                }
            }
            else
                OperationsControl.Message("İnternet bağlantınız yoxdur", fMessage.enmType.Error);
            Cursor.Current = Cursors.Default;
        }

        private void bUpdateControl_Click(object sender, EventArgs e)
        {
            try
            {
                UpdateControl();
            }
            catch (WebException ex)
            {
                using (EventLog eventLog = new EventLog("Application"))
                {
                    eventLog.Source = "Next Market";
                    eventLog.WriteEntry(ex.Message, EventLogEntryType.Error, 404, 2666);
                }
                MessageBox.Show("Uzaq serverə qoşularkən xəta yarandı. Bir müddət sonra yenidən cəhd edin", "Mesaj", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void lOpenApplicationFolder_Click(object sender, EventArgs e)
        {
            Process.Start(Application.StartupPath);
        }

        private void bUpdateLog_Click(object sender, EventArgs e)
        {
            OperationsControl.Message("Tezliklə xidmətinizdə", fMessage.enmType.Info);
        }
        #endregion [...Update...]


        private void bRetunProduct_Click(object sender, EventArgs e)
        {
            //fMehsulAlisi f = new fMehsulAlisi();
            //f.Operation = "Return";
            //f.ShowDialog();
        }

        private void fDashboard_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void accordionControlElement11_Click(object sender, EventArgs e)
        {

        }
    }
}