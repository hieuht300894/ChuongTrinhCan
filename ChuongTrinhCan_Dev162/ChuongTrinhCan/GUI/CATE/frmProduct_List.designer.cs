namespace ChuongTrinhCan.GUI.CATE
{
    partial class frmProduct_List
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmProduct_List));
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.btnSend = new DevExpress.XtraEditors.SimpleButton();
            this.gctProduct_List = new DevExpress.XtraGrid.GridControl();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.grvProduct_List = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colKeyID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPrice = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rsptNumber = new DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit();
            this.colPriceCustomer = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colIsEnable = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStatus = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colIsSend = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCreatedBy = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCreatedDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rdeDate = new DevExpress.XtraEditors.Repository.RepositoryItemDateEdit();
            this.colModifiedBy = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colModifiedDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNote = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colIDAgency = new DevExpress.XtraGrid.Columns.GridColumn();
            this.coleDryDetails = new DevExpress.XtraGrid.Columns.GridColumn();
            this.coleMillDetails = new DevExpress.XtraGrid.Columns.GridColumn();
            this.coleOrderDetails = new DevExpress.XtraGrid.Columns.GridColumn();
            this.coleSeparateColorDetails = new DevExpress.XtraGrid.Columns.GridColumn();
            this.coleWarehouseFinishedProducts = new DevExpress.XtraGrid.Columns.GridColumn();
            this.coleWarehouseIns = new DevExpress.XtraGrid.Columns.GridColumn();
            this.coleWarehouseMills = new DevExpress.XtraGrid.Columns.GridColumn();
            this.coleWarehouseOuts = new DevExpress.XtraGrid.Columns.GridColumn();
            this.coleBillOrderDries = new DevExpress.XtraGrid.Columns.GridColumn();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            ((System.ComponentModel.ISupportInitialize)(this.popGridMenu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gctProduct_List)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvProduct_List)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rsptNumber)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rdeDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rdeDate.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnEdit
            // 
            this.btnEdit.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnEdit.ImageOptions.Image")));
            this.btnEdit.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnEdit.ImageOptions.LargeImage")));
            this.btnEdit.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            // 
            // bar3
            // 
            this.bar3.OptionsBar.DrawDragBorder = false;
            this.bar3.OptionsBar.MultiLine = true;
            this.bar3.OptionsBar.UseWholeRow = true;
            // 
            // btnDisable
            // 
            this.btnDisable.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnDisable.ImageOptions.Image")));
            this.btnDisable.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnDisable.ImageOptions.LargeImage")));
            this.btnDisable.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            // 
            // btnRefresh
            // 
            this.btnRefresh.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnRefresh.ImageOptions.Image")));
            this.btnRefresh.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnRefresh.ImageOptions.LargeImage")));
            this.btnRefresh.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            // 
            // btnSave
            // 
            this.btnSave.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnSave.ImageOptions.Image")));
            this.btnSave.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnSave.ImageOptions.LargeImage")));
            // 
            // btnCancel
            // 
            this.btnCancel.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnCancel.ImageOptions.Image")));
            this.btnCancel.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnCancel.ImageOptions.LargeImage")));
            // 
            // btnSaveAndAdd
            // 
            this.btnSaveAndAdd.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnSaveAndAdd.ImageOptions.Image")));
            this.btnSaveAndAdd.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnSaveAndAdd.ImageOptions.LargeImage")));
            // 
            // btnPrintPreview
            // 
            this.btnPrintPreview.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnPrintPreview.ImageOptions.Image")));
            this.btnPrintPreview.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnPrintPreview.ImageOptions.LargeImage")));
            // 
            // btnExportExcel
            // 
            this.btnExportExcel.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnExportExcel.ImageOptions.Image")));
            this.btnExportExcel.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnExportExcel.ImageOptions.LargeImage")));
            // 
            // btnAdd
            // 
            this.btnAdd.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnAdd.ImageOptions.Image")));
            this.btnAdd.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnAdd.ImageOptions.LargeImage")));
            this.btnAdd.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            // 
            // bar1
            // 
            this.bar1.OptionsBar.DrawBorder = false;
            this.bar1.OptionsBar.DrawDragBorder = false;
            this.bar1.OptionsBar.MultiLine = true;
            this.bar1.OptionsBar.UseWholeRow = true;
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.btnSend);
            this.layoutControl1.Controls.Add(this.gctProduct_List);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 24);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(582, 142, 250, 350);
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(784, 316);
            this.layoutControl1.TabIndex = 4;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // btnSend
            // 
            this.btnSend.Image = ((System.Drawing.Image)(resources.GetObject("btnSend.Image")));
            this.btnSend.Location = new System.Drawing.Point(675, 266);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(97, 38);
            this.btnSend.StyleController = this.layoutControl1;
            this.btnSend.TabIndex = 5;
            this.btnSend.Text = "Đồng bộ";
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // gctProduct_List
            // 
            this.gctProduct_List.DataSource = this.bindingSource1;
            this.gctProduct_List.Location = new System.Drawing.Point(12, 12);
            this.gctProduct_List.MainView = this.grvProduct_List;
            this.gctProduct_List.Name = "gctProduct_List";
            this.gctProduct_List.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.rsptNumber,
            this.rdeDate});
            this.gctProduct_List.Size = new System.Drawing.Size(760, 250);
            this.gctProduct_List.TabIndex = 4;
            this.gctProduct_List.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvProduct_List});
            this.gctProduct_List.MouseClick += new System.Windows.Forms.MouseEventHandler(this.gctProduct_List_MouseClick);
            // 
            // bindingSource1
            // 
            this.bindingSource1.DataSource = typeof(EntityModel.DataModel.eProduct);
            // 
            // grvProduct_List
            // 
            this.grvProduct_List.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colKeyID,
            this.colCode,
            this.colName,
            this.colPrice,
            this.colPriceCustomer,
            this.colIsEnable,
            this.colStatus,
            this.colIsSend,
            this.colCreatedBy,
            this.colCreatedDate,
            this.colModifiedBy,
            this.colModifiedDate,
            this.colNote,
            this.colIDAgency,
            this.coleDryDetails,
            this.coleMillDetails,
            this.coleOrderDetails,
            this.coleSeparateColorDetails,
            this.coleWarehouseFinishedProducts,
            this.coleWarehouseIns,
            this.coleWarehouseMills,
            this.coleWarehouseOuts,
            this.coleBillOrderDries});
            this.grvProduct_List.GridControl = this.gctProduct_List;
            this.grvProduct_List.Name = "grvProduct_List";
            this.grvProduct_List.DoubleClick += new System.EventHandler(this.grvProduct_List_DoubleClick);
            // 
            // colKeyID
            // 
            this.colKeyID.FieldName = "KeyID";
            this.colKeyID.Name = "colKeyID";
            // 
            // colCode
            // 
            this.colCode.Caption = "Mã SP";
            this.colCode.FieldName = "Code";
            this.colCode.Name = "colCode";
            this.colCode.OptionsColumn.AllowEdit = false;
            this.colCode.Visible = true;
            this.colCode.VisibleIndex = 0;
            // 
            // colName
            // 
            this.colName.Caption = "Tên SP";
            this.colName.FieldName = "Name";
            this.colName.Name = "colName";
            this.colName.OptionsColumn.AllowEdit = false;
            this.colName.Visible = true;
            this.colName.VisibleIndex = 1;
            // 
            // colPrice
            // 
            this.colPrice.Caption = "Giá sấy";
            this.colPrice.ColumnEdit = this.rsptNumber;
            this.colPrice.FieldName = "Price";
            this.colPrice.Name = "colPrice";
            this.colPrice.OptionsColumn.AllowEdit = false;
            this.colPrice.Visible = true;
            this.colPrice.VisibleIndex = 2;
            // 
            // rsptNumber
            // 
            this.rsptNumber.AutoHeight = false;
            this.rsptNumber.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rsptNumber.Name = "rsptNumber";
            // 
            // colPriceCustomer
            // 
            this.colPriceCustomer.Caption = "Giá SP";
            this.colPriceCustomer.ColumnEdit = this.rsptNumber;
            this.colPriceCustomer.FieldName = "PriceCustomer";
            this.colPriceCustomer.Name = "colPriceCustomer";
            this.colPriceCustomer.OptionsColumn.AllowEdit = false;
            this.colPriceCustomer.Visible = true;
            this.colPriceCustomer.VisibleIndex = 3;
            // 
            // colIsEnable
            // 
            this.colIsEnable.FieldName = "IsEnable";
            this.colIsEnable.Name = "colIsEnable";
            // 
            // colStatus
            // 
            this.colStatus.FieldName = "Status";
            this.colStatus.Name = "colStatus";
            // 
            // colIsSend
            // 
            this.colIsSend.FieldName = "IsSend";
            this.colIsSend.Name = "colIsSend";
            // 
            // colCreatedBy
            // 
            this.colCreatedBy.FieldName = "CreatedBy";
            this.colCreatedBy.Name = "colCreatedBy";
            // 
            // colCreatedDate
            // 
            this.colCreatedDate.Caption = "Ngày tạo";
            this.colCreatedDate.ColumnEdit = this.rdeDate;
            this.colCreatedDate.FieldName = "CreatedDate";
            this.colCreatedDate.Name = "colCreatedDate";
            this.colCreatedDate.OptionsColumn.AllowEdit = false;
            this.colCreatedDate.Visible = true;
            this.colCreatedDate.VisibleIndex = 4;
            // 
            // rdeDate
            // 
            this.rdeDate.AutoHeight = false;
            this.rdeDate.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rdeDate.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rdeDate.Mask.EditMask = "dd/MM/yyyy";
            this.rdeDate.Name = "rdeDate";
            // 
            // colModifiedBy
            // 
            this.colModifiedBy.FieldName = "ModifiedBy";
            this.colModifiedBy.Name = "colModifiedBy";
            // 
            // colModifiedDate
            // 
            this.colModifiedDate.Caption = "Ngày cập nhật";
            this.colModifiedDate.ColumnEdit = this.rdeDate;
            this.colModifiedDate.FieldName = "ModifiedDate";
            this.colModifiedDate.Name = "colModifiedDate";
            this.colModifiedDate.OptionsColumn.AllowEdit = false;
            this.colModifiedDate.Visible = true;
            this.colModifiedDate.VisibleIndex = 5;
            // 
            // colNote
            // 
            this.colNote.Caption = "Ghi chú";
            this.colNote.FieldName = "Note";
            this.colNote.Name = "colNote";
            this.colNote.OptionsColumn.AllowEdit = false;
            this.colNote.Visible = true;
            this.colNote.VisibleIndex = 6;
            // 
            // colIDAgency
            // 
            this.colIDAgency.FieldName = "IDAgency";
            this.colIDAgency.Name = "colIDAgency";
            // 
            // coleDryDetails
            // 
            this.coleDryDetails.FieldName = "eDryDetails";
            this.coleDryDetails.Name = "coleDryDetails";
            // 
            // coleMillDetails
            // 
            this.coleMillDetails.FieldName = "eMillDetails";
            this.coleMillDetails.Name = "coleMillDetails";
            // 
            // coleOrderDetails
            // 
            this.coleOrderDetails.FieldName = "eOrderDetails";
            this.coleOrderDetails.Name = "coleOrderDetails";
            // 
            // coleSeparateColorDetails
            // 
            this.coleSeparateColorDetails.FieldName = "eSeparateColorDetails";
            this.coleSeparateColorDetails.Name = "coleSeparateColorDetails";
            // 
            // coleWarehouseFinishedProducts
            // 
            this.coleWarehouseFinishedProducts.FieldName = "eWarehouseFinishedProducts";
            this.coleWarehouseFinishedProducts.Name = "coleWarehouseFinishedProducts";
            // 
            // coleWarehouseIns
            // 
            this.coleWarehouseIns.FieldName = "eWarehouseIns";
            this.coleWarehouseIns.Name = "coleWarehouseIns";
            // 
            // coleWarehouseMills
            // 
            this.coleWarehouseMills.FieldName = "eWarehouseMills";
            this.coleWarehouseMills.Name = "coleWarehouseMills";
            // 
            // coleWarehouseOuts
            // 
            this.coleWarehouseOuts.FieldName = "eWarehouseOuts";
            this.coleWarehouseOuts.Name = "coleWarehouseOuts";
            // 
            // coleBillOrderDries
            // 
            this.coleBillOrderDries.FieldName = "eBillOrderDries";
            this.coleBillOrderDries.Name = "coleBillOrderDries";
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.layoutControlItem2,
            this.emptySpaceItem1});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "Root";
            this.layoutControlGroup1.Size = new System.Drawing.Size(784, 316);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.gctProduct_List;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(764, 254);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.btnSend;
            this.layoutControlItem2.Location = new System.Drawing.Point(663, 254);
            this.layoutControlItem2.MaxSize = new System.Drawing.Size(101, 42);
            this.layoutControlItem2.MinSize = new System.Drawing.Size(101, 42);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(101, 42);
            this.layoutControlItem2.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem2.TextVisible = false;
            this.layoutControlItem2.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.Location = new System.Drawing.Point(0, 254);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(663, 42);
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // frmProduct_List
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 361);
            this.Controls.Add(this.layoutControl1);
            this.Name = "frmProduct_List";
            this.Text = "Danh sách sản phẩm";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmProduct_List_FormClosing);
            this.Load += new System.EventHandler(this.frmProduct_List_Load);
            this.Controls.SetChildIndex(this.layoutControl1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.popGridMenu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gctProduct_List)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvProduct_List)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rsptNumber)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rdeDate.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rdeDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraGrid.GridControl gctProduct_List;
        private DevExpress.XtraGrid.Views.Grid.GridView grvProduct_List;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private System.Windows.Forms.BindingSource bindingSource1;
        private DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit rsptNumber;
        private DevExpress.XtraEditors.Repository.RepositoryItemDateEdit rdeDate;
        private DevExpress.XtraGrid.Columns.GridColumn colKeyID;
        private DevExpress.XtraGrid.Columns.GridColumn colCode;
        private DevExpress.XtraGrid.Columns.GridColumn colName;
        private DevExpress.XtraGrid.Columns.GridColumn colPrice;
        private DevExpress.XtraGrid.Columns.GridColumn colPriceCustomer;
        private DevExpress.XtraGrid.Columns.GridColumn colIsEnable;
        private DevExpress.XtraGrid.Columns.GridColumn colStatus;
        private DevExpress.XtraGrid.Columns.GridColumn colIsSend;
        private DevExpress.XtraGrid.Columns.GridColumn colCreatedBy;
        private DevExpress.XtraGrid.Columns.GridColumn colCreatedDate;
        private DevExpress.XtraGrid.Columns.GridColumn colModifiedBy;
        private DevExpress.XtraGrid.Columns.GridColumn colModifiedDate;
        private DevExpress.XtraGrid.Columns.GridColumn colNote;
        private DevExpress.XtraGrid.Columns.GridColumn colIDAgency;
        private DevExpress.XtraGrid.Columns.GridColumn coleDryDetails;
        private DevExpress.XtraGrid.Columns.GridColumn coleMillDetails;
        private DevExpress.XtraGrid.Columns.GridColumn coleOrderDetails;
        private DevExpress.XtraGrid.Columns.GridColumn coleSeparateColorDetails;
        private DevExpress.XtraGrid.Columns.GridColumn coleWarehouseFinishedProducts;
        private DevExpress.XtraGrid.Columns.GridColumn coleWarehouseIns;
        private DevExpress.XtraGrid.Columns.GridColumn coleWarehouseMills;
        private DevExpress.XtraGrid.Columns.GridColumn coleWarehouseOuts;
        private DevExpress.XtraGrid.Columns.GridColumn coleBillOrderDries;
        private DevExpress.XtraEditors.SimpleButton btnSend;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
    }
}