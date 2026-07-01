using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Barcode_Sales.Services.Interfaces;
using Barcode_Sales.Terminals.DTOs;
using DevExpress.DocumentView;
using DevExpress.XtraEditors;
using DevExpress.XtraLayout.Utils;

namespace Barcode_Sales.Forms
{
    public partial class fTestPay : DevExpress.XtraEditors.XtraForm
    {
        private readonly IPosSaleService _saleService;

        private PosSaleDto _data;
        public fTestPay()
        {
            InitializeComponent();
        }

        private void fTestPay_Load(object sender, EventArgs e)
        {
            tTotal.Text = 25.ToString("F2");
        }

        private void bCash_Click(object sender, EventArgs e)
        {
            tCash_Paid.Text = 25.ToString("N2");
            layoutItemCashBalance.Visibility = LayoutVisibility.Always;
            layoutItemCashPaid.Visibility = LayoutVisibility.Always;
            layoutItemCashCard_Card.Visibility = LayoutVisibility.Never;
            layoutItemCashCard_Cash.Visibility = LayoutVisibility.Never;
        }

        private void bCard_Click(object sender, EventArgs e)
        {
            layoutItemCashBalance.Visibility = LayoutVisibility.Never;
            layoutItemCashPaid.Visibility = LayoutVisibility.Never;
            layoutItemCashCard_Card.Visibility = LayoutVisibility.Never;
            layoutItemCashCard_Cash.Visibility = LayoutVisibility.Never;
        }

        private void bCashCard_Click(object sender, EventArgs e)
        {
            layoutItemCashCard_Card.Visibility = LayoutVisibility.Always;
            layoutItemCashCard_Cash.Visibility = LayoutVisibility.Always;
            layoutItemCashBalance.Visibility = LayoutVisibility.Always;

            layoutItemCashPaid.Visibility = LayoutVisibility.Never;
        }

        
    }
}