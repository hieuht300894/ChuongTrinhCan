using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ChuongTrinhCan.Module;

namespace ChuongTrinhCan
{
    public partial class frmCauHinh : Form
    {
        #region Variable
        public delegate void LoadData();
        public LoadData ReloadData;

        string[] ports;
        string[] baudRate = new string[] { "1200", "2400", "4800", "9600", "19200", "38400", "57600", "115200" };
        string[] parity = new string[] { "None", "Even", "Mark", "Odd", "Space" };
        string[] stopBits = new string[] { "One", "OnePointFive", "Two" };
        string[] handshake = new string[] { "None", "RequestToSend", "RequestToSendXOnXOff", "XOnXOff" };
        #endregion

        #region Form
        public frmCauHinh()
        {
            InitializeComponent();
        }

        private void frmCauHinh_Load(object sender, EventArgs e)
        {
            LoadDataForm();
        }
        #endregion

        #region Method
        private void LoadDataForm()
        {
            lciMsg.Text = "Chưa kết nối";
            InitFormCollection();
            SetControlValue();
        }

        private void InitFormCollection()
        {
            sptDataBit.Value = 7;

            cbbPort.Properties.Items.Clear();
            ports = SerialPort.GetPortNames();
            ports.ToList().ForEach(x => cbbPort.Properties.Items.Add(x));
            cbbPort.SelectedIndex = 0;

            cbbParity.Properties.Items.Clear();
            parity.ToList().ForEach(x => cbbParity.Properties.Items.Add(x));
            cbbParity.SelectedIndex = 0;

            cbbStopBits.Properties.Items.Clear();
            stopBits.ToList().ForEach(x => cbbStopBits.Properties.Items.Add(x));
            cbbStopBits.SelectedIndex = 0;

            cbbHandshake.Properties.Items.Clear();
            handshake.ToList().ForEach(x => cbbHandshake.Properties.Items.Add(x));
            cbbHandshake.SelectedIndex = 0;

            cbbBaudrate.Properties.Items.Clear();
            baudRate.ToList().ForEach(x => cbbBaudrate.Properties.Items.Add(x));
            cbbBaudrate.SelectedIndex = 0;
        }

        private void SetControlValue()
        {
            cbbPort.SelectedIndex = cbbPort.Properties.Items.Cast<string>().ToList().FindIndex(x => x.Equals(Properties.Settings.Default.Port));
            cbbBaudrate.SelectedIndex = cbbBaudrate.Properties.Items.Cast<string>().ToList().FindIndex(x => x.Equals(Properties.Settings.Default.BaudRate));
            cbbHandshake.SelectedIndex = cbbHandshake.Properties.Items.Cast<string>().ToList().FindIndex(x => x.Equals(Properties.Settings.Default.HandShake));
            cbbParity.SelectedIndex = cbbParity.Properties.Items.Cast<string>().ToList().FindIndex(x => x.Equals(Properties.Settings.Default.Parity));
            cbbStopBits.SelectedIndex = cbbStopBits.Properties.Items.Cast<string>().ToList().FindIndex(x => x.Equals(Properties.Settings.Default.StopBits));
            sptDataBit.Value = Properties.Settings.Default.DataBit;
            txtSymbol.EditValue = Properties.Settings.Default.Symbol;
            sptExchange.Value = Properties.Settings.Default.Exchange;
            sptKG.Value = Properties.Settings.Default.KG;
        }

        private bool ValidateValue()
        {
            cbbPort.ErrorText = "";
            cbbBaudrate.ErrorText = "";
            sptDataBit.ErrorText = "";
            sptExchange.ErrorText = "";
            sptKG.ErrorText = "";

            bool chk = true;
            if (string.IsNullOrEmpty(cbbPort.Text))
            {
                cbbPort.ErrorText = "Vui lòng chọn Port";
                chk = false;
            }
            if (string.IsNullOrEmpty(cbbBaudrate.Text))
            {
                cbbBaudrate.ErrorText = "Vui lòng chọn BaudRate";
                chk = false;
            }
            if (sptDataBit.Value <= 0)
            {
                sptDataBit.ErrorText = "Vui lòng nhập lớn hơn 0";
                chk = false;
            }
            //if (txtUnit.Value <= 0)
            //{
            //    txtUnit.ErrorText = "Vui lòng nhập lớn hơn 0";
            //    chk = false;
            //}
            if (sptKG.Value <= 0)
            {
                sptKG.ErrorText = "Vui lòng nhập lớn hơn 0";
                chk = false;
            }
            return chk;
        }

        private bool CheckConnectStatus()
        {
            bool chk = false;
            try
            {
                SerialPort serial = new SerialPort();
                serial.PortName = cbbPort.Text;
                serial.BaudRate = Convert.ToInt32(cbbBaudrate.Text);
                serial.DataBits = (int)sptDataBit.Value;
                serial.Handshake = (Handshake)Enum.Parse(typeof(Handshake), cbbHandshake.Text);
                serial.StopBits = (StopBits)Enum.Parse(typeof(StopBits), cbbStopBits.Text);
                serial.Parity = (Parity)Enum.Parse(typeof(Parity), cbbParity.Text);
                serial.Open();
                chk = serial.IsOpen;
                serial.Close();
            }
            catch { }
            lciMsg.Text = chk ? "Kết nối thành công" : "Kết nối thất bại";
            return chk;
        }

        private void CustomForm()
        {
            sptDataBit.Format();
            sptExchange.Format();
            sptKG.Format(4);

            sptKG.Properties.MinValue = 1;
        }
        #endregion

        #region Event
        private void frmCauHinh_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Port = cbbPort.Text;
            Properties.Settings.Default.BaudRate = cbbBaudrate.Text;
            Properties.Settings.Default.DataBit = (int)sptDataBit.Value;
            Properties.Settings.Default.Parity = cbbParity.Text;
            Properties.Settings.Default.HandShake = cbbHandshake.Text;
            Properties.Settings.Default.StopBits = cbbStopBits.Text;
            Properties.Settings.Default.Symbol = txtSymbol.Text.ToUpper();
            Properties.Settings.Default.Exchange = sptExchange.Value;
            Properties.Settings.Default.KG = sptKG.Value;

            bool chk = ValidateValue() && CheckConnectStatus();
            Properties.Settings.Default.IsConfigDevice = chk;
            if (chk && ReloadData != null)
            {
                Properties.Settings.Default.Save();
                ReloadData();
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
            }
        }
        #endregion
    }
}
