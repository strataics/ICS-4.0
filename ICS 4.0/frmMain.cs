using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using ICS_4._0.Buyer;

namespace ICS_4._0
{
    public partial class frmMain : DevExpress.XtraEditors.XtraForm
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            lblDate.Text = DateTime.Now.ToLongDateString();
        }

        private void nbiNewBuyer_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            frmBuyer buyer = new frmBuyer();
            buyer.TopLevel = false;
            buyer.AutoScroll = true;
            pnl2.Controls.Add(buyer);
            buyer.Show();
        }
    }
}