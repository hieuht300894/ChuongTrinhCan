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
using ChuongTrinhCan.Module;
using ChuongTrinhCan.BLL.CATE;

namespace ChuongTrinhCan.GUI.CATE
{
    public partial class frmCustomer : frmBase
    {
        #region Variables
        public delegate void LoadData(int strKey);
        public LoadData ReLoadParent;
        public eCustomer iEntry;
        eCustomer _acEntry;
        public bool? IsEnable { get; set; }
        public bool IsExtract { get; set; }
        #endregion

        #region Form Events
        public frmCustomer()
        {
            InitializeComponent();
        }

        private void frmCustomer_Load(object sender, EventArgs e)
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
                    iEntry = null;
                    loadDataForm();
                    fType = eFormType.Add;
                    this.Text = "Thêm mới khách hàng";
                }
                else
                    clsGeneral.showMessage("Lưu dữ liệu không thành công.\r\nVui lòng kiểm tra lại");
        }
        #endregion

        #region Methods
        private void customForm()
        {
            txtCode.NotUnicode(true, true);
            //txtName.IsPersonName();
            txtCode.Format();
            txtName.Format();
            txtAddress.Format();
            txtContact.Format();
            this.CenterToScreen();
        }

        private bool validationForm()
        {
            bool bRe = true;
            txtCode.ErrorText = string.Empty;
            txtName.ErrorText = string.Empty;
            txtAddress.ErrorText = string.Empty;

            string setFocusControl = "";

            if (string.IsNullOrEmpty(txtName.Text.Trim()))
            {
                txtName.ErrorText = "Vui lòng nhập tên khách hàng";
                bRe = false; setFocusControl = txtName.Name;
            }

            if (string.IsNullOrEmpty(txtCode.Text.Trim()))
            {
                txtCode.ErrorText = "Vui lòng nhập mã khách hàng";
                bRe = false; setFocusControl = txtCode.Name;
            }
            //else if (clsCustomer.Instance.checkExistCustomer(txtCode.Text, _acEntry.KeyID))
            //{
            //    txtCode.ErrorText = "Mã khách hàng đã tồn tại.".Translation("msgDuplicatedCode", this.Name);
            //    bRe = false; setFocusControl = txtCode.Name;
            //}

            if (string.IsNullOrEmpty(txtAddress.Text.Trim()))
            {
                txtAddress.ErrorText = "Vui lòng nhập địa chỉ khách hàng";
                bRe = false; setFocusControl = txtAddress.Name;
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
            txtAddress.Text = _acEntry.Address;
            txtContact.Text = _acEntry.Contact;
            mmoNote.Text = _acEntry.Note;
            if (_acEntry.KeyID == 0)
            {
                //txtCode.Text = "CUSTOMER";
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
            iEntry = iEntry ?? new eCustomer();
            _acEntry = clsCustomer.Instance.getEntry(iEntry.KeyID);
            setControlValue();
        }

        private bool saveData()
        {
            bool bRe = false;

            _acEntry.Name = txtName.Text.Trim();
            _acEntry.Address = txtAddress.Text.Trim();
            _acEntry.Contact = txtContact.Text.Trim();
            _acEntry.Note = mmoNote.Text.Trim();
            
            if (_acEntry.KeyID == 0)
            {
                _acEntry.IDAgency = clsGeneral.curAgency.KeyID;
                _acEntry.Code = txtCode.Text.Trim().ToUpper();
                //_acEntry.CreatedBy = clsGeneral.curPersonnel.KeyID;
                _acEntry.CreatedDate = DateTime.Now.ServerNow();
                _acEntry.Status = 1;
            }
            else
            {
                //_acEntry.ModifiedBy = clsGeneral.curPersonnel.KeyID;
                _acEntry.ModifiedDate = DateTime.Now.ServerNow();
                _acEntry.Status = 2;
            }

            bRe = clsCustomer.Instance.accessEntry(_acEntry);

            if (bRe && ReLoadParent != null)
                ReLoadParent(_acEntry.KeyID);

            return bRe;
        }
        #endregion
    }
}