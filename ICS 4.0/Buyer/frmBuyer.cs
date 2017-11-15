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
using MySql.Data.MySqlClient;
using System.Configuration;

namespace ICS_4._0.Buyer
{
    public partial class frmBuyer : DevExpress.XtraEditors.XtraForm
    {
        public frmBuyer()
        {
            InitializeComponent();
        }
        public string strBranchID;
        string strLog, strBID, dd, dated;
        private void BuyerID()
        {
            MySqlConnection Con;
            String ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            Con = new MySqlConnection(ConnectionString);
            Con.Open();
            try
            {
                MySqlCommand Com = new MySqlCommand() { Connection = Con, CommandText = String.Format("SELECT COUNT(BuyerID) FROM buyer WHERE DateAdded='" + dated + "' ") };
                MySqlDataReader reader = Com.ExecuteReader();
                object[] obj = new object[256];
                if (reader.Read())
                {
                    reader.GetValues(obj);
                    int value = int.Parse(obj[0].ToString());
                    value++;
                    strBID = strBranchID + "-B-" + dd + "-" + value.ToString();
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void frmBuyer_Load(object sender, EventArgs e)
        {
            txtBuyerDateOfBirth.Properties.DisplayFormat.FormatString = "yyyy-MM-dd";
            txtBuyerDateOfBirth.Properties.Mask.EditMask = "yyyy-MM-dd";
            txtBuyerDateOfBirth.Properties.EditFormat.FormatString = "yyyy-MM-dd";
            txtBuyerDateOfBirth.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            txtBuyerDateOfBirth.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            txtSpouseDateOfBirth.Properties.DisplayFormat.FormatString = "yyyy-MM-dd";
            txtSpouseDateOfBirth.Properties.Mask.EditMask = "yyyy-MM-dd";
            txtSpouseDateOfBirth.Properties.EditFormat.FormatString = "yyyy-MM-dd";
            txtSpouseDateOfBirth.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            txtSpouseDateOfBirth.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;

            DateTime d1 = DateTime.Now;
            dd = d1.ToString("yy-MM-dd");
            DateTime d2 = DateTime.Now;
            dated = d2.ToString("yyyy-MM-dd");

            timer1.Enabled = true;
            timer2.Enabled = true;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            strLog = DateTime.Now.ToString("yyyy-MM-dd hh:MM:ss");
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            BuyerID();
        }
    }
}