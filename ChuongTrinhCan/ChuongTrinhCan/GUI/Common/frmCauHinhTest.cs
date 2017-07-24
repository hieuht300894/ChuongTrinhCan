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

namespace ChuongTrinhCan
{
    public partial class frmCauHinhTest : Form
    {
        delegate void SetTextCallback(string text);
        Random random;
        SerialPort serial;
        string InputData = String.Empty;
        char[] kytu = new char[] { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
        public frmCauHinhTest()
        {
            InitializeComponent();
        }

        private void frmCauHinhTest_Load(object sender, EventArgs e)
        {
            try
            {
                random = new Random();
                serial = new SerialPort();
                serial.ReadTimeout = 5000;
                serial.DataReceived += serial_DataReceived;
                lbMessage.Text = "Chưa kết nối";
                LoadPort();
                LoadBaudRate();
            }
            catch { }
        }

        void serial_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            InputData = serial.ReadExisting();

            if (InputData != String.Empty)
                SetText(InputData); // Gọi delegate đã khai báo trước đó.
        }

        private void SetText(string text)
        {
            if (this.mmeData.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(SetText); // khởi tạo 1 delegate mới gọi đến SetText
                this.BeginInvoke(d, new object[] { text });
            }
            else this.mmeData.Text += text + "\n";
        }

        private void LoadPort()
        {
            cbbPort.Properties.Items.Clear();
            string[] ports = SerialPort.GetPortNames();
            ports.ToList().ForEach(x => cbbPort.Properties.Items.Add(x));
        }

        private void LoadBaudRate()
        {
            cbbBaudrate.Properties.Items.Clear();
            string[] BaudRate = { "1200", "2400", "4800", "9600", "19200", "38400", "57600", "115200" };
            BaudRate.ToList().ForEach(x => cbbBaudrate.Properties.Items.Add(x));
        }

        private void btnDisconnect_Click(object sender, EventArgs e)
        {
            if (serial.IsOpen)
                serial.Close();

            lbMessage.Text = serial.IsOpen ? "Đã kết nối" : "Chưa kết nối";
            timeSendData.Enabled = false;
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            if (serial.IsOpen)
                serial.Close();

            cbbPort.SelectedItem = "COM2";
            cbbBaudrate.SelectedItem = "9600";
            if (!string.IsNullOrEmpty(cbbPort.Text) && !string.IsNullOrEmpty(cbbBaudrate.Text))
            {
                serial.PortName = cbbPort.Text;
                serial.BaudRate = Convert.ToInt32(cbbBaudrate.Text);
                serial.DataBits = Properties.Settings.Default.DataBit;
                serial.Handshake = (Handshake)Enum.Parse(typeof(Handshake), Properties.Settings.Default.HandShake);
                serial.StopBits = (StopBits)Enum.Parse(typeof(StopBits), Properties.Settings.Default.StopBits);
                serial.Parity = (Parity)Enum.Parse(typeof(Parity), Properties.Settings.Default.Parity);
                serial.DiscardNull = true;
                serial.DtrEnable = true;
                //serial.Encoding = Encoding.GetEncoding(ASCIIEncoding.ASCII.EncodingName);
                serial.Open();
                lbMessage.Text = serial.IsOpen ? "Đã kết nối" : "Chưa kết nối";
                timeSendData.Enabled = true;
            }
        }

        private void frmCauHinhTest_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (serial.IsOpen)
                serial.Close();
            timeSendData.Enabled = false;

        }

        private void timeSendData_Tick(object sender, EventArgs e)
        {
            int val = random.Next(0, 65536);
            serial.Write(val + (val % 2 == 0 ? "G" : "M"));

        }
    }
}
