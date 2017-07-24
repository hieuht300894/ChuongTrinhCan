using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using EntityModel.DataModel;
using ChuongTrinhCan.Module;
using ChuongTrinhCan.BLL.CATE;

namespace ChuongTrinhCan.GUI.CATE
{
    public partial class frmCustomer_List : frmBase
    {
        #region Variable
        public delegate void LoadData(int id);
        public LoadData ReloadData;
        #endregion

        #region Form Events
        public frmCustomer_List()
        {
            InitializeComponent();
        }

        private void frmCustomer_List_Load(object sender, EventArgs e)
        {
            clsGeneral.CallWaitForm(this);
            loadData(0);
            customForm();
            clsGeneral.CloseWaitForm();
        }

        private void btnFilter_Click(object sender, EventArgs e)
        {
            loadFilter(0);
        }

        private void frmCustomer_List_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (ReloadData != null)
                ReloadData(0);
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            sendData();
        }
        #endregion

        #region Grid Events
        private void gctCustomer_List_MouseClick(object sender, MouseEventArgs e)
        {
            base.ShowGridPopup(sender, e);
        }

        private void grvCustomer_List_DoubleClick(object sender, EventArgs e)
        {
            MouseEventArgs mouse = e as MouseEventArgs;
            DevExpress.XtraGrid.Views.Grid.ViewInfo.GridHitInfo hi = grvCustomer_List.CalcHitInfo(mouse.Location);
            if (grvCustomer_List.FocusedRowHandle >= 0 && (hi.InRow || hi.InRowCell))
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
            gctCustomer_List.Format();
            grvCustomer_List.OptionsView.ShowFooter = false;
            grvCustomer_List.OptionsSelection.MultiSelect = true;
            grvCustomer_List.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.RowSelect;
        }
        private void loadFilter(int KeyID)
        {
            gctCustomer_List.DataSource = clsCustomer.Instance.searchCustomer(new eCustomer()
            {
                Code = searchCode.Text,
                Name = searchName.Text,
                Contact = searchContact.Text,
                IsEnable = base.isEnable
            });
            if (KeyID > 0)
                grvCustomer_List.FocusedRowHandle = grvCustomer_List.LocateByValue("KeyID", KeyID);
        }
        private void loadCustomer()
        {
            IList<eCustomer> lst = clsCustomer.Instance.searchCustomer(btsIsEnable.Checked);
            searchCode.Properties.Items.Clear();
            searchCode.Properties.Items.AddRange(lst.Where(x => !string.IsNullOrEmpty(x.Code)).Select(x => x.Code).ToArray<string>());

            searchName.Properties.Items.Clear();
            searchName.Properties.Items.AddRange(lst.Where(x => !string.IsNullOrEmpty(x.Name)).Select(x => x.Name).ToArray<string>());

            searchContact.Properties.Items.Clear();
            searchContact.Properties.Items.AddRange(lst.Where(x => !string.IsNullOrEmpty(x.Contact)).Select(x => x.Contact).ToArray<string>());
        }
        private void loadData(int KeyID)
        {
            loadCustomer();
            loadFilter(KeyID);
        }
        private void insertEntry()
        {
            using (frmCustomer _frm = new frmCustomer())
            {
                _frm.IsExtract = false;
                _frm.Text = "Thêm mới khách hàng";
                _frm.fType = eFormType.Add;
                _frm.ReLoadParent = this.loadFilter;
                _frm.ShowDialog();
            }
        }
        private void updateEntry()
        {
            //if (!clsGeneral.curPermission.IsEdit)
            //    return;

            if (grvCustomer_List.RowCount > 0 && grvCustomer_List.FocusedRowHandle >= 0)
            {
                try
                {
                    using (frmCustomer _frm = new frmCustomer())
                    {
                        eCustomer _eEntry = (eCustomer)grvCustomer_List.GetRow(grvCustomer_List.FocusedRowHandle);
                        _frm.iEntry = _eEntry;
                        _frm.IsExtract = false;
                        _frm.Text = "Cập nhật khách hàng";
                        _frm.fType = eFormType.Edit;
                        _frm.ReLoadParent = this.loadFilter;
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
            if (clsGeneral.showConfirmMessage("Xác nhận xóa dữ liệu") && grvCustomer_List.FocusedRowHandle >= 0)
            {
                if (clsCustomer.Instance.deleteEntry(grvCustomer_List.DeleteItem<eCustomer>()))
                    clsGeneral.showMessage("Xóa dữ liệu thành công");
                else
                    clsGeneral.showMessage("Xóa dữ liệu không thành công.\r\nVui lòng kiểm tra lại");
            }
        }
        private void refreshEntry()
        {
            loadFilter(0);
        }
        private void sendData()
        {
            List<int> lstID = new List<int>();
            grvCustomer_List.GetSelectedRows().ToList().ForEach(x => lstID.Add(Convert.ToInt32(grvCustomer_List.GetRowCellValue(x, colKeyID))));
            if (clsCustomer.Instance.asyncData(lstID))
                clsGeneral.showMessage("Đồng bộ dữ liệu xong");
            else
                clsGeneral.showMessage("Đồng bộ dữ liệu không thành công.\r\nVui lòng kiểm tra lại");
        }
        #endregion
    }
}