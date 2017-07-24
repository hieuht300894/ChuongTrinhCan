using ChuongTrinhCan.Module;
using ChuongTrinhCan.Report;
using DevExpress.XtraReports.UI;
using EntityModel.DataModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing.Printing;
using System.Windows.Forms;

namespace ChuongTrinhCan.GUI.Common
{
    public partial class frmSetting : DevExpress.XtraEditors.XtraForm
    {
        public delegate void LoadData(string msg);
        public LoadData ReloadData;
        DialogResult dRe = DialogResult.Cancel;
        //string _sqlName, _sqlUser, _sqlPass;
        //bool _wAu;

        #region Form Events
        public frmSetting()
        {
            InitializeComponent();
        }

        private void frmSetting_Load(object sender, EventArgs e)
        {
            btnLuu.Enabled = false;
            //Load giá trị mặc định cho các field
            //txtComputerName.Text = Environment.MachineName;
            //txtMayChuFTP.EditValue = clsGeneral.Decrypt(Properties.Settings.Default.ftp);
            //txtTenFPT.EditValue = clsGeneral.Decrypt(Properties.Settings.Default.ftp_user);
            //txtPassFTP.EditValue = clsGeneral.Decrypt(Properties.Settings.Default.ftp_pw);

            txtComputerName.EditValue = Properties.Settings.Default.ComputerName;
            txtSQLServerName.EditValue = clsGeneral.Decrypt(Properties.Settings.Default.sServerName);
            tsbSQLAuthentication.IsOn = !Properties.Settings.Default.sWinAu;
            txtSQLUserName.EditValue = clsGeneral.Decrypt(Properties.Settings.Default.sUserName);
            txtSQLPassword.EditValue = clsGeneral.Decrypt(Properties.Settings.Default.sPassword);
            cbbDatabase.Enabled = false;

            txtSerComName.EditValue = Properties.Settings.Default.ServerComputerName;
            txtSerSerName.EditValue = clsGeneral.Decrypt(Properties.Settings.Default.ServerServerName);
            tgsWAuth.IsOn = !Properties.Settings.Default.ServerWinAu;
            txtSerUsername.EditValue = clsGeneral.Decrypt(Properties.Settings.Default.ServerUsername);
            txtSerPassword.EditValue = clsGeneral.Decrypt(Properties.Settings.Default.ServerPassword);
            cbbSerDB.Enabled = false;

            this.KeyPreview = true;

            loadPrinter();
            lokPrinter.Format(false);
        }

        //Sự kiện click btnKiemTra
        private void btnKiemTra_Click(object sender, EventArgs e)
        {
            //_sqlName = txtSQLServerName.Text;
            //_sqlUser = txtSQLUserName.Text;
            //_sqlPass = txtSQLPassword.Text;
            //_wAu = !tsbSQLAuthentication.IsOn;
            if (checkConnection(txtSQLServerName.Text.Trim(), !tsbSQLAuthentication.IsOn, txtSQLUserName.Text.Trim(), txtSQLPassword.Text.Trim()))
            {
                cbbDatabase.Properties.Items.Clear();
                cbbDatabase.Properties.Items.AddRange(lstDatabase);
                cbbDatabase.Enabled = true;
                btnLuu.Enabled = true;
                cbbDatabase.EditValue = "ChuongTrinhCan";
            }
            else
            {
                cbbDatabase.Properties.Items.Clear();
                cbbDatabase.Enabled = false;
            }
        }

        private void btnSerConnect_Click(object sender, EventArgs e)
        {
            if (checkConnection(txtSerSerName.Text.Trim(), !tgsWAuth.IsOn, txtSerUsername.Text.Trim(), txtSerPassword.Text.Trim()))
            {
                cbbSerDB.Properties.Items.Clear();
                cbbSerDB.Properties.Items.AddRange(lstDatabase);
                cbbSerDB.Enabled = true;
                cbbSerDB.EditValue = "PhuocLoi";
            }
            else
            {
                cbbSerDB.Properties.Items.Clear();
                cbbSerDB.Enabled = false;
            }
        }

        //Xử lý sự kiện btnLuu
        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(cbbDatabase.Text))
            {
                Properties.Settings.Default.ComputerName = txtComputerName.Text.Trim();
                Properties.Settings.Default.sServerName = clsGeneral.Encrypt(txtSQLServerName.Text.Trim());
                Properties.Settings.Default.sWinAu = !tsbSQLAuthentication.IsOn;
                Properties.Settings.Default.sDBName = clsGeneral.Encrypt(cbbDatabase.Text.Trim());
                Properties.Settings.Default.sUserName = clsGeneral.Encrypt(txtSQLUserName.Text.Trim());
                Properties.Settings.Default.sPassword = clsGeneral.Encrypt(txtSQLPassword.Text.Trim());
                Properties.Settings.Default.IsConfigSQL = true;
            }

            if (!string.IsNullOrEmpty(cbbSerDB.Text))
            {
                Properties.Settings.Default.ServerComputerName = txtSerComName.Text.Trim();
                Properties.Settings.Default.ServerServerName = clsGeneral.Encrypt(txtSerSerName.Text.Trim());
                Properties.Settings.Default.ServerWinAu = !tgsWAuth.IsOn;
                Properties.Settings.Default.ServerDBName = clsGeneral.Encrypt(cbbSerDB.Text.Trim());
                Properties.Settings.Default.ServerUsername = clsGeneral.Encrypt(txtSerUsername.Text.Trim());
                Properties.Settings.Default.ServerPassword = clsGeneral.Encrypt(txtSerPassword.Text.Trim());
            }

            Properties.Settings.Default.Save();
            Properties.Settings.Default.Reload();
            dRe = System.Windows.Forms.DialogResult.OK;
            if (ReloadData != null)
                ReloadData(txtComputerName.Text);
            this.Close();
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmSetting_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Control)
            {
                if (e.KeyCode.Equals(Keys.S))
                {
                    btnLuu_Click(null, null);
                }
                else if (e.KeyCode.Equals(Keys.H))
                {
                    btnHuy_Click(null, null);
                }
                else if (e.KeyCode.Equals(Keys.E))
                {
                    btnKiemTra_Click(null, null);
                }
            }
        }

        private void frmSetting_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.DialogResult = dRe;
        }

        private void tsbXacThuc_Toggled(object sender, EventArgs e)
        {
            if (tsbSQLAuthentication.IsOn)
            {
                lciUserName.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                lciPassword.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
            }
            else
            {
                lciUserName.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                lciPassword.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            }
        }

        private void tgsWAuth_Toggled(object sender, EventArgs e)
        {
            if (tgsWAuth.IsOn)
            {
                lciSerUser.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                lciSerPass.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
            }
            else
            {
                lciSerUser.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                lciSerPass.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            }
        }

        private void cbbDatabase_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(cbbDatabase.Text))
                btnLuu.Enabled = false;
            else
                btnLuu.Enabled = true;
        }

        private void cbbSerDB_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(cbbSerDB.Text))
                btnLuu.Enabled = false;
            else
                btnLuu.Enabled = true;
        }
        #endregion

        #region Methods
        List<string> lstDatabase;

        public bool checkConnection(string ServerName, bool winAu, string UserName, string Password)
        {
            bool bRe = false;
            if (string.IsNullOrEmpty(ServerName)) return false;
            System.Data.SqlClient.SqlConnectionStringBuilder conB = new System.Data.SqlClient.SqlConnectionStringBuilder()
            {
                DataSource = ServerName,
                UserID = UserName,
                Password = Password,
                IntegratedSecurity = winAu,
                ConnectTimeout = 10

            };

            using (System.Data.SqlClient.SqlConnection con = new System.Data.SqlClient.SqlConnection(conB.ConnectionString))
            {
                try
                {
                    con.Open();
                    using (System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand("SELECT name from sys.databases", con))
                    {
                        lstDatabase = new List<string>();
                        using (IDataReader dr = cmd.ExecuteReader())
                        {
                            while (dr.Read())
                            {
                                lstDatabase.Add(dr[0].ToString());
                            }
                        }
                    }
                    bRe = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                return bRe;
            }
        }

        private void loadPrinter()
        {
            List<string> lstPrinter = new List<string>();
            foreach (string printer in PrinterSettings.InstalledPrinters)
            {
                lstPrinter.Add(printer);
            }
            lokPrinter.Properties.DataSource = lstPrinter.ToArray();
            lokPrinter.EditValue = Properties.Settings.Default.PrinterName;
        }
        private void printData()
        {
            rptPhieuCan rpt = new rptPhieuCan();
            List<eScaleInfomation> lst = new List<eScaleInfomation>();
            eScaleInfomation info = new eScaleInfomation();
            info.Code = "ABC";
            info.VehicleNumber = "ABC-12345";
            info.CustomerName = "KHÁCH HÀNG";
            info.ProductName = "SẢN PHẨM";
            info.ExportName = "NHẬP/XUẤT";
            info.WarehouseName = "KHO";
            info.Note = String.Empty;
            info.DateScale1 =  DateTime.Now.ServerNow();
            lst.Add(info);
            rpt.DataSource = lst;
            rpt.Parameters["_Name"].Value = clsGeneral.curAgency.Name;
            rpt.Parameters["_Address"].Value = clsGeneral.curAgency.Address;
            rpt.Parameters["_Phone"].Value = clsGeneral.curAgency.Phone;
            rpt.Parameters["_Mail"].Value = clsGeneral.curAgency.Email;

            ReportPrintTool report = new ReportPrintTool(rpt);
            report.PrinterSettings.PrinterName = lokPrinter.Text.Trim();
            report.PrinterSettings.DefaultPageSettings.Landscape = rpt.Landscape;
            report.PrinterSettings.DefaultPageSettings.PaperSize = new PaperSize(rpt.PaperKind.ToString(), rpt.PageWidth, rpt.PageHeight);

            try
            {
                if (report.PrinterSettings.IsValid)
                {
                    report.Print();
                    Properties.Settings.Default.PrinterName = lokPrinter.Text.Trim();
                    Properties.Settings.Default.Save();
                }
            }
            catch   { }
        }
        #endregion

        private void btnCheck_Click(object sender, EventArgs e)
        {
            printData();
        }
    }
}
