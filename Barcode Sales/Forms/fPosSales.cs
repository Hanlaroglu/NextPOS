﻿using DevExpress.XtraEditors;
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
    public partial class fPosSales : DevExpress.XtraEditors.XtraForm
    {
        public fPosSales()
        {
            InitializeComponent();
        }

        private void bControlPanel_Click(object sender, EventArgs e)
        {
            fPosSalesControlPanel f = new fPosSalesControlPanel();
            f.ShowDialog();
        }
    }
}