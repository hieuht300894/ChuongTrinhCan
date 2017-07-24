using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChuongTrinhCan.GUI.Common
{
    public partial class frmDisplay : frmBase
    {
        #region Variable
        public delegate void LoadData(int id);
        public LoadData ReloadData;
        List<string> lstFontTypes;
        List<string> lstFontFamilies;
        List<int> lstFontSizes;
        List<Control> lstControls;
        #endregion

        public frmDisplay()
        {
            InitializeComponent();
        }

        private void frmDisplay_Load(object sender, EventArgs e)
        {
            loadData();
            customForm();
        }

        private void loadData()
        {
            initData();
            resetData();
            setData();

        }

        private void initData()
        {
            InstalledFontCollection iFont = new InstalledFontCollection();
            lstFontFamilies = new List<string>();
            iFont.Families.ToList().ForEach(x => lstFontFamilies.Add(x.Name));
            lstFontTypes = new List<string>() { FontStyle.Regular.ToString(), FontStyle.Bold.ToString(), FontStyle.Italic.ToString(), FontStyle.Underline.ToString(), FontStyle.Strikeout.ToString() };
            lstFontSizes = new List<int>() { 8, 9, 10, 11, 12, 14, 16, 18, 20, 22, 24, 28, 36, 48, 72 };
            lstControls = new List<Control>() { cbbFontFamily_General, cbbFontSize_General, cbbFontStyle_General, cbbFontSize_KG, cbbFontStyle_KG, clrBackColor_Add, clrBackColor_Delete, clrBackColor_Edit, clrBackColor_KG, clrForeColor_KG, clrBackColor_NewScale };
        }

        private void resetData()
        {
            cbbFontFamily_General.Properties.Items.Clear();
            cbbFontSize_General.Properties.Items.Clear();
            cbbFontStyle_General.Properties.Items.Clear();
            cbbFontSize_KG.Properties.Items.Clear();
            cbbFontStyle_KG.Properties.Items.Clear();
        }

        private void setData()
        {
            cbbFontFamily_General.Properties.Items.AddRange(lstFontFamilies.ToArray<string>());
            cbbFontStyle_General.Properties.Items.AddRange(lstFontTypes.ToArray<string>());
            cbbFontStyle_KG.Properties.Items.AddRange(lstFontTypes.ToArray<string>());
            cbbFontSize_General.Properties.Items.AddRange(lstFontSizes.ToArray<int>());
            cbbFontSize_KG.Properties.Items.AddRange(lstFontSizes.ToArray<int>());

            cbbFontFamily_General.SelectedItem = Properties.Settings.Default.GeneralFont.FontFamily.Name;
            cbbFontStyle_General.SelectedItem = Properties.Settings.Default.GeneralFont.Style.ToString();
            cbbFontSize_General.SelectedItem = Convert.ToInt32(Properties.Settings.Default.GeneralFont.Size);
            if (cbbFontSize_General.SelectedIndex == -1)
                cbbFontSize_General.Text = Convert.ToInt32(Properties.Settings.Default.GeneralFont.Size).ToString();

            Font f = Properties.Settings.Default.ScaleNumberFont;
            cbbFontStyle_KG.SelectedItem = Properties.Settings.Default.ScaleNumberFont.Style.ToString();
            cbbFontSize_KG.SelectedItem = Convert.ToInt32(Properties.Settings.Default.ScaleNumberFont.Size);
            if (cbbFontSize_KG.SelectedIndex == -1)
                cbbFontSize_KG.Text = Convert.ToInt32(Properties.Settings.Default.ScaleNumberFont.Size).ToString();
            clrBackColor_KG.Color = Properties.Settings.Default.ScaleNumberBackground;
            clrForeColor_KG.Color = Properties.Settings.Default.ScaleNumberForecolor;

            clrBackColor_NewScale.Color = Properties.Settings.Default.NewScale;
            clrBackColor_Add.Color = Properties.Settings.Default.Add;
            clrBackColor_Edit.Color = Properties.Settings.Default.Edit;
            clrBackColor_Delete.Color = Properties.Settings.Default.Delete;
        }

        private float isNumber(string value)
        {
            string text = "";
            value.ToList<char>().ForEach(x => text += (x >= '0' && x <= '9') ? x.ToString() : "");
            //foreach(char c in value)
            //{
            //    text += c >= '0' && c <= '9' ? c.ToString() : "";
            //}
            if (string.IsNullOrEmpty(text))
                return 12;
            else
                return float.Parse(text);
        }

        private void changeStyle(Control control)
        {
            if (control is ComboBoxEdit)
            {
                ComboBoxEdit cbb = control as ComboBoxEdit;
                if (cbb.Name.StartsWith("cbbFontFamily"))
                    lbMsg.Font = new Font(cbb.Text.Trim(), lbMsg.Font.Size, lbMsg.Font.Style);
                if (cbb.Name.StartsWith("cbbFontStyle"))
                    lbMsg.Font = new Font(lbMsg.Font.FontFamily, lbMsg.Font.Size, (FontStyle)Enum.Parse(typeof(FontStyle), cbb.Text.Trim()));
                if (cbb.Name.StartsWith("cbbFontSize"))
                    lbMsg.Font = new Font(lbMsg.Font.FontFamily, isNumber(cbb.Text.Trim()), lbMsg.Font.Style);
            }
            if (control is ColorEdit)
            {
                ColorEdit clr = control as ColorEdit;
                if (clr.Name.StartsWith("clrBackColor"))
                    lbMsg.BackColor = clr.Color;
                if (clr.Name.StartsWith("clrForeColor"))
                    lbMsg.ForeColor = clr.Color;
            }
        }

        private void customForm()
        {
            bar3.Visible = false;
            foreach (Control ctr in lstControls)
            {
                ctr.TextChanged += ctr_TextChanged;
                ctr.KeyDown += ctr_KeyDown;
            }

        }

        void ctr_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                changeStyle(sender as Control);
        }

        void ctr_TextChanged(object sender, EventArgs e)
        {
            changeStyle(sender as Control);
        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.GeneralFont = new Font(cbbFontFamily_General.Text.Trim(), float.Parse(cbbFontSize_General.Text.Trim()), (FontStyle)Enum.Parse(typeof(FontStyle), cbbFontStyle_General.Text.Trim()));
            Properties.Settings.Default.ScaleNumberFont = new Font(cbbFontFamily_General.Text.Trim(), float.Parse(cbbFontSize_KG.Text.Trim()), (FontStyle)Enum.Parse(typeof(FontStyle), cbbFontStyle_KG.Text.Trim()));

            Properties.Settings.Default.ScaleNumberBackground = clrBackColor_KG.Color;
            Properties.Settings.Default.ScaleNumberForecolor = clrForeColor_KG.Color;
            Properties.Settings.Default.NewScale = clrBackColor_NewScale.Color;
            Properties.Settings.Default.Add = clrBackColor_Add.Color;
            Properties.Settings.Default.Edit = clrBackColor_Edit.Color;
            Properties.Settings.Default.Delete = clrBackColor_Delete.Color;

            Properties.Settings.Default.Save();

            if (ReloadData != null)
                ReloadData(1);
        }
    }
}
