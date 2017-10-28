﻿using System;
using System.Windows.Forms;
using System.Collections.Generic;
using ChuongTrinhCan.Module;

namespace ChuongTrinhCan
{
    public partial class frmBase : DevExpress.XtraEditors.XtraForm
    {
        public eFormType fType;
        public bool isEnable = true;

        public frmBase()
        {
            InitializeComponent();
            btsIsEnable.CheckedChanged += btsChanged;
            btsIsEnable.CheckedChanged += btsIsEnable_CheckedChanged;
        }

        private void btsChanged(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            isEnable = btsIsEnable.Checked;
            btsIsEnable.Caption = btsIsEnable.Checked ? "Kích hoạt": "Không kích hoạt";
        }

        private void BarItemVisibility()
        {
            if (fType == eFormType.Default)
            {
                btnAdd.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                btnEdit.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                btnDisable.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                btnRefresh.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            }
            if (fType == eFormType.List)
            {
                btsIsEnable.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            }
            if (fType == eFormType.Add || fType == eFormType.Edit)
            {
                btnSave.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                btnSaveAndAdd.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                btnCancel.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            }
            if (fType == eFormType.Print)
            {
                btnPrintPreview.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                btnExportExcel.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            }
        }

        private void setCaptionButton()
        {
        }

        protected virtual void frmBase_Load(object sender, EventArgs e)
        {
            loadAccessForm();
            btsIsEnable.Caption = btsIsEnable.Checked ? "Kích hoạt" : "Không kích hoạt";
            BarItemVisibility();
            setCaptionButton();
        }

        private void loadAccessForm()
        {
            //if (fType == eFormType.Default && (this.Name.StartsWith("frm") || this.Name.StartsWith("bbi")))
            //{
            //    if (this.Name.StartsWith("bbi"))
            //        clsGeneral.curUserFeature = new EntityModel.DataModel.xUserFeature() { IsAdd = true, IsDelete = true, IsEdit = true, IsEnable = true };
            //    else
            //    {
            //        if (clsGeneral.curPersonnel.KeyID > 0 && clsGeneral.curAccount.IDPermission.HasValue && clsGeneral.curAccount.IDPermission > 0)
            //            clsGeneral.curUserFeature = clsUserRole.Instance.getUserFeature(this.Name);
            //        else if (clsGeneral.curPersonnel.KeyID == 0 && clsGeneral.curAccount.IDPermission.HasValue && clsGeneral.curAccount.IDPermission == 0)
            //            clsGeneral.curUserFeature = new EntityModel.DataModel.xUserFeature() { IsAdd = true, IsDelete = true, IsEdit = true, IsEnable = true };
            //    }
            //}
        }

        protected virtual void btnAdd_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        protected virtual void btnEdit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        protected virtual void btnDelete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        protected virtual void btnRefresh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        protected virtual void btnExportExcel_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        protected virtual void btnCancel_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        protected virtual void btnPrintPreview_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        protected virtual void btnSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        protected virtual void btnSaveAndAdd_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        protected virtual void btsIsEnable_CheckedChanged(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        protected virtual void bbpAdd_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        protected virtual void bbpEdit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        protected virtual void bbpDelete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        protected virtual void bbpRefresh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        protected virtual void ShowGridPopup(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                DevExpress.XtraGrid.GridControl gctMain = (DevExpress.XtraGrid.GridControl)sender;
                DevExpress.XtraGrid.Views.Grid.ViewInfo.GridHitInfo hi = ((DevExpress.XtraGrid.Views.Grid.GridView)gctMain.DefaultView).CalcHitInfo(e.Location);
                if (hi.RowHandle >= 0 && (hi.InRow || hi.InRowCell))
                {
                    bbpAdd.Enabled = bbpEdit.Enabled = bbpDisable.Enabled = bbpRefresh.Enabled = true;
                }
                else
                {
                    bbpAdd.Enabled = bbpRefresh.Enabled = true;
                    bbpEdit.Enabled = bbpDisable.Enabled = false;
                }

                //if (fType == eFormType.Default)
                //{
                //    bbpAdd.Enabled = clsGeneral.curUserFeature.IsAdd && bbpAdd.Enabled;
                //    bbpEdit.Enabled = clsGeneral.curUserFeature.IsEdit && bbpEdit.Enabled;
                //    bbpDisable.Enabled = clsGeneral.curUserFeature.IsDelete && bbpDisable.Enabled;
                //}

                popGridMenu.ShowPopup(MousePosition);
            }
        }

        private void frmBase_ControlAdded(object sender, ControlEventArgs e)
        {
         
        }

        private void frmBase_Enter(object sender, EventArgs e)
        {
            loadAccessForm();
        }

        protected virtual void _showPercent(int value)
        {
            betPercent.EditValue = value;
            if (value == 100)
                betPercent.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
        }

        protected virtual void _showMessage(bool status)
        {
        // ("Đã xóa xong dữ liệu.");
        }
    }
}