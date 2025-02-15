using Barcode_Sales.Helpers.Messages;
using Barcode_Sales.Operations.Abstract;
using Barcode_Sales.Operations.Concrete;
using Barcode_Sales.Validations;
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

namespace Barcode_Sales.Forms
{
    public partial class fRegistration : DevExpress.XtraEditors.XtraForm
    {
        ICompanyOperation companyOperation = new CompanyManager();
        private Company _company;

        public fRegistration()
        {
            InitializeComponent();
            dateRegistration.DateTime = DateTime.Now;
        }

        private void wizardControl1_CancelClick(object sender, CancelEventArgs e)
        {
            if (CommonMessageBox.QuestionDialogResult("Çıxış etmək istədiyinizə əminsiniz ?", "Mesaj"))
            {
                Application.Exit();
            }
        }

        private void wizardControl1_FinishClick(object sender, CancelEventArgs e)
        {
            companyOperation.Add(_company);
        }

        private void wizardControl1_NextClick(object sender, DevExpress.XtraWizard.WizardCommandButtonClickEventArgs e)
        {
            if (e.Page == wizardPage1)
            {
                _company = new Company();
                _company.CompanyName = tCompanyName.Text.Trim();
                _company.Voen = tVoen.Text;
                _company.CompanyCode = tCompanyCode.Text;
                _company.Address = tAddress.Text.Trim();
                _company.Phone = tPhone.Text;
                _company.Email = tEmail.Text.Trim();
                _company.RegistrationDate = dateRegistration.DateTime;

                var validator = ValidationHelpers.ValidateMessage(_company, new CompanyValidation(), this);

                if (!validator.IsValid)
                {
                    wizardControl1.SelectedPage = wizardPage1;
                    return;
                }
            }
            else if (e.Page == completionWizardPage1)
            {

            }
        }
    }
}