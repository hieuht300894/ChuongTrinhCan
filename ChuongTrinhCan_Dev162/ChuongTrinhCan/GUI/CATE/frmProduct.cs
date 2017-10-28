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
using EntityModel.DataModel;
using ChuongTrinhCan.BLL.CATE;
using ChuongTrinhCan.BLL.Common;
using ChuongTrinhCan.Module;

namespace ChuongTrinhCan.GUI.CATE
{
    public partial class frmProduct : frmBase
    {
        #region Variables
        public delegate void LoadData(int strKey);
        public LoadData ReLoadParent;
        public bool? IsEnable { get; set; }
        public eProduct iEntry;
        eProduct _acEntry;
        #endregion

        #region Form Events
        public frmProduct()
        {
            InitializeComponent();
        }

        private void frmProduct_Load(object sender, EventArgs e)
        {
            loadDataForm();
            customForm();
        }
        #endregion

        #region Base Button Events
        protected override void btnCancel_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            loadDataForm();
        }

        protected override void btnSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (validationForm())
                if (saveData())
                    this.DialogResult = System.Windows.Forms.DialogResult.OK;
                else
                    clsGeneral.showMessage("Lưu dữ liệu không thành công.\r\nVui lòng kiểm tra lại");
        }

        protected override void btnSaveAndAdd_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (validationForm())
                if (saveData())
                {
                    iEntry = _acEntry = new eProduct() { IsEnable = true };
                    setControlValue();
                    fType = eFormType.Add;
                    this.Text = "Thêm mới sản phẩm";
                }
                else
                    clsGeneral.showMessage("Lưu dữ liệu không thành công.\r\nVui lòng kiểm tra lại");
        }
        #endregion

        #region Methods
        private void customForm()
        {
            txtCode.NotUnicode(true, true);
            txtCode.Format();
            txtName.Format();
            spnPrice.Format(2);
            sptPriceCus.Format(2);
            this.CenterToScreen();
        }

        public bool validationForm()
        {
            bool bRe = true;
            txtCode.ErrorText = string.Empty;
            txtName.ErrorText = string.Empty;

            string setFocusControl = "";

            if (string.IsNullOrEmpty(txtName.Text.Trim()))
            {
                txtName.ErrorText = "Vui lòng nhập tên sản phẩm";
                bRe = false; setFocusControl = txtName.Name;
            }

            if (string.IsNullOrEmpty(txtCode.Text.Trim()))
            {
                txtCode.ErrorText = "Vui lòng nhập mã sản phẩm";
                bRe = false; setFocusControl = txtCode.Name;
            }

            if (!string.IsNullOrEmpty(setFocusControl))
            {
                this.Controls.Find(setFocusControl, true).First().Select();
            }
            return bRe;
        }

        private void setControlValue()
        {
            txtCode.Text = _acEntry.Code;
            txtName.Text = _acEntry.Name;
            spnPrice.EditValue = _acEntry.Price;
            sptPriceCus.EditValue = _acEntry.PriceCustomer;
            mmoNote.Text = _acEntry.Note;
            if (_acEntry.KeyID == 0)
            {
                txtCode.TabStop = true;
                txtCode.ReadOnly = false;
                txtCode.Select();
            }
            else
            {
                txtCode.TabStop = false;
                txtCode.ReadOnly = true;
                txtName.Select();
            }
        }

        private void loadDataForm()
        {
            iEntry = iEntry ?? new eProduct();
            _acEntry = clsProduct.Instance.getEntry(iEntry.KeyID);
            setControlValue();
        }

        public bool saveData()
        {
            bool bRe = false;

            _acEntry.Name = txtName.Text.Trim();
            _acEntry.Note = mmoNote.Text.Trim();
            _acEntry.Price = spnPrice.ToDecimal();
            _acEntry.PriceCustomer = sptPriceCus.ToDecimal();

            if (_acEntry.KeyID == 0)
            {
                _acEntry.IDAgency = clsGeneral.curAgency.KeyID;
                _acEntry.Code = txtCode.Text.Trim().ToUpper();
                _acEntry.CreatedDate = DateTime.Now.ServerNow();
                _acEntry.Status = 1;
            }
            else
            {
                _acEntry.ModifiedDate = DateTime.Now.ServerNow();
                _acEntry.Status = 2;
            }

            bRe = clsProduct.Instance.accessEntry(_acEntry);

            if (bRe && ReLoadParent != null)
                ReLoadParent(_acEntry.KeyID);

            return bRe;
        }
        #endregion
    }
}