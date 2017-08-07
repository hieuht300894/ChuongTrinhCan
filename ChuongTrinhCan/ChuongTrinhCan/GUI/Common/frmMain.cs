using ChuongTrinhCan.BLL.CATE;
using ChuongTrinhCan.BLL.Common;
using ChuongTrinhCan.GUI.CATE;
using ChuongTrinhCan.GUI.REPORT;
using ChuongTrinhCan.Module;
using ChuongTrinhCan.Report;
using DevExpress.LookAndFeel;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Popup;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraLayout;
using DevExpress.XtraReports.UI;
using EntityModel.DataModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Printing;
using System.IO.Ports;
using System.Linq;
using System.Windows.Forms;

namespace ChuongTrinhCan.GUI.Common
{
    public partial class frmMain : XtraForm
    {
        #region Variable
        #region Control
        List<Control> lstInput;
        List<Control> lstFilter;
        List<Control> lstOther;
        Control nextControl;//Control tiếp theo
        int areaIndex = 0;//Vị trí vùng control
        bool backForward = false;
        #endregion

        #region SerialPort
        delegate void GetData(string text);
        GetData getData;
        SerialPort serial;
        string InputData = String.Empty;
        #endregion

        #region Entry
        //List<eScaleInfomation> lstData;
        BindingList<eCustomer> lstCustomers;
        BindingList<eProduct> lstProducts;
        BindingList<eWarehouse> lstWarehouses;
        eScaleInfomation _iEntry;
        eScaleInfomation _aEntry;
        int status = 1;
        int posWeight = 1;
        bool isFilter = false;
        bool isFindAll = true;
        #endregion
        #endregion

        #region Form
        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            clsGeneral.CallWaitForm(this);
            layoutControl1.Visible = false;
            LoadData();
            loadGiaoDien(0);
            customForm();
            layoutControl1.Visible = true;
            clsGeneral.CloseWaitForm();
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (serial != null && serial.IsOpen)
                serial.Close();
        }

        private void ShowGridPopup(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                DevExpress.XtraGrid.GridControl gctMain = (DevExpress.XtraGrid.GridControl)sender;
                DevExpress.XtraGrid.Views.Grid.ViewInfo.GridHitInfo hi = ((DevExpress.XtraGrid.Views.Grid.GridView)gctMain.DefaultView).CalcHitInfo(e.Location);
                if (hi.RowHandle >= 0 && (hi.InRow || hi.InRowCell))
                {
                    bbiPrint.Enabled = true;
                    popGridMenu.ShowPopup(MousePosition);
                }
                else
                    bbiPrint.Enabled = false;

            }
        }
        #endregion

        #region Method
        private void LoadData()
        {
            lstCustomers = new BindingList<eCustomer>();
            lstProducts = new BindingList<eProduct>();
            lstWarehouses = new BindingList<eWarehouse>();
            lstCustomers.AllowNew = lstProducts.AllowNew = lstWarehouses.AllowNew = true;
            lstCustomers.AllowEdit = lstProducts.AllowEdit = lstWarehouses.AllowEdit = true;
            lstCustomers.AllowRemove = lstProducts.AllowRemove = lstWarehouses.AllowRemove = true;

            lstInput = new List<Control>() { src_Input_SoXe, lok_Input_KH, lok_Input_Kho, lok_Input_SP, btnCan, btnSave, btnPrint, btnCanMoi };//8
            lstFilter = new List<Control>() { src_Filter_SoXe, lok_Filter_KH, lok_Filter_Kho, lok_Filter_SP, rdgNhapXuat, fDate, tDate, btn_Filter_Find, btn_Filter_Excel };//10
            lstOther = new List<Control>() { mmeGhiChu, txtMaPhieu, deNgayCan, sptDonGia, sptThanhTien, sptKL1, sptKL2, sptKLHang };//7
            nextControl = lstInput[0];
            areaIndex = 1;
            backForward = false;

            InitConfig();
            ConnectDevice();
        }

        private DialogResult CauHinhThietBi()
        {
            if (serial != null && serial.IsOpen)
            {
                tmCheck.Stop();
                serial.Close();
            }
            frmCauHinh frm = new frmCauHinh();
            frm.Text = "Cấu hình cân";
            frm.ReloadData = this.ConnectDevice;
            return frm.ShowDialog();
        }

        private DialogResult CauHinhSQL()
        {
            frmSetting frm = new frmSetting();
            frm.Text = "Cấu hình SQL";
            frm.ReloadData = checkConnection;
            return frm.ShowDialog();
        }

        private DialogResult CauHinhChung()
        {
            frmInfomation frm = new frmInfomation();
            frm.Text = "Cấu hình chung";
            frm.ReloadData = this.loadGeneralInfo;
            return frm.ShowDialog();
        }

        private DialogResult CauHinhGiaoDien()
        {
            frmDisplay frm = new frmDisplay();
            frm.Text = "Cài đặt giao diện";
            frm.ReloadData = this.loadGiaoDien;
            return frm.ShowDialog();
        }

        private void DanhMucKhachHang()
        {
            frmCustomer_List frm = new frmCustomer_List();
            frm.Text = "Danh sách khách hàng";
            frm.ReloadData = this.loadCustomer;
            frm.ShowDialog();
        }

        private void DanhMucSanPham()
        {
            frmProduct_List frm = new frmProduct_List();
            frm.Text = "Danh sách sản phẩm";
            frm.ReloadData = this.loadProduct;
            frm.ShowDialog();
        }

        private void DanhMucKho()
        {
            frmWarehouse frm = new frmWarehouse();
            frm.Text = "Danh sách kho";
            frm.ReloadData = this.loadWarehouse;
            frm.ShowDialog();
        }

        private void DanhMucXacXe()
        {
            frmVehicleEmpty frm = new frmVehicleEmpty();
            frm.Text = "Danh sách khối lượng xe trống";
            frm.ShowDialog();
        }

        private void loadGiaoDien(int id)
        {
            if (id > 0)
                layoutControl1.Visible = false;

            foreach (Control ctr in this.Controls)
            {
                if (ctr is LayoutControl)
                {
                    LayoutControl lc = ctr as LayoutControl;
                    foreach (Control _ctr in lc.Controls)
                    {
                        Font f = Properties.Settings.Default.GeneralFont;
                        BaseEdit baseEdit = _ctr as BaseEdit;
                        if (baseEdit != null)
                        {
                            baseEdit.Properties.Appearance.Font = f;
                            baseEdit.Properties.AppearanceDisabled.Font = f;
                            baseEdit.LookAndFeel.Style = LookAndFeelStyle.Office2003;
                            baseEdit.LookAndFeel.UseDefaultLookAndFeel = false;
                        }

                        if (_ctr is SpinEdit && _ctr.Name.Equals(sptKG.Name))
                        {
                            SpinEdit spt = _ctr as SpinEdit;
                            f = Properties.Settings.Default.ScaleNumberFont;
                            spt.Properties.AppearanceDisabled.Options.UseBackColor = true;
                            spt.Properties.AppearanceDisabled.Options.UseForeColor = true;
                            spt.Properties.AppearanceDisabled.BackColor = Properties.Settings.Default.ScaleNumberBackground;
                            spt.Properties.AppearanceDisabled.BackColor2 = Properties.Settings.Default.ScaleNumberBackground;
                            spt.Properties.AppearanceDisabled.ForeColor = Properties.Settings.Default.ScaleNumberForecolor;
                            spt.Properties.AppearanceDisabled.Font = f;
                        }
                        if (_ctr is SimpleButton)
                            _ctr.Font = new Font(f.FontFamily, f.Size, FontStyle.Bold);
                        if (_ctr is GridControl)
                        {
                            ((_ctr as GridControl).DefaultView as GridView).Format(false, true, true);
                            colPrice.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.None;
                        }
                        if (_ctr.Name.Equals(sptKL1.Name) || _ctr.Name.Equals(sptKL2.Name) || _ctr.Name.Equals(sptKLHang.Name))
                        {
                            TextEdit txt = _ctr as TextEdit;
                            f = Properties.Settings.Default.ScaleNumberFont;
                            txt.Properties.AppearanceDisabled.Font = new Font(f.FontFamily, f.Size * 0.6f, FontStyle.Bold);
                        }
                        if (_ctr is LookUpEdit)
                        {
                            LookUpEdit lok = _ctr as LookUpEdit;
                            lok.Format(false);
                            lok.Properties.AppearanceDropDown.Font = f;
                        }
                        if (_ctr is DateEdit)
                        {
                            DateEdit de = _ctr as DateEdit;
                            de.Properties.AppearanceDropDown.Font = f;
                        }
                        if (_ctr is SearchControl)
                        {
                            SearchControl src = _ctr as SearchControl;
                            src.Properties.CharacterCasing = CharacterCasing.Upper;
                            src.Properties.AppearanceDropDown.Font = f;
                            src.Properties.FilterCondition = DevExpress.Data.Filtering.FilterCondition.Contains;
                            src.Properties.ImmediatePopup = true;
                        }
                    }
                    lc.Items.Where(x => x is LayoutControlItem).ToList().ForEach(x => x.AppearanceItemCaption.Font = Properties.Settings.Default.GeneralFont);
                }
            }

            if (id > 0)
                layoutControl1.Visible = true;
        }

        private void loadGeneralInfo()
        {
            this.Text = "Chương trình cân - " + clsGeneral.curAgency.Name;
            this.bsiAgency.Caption = " Chi nhánh: " + clsGeneral.curAgency.Name;
            initData();
        }

        private void InitConfig()
        {
            bool success = true;
            if (success)
            {
                if (!Properties.Settings.Default.IsConfigSQL)
                {
                    clsGeneral.CloseWaitForm();
                    if (XtraMessageBox.Show("Cấu hình kêt nối SQL?", "Thông báo", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                        success = CauHinhSQL() == System.Windows.Forms.DialogResult.OK;
                    else
                        success = false;
                    clsGeneral.CallWaitForm(this);
                }
                else
                    checkConnection(Properties.Settings.Default.ComputerName);
            }

            if (success)
            {
                if (!Properties.Settings.Default.IsConfigAgency)
                {
                    clsGeneral.CloseWaitForm();
                    if (XtraMessageBox.Show("Cấu hình chi nhánh?", "Thông báo", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                        success = CauHinhChung() == System.Windows.Forms.DialogResult.OK;
                    else
                        success = false;
                    clsGeneral.CallWaitForm(this);
                }
                else
                    clsGeneral.curAgency = clsAgency.Instance.GetAgency(Properties.Settings.Default.IDAgency);
            }

            if (success)
                loadGeneralInfo();
            else
                Application.Exit();
        }

        private void checkConnection(string computerName)
        {
            this.bsiComName.Caption = "Computer Name: " + computerName;
            string _sName, _sDatabase, _sUser, _sPass;
            bool _wAu;
            _wAu = Properties.Settings.Default.sWinAu;
            _sName = clsGeneral.Decrypt(Properties.Settings.Default.sServerName);
            _sDatabase = clsGeneral.Decrypt(Properties.Settings.Default.sDBName);
            _sUser = clsGeneral.Decrypt(Properties.Settings.Default.sUserName);
            _sPass = clsGeneral.Decrypt(Properties.Settings.Default.sPassword);

            string _conString = "";
            if (!_wAu)
                _conString = "data source={0};initial catalog={1};Integrated Security={2};user id={3};password={4};MultipleActiveResultSets=True;App=EntityFramework";
            else
                _conString = "data source={0};initial catalog={1};Integrated Security={2};MultipleActiveResultSets=True;App=EntityFramework";
            EntityModel.Module.dbConnectString = string.Format(_conString, _sName, _sDatabase, _wAu, _sUser, _sPass);
            EntityModel.Module.InitDefaultData();

            fDate.DateTime = tDate.DateTime = deNgayCan.DateTime = DateTime.Now.ServerNow();
        }

        private void ConnectDevice()
        {
            try
            {
                if (!Properties.Settings.Default.IsConfigDevice)
                {
                    clsGeneral.CloseWaitForm();
                    DialogResult res = XtraMessageBox.Show("Kết nối không thành công.\nThiết lập cấu hình?", "Thông báo", MessageBoxButtons.YesNo);
                    if (res == System.Windows.Forms.DialogResult.Yes)
                    {
                        if (CauHinhThietBi() == System.Windows.Forms.DialogResult.OK)
                            clsGeneral.CallWaitForm(this);
                    }
                    else
                        Application.Exit();
                }
                else
                {
                    getData = new GetData(SetValue);
                    serial = new SerialPort();
                    serial.ReadTimeout = 10000;
                    serial.WriteTimeout = 10000;
                    serial.DataReceived += serial_DataReceived;
                    serial.ErrorReceived += serial_ErrorReceived;
                    if (!string.IsNullOrEmpty(Properties.Settings.Default.Port) && !string.IsNullOrEmpty(Properties.Settings.Default.BaudRate) &&
                        !string.IsNullOrEmpty(Properties.Settings.Default.HandShake) && !string.IsNullOrEmpty(Properties.Settings.Default.StopBits) &&
                        !string.IsNullOrEmpty(Properties.Settings.Default.Parity) && Properties.Settings.Default.DataBit > 0)
                    {
                        serial.PortName = Properties.Settings.Default.Port;
                        serial.BaudRate = Convert.ToInt32(Properties.Settings.Default.BaudRate);
                        serial.DataBits = Properties.Settings.Default.DataBit;
                        serial.Handshake = (Handshake)Enum.Parse(typeof(Handshake), Properties.Settings.Default.HandShake);
                        serial.StopBits = (StopBits)Enum.Parse(typeof(StopBits), Properties.Settings.Default.StopBits);
                        serial.Parity = (Parity)Enum.Parse(typeof(Parity), Properties.Settings.Default.Parity);
                        serial.DiscardNull = true;
                        serial.DtrEnable = true;
                        //serial.Encoding = Encoding.GetEncoding(ASCIIEncoding.ASCII.EncodingName);
                        serial.Open();
                        bsiDeviceStatus.Caption = "Device: " + serial.PortName + " - " + (serial.IsOpen ? "OK" : "STOP");
                    }
                    tmCheck.Start();
                }
            }
            catch
            {
                DialogResult res = XtraMessageBox.Show("Kết nối không thành công.\nThiết lập cấu hình?", "Thông báo", MessageBoxButtons.YesNo);
                if (res == System.Windows.Forms.DialogResult.Yes)
                {
                    if (CauHinhThietBi() == System.Windows.Forms.DialogResult.OK)
                        clsGeneral.CallWaitForm(this);
                }
                else
                    Application.Exit();
            }
        }

        void serial_ErrorReceived(object sender, SerialErrorReceivedEventArgs e)
        {
            if (serial != null)
                bsiDeviceStatus.Caption = "Device: " + serial.PortName + " - " + e.EventType.ToString();
        }

        void serial_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            sptKG.BeginInvoke(getData, serial.ReadExisting());
        }

        private void SetValue(string text)
        {
            InputData += text.Trim();
            char[] symbols = Properties.Settings.Default.Symbol.ToArray<char>();
            int index = -1;
            foreach (char c in symbols)
            {
                index = InputData.IndexOf(c);
                if (index != -1)
                    break;
            }

            if (index != -1)
            {
                string val = GetNumber(InputData.Substring(0, index));
                decimal number = string.IsNullOrEmpty(val) ? 0 : Convert.ToDecimal(val);
                sptKG.Value = (number * Properties.Settings.Default.KG);
                InputData = "";
            }
        }

        private string GetNumber(string text)
        {
            string res = "";
            foreach (char c in text)
            {
                res += Char.IsNumber(c) ? c.ToString() : "";
            }
            return res;
        }

        private void initData()
        {
            loadCustomer(0);
            loadProduct(0);
            loadWarehouse(0);
            loadVehicle();
            loadFilter(0, DateTime.Now.ServerNow(), DateTime.Now.ServerNow());
            loadDataForm();
        }

        private void loadCode()
        {
            txtMaPhieu.EditValue = clsScaleInfomation.Instance.getID();
        }

        private void loadVehicle()
        {
            src_Input_SoXe.Properties.Items.Clear();
            src_Filter_SoXe.Properties.Items.Clear();
            string[] arr = clsScaleInfomation.Instance.getVehicle().ToArray<string>();
            src_Input_SoXe.Properties.Items.AddRange(arr);
            src_Filter_SoXe.Properties.Items.AddRange(arr);
            //src_Input_SoXe.Properties.DataSource = lok_Filter_SoXe.Properties.DataSource = clsScaleInfomation.Instance.getVehicle();
            //lok_Input_SoXe.Properties.ValueMember = lok_Filter_SoXe.Properties.ValueMember = "KeyID";
            //lok_Input_SoXe.Properties.DisplayMember = lok_Filter_SoXe.Properties.DisplayMember = "Name";
        }

        private void loadCustomer(int id)
        {
            lstCustomers = new BindingList<eCustomer>(clsCustomer.Instance.getAllCustomer());
            lstCustomers.Insert(0, new eCustomer() { Name = "" });

            lok_Input_KH.Properties.DataSource = lok_Filter_KH.Properties.DataSource = lstCustomers;
            lok_Input_KH.Properties.ValueMember = lok_Filter_KH.Properties.ValueMember = "KeyID";
            lok_Input_KH.Properties.DisplayMember = lok_Filter_KH.Properties.DisplayMember = "Name";

            if (id > 0)
                lok_Input_KH.EditValue = id;
        }

        private void loadProduct(int id)
        {
            lstProducts = new BindingList<eProduct>(clsProduct.Instance.getAllProduct());
            lstProducts.Insert(0, new eProduct() { Name = "" });

            lok_Input_SP.Properties.DataSource = lok_Filter_SP.Properties.DataSource = lstProducts;
            lok_Input_SP.Properties.ValueMember = lok_Filter_SP.Properties.ValueMember = "KeyID";
            lok_Input_SP.Properties.DisplayMember = lok_Filter_SP.Properties.DisplayMember = "Name";

            if (id > 0)
                lok_Input_SP.EditValue = id;
        }

        private void loadWarehouse(int id)
        {
            lstWarehouses = new BindingList<eWarehouse>(clsWarehouse.Instance.getAllWarehouse());
            lstWarehouses.Insert(0, new eWarehouse() { Name = "" });

            lok_Input_Kho.Properties.DataSource = lok_Filter_Kho.Properties.DataSource = lstWarehouses;
            lok_Input_Kho.Properties.ValueMember = lok_Filter_Kho.Properties.ValueMember = "KeyID";
            lok_Input_Kho.Properties.DisplayMember = lok_Filter_Kho.Properties.DisplayMember = "Name";

            if (id > 0)
                lok_Input_Kho.EditValue = id;
        }

        private void loadFilter(int KeyID, DateTime fDate, DateTime tDate)
        {
            loadCode();
            gctThongTin.DataSource = clsScaleInfomation.Instance.getAll(fDate, tDate);
            if (KeyID > 0)
                grvThongTin.FocusedRowHandle = grvThongTin.LocateByValue(colKeyID.FieldName, KeyID);
        }

        private void loadFilter(int KeyID, bool FindAll)
        {
            switch (rdgNhapXuat.SelectedIndex)
            {
                case 0:
                    gctThongTin.DataSource = clsScaleInfomation.Instance.getAll(fDate.DateTime, tDate.DateTime, true, null, null, src_Filter_SoXe.Text.Trim(), lok_Filter_KH.Text.Trim(), lok_Filter_Kho.Text.Trim(), lok_Filter_SP.Text.Trim(), FindAll);
                    break;
                case 1:
                    gctThongTin.DataSource = clsScaleInfomation.Instance.getAll(fDate.DateTime, tDate.DateTime, true, true, false, src_Filter_SoXe.Text.Trim(), lok_Filter_KH.Text.Trim(), lok_Filter_Kho.Text.Trim(), lok_Filter_SP.Text.Trim(), FindAll);
                    break;
                case 2:
                    gctThongTin.DataSource = clsScaleInfomation.Instance.getAll(fDate.DateTime, tDate.DateTime, true, false, true, src_Filter_SoXe.Text.Trim(), lok_Filter_KH.Text.Trim(), lok_Filter_Kho.Text.Trim(), lok_Filter_SP.Text.Trim(), FindAll);
                    break;
            }
            if (KeyID > 0)
                grvThongTin.FocusedRowHandle = grvThongTin.LocateByValue(colKeyID.FieldName, KeyID);
        }

        private void addNewCustomer(LookUpEdit lokMain, string name)
        {
            int id = lstCustomers.Min(x => x.KeyID);
            eCustomer item = new eCustomer();
            item.KeyID = id > 0 ? -1 : id - 1;
            item.Name = name;
            item.IsEnable = true;
            lstCustomers.Add(item);

            lokMain.Properties.DataSource = lstCustomers;
            lokMain.EditValue = item.KeyID;
        }

        private void addNewProduct(LookUpEdit lokMain, string name)
        {
            int id = lstProducts.Min(x => x.KeyID);
            eProduct item = new eProduct();
            item.KeyID = id > 0 ? -1 : id - 1;
            item.Name = name;
            item.IsEnable = true;
            lstProducts.Add(item);

            lokMain.Properties.DataSource = lstProducts;
            lokMain.EditValue = item.KeyID;
        }

        private void addNewWarehouse(LookUpEdit lokMain, string name)
        {
            int id = lstWarehouses.Min(x => x.KeyID);
            eWarehouse item = new eWarehouse();
            item.KeyID = id > 0 ? -1 : id - 1;
            item.Name = name;
            item.IsEnable = true;
            lstWarehouses.Add(item);

            lokMain.Properties.DataSource = lstWarehouses;
            lokMain.EditValue = item.KeyID;
        }

        private void GetNextControlInput(Control ctr)
        {
            if (lstInput.Any(x => x.Name.Equals(ctr.Name)))
            {
                int count = lstInput.Count;
                int index = lstInput.FindIndex(x => x.Name.Equals(ctr.Name)) + 1;
                for (int i = index; i < count; i++)
                {
                    if (lstInput[i].Enabled)
                    {
                        index = i;
                        break;
                    }
                }
                if (index >= count)
                {
                    index = 0;
                    backForward = true;
                }
                nextControl = lstInput[index];
                areaIndex = 1;
            }

            if (lstFilter.Any(x => x.Name.Equals(ctr.Name)))
            {
                int count = lstFilter.Count;
                int index = lstFilter.FindIndex(x => x.Name.Equals(ctr.Name)) + 1;
                for (int i = index; i < count; i++)
                {
                    if (lstFilter[i].Enabled)
                    {
                        index = i;
                        break;
                    }
                }
                if (index >= count)
                {
                    index = 0;
                    backForward = true;
                }
                nextControl = lstFilter[index];
                areaIndex = 2;
            }

            if (lstOther.Any(x => x.Name.Equals(ctr.Name)))
            {
                int count = lstOther.Count;
                int index = lstOther.FindIndex(x => x.Name.Equals(ctr.Name)) + 1;
                for (int i = index; i < count; i++)
                {
                    if (lstOther[i].Enabled)
                    {
                        index = i;
                        break;
                    }
                }
                if (index >= count)
                {
                    index = 0;
                    backForward = true;
                }
                nextControl = lstOther[index];
                areaIndex = 3;
            }
        }

        private void loadDataForm()
        {
            resetToDefault();
            _iEntry = _iEntry ?? new eScaleInfomation();
            _aEntry = clsScaleInfomation.Instance.getEntry(_iEntry.KeyID);
            setControlValue();
        }

        private void setControlValue()
        {
            posWeight = 0;

            src_Input_SoXe.EditValue = _aEntry.VehicleNumber;
            if (_aEntry.IDCustomer > 0)
                lok_Input_KH.EditValue = _aEntry.IDCustomer;
            if (_aEntry.IDWarehouse > 0)
                lok_Input_Kho.EditValue = _aEntry.IDWarehouse;
            if (_aEntry.IDProduct > 0)
                lok_Input_SP.EditValue = _aEntry.IDProduct;
            sptKL1.Text = _aEntry.Weight1 == 0 ? string.Empty : _aEntry.Weight1.ToString("#,#");
            sptKL2.Text = _aEntry.Weight2 == 0 ? string.Empty : _aEntry.Weight2.ToString("#,#");
            sptKLHang.Text = _aEntry.WeightProduct == 0 ? string.Empty : _aEntry.WeightProduct.ToString("#,#");
            sptDonGia.Value = _aEntry.Price;
            sptThanhTien.Value = _aEntry.TotalPrice;
            mmeGhiChu.EditValue = _aEntry.Note;

            if (_aEntry.KeyID == 0 || !_aEntry.DateScale2.HasValue)
            {
                eVehicleEmpty vehicle = clsVehicleEmpty.Instance.getVehicleWeight(src_Input_SoXe.Text.Trim());
                string msg = "Tìm thấy xác xe " + src_Input_SoXe.Text.Trim();
                if (vehicle != null && clsGeneral.showConfirmMessage(msg + "=" + vehicle.EmptyWeight.ToString("#,#") + " KG\nBạn có muốn sử dụng khối lượng này?"))
                {
                    sptKL2.Text = vehicle.EmptyWeight == 0 ? string.Empty : vehicle.EmptyWeight.ToString("#,#");
                    setWeight(0);
                }
                posWeight = string.IsNullOrEmpty(sptKL2.Text) ? 2 : posWeight;
                posWeight = string.IsNullOrEmpty(sptKL1.Text) ? 1 : posWeight;
            }
        }

        private void setInfomation()
        {
            posWeight = 0;

            if (_aEntry.IDCustomer > 0)
                lok_Input_KH.EditValue = _aEntry.IDCustomer;
            if (_aEntry.IDWarehouse > 0)
                lok_Input_Kho.EditValue = _aEntry.IDWarehouse;
            if (_aEntry.IDProduct > 0)
                lok_Input_SP.EditValue = _aEntry.IDProduct;
            sptKL1.Text = _aEntry.Weight1 == 0 ? string.Empty : _aEntry.Weight1.ToString("#,#");
            sptKL2.Text = _aEntry.Weight2 == 0 ? string.Empty : _aEntry.Weight2.ToString("#,#");
            sptKLHang.Text = _aEntry.WeightProduct == 0 ? string.Empty : _aEntry.WeightProduct.ToString("#,#");
            sptDonGia.Value = _aEntry.Price;
            sptThanhTien.Value = _aEntry.TotalPrice;
            mmeGhiChu.EditValue = _aEntry.Note;

            if (_aEntry.KeyID == 0 || !_aEntry.DateScale2.HasValue)
            {
                eVehicleEmpty vehicle = clsVehicleEmpty.Instance.getVehicleWeight(src_Input_SoXe.Text.Trim());
                string msg = "Tìm thấy xác xe " + src_Input_SoXe.Text.Trim();
                if (vehicle != null && clsGeneral.showConfirmMessage(msg + "=" + vehicle.EmptyWeight.ToString("#,#") + " KG\nBạn có muốn sử dụng khối lượng này?"))
                {
                    sptKL2.Text = vehicle.EmptyWeight == 0 ? string.Empty : vehicle.EmptyWeight.ToString("#,#");
                    setWeight(0);
                }
                posWeight = string.IsNullOrEmpty(sptKL2.Text) ? 2 : posWeight;
                posWeight = string.IsNullOrEmpty(sptKL1.Text) ? 1 : posWeight;
            }
        }

        private void setWeight(decimal number, int pos = 0)
        {
            if (pos == 1)
                sptKL1.Text = number == 0 ? string.Empty : number.ToString("#,#");
            if (pos == 2)
                sptKL2.Text = number == 0 ? string.Empty : number.ToString("#,#");

            if (!string.IsNullOrEmpty(sptKL1.Text) && !string.IsNullOrEmpty(sptKL2.Text))
            {
                sptKLHang.Text = Math.Abs(Convert.ToDecimal(sptKL1.Text) - Convert.ToDecimal(sptKL2.Text)).ToString("#,#");
                sptThanhTien.Value = sptDonGia.Value * Convert.ToDecimal(string.IsNullOrEmpty(sptKLHang.Text) ? "0" : sptKLHang.Text);
            }
        }

        private void resetToDefault()
        {
            src_Input_SoXe.ErrorText = "";
            lok_Input_KH.ErrorText = "";
            sptKL1.ErrorText = "";
            lok_Input_KH.EditValue = null;
            lok_Input_Kho.EditValue = null;
            lok_Input_SP.EditValue = null;
        }

        private void printData()
        {
            rptPhieuCan rpt = new rptPhieuCan();
            List<eScaleInfomation> lst = new List<eScaleInfomation>();
            eScaleInfomation info = new eScaleInfomation();
            info.Code = _aEntry.Code;
            info.VehicleNumber = _aEntry.VehicleNumber;
            info.CustomerName = _aEntry.CustomerName;
            info.ProductName = _aEntry.ProductName;
            info.ExportName = _aEntry.ExportName;
            info.WarehouseName = _aEntry.WarehouseName;
            info.Note = _aEntry.Note;
            info.DateScale1 = _aEntry.KeyID > 0 ? _aEntry.DateScale1 : DateTime.Now.ServerNow();
            info.DateScale2 = _aEntry.DateScale2;
            if (_aEntry.Weight1 > _aEntry.Weight2)
            {
                info.Weight1 = _aEntry.Weight1;
                info.Weight2 = _aEntry.Weight2;
            }
            else
            {
                info.Weight1 = _aEntry.Weight2;
                info.Weight2 = _aEntry.Weight1;
            }
            info.WeightProduct = _aEntry.WeightProduct;
            info.Price = _aEntry.Price;
            info.TotalPrice = _aEntry.TotalPrice;
            lst.Add(info);
            rpt.DataSource = lst;
            rpt.Parameters["_Name"].Value = clsGeneral.curAgency.Name;
            rpt.Parameters["_Address"].Value = clsGeneral.curAgency.Address;
            rpt.Parameters["_Phone"].Value = clsGeneral.curAgency.Phone;
            rpt.Parameters["_Mail"].Value = clsGeneral.curAgency.Email;

            ReportPrintTool report = new ReportPrintTool(rpt);
            report.PrinterSettings.PrinterName = Properties.Settings.Default.PrinterName;
            report.PrinterSettings.DefaultPageSettings.Landscape = rpt.Landscape;
            report.PrinterSettings.DefaultPageSettings.PaperSize = new PaperSize(rpt.PaperKind.ToString(), rpt.PageWidth, rpt.PageHeight);

            try
            {
                if (report.PrinterSettings.IsValid)
                    report.Print(Properties.Settings.Default.PrinterName);
                else
                {
                    report.PrintDialog();
                    Properties.Settings.Default.PrinterName = report.PrinterSettings.PrinterName;
                    Properties.Settings.Default.Save();
                }
            }
            catch
            {
                report.PrintDialog();
                Properties.Settings.Default.PrinterName = report.PrinterSettings.PrinterName;
                Properties.Settings.Default.Save();
            }
        }

        private bool validationForm()
        {
            bool chk = true;
            src_Input_SoXe.ErrorText = "";
            lok_Input_KH.ErrorText = "";
            sptKL1.ErrorText = "";

            if (string.IsNullOrEmpty(src_Input_SoXe.Text.Trim()))
            {
                src_Input_SoXe.ErrorText = "Xin nhập số xe";
                chk = false;
            }

            if (lok_Input_KH.ToInt32() == 0)
            {
                lok_Input_KH.ErrorText = "Xin chọn khách hàng";
                chk = false;
            }

            if (string.IsNullOrEmpty(sptKL1.Text))
            {
                sptKL1.ErrorText = "Số lượng cân không hợp lệ";
                chk = false;
            }
            return chk;
        }

        private bool saveData(bool isPrint)
        {
            bool chk = false;

            _iEntry = _iEntry ?? new eScaleInfomation();
            _aEntry = clsScaleInfomation.Instance.getEntry(_iEntry.KeyID);

            _aEntry.VehicleNumber = src_Input_SoXe.Text.Trim();
            _aEntry.IDCustomer = lok_Input_KH.ToInt32();
            _aEntry.CustomerName = lok_Input_KH.Text.Trim();
            _aEntry.IDProduct = lok_Input_SP.ToInt32();
            _aEntry.ProductName = lok_Input_SP.Text.Trim();
            _aEntry.IDWarehouse = lok_Input_Kho.ToInt32();
            _aEntry.WarehouseName = lok_Input_Kho.Text.Trim();
            _aEntry.Price = sptDonGia.ToDecimal();
            _aEntry.TotalPrice = sptThanhTien.ToDecimal();
            _aEntry.Note = mmeGhiChu.Text.Trim();

            //Lưu các giá trị mới
            if (lok_Input_KH.ToInt32() < 0)
            {
                eCustomer item = clsCustomer.Instance.getEntry(lok_Input_KH.ToInt32());
                item.Code = _aEntry.CustomerName.NoSign().NoSpace();
                item.Name = _aEntry.CustomerName;
                item.CreatedDate = DateTime.Now.ServerNow();
                item.Status = 1;
                if (clsCustomer.Instance.accessEntry(item))
                {
                    _aEntry.IDCustomer = item.KeyID;
                    loadCustomer(item.KeyID);
                }
                else
                {
                    clsGeneral.showMessage("Lưu dữ liệu khách hàng không thành công");
                    return false;
                }
            }

            if (lok_Input_SP.ToInt32() < 0)
            {
                eProduct item = clsProduct.Instance.getEntry(lok_Input_SP.ToInt32());
                item.Code = _aEntry.ProductName.NoSign().NoSpace();
                item.Name = _aEntry.ProductName;
                item.CreatedDate = DateTime.Now.ServerNow();
                item.Status = 1;
                if (clsProduct.Instance.accessEntry(item))
                {
                    _aEntry.IDProduct = item.KeyID;
                    loadProduct(item.KeyID);
                }
                else
                {
                    clsGeneral.showMessage("Lưu dữ liệu sản phẩm không thành công");
                    return false;
                }
            }

            if (lok_Input_Kho.ToInt32() < 0)
            {
                eWarehouse item = clsWarehouse.Instance.getEntry(lok_Input_Kho.ToInt32());
                item.Code = _aEntry.WarehouseName.NoSign().NoSpace();
                item.Name = _aEntry.WarehouseName;
                item.CreatedDate = DateTime.Now.ServerNow();
                if (clsWarehouse.Instance.accessEntry(item))
                {
                    _aEntry.IDWarehouse = item.KeyID;
                    loadWarehouse(item.KeyID);
                }
                else
                {
                    clsGeneral.showMessage("Lưu dữ liệu kho không thành công");
                    return false;
                }
            }

            if (_aEntry.KeyID == 0)
            {
                _aEntry.IDAgency = clsGeneral.curAgency.KeyID;
                _aEntry.Code = txtMaPhieu.Text.Trim();
                _aEntry.CreatedDate = DateTime.Now.ServerNow();
                _aEntry.DateScale1 = DateTime.Now.ServerNow();
            }

            if (!_aEntry.DateScale2.HasValue && !string.IsNullOrEmpty(sptKL2.Text))
                _aEntry.DateScale2 = DateTime.Now.ServerNow();

            _aEntry.Weight1 = string.IsNullOrEmpty(sptKL1.Text) ? 0 : Convert.ToDecimal(sptKL1.Text);
            _aEntry.Weight2 = string.IsNullOrEmpty(sptKL2.Text) ? 0 : Convert.ToDecimal(sptKL2.Text);

            if (!string.IsNullOrEmpty(sptKL1.Text) && !string.IsNullOrEmpty(sptKL2.Text) && !string.IsNullOrEmpty(sptKLHang.Text))
            {
                _aEntry.WeightProduct = Convert.ToDecimal(sptKLHang.Text);
                if (_aEntry.Weight1 > _aEntry.Weight2)
                {
                    _aEntry.ExportName = "Nhập";
                    _aEntry.IsImport = true;
                }
                else
                {
                    _aEntry.ExportName = "Xuất";
                    _aEntry.IsExport = true;
                }
            }

            chk = clsScaleInfomation.Instance.accessEntry(_aEntry);
            if (chk)
            {
                _iEntry.KeyID = _aEntry.KeyID;
                if (isFilter) loadFilter(_aEntry.KeyID, !isFindAll);
                else loadFilter(_aEntry.KeyID, DateTime.Now.ServerNow(), DateTime.Now.ServerNow());
            }
            return chk;
        }

        private void exportExcel()
        {
            frmReportExcel frm = new frmReportExcel(gctThongTin, "Danh sách phiếu cân hàng", fDate.DateTime, tDate.DateTime);
            frm.Text = "Thống kê phiếu cân hàng";
            frm.ShowDialog();
        }

        private void customForm()
        {
            bbiMenu.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;

            sptDonGia.Format();
            sptThanhTien.Format();
            rsptNumber.Format();

            colPrice.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.None;

            foreach (Control ctrInput in lstInput)
            {
                ctrInput.MouseDown += ctrInput_MouseDown;
                ctrInput.PreviewKeyDown += ctrInput_PreviewKeyDown;
                ctrInput.Enter += ctrInput_Enter;

                if (ctrInput is LookUpEdit)
                {
                    LookUpEdit lok = ctrInput as LookUpEdit;
                    lok.QueryPopUp -= lok_QueryPopUp;
                    lok.QueryPopUp += lok_QueryPopUp;
                    lok.QueryCloseUp -= lok_QueryCloseUp;
                    lok.QueryCloseUp += lok_QueryCloseUp;
                    lok.LostFocus -= lok_LostFocus;
                    lok.LostFocus += lok_LostFocus;
                }
            }

            foreach (Control ctrFilter in lstFilter)
            {
                ctrFilter.MouseDown += ctrFilter_MouseDown;
                ctrFilter.PreviewKeyDown += ctrFilter_PreviewKeyDown;
                ctrFilter.Enter += ctrFilter_Enter;

                if (ctrFilter is LookUpEdit)
                {
                    LookUpEdit lok = ctrFilter as LookUpEdit;
                    lok.QueryPopUp -= lok_QueryPopUp;
                    lok.QueryPopUp += lok_QueryPopUp;
                    lok.QueryCloseUp -= lok_QueryCloseUp;
                    lok.QueryCloseUp += lok_QueryCloseUp;
                    lok.LostFocus -= lok_LostFocus;
                    lok.LostFocus += lok_LostFocus;
                }
            }

            foreach (Control ctrOther in lstOther)
            {
                ctrOther.MouseDown += ctrOther_MouseDown;
                ctrOther.PreviewKeyDown += ctrOther_PreviewKeyDown;
                ctrOther.Enter += ctrOther_Enter;
            }

            gctThongTin.Enter += gctThongTin_Enter;
            gctThongTin.MouseDown += gctThongTin_MouseDown;

            btn_Filter_Find.Click += btn_Filter_Find_Click;
            btnCan.Click += btnCan_Click;
        }
        #endregion

        #region Event
        #region Key Mouse Event
        void ctrInput_MouseDown(object sender, MouseEventArgs e)
        {
            btnSave.Enabled = true;
            nextControl = sender as Control;
            nextControl.Select();
            areaIndex = 1;
        }

        void ctrFilter_MouseDown(object sender, MouseEventArgs e)
        {
            btnSave.Enabled = false;
            nextControl = sender as Control;
            nextControl.Select();
            areaIndex = 2;
        }

        void ctrOther_MouseDown(object sender, MouseEventArgs e)
        {
            nextControl = sender as Control;
            nextControl.Select();
            areaIndex = 3;
        }

        void gctThongTin_MouseDown(object sender, MouseEventArgs e)
        {
            nextControl = sender as Control;
            nextControl.Select();
        }

        void gctThongTin_Enter(object sender, EventArgs e)
        {
            backForward = !backForward;
            nextControl.Select();
        }

        void ctrInput_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Tab)
            {
                if (sender is LookUpEdit)
                {
                    LookUpEdit lok = sender as LookUpEdit;
                    if (!string.IsNullOrEmpty(lok.Text.Trim()))
                    {
                        if ((lok.Name.Equals(lok_Input_KH.Name) || lok.Name.Equals(lok_Filter_KH.Name)) && !lstCustomers.Any(x => x.Name.Equals(lok.Text.Trim())))
                            addNewCustomer(lok, lok.Text.Trim());
                        if ((lok.Name.Equals(lok_Input_SP.Name) || lok.Name.Equals(lok_Filter_SP.Name)) && !lstProducts.Any(x => x.Name.Equals(lok.Text.Trim())))
                            addNewProduct(lok, lok.Text.Trim());
                        if ((lok.Name.Equals(lok_Input_Kho.Name) || lok.Name.Equals(lok_Filter_Kho.Name)) && !lstWarehouses.Any(x => x.Name.Equals(lok.Text.Trim())))
                            addNewWarehouse(lok, lok.Text.Trim());
                    }
                }
                if (sender is SearchControl && ((Control)sender).Name.Equals(src_Input_SoXe.Name))
                {
                    SearchControl src = sender as SearchControl;
                    eVehicleEmpty vehicle = clsVehicleEmpty.Instance.getVehicleWeight(src.Text.Trim());
                    string msg = "Tìm thấy xác xe " + src.Text.Trim();
                    if (vehicle != null && clsGeneral.showConfirmMessage(msg + "=" + vehicle.EmptyWeight.ToString("#,#") + " KG\nBạn có muốn sử dụng khối lượng này?"))
                    {
                        sptKL2.Text = vehicle.EmptyWeight == 0 ? string.Empty : vehicle.EmptyWeight.ToString("#,#");
                        setWeight(0);
                    }
                }
                GetNextControlInput(sender as Control);
            }
        }

        void ctrFilter_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Tab)
            {
                if (sender is LookUpEdit)
                {
                    LookUpEdit lok = sender as LookUpEdit;
                    if (!string.IsNullOrEmpty(lok.Text.Trim()))
                    {
                        if ((lok.Name.Equals(lok_Input_KH.Name) || lok.Name.Equals(lok_Filter_KH.Name)) && !lstCustomers.Any(x => x.Name.Equals(lok.Text.Trim())))
                            addNewCustomer(lok, lok.Text.Trim());
                        if ((lok.Name.Equals(lok_Input_SP.Name) || lok.Name.Equals(lok_Filter_SP.Name)) && !lstProducts.Any(x => x.Name.Equals(lok.Text.Trim())))
                            addNewProduct(lok, lok.Text.Trim());
                        if ((lok.Name.Equals(lok_Input_Kho.Name) || lok.Name.Equals(lok_Filter_Kho.Name)) && !lstWarehouses.Any(x => x.Name.Equals(lok.Text.Trim())))
                            addNewWarehouse(lok, lok.Text.Trim());
                    }
                }
                GetNextControlInput(sender as Control);
            }
        }

        void ctrOther_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Tab)
                GetNextControlInput(sender as Control);
        }

        void ctrInput_Enter(object sender, EventArgs e)
        {
            if (areaIndex != 1)
                nextControl.Select();
            else if (backForward)
            {
                nextControl.Select();
                backForward = false;
            }
        }

        void ctrFilter_Enter(object sender, EventArgs e)
        {
            if (areaIndex != 2)
                nextControl.Select();
            else if (backForward)
            {
                nextControl.Select();
                backForward = false;
            }
        }

        void ctrOther_Enter(object sender, EventArgs e)
        {
            if (areaIndex != 3)
                nextControl.Select();
            else if (backForward)
            {
                nextControl.Select();
                backForward = false;
            }
        }

        void lok_QueryPopUp(object sender, CancelEventArgs e)
        {
            LookUpEdit lok = sender as LookUpEdit;
            lok.Properties.BeginUpdate();
            if (lok.Name.Equals(lok_Input_KH.Name) || lok.Name.Equals(lok_Filter_KH.Name))
                lok.Properties.DataSource = lstCustomers.Where(x => (x.IsEnable && x.Status != 3) || x.KeyID == lok.ToInt32());
            if (lok.Name.Equals(lok_Input_SP.Name) || lok.Name.Equals(lok_Filter_SP.Name))
                lok.Properties.DataSource = lstProducts.Where(x => (x.IsEnable && x.Status != 3) || x.KeyID == lok.ToInt32());
            if (lok.Name.Equals(lok_Input_Kho.Name) || lok.Name.Equals(lok_Filter_Kho.Name))
                lok.Properties.DataSource = lstWarehouses.Where(x => x.IsEnable || x.KeyID == lok.ToInt32());
            lok.Properties.EndUpdate();
        }

        void lok_QueryCloseUp(object sender, CancelEventArgs e)
        {
            LookUpEdit lok = sender as LookUpEdit;
            lok.Properties.BeginUpdate();
            if (lok.Name.Equals(lok_Input_KH.Name) || lok.Name.Equals(lok_Filter_KH.Name))
                lok.Properties.DataSource = lstCustomers;
            if (lok.Name.Equals(lok_Input_SP.Name) || lok.Name.Equals(lok_Filter_SP.Name))
                lok.Properties.DataSource = lstProducts;
            if (lok.Name.Equals(lok_Input_Kho.Name) || lok.Name.Equals(lok_Filter_Kho.Name))
                lok.Properties.DataSource = lstWarehouses;
            lok.Properties.EndUpdate();
        }

        void lok_LostFocus(object sender, EventArgs e)
        {
            if (sender is LookUpEdit)
            {
                LookUpEdit lok = sender as LookUpEdit;
                if (!string.IsNullOrEmpty(lok.Text.Trim()))
                {
                    if ((lok.Name.Equals(lok_Input_KH.Name) || lok.Name.Equals(lok_Filter_KH.Name)) && !lstCustomers.Any(x => x.Name.Equals(lok.Text.Trim())))
                        addNewCustomer(lok, lok.Text.Trim());
                    if ((lok.Name.Equals(lok_Input_SP.Name) || lok.Name.Equals(lok_Filter_SP.Name)) && !lstProducts.Any(x => x.Name.Equals(lok.Text.Trim())))
                        addNewProduct(lok, lok.Text.Trim());
                    if ((lok.Name.Equals(lok_Input_Kho.Name) || lok.Name.Equals(lok_Filter_Kho.Name)) && !lstWarehouses.Any(x => x.Name.Equals(lok.Text.Trim())))
                        addNewWarehouse(lok, lok.Text.Trim());
                }
            }
        }
        #endregion

        #region Button
        private void bbiMenu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmCauHinhTest frm = new frmCauHinhTest();
            frm.Text = "Cấu hình cân test";
            frm.Show();
        }

        private void bbiDevice_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (CauHinhThietBi() == DialogResult.Cancel)
                ConnectDevice();
        }

        private void bbiSQL_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            CauHinhSQL();
        }

        private void bbiKhachHang_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DanhMucKhachHang();
        }

        private void bbiGeneral_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            CauHinhChung();
        }

        private void bbiSanPham_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DanhMucSanPham();
        }

        private void bbiPrint_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (grvThongTin.FocusedRowHandle >= 0)
            {
                _aEntry = grvThongTin.GetFocusedRow() as eScaleInfomation;
                printData();
            }
        }

        private void bbiXacXe_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DanhMucXacXe();
        }

        private void bbiKho_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DanhMucKho();
        }

        private void bbiDisplay_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            CauHinhGiaoDien();
        }

        private void btnCan_Click(object sender, EventArgs e)
        {
            setWeight(sptKG.Value, posWeight);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            clsGeneral.CallWaitForm(this);
            if (validationForm())
            {
                if (saveData(false))
                {
                    btnCan.Enabled = false;
                    btnPrint.Select();
                    clsGeneral.CloseWaitForm();
                }
                else
                {
                    clsGeneral.CloseWaitForm();
                    clsGeneral.showMessage("Lưu dữ liệu không thành công.\r\nVui lòng kiểm tra lại");
                }
            }
            else
                clsGeneral.CloseWaitForm();

        }

        private void btnCanMoi_Click(object sender, EventArgs e)
        {
            clsGeneral.CallWaitForm(this);
            isFilter = false;
            status = 1;
            posWeight = 0;
            _iEntry = _aEntry = null;
            initData();
            btnCan.Enabled = true;
            src_Input_SoXe.Select();
            clsGeneral.CloseWaitForm();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            printData();
            btnCanMoi.Select();
        }

        private void btn_Filter_Find_Click(object sender, EventArgs e)
        {
            clsGeneral.CallWaitForm(this);
            isFilter = true;
            loadFilter(0, isFindAll);
            isFindAll = !isFindAll;
            btn_Filter_Find.Text = isFindAll ? "Tìm tất cả" : "Tìm chi tiết";
            clsGeneral.CloseWaitForm();
        }

        private void btn_Filter_Excel_Click(object sender, EventArgs e)
        {
            exportExcel();
            src_Filter_SoXe.Select();
        }
        #endregion

        #region LookUpEdit
        #endregion

        #region GridControl
        private void grvThongTin_DoubleClick(object sender, EventArgs e)
        {
            GridView view = sender as GridView;
            if (view.FocusedRowHandle >= 0)
            {
                status = 2;
                _iEntry = view.GetFocusedRow() as eScaleInfomation;
                if (_iEntry != null)
                {
                    btnCan.Enabled = (!_iEntry.DateScale2.HasValue && (!_iEntry.IsImport && !_iEntry.IsExport));
                    btnSave.Enabled = true;
                }
                loadDataForm();
            }
        }

        private void grvThongTin_RowCellStyle(object sender, RowCellStyleEventArgs e)
        {
            GridView view = sender as GridView;
            eScaleInfomation info = view.GetRow(e.RowHandle) as eScaleInfomation;
            if (e.RowHandle >= 0 && info != null)
            {
                e.Appearance.Options.UseBackColor = true;
                Color defaultColor = e.Appearance.BackColor;
                e.Appearance.BackColor = info.DateScale2.HasValue ? defaultColor : Properties.Settings.Default.NewScale;
                e.Appearance.BackColor2 = info.DateScale2.HasValue ? defaultColor : Properties.Settings.Default.NewScale;
            }
        }

        private void gctThongTin_MouseClick(object sender, MouseEventArgs e)
        {
            ShowGridPopup(sender, e);
        }
        #endregion

        #region SpinEdit
        private void sptDonGia_EditValueChanged(object sender, EventArgs e)
        {
            setWeight(0);
        }

        private void sptThanhTien_EditValueChanged(object sender, EventArgs e)
        {
            setWeight(0);
        }
        #endregion

        private void tmCheck_Tick(object sender, EventArgs e)
        {
            //if (serial != null && !serial.IsOpen)
            //    serial.Open();
        }
        #endregion
    }
}
