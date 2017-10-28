using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using EntityModel.DataModel;
using ChuongTrinhCan.Module;
using ChuongTrinhCan.BLL.CATE;

namespace ChuongTrinhCan.GUI.CATE
{
    public partial class frmProduct_List : frmBase
    {
        #region Variable
        public delegate void LoadData(int id);
        public LoadData ReloadData;
        #endregion

        #region Form Events
        public frmProduct_List()
        {
            InitializeComponent();
        }
        private void frmProduct_List_Load(object sender, EventArgs e)
        {
            clsGeneral.CallWaitForm(this);
            loadData(0);
            customForm();
            clsGeneral.CloseWaitForm();
        }
        private void frmProduct_List_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (ReloadData != null)
                ReloadData(0);
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            sendData();
        }
        #endregion

        #region Grids Events
        private void gctProduct_List_MouseClick(object sender, MouseEventArgs e)
        {
            base.ShowGridPopup(sender, e);
        }

        private void grvProduct_List_DoubleClick(object sender, EventArgs e)
        {
            MouseEventArgs mouse = e as MouseEventArgs;
            DevExpress.XtraGrid.Views.Grid.ViewInfo.GridHitInfo hi = grvProduct_List.CalcHitInfo(mouse.Location);
            if (grvProduct_List.FocusedRowHandle >= 0 && (hi.InRow || hi.InRowCell))
            {
                updateEntry();
            }
        }
        #endregion

        #region Base Button Events
        protected override void btnAdd_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            insertEntry();
        }

        protected override void btnRefresh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            refreshEntry();
        }

        protected override void btnEdit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            updateEntry();
        }

        protected override void btnDelete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            deleteEntry();
        }

        protected override void btsIsEnable_CheckedChanged(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            refreshEntry();
        }

        protected override void bbpAdd_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            insertEntry();
        }

        protected override void bbpEdit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            updateEntry();
        }

        protected override void bbpDelete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            deleteEntry();
        }

        protected override void bbpRefresh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            refreshEntry();
        }
        #endregion

        #region Methods
        private void customForm()
        {
            gctProduct_List.Format();
            rsptNumber.Format(2);
            grvProduct_List.OptionsView.ShowFooter = false;
            grvProduct_List.OptionsSelection.MultiSelect = true;
            grvProduct_List.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.RowSelect;
        }
        private void loadData(int KeyID)
        {
            gctProduct_List.DataSource = clsProduct.Instance.searchProduct(true);
            if (KeyID > 0)
                grvProduct_List.FocusedRowHandle = grvProduct_List.LocateByValue("KeyID", KeyID);
        }
        private void insertEntry()
        {
            using (frmProduct _frm = new frmProduct())
            {
                _frm.Text = "Thêm mới sản phẩm";
                _frm.fType = eFormType.Add;
                _frm.ReLoadParent = this.loadData;
                _frm.ShowDialog();
            }
        }
        private void updateEntry()
        {
            //if (!clsGeneral.curPermission.IsEdit)
            //    return;

            if (grvProduct_List.RowCount > 0 && grvProduct_List.FocusedRowHandle >= 0)
            {
                try
                {
                    using (frmProduct _frm = new frmProduct())
                    {
                        eProduct _eEntry = (eProduct)grvProduct_List.GetRow(grvProduct_List.FocusedRowHandle);
                        _frm.iEntry = _eEntry;
                        _frm.Text = "Cập nhật sản phẩm";
                        _frm.fType = eFormType.Edit;
                        _frm.ReLoadParent = this.loadData;
                        _frm.ShowDialog();
                    }
                }
                catch (Exception ex)
                {
                    clsGeneral.showErrorException(ex, "Exception");
                }
            }
        }
        private void deleteEntry()
        {
            if (clsGeneral.showConfirmMessage("Xác nhận xóa dữ liệu") && grvProduct_List.FocusedRowHandle >= 0)
            {
                if (clsProduct.Instance.deleteEntry(grvProduct_List.DeleteItem<eProduct>()))
                    clsGeneral.showMessage("Xóa dữ liệu thành công");
                else
                    clsGeneral.showMessage("Lưu dữ liệu không thành công.\r\nVui lòng kiểm tra lại");
            }
        }
        private void refreshEntry()
        {
            loadData(0);
        }
        private void sendData()
        {
            List<int> lstID = new List<int>();
            grvProduct_List.GetSelectedRows().ToList().ForEach(x => lstID.Add(Convert.ToInt32(grvProduct_List.GetRowCellValue(x, colKeyID))));
            if (clsProduct.Instance.asyncData(lstID))
                clsGeneral.showMessage("Đồng bộ dữ liệu xong");
            else
                clsGeneral.showMessage("Đồng bộ dữ liệu không thành công.\r\nVui lòng kiểm tra lại");
        }
        #endregion
    }
}