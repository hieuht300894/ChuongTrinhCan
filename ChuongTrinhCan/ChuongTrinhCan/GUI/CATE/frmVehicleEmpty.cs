using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Entity;
using ChuongTrinhCan.Module;
using ChuongTrinhCan.BLL.CATE;
using EntityModel.DataModel;

namespace ChuongTrinhCan.GUI.CATE
{
    public partial class frmVehicleEmpty : frmBase
    {
        #region Variable
        eVehicleEmpty _aEntry;
        #endregion

        #region Form
        public frmVehicleEmpty()
        {
            InitializeComponent();
        }

        private void frmVehicleEmpty_Load(object sender, EventArgs e)
        {
            clsGeneral.CallWaitForm(this);
            loadData(0);
            loadNewData();
            customForm();
            clsGeneral.CloseWaitForm();
        }

        #endregion

        #region Method
        private void loadData(int KeyID)
        {
            gctVehicle.DataSource = clsVehicleEmpty.Instance.getAll();
            if (KeyID > 0)
                grvVehicle.FocusedRowHandle = grvVehicle.LocateByValue(colKeyID.FieldName, KeyID);
        }

        private void loadNewData()
        {
            _aEntry = clsVehicleEmpty.Instance.getEntry(0);
            if (_aEntry != null)
            {
                txtNumber.EditValue = _aEntry.VehicleNumber;
                sptWeight.Value = _aEntry.EmptyWeight;
            }
            else
                btn_Save.Enabled = false;
        }

        private bool saveData()
        {
            bool chk = true;

            if (_aEntry.KeyID == 0)
                _aEntry.CreatedDate = DateTime.Now.ServerNow();
            else
                _aEntry.ModifiedDate = DateTime.Now.ServerNow();

            chk = clsVehicleEmpty.Instance.accessEntry(_aEntry);
            if (chk)
                loadData(_aEntry.KeyID);
            return chk;
        }

        private void customForm()
        {
            bar3.Visible = false;
            gctVehicle.Format();
            sptWeight.Format();
            rsptNumber.Format();

            grvVehicle.OptionsView.ShowFooter = false;
        }
        #endregion

        #region Event
        private void btn_Save_Click(object sender, EventArgs e)
        {
            if (saveData()) { btn_Save.Enabled = false; }
            else clsGeneral.showMessage("Lưu dữ liệu không thành công.\r\nVui lòng kiểm tra lại");
        }

        private void rbtnDelete_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Index == 0 && clsGeneral.showConfirmMessage("Xác nhận xóa dữ liệu") && grvVehicle.FocusedRowHandle >= 0)
            {
                if (clsVehicleEmpty.Instance.deleteEntry(grvVehicle.DeleteItem<eVehicleEmpty>().FirstOrDefault()))
                    clsGeneral.showMessage("Xóa dữ liệu thành công");
                else
                    clsGeneral.showMessage("Xóa dữ liệu không thành công.\r\nVui lòng kiểm tra lại");
            }
        }
        #endregion
    }
}
