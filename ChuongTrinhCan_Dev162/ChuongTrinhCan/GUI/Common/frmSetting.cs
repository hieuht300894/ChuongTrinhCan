using ChuongTrinhCan.Module;
using ChuongTrinhCan.Report;
using DevExpress.XtraEditors;
using DevExpress.XtraReports.UI;
using EntityModel.DataModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing.Printing;
using System.Windows.Forms;

namespace ChuongTrinhCan.GUI.Common
{
    //public partial class frmSetting : DevExpress.XtraEditors.XtraForm
    //{
    //    public delegate void LoadData(string msg);
    //    public LoadData ReloadData;
    //    DialogResult dRe = DialogResult.Cancel;
    //    //string _sqlName, _sqlUser, _sqlPass;
    //    //bool _wAu;

    //    #region Form Events
    //    public frmSetting()
    //    {
    //        InitializeComponent();
    //    }

    //    private void frmSetting_Load(object sender, EventArgs e)
    //    {
    //        btnLuu.Enabled = false;
    //        //Load giá trị mặc định cho các field
    //        //txtComputerName.Text = Environment.MachineName;
    //        //txtMayChuFTP.EditValue = clsGeneral.Decrypt(Properties.Settings.Default.ftp);
    //        //txtTenFPT.EditValue = clsGeneral.Decrypt(Properties.Settings.Default.ftp_user);
    //        //txtPassFTP.EditValue = clsGeneral.Decrypt(Properties.Settings.Default.ftp_pw);

    //        txtComputerName.EditValue = Properties.Settings.Default.ComputerName;
    //        txtSQLServerName.EditValue = clsGeneral.Decrypt(Properties.Settings.Default.sServerName);
    //        tsbSQLAuthentication.IsOn = !Properties.Settings.Default.sWinAu;
    //        txtSQLUserName.EditValue = clsGeneral.Decrypt(Properties.Settings.Default.sUserName);
    //        txtSQLPassword.EditValue = clsGeneral.Decrypt(Properties.Settings.Default.sPassword);
    //        cbbDatabase.Enabled = false;

    //        txtSerComName.EditValue = Properties.Settings.Default.ServerComputerName;
    //        txtSerSerName.EditValue = clsGeneral.Decrypt(Properties.Settings.Default.ServerServerName);
    //        tgsWAuth.IsOn = !Properties.Settings.Default.ServerWinAu;
    //        txtSerUsername.EditValue = clsGeneral.Decrypt(Properties.Settings.Default.ServerUsername);
    //        txtSerPassword.EditValue = clsGeneral.Decrypt(Properties.Settings.Default.ServerPassword);
    //        cbbSerDB.Enabled = false;

    //        this.KeyPreview = true;

    //        loadPrinter();
    //        lokPrinter.Format(false);
    //    }

    //    //Sự kiện click btnKiemTra
    //    private void btnKiemTra_Click(object sender, EventArgs e)
    //    {
    //        //_sqlName = txtSQLServerName.Text;
    //        //_sqlUser = txtSQLUserName.Text;
    //        //_sqlPass = txtSQLPassword.Text;
    //        //_wAu = !tsbSQLAuthentication.IsOn;
    //        if (checkConnection(txtSQLServerName.Text.Trim(), !tsbSQLAuthentication.IsOn, txtSQLUserName.Text.Trim(), txtSQLPassword.Text.Trim()))
    //        {
    //            cbbDatabase.Properties.Items.Clear();
    //            cbbDatabase.Properties.Items.AddRange(lstDatabase);
    //            cbbDatabase.Enabled = true;
    //            btnLuu.Enabled = true;
    //            cbbDatabase.EditValue = "PhuocLoi";
    //        }
    //        else
    //        {
    //            cbbDatabase.Properties.Items.Clear();
    //            cbbDatabase.Enabled = false;
    //        }
    //    }

    //    private void btnSerConnect_Click(object sender, EventArgs e)
    //    {
    //        if (checkConnection(txtSerSerName.Text.Trim(), !tgsWAuth.IsOn, txtSerUsername.Text.Trim(), txtSerPassword.Text.Trim()))
    //        {
    //            cbbSerDB.Properties.Items.Clear();
    //            cbbSerDB.Properties.Items.AddRange(lstDatabase);
    //            cbbSerDB.Enabled = true;
    //            cbbSerDB.EditValue = "PhuocLoi";
    //        }
    //        else
    //        {
    //            cbbSerDB.Properties.Items.Clear();
    //            cbbSerDB.Enabled = false;
    //        }
    //    }

    //    //Xử lý sự kiện btnLuu
    //    private void btnLuu_Click(object sender, EventArgs e)
    //    {
    //        if (!string.IsNullOrEmpty(cbbDatabase.Text))
    //        {
    //            Properties.Settings.Default.ComputerName = txtComputerName.Text.Trim();
    //            Properties.Settings.Default.sServerName = clsGeneral.Encrypt(txtSQLServerName.Text.Trim());
    //            Properties.Settings.Default.sWinAu = !tsbSQLAuthentication.IsOn;
    //            Properties.Settings.Default.sDBName = clsGeneral.Encrypt(cbbDatabase.Text.Trim());
    //            Properties.Settings.Default.sUserName = clsGeneral.Encrypt(txtSQLUserName.Text.Trim());
    //            Properties.Settings.Default.sPassword = clsGeneral.Encrypt(txtSQLPassword.Text.Trim());
    //            Properties.Settings.Default.IsConfigSQL = true;
    //        }

    //        if (!string.IsNullOrEmpty(cbbSerDB.Text))
    //        {
    //            Properties.Settings.Default.ServerComputerName = txtSerComName.Text.Trim();
    //            Properties.Settings.Default.ServerServerName = clsGeneral.Encrypt(txtSerSerName.Text.Trim());
    //            Properties.Settings.Default.ServerWinAu = !tgsWAuth.IsOn;
    //            Properties.Settings.Default.ServerDBName = clsGeneral.Encrypt(cbbSerDB.Text.Trim());
    //            Properties.Settings.Default.ServerUsername = clsGeneral.Encrypt(txtSerUsername.Text.Trim());
    //            Properties.Settings.Default.ServerPassword = clsGeneral.Encrypt(txtSerPassword.Text.Trim());
    //        }

    //        Properties.Settings.Default.Save();
    //        Properties.Settings.Default.Reload();
    //        dRe = System.Windows.Forms.DialogResult.OK;
    //        if (ReloadData != null)
    //            ReloadData(txtComputerName.Text);
    //        this.Close();
    //    }

    //    private void btnHuy_Click(object sender, EventArgs e)
    //    {
    //        this.Close();
    //    }

    //    private void frmSetting_KeyUp(object sender, KeyEventArgs e)
    //    {
    //        if (e.Control)
    //        {
    //            if (e.KeyCode.Equals(Keys.S))
    //            {
    //                btnLuu_Click(null, null);
    //            }
    //            else if (e.KeyCode.Equals(Keys.H))
    //            {
    //                btnHuy_Click(null, null);
    //            }
    //            else if (e.KeyCode.Equals(Keys.E))
    //            {
    //                btnKiemTra_Click(null, null);
    //            }
    //        }
    //    }

    //    private void frmSetting_FormClosing(object sender, FormClosingEventArgs e)
    //    {
    //        this.DialogResult = dRe;
    //    }

    //    private void tsbXacThuc_Toggled(object sender, EventArgs e)
    //    {
    //        if (tsbSQLAuthentication.IsOn)
    //        {
    //            lciUserName.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
    //            lciPassword.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
    //        }
    //        else
    //        {
    //            lciUserName.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
    //            lciPassword.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
    //        }
    //    }

    //    private void tgsWAuth_Toggled(object sender, EventArgs e)
    //    {
    //        if (tgsWAuth.IsOn)
    //        {
    //            lciSerUser.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
    //            lciSerPass.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
    //        }
    //        else
    //        {
    //            lciSerUser.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
    //            lciSerPass.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
    //        }
    //    }

    //    private void cbbDatabase_TextChanged(object sender, EventArgs e)
    //    {
    //        if (string.IsNullOrEmpty(cbbDatabase.Text))
    //            btnLuu.Enabled = false;
    //        else
    //            btnLuu.Enabled = true;
    //    }

    //    private void cbbSerDB_TextChanged(object sender, EventArgs e)
    //    {
    //        if (string.IsNullOrEmpty(cbbSerDB.Text))
    //            btnLuu.Enabled = false;
    //        else
    //            btnLuu.Enabled = true;
    //    }
    //    #endregion

    //    #region Methods
    //    List<string> lstDatabase;

    //    public bool checkConnection(string ServerName, bool winAu, string UserName, string Password)
    //    {
    //        bool bRe = false;
    //        if (string.IsNullOrEmpty(ServerName)) return false;
    //        System.Data.SqlClient.SqlConnectionStringBuilder conB = new System.Data.SqlClient.SqlConnectionStringBuilder()
    //        {
    //            DataSource = ServerName,
    //            UserID = UserName,
    //            Password = Password,
    //            IntegratedSecurity = winAu,
    //            ConnectTimeout = 10

    //        };

    //        using (System.Data.SqlClient.SqlConnection con = new System.Data.SqlClient.SqlConnection(conB.ConnectionString))
    //        {
    //            try
    //            {
    //                con.Open();
    //                using (System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand("SELECT name from sys.databases", con))
    //                {
    //                    lstDatabase = new List<string>();
    //                    using (IDataReader dr = cmd.ExecuteReader())
    //                    {
    //                        while (dr.Read())
    //                        {
    //                            lstDatabase.Add(dr[0].ToString());
    //                        }
    //                    }
    //                }
    //                bRe = true;
    //            }
    //            catch (Exception ex)
    //            {
    //                MessageBox.Show(ex.Message);
    //            }
    //            return bRe;
    //        }
    //    }

    //    private void loadPrinter()
    //    {
    //        List<string> lstPrinter = new List<string>();
    //        foreach (string printer in PrinterSettings.InstalledPrinters)
    //        {
    //            lstPrinter.Add(printer);
    //        }
    //        lokPrinter.Properties.DataSource = lstPrinter.ToArray();
    //        lokPrinter.EditValue = Properties.Settings.Default.PrinterName;
    //    }
    //    private void printData()
    //    {
    //        rptPhieuCan rpt = new rptPhieuCan();
    //        List<eScaleInfomation> lst = new List<eScaleInfomation>();
    //        eScaleInfomation info = new eScaleInfomation();
    //        info.Code = "ABC";
    //        info.VehicleNumber = "ABC-12345";
    //        info.CustomerName = "KHÁCH HÀNG";
    //        info.ProductName = "SẢN PHẨM";
    //        info.ExportName = "NHẬP/XUẤT";
    //        info.WarehouseName = "KHO";
    //        info.Note = String.Empty;
    //        info.DateScale1 =  DateTime.Now.ServerNow();
    //        lst.Add(info);
    //        rpt.DataSource = lst;
    //        rpt.Parameters["_Name"].Value = clsGeneral.curAgency.Name;
    //        rpt.Parameters["_Address"].Value = clsGeneral.curAgency.Address;
    //        rpt.Parameters["_Phone"].Value = clsGeneral.curAgency.Phone;
    //        rpt.Parameters["_Mail"].Value = clsGeneral.curAgency.Email;

    //        ReportPrintTool report = new ReportPrintTool(rpt);
    //        report.PrinterSettings.PrinterName = lokPrinter.Text.Trim();
    //        report.PrinterSettings.DefaultPageSettings.Landscape = rpt.Landscape;
    //        report.PrinterSettings.DefaultPageSettings.PaperSize = new PaperSize(rpt.PaperKind.ToString(), rpt.PageWidth, rpt.PageHeight);

    //        try
    //        {
    //            if (report.PrinterSettings.IsValid)
    //            {
    //                report.Print();
    //                Properties.Settings.Default.PrinterName = lokPrinter.Text.Trim();
    //                Properties.Settings.Default.Save();
    //            }
    //        }
    //        catch   { }
    //    }
    //    #endregion

    //    private void btnCheck_Click(object sender, EventArgs e)
    //    {
    //        printData();
    //    }
    //}

    public partial class frmSetting : XtraForm
    {
        public delegate void LoadData(string msg);
        public LoadData ReloadData;
        DialogResult dRe = DialogResult.Cancel;

        public frmSetting()
        {
            InitializeComponent();
        }

        #region Form Events
        private void frmSetting_Load(object sender, EventArgs e)
        {
            #region FTP
            //txtMayChuFTP.EditValue = clsGeneral.Decrypt(Properties.Settings.Default.ftp);
            //txtTenFPT.EditValue = clsGeneral.Decrypt(Properties.Settings.Default.ftp_user);
            //txtPassFTP.EditValue = clsGeneral.Decrypt(Properties.Settings.Default.ftp_pw);
            #endregion

            #region Client
            txtComputerName_Client.Text = string.IsNullOrEmpty(Properties.Settings.Default.sComputerName) ?
                Environment.MachineName :
                Properties.Settings.Default.sComputerName;
            txtSQLServerName_Client.Text = clsGeneral.Decrypt(Properties.Settings.Default.sServerName_Client);
            tsbSQLAuthentication_Client.IsOn = !Properties.Settings.Default.sWinAu_Client;
            txtSQLUserName_Client.Text = clsGeneral.Decrypt(Properties.Settings.Default.sUserName_Client);
            txtSQLPassword_Client.Text = clsGeneral.Decrypt(Properties.Settings.Default.sPassword_Client);
            if (!string.IsNullOrEmpty(clsGeneral.Decrypt(Properties.Settings.Default.sDBName_Client)))
            {
                cbbDatabase_Client.Properties.Items.Add(clsGeneral.Decrypt(Properties.Settings.Default.sDBName_Client));
                cbbDatabase_Client.SelectedIndex = 0;
            }
            cbbDatabase_Client.Enabled = cbbDatabase_Client.Properties.Items.Count > 0;
            if (tsbSQLAuthentication_Client.IsOn)
            {
                lciUserName_Client.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                lciPassword_Client.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
            }
            else
            {
                lciUserName_Client.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                lciPassword_Client.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            }
            #endregion

            #region Server
            txtComputerName_Server.Text = Properties.Settings.Default.sComputerName_Server;
            txtSQLServerName_Server.Text = clsGeneral.Decrypt(Properties.Settings.Default.sServerName_Server);
            tsbSQLAuthentication_Server.IsOn = !Properties.Settings.Default.sWinAu_Server;
            txtSQLUserName_Server.Text = clsGeneral.Decrypt(Properties.Settings.Default.sUserName_Server);
            txtSQLPassword_Server.Text = clsGeneral.Decrypt(Properties.Settings.Default.sPassword_Server);
            if (!string.IsNullOrEmpty(clsGeneral.Decrypt(Properties.Settings.Default.sDBName_Server)))
            {
                cbbDatabase_Server.Properties.Items.Add(clsGeneral.Decrypt(Properties.Settings.Default.sDBName_Server));
                cbbDatabase_Server.SelectedIndex = 0;
            }
            cbbDatabase_Server.Enabled = cbbDatabase_Server.Properties.Items.Count > 0;
            if (tsbSQLAuthentication_Server.IsOn)
            {
                lciUsername_Server.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                lciPassword_Server.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
            }
            else
            {
                lciUsername_Server.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                lciPassword_Server.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            }
            #endregion

            #region Printer
            List<string> lstPrinter = new List<string>();
            foreach (string printer in PrinterSettings.InstalledPrinters)
            {
                lstPrinter.Add(printer);
            }
            lokPrinter.Properties.DataSource = lstPrinter.ToArray();
            lokPrinter.EditValue = Properties.Settings.Default.PrinterName;
            #endregion

            #region Event
            btnCheckPrinter.Click += btnCheckPrinter_Click;
            btnTestConnect_Client.Click += btnTestConnect_Client_Click;
            btnTestConnect_Server.Click += btnTestConnect_Server_Click;
            tsbSQLAuthentication_Client.Toggled += tsbSQLAuthentication_Client_Toggled;
            tsbSQLAuthentication_Server.Toggled += tsbSQLAuthentication_Server_Toggled;
            #endregion
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(cbbDatabase_Client.Text))
            {
                Properties.Settings.Default.sComputerName = txtComputerName_Client.Text;
                Properties.Settings.Default.sServerName_Client = clsGeneral.Encrypt(txtSQLServerName_Client.Text);
                Properties.Settings.Default.sWinAu_Client = !tsbSQLAuthentication_Client.IsOn;
                Properties.Settings.Default.sDBName_Client = clsGeneral.Encrypt(cbbDatabase_Client.Text);
                Properties.Settings.Default.sUserName_Client = clsGeneral.Encrypt(txtSQLUserName_Client.Text);
                Properties.Settings.Default.sPassword_Client = clsGeneral.Encrypt(txtSQLPassword_Client.Text);
                Properties.Settings.Default.IsConfigSQL = true;
                ReloadData?.Invoke(txtComputerName_Client.Text);
            }

            if (!string.IsNullOrEmpty(cbbDatabase_Client.Text))
            {
                Properties.Settings.Default.sComputerName_Server = txtComputerName_Server.Text;
                Properties.Settings.Default.sServerName_Server = clsGeneral.Encrypt(txtSQLServerName_Server.Text);
                Properties.Settings.Default.sWinAu_Server = !tsbSQLAuthentication_Server.IsOn;
                Properties.Settings.Default.sDBName_Server = clsGeneral.Encrypt(cbbDatabase_Server.Text);
                Properties.Settings.Default.sUserName_Server = clsGeneral.Encrypt(txtSQLUserName_Server.Text);
                Properties.Settings.Default.sPassword_Server = clsGeneral.Encrypt(txtSQLPassword_Server.Text);
            }

            Properties.Settings.Default.Save();
            Properties.Settings.Default.Reload();

            dRe = DialogResult.OK;
            this.Close();

        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmSetting_KeyUp(object sender, KeyEventArgs e)
        {
            //if (e.Control)
            //{
            //    if (e.KeyCode.Equals(Keys.S))
            //    {
            //        btnLuu_Click(null, null);
            //    }
            //    else if (e.KeyCode.Equals(Keys.H))
            //    {
            //        btnHuy_Click(null, null);
            //    }
            //    else if (e.KeyCode.Equals(Keys.E))
            //    {
            //        btnKiemTra_Click(null, null);
            //    }
            //}
        }

        private void frmSetting_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.DialogResult = dRe;
        }

        private void btnKiemTra_Click(object sender, EventArgs e)
        {

        }

        private void btnTestConnect_Server_Click(object sender, EventArgs e)
        {
            if (checkConnection(cbbDatabase_Server, txtSQLServerName_Server.Text, !tsbSQLAuthentication_Server.IsOn, txtSQLUserName_Server.Text, txtSQLPassword_Server.Text))
            {
                cbbDatabase_Server.Enabled = true;
                cbbDatabase_Server.EditValue = "";
            }
            else
            {
                cbbDatabase_Server.Properties.Items.Clear();
                cbbDatabase_Server.Enabled = false;
            }
        }

        private void btnTestConnect_Client_Click(object sender, EventArgs e)
        {
            if (checkConnection(cbbDatabase_Client, txtSQLServerName_Client.Text, !tsbSQLAuthentication_Client.IsOn, txtSQLUserName_Client.Text, txtSQLPassword_Client.Text))
            {
                cbbDatabase_Client.Enabled = true;
                cbbDatabase_Client.EditValue = "DB_CAN";
            }
            else
            {
                cbbDatabase_Client.Properties.Items.Clear();
                cbbDatabase_Client.Enabled = false;
            }
        }

        private void btnCheckPrinter_Click(object sender, EventArgs e)
        {
            printData();
        }

        private void tsbSQLAuthentication_Server_Toggled(object sender, EventArgs e)
        {
            if (tsbSQLAuthentication_Server.IsOn)
            {
                lciUsername_Server.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                lciPassword_Server.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
            }
            else
            {
                lciUsername_Server.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                lciPassword_Server.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            }
        }

        private void tsbSQLAuthentication_Client_Toggled(object sender, EventArgs e)
        {
            if (tsbSQLAuthentication_Client.IsOn)
            {
                lciUserName_Client.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                lciPassword_Client.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
            }
            else
            {
                lciUserName_Client.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                lciPassword_Client.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            }
        }
        #endregion

        #region Methods
        public bool checkConnection(ComboBoxEdit cbbMain, string ServerName, bool winAu, string UserName, string Password)
        {
            if (string.IsNullOrEmpty(ServerName)) return false;
            System.Data.SqlClient.SqlConnectionStringBuilder conB = new System.Data.SqlClient.SqlConnectionStringBuilder()
            {
                DataSource = ServerName,
                UserID = UserName,
                Password = Password,
                IntegratedSecurity = winAu,
                ConnectTimeout = 30
            };

            using (System.Data.SqlClient.SqlConnection con = new System.Data.SqlClient.SqlConnection(conB.ConnectionString))
            {
                try
                {
                    con.Open();
                    using (System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand("SELECT name from sys.databases", con))
                    {
                        using (IDataReader dr = cmd.ExecuteReader())
                        {
                            cbbMain = cbbMain ?? new ComboBoxEdit();
                            cbbMain.Properties.Items.Clear();
                            while (dr.Read())
                            {
                                cbbMain.Properties.Items.Add(dr[0].ToString());
                            }
                        }
                    }
                    return true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return false;
                }
            }
        }

        #region Printer
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
            info.DateScale1 = DateTime.Now.ServerNow();
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
            catch { }
        }
        #endregion

        #region Client DB

        #endregion

        #region Server DB

        #endregion

        #endregion
    }
}
