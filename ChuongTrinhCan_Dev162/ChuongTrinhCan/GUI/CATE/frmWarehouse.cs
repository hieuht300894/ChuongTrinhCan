using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EntityModel.DataModel;
using System.Data.Entity;
using ChuongTrinhCan.Module;
using ChuongTrinhCan.BLL.CATE;

namespace ChuongTrinhCan.GUI.CATE
{
    public partial class frmWarehouse : frmBase
    {
        #region Variable
        public delegate void LoadData(int id);
        public LoadData ReloadData;
        eWarehouse _iEntry;
        eWarehouse _aEntry;
        #endregion

        #region Form
        public frmWarehouse()
        {
            InitializeComponent();
        }

        private void frmWarehouse_Load(object sender, EventArgs e)
        {
            clsGeneral.CallWaitForm(this);
            loadData(0);
            loadDataForm();
            customForm();
            clsGeneral.CloseWaitForm();
        }

        private void frmWarehouse_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (ReloadData != null)
                ReloadData(0);
        }
        #endregion

        #region Method
        private void loadData(int keyID)
        {
            gctWarehouse.DataSource = clsWarehouse.Instance.searchWarehouse(true);
            if (keyID > 0)
                grvWarehouse.FocusedRowHandle = grvWarehouse.LocateByValue(colKeyID.FieldName, keyID);
        }

        private void loadDataForm()
        {
            _iEntry = _iEntry ?? new eWarehouse();
            _aEntry = clsWarehouse.Instance.getEntry(_iEntry.KeyID);

            setControlValue();
        }

        private void setControlValue()
        {
            txtCode.EditValue = _aEntry.Code;
            txtName.EditValue = _aEntry.Name;
            mmeNote.EditValue = _aEntry.Note;
        }

        private bool validationForm()
        {
            txtCode.ErrorText = "";
            txtName.ErrorText = "";

            bool chk = true;
            if (string.IsNullOrEmpty(txtCode.Text.Trim()))
            {
                txtCode.ErrorText = "Xin nhập mã.";
                chk = false;
            }
            if (string.IsNullOrEmpty(txtName.Text.Trim()))
            {
                txtName.ErrorText = "Xin nhập tên.";
                chk = false;
            }
            return chk;
        }

        private bool saveData()
        {
            bool chk = false;
            _aEntry.Code = txtCode.Text.Trim();
            _aEntry.Name = txtName.Text.Trim();
            _aEntry.Note = mmeNote.Text.Trim();
            if (_aEntry.KeyID == 0)
                _aEntry.CreatedDate = DateTime.Now.ServerNow();
            else
                _aEntry.ModifiedDate = DateTime.Now.ServerNow();

            chk = clsWarehouse.Instance.accessEntry(_aEntry);
            return chk;
        }

        private void updateEntry()
        {
            _iEntry = grvWarehouse.GetFocusedRow() as eWarehouse;
            loadDataForm();
        }

        private void deleteEntry()
        {
            if (clsGeneral.showConfirmMessage("Xác nhận xóa dữ liệu") && grvWarehouse.FocusedRowHandle >= 0)
            {
                if (clsWarehouse.Instance.deleteEntry(Convert.ToInt32(grvWarehouse.GetRowCellValue(grvWarehouse.FocusedRowHandle, colKeyID))))
                {
                    clsGeneral.showMessage("Xóa dữ liệu thành công");
                    grvWarehouse.DeleteItem<eWarehouse>();
                }
                else
                    clsGeneral.showMessage("Xóa dữ liệu không thành công.\r\nVui lòng kiểm tra lại");
            }
        }

        private void customForm()
        {
            bar3.Visible = false;
            gctWarehouse.Format();
            grvWarehouse.OptionsView.ShowFooter = false;
        }
        #endregion

        #region Event
        private void grvWarehouse_DoubleClick(object sender, EventArgs e)
        {
            updateEntry();
        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
            if (validationForm())
            {
                if (saveData())
                {
                    loadData(_aEntry.KeyID);
                    _iEntry = _aEntry = null;
                    loadDataForm();
                }
                else clsGeneral.showMessage("Lưu dữ liệu không thành công.\r\nVui lòng kiểm tra lại");
            }
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            _iEntry = _aEntry = null;
            loadDataForm();
        }

        private void rbtnDelete_Click(object sender, EventArgs e)
        {
            deleteEntry();
        }
        #endregion
    }
}
