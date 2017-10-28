namespace ChuongTrinhCan.GUI.CATE
{
    partial class frmWarehouse
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmWarehouse));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.gctWarehouse = new DevExpress.XtraGrid.GridControl();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.grvWarehouse = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colKeyID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCreatedDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colModifiedDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNote = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colIsEnable = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colIDAgency = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDelete = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rbtnDelete = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.dockManager1 = new DevExpress.XtraBars.Docking.DockManager(this.components);
            this.dockPanel1 = new DevExpress.XtraBars.Docking.DockPanel();
            this.dockPanel1_Container = new DevExpress.XtraBars.Docking.ControlContainer();
            this.layoutControl2 = new DevExpress.XtraLayout.LayoutControl();
            this.btn_Cancel = new DevExpress.XtraEditors.SimpleButton();
            this.mmeNote = new DevExpress.XtraEditors.MemoEdit();
            this.btn_Save = new DevExpress.XtraEditors.SimpleButton();
            this.txtName = new DevExpress.XtraEditors.TextEdit();
            this.txtCode = new DevExpress.XtraEditors.TextEdit();
            this.layoutControlGroup2 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.emptySpaceItem2 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem6 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.popGridMenu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gctWarehouse)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvWarehouse)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rbtnDelete)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dockManager1)).BeginInit();
            this.dockPanel1.SuspendLayout();
            this.dockPanel1_Container.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl2)).BeginInit();
            this.layoutControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mmeNote.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.gctWarehouse);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(300, 24);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(484, 316);
            this.layoutControl1.TabIndex = 4;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // gctWarehouse
            // 
            this.gctWarehouse.DataSource = this.bindingSource1;
            this.gctWarehouse.Location = new System.Drawing.Point(12, 12);
            this.gctWarehouse.MainView = this.grvWarehouse;
            this.gctWarehouse.Name = "gctWarehouse";
            this.gctWarehouse.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.rbtnDelete});
            this.gctWarehouse.Size = new System.Drawing.Size(460, 292);
            this.gctWarehouse.TabIndex = 4;
            this.gctWarehouse.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvWarehouse});
            // 
            // bindingSource1
            // 
            this.bindingSource1.DataSource = typeof(EntityModel.DataModel.eWarehouse);
            // 
            // grvWarehouse
            // 
            this.grvWarehouse.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colKeyID,
            this.colCode,
            this.colName,
            this.colCreatedDate,
            this.colModifiedDate,
            this.colNote,
            this.colIsEnable,
            this.colIDAgency,
            this.colDelete});
            this.grvWarehouse.GridControl = this.gctWarehouse;
            this.grvWarehouse.Name = "grvWarehouse";
            this.grvWarehouse.DoubleClick += new System.EventHandler(this.grvWarehouse_DoubleClick);
            // 
            // colKeyID
            // 
            this.colKeyID.FieldName = "KeyID";
            this.colKeyID.Name = "colKeyID";
            // 
            // colCode
            // 
            this.colCode.Caption = "Mã";
            this.colCode.FieldName = "Code";
            this.colCode.Name = "colCode";
            this.colCode.OptionsColumn.AllowEdit = false;
            this.colCode.Visible = true;
            this.colCode.VisibleIndex = 0;
            this.colCode.Width = 83;
            // 
            // colName
            // 
            this.colName.Caption = "Tên";
            this.colName.FieldName = "Name";
            this.colName.Name = "colName";
            this.colName.OptionsColumn.AllowEdit = false;
            this.colName.Visible = true;
            this.colName.VisibleIndex = 1;
            this.colName.Width = 83;
            // 
            // colCreatedDate
            // 
            this.colCreatedDate.Caption = "Ngày tạo";
            this.colCreatedDate.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.colCreatedDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.colCreatedDate.FieldName = "CreatedDate";
            this.colCreatedDate.Name = "colCreatedDate";
            this.colCreatedDate.OptionsColumn.AllowEdit = false;
            this.colCreatedDate.Visible = true;
            this.colCreatedDate.VisibleIndex = 2;
            this.colCreatedDate.Width = 102;
            // 
            // colModifiedDate
            // 
            this.colModifiedDate.Caption = "Ngày cập nhật";
            this.colModifiedDate.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.colModifiedDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.colModifiedDate.FieldName = "ModifiedDate";
            this.colModifiedDate.Name = "colModifiedDate";
            this.colModifiedDate.OptionsColumn.AllowEdit = false;
            this.colModifiedDate.Visible = true;
            this.colModifiedDate.VisibleIndex = 3;
            this.colModifiedDate.Width = 99;
            // 
            // colNote
            // 
            this.colNote.Caption = "Ghi chú";
            this.colNote.FieldName = "Note";
            this.colNote.Name = "colNote";
            this.colNote.OptionsColumn.AllowEdit = false;
            this.colNote.Visible = true;
            this.colNote.VisibleIndex = 4;
            this.colNote.Width = 95;
            // 
            // colIsEnable
            // 
            this.colIsEnable.FieldName = "IsEnable";
            this.colIsEnable.Name = "colIsEnable";
            // 
            // colIDAgency
            // 
            this.colIDAgency.FieldName = "IDAgency";
            this.colIDAgency.Name = "colIDAgency";
            // 
            // colDelete
            // 
            this.colDelete.ColumnEdit = this.rbtnDelete;
            this.colDelete.MaxWidth = 30;
            this.colDelete.MinWidth = 30;
            this.colDelete.Name = "colDelete";
            this.colDelete.Visible = true;
            this.colDelete.VisibleIndex = 5;
            this.colDelete.Width = 30;
            // 
            // rbtnDelete
            // 
            this.rbtnDelete.AutoHeight = false;
            this.rbtnDelete.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleCenter, ((System.Drawing.Image)(resources.GetObject("rbtnDelete.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, "", null, null, true)});
            this.rbtnDelete.Name = "rbtnDelete";
            this.rbtnDelete.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
            this.rbtnDelete.Click += new System.EventHandler(this.rbtnDelete_Click);
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem4});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Size = new System.Drawing.Size(484, 316);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.gctWarehouse;
            this.layoutControlItem4.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(464, 296);
            this.layoutControlItem4.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem4.TextVisible = false;
            // 
            // dockManager1
            // 
            this.dockManager1.Form = this;
            this.dockManager1.RootPanels.AddRange(new DevExpress.XtraBars.Docking.DockPanel[] {
            this.dockPanel1});
            this.dockManager1.TopZIndexControls.AddRange(new string[] {
            "DevExpress.XtraBars.BarDockControl",
            "DevExpress.XtraBars.StandaloneBarDockControl",
            "System.Windows.Forms.StatusBar",
            "System.Windows.Forms.MenuStrip",
            "System.Windows.Forms.StatusStrip",
            "DevExpress.XtraBars.Ribbon.RibbonStatusBar",
            "DevExpress.XtraBars.Ribbon.RibbonControl",
            "DevExpress.XtraBars.Navigation.OfficeNavigationBar",
            "DevExpress.XtraBars.Navigation.TileNavPane"});
            // 
            // dockPanel1
            // 
            this.dockPanel1.Controls.Add(this.dockPanel1_Container);
            this.dockPanel1.Dock = DevExpress.XtraBars.Docking.DockingStyle.Left;
            this.dockPanel1.ID = new System.Guid("eb24f708-0b30-4bac-987e-35780b0c6b78");
            this.dockPanel1.Location = new System.Drawing.Point(0, 24);
            this.dockPanel1.Name = "dockPanel1";
            this.dockPanel1.Options.AllowDockAsTabbedDocument = false;
            this.dockPanel1.Options.AllowDockBottom = false;
            this.dockPanel1.Options.AllowDockFill = false;
            this.dockPanel1.Options.AllowDockRight = false;
            this.dockPanel1.Options.AllowDockTop = false;
            this.dockPanel1.Options.AllowFloating = false;
            this.dockPanel1.Options.FloatOnDblClick = false;
            this.dockPanel1.Options.ResizeDirection = DevExpress.XtraBars.Docking.Helpers.ResizeDirection.None;
            this.dockPanel1.Options.ShowAutoHideButton = false;
            this.dockPanel1.Options.ShowCloseButton = false;
            this.dockPanel1.Options.ShowMaximizeButton = false;
            this.dockPanel1.OriginalSize = new System.Drawing.Size(300, 200);
            this.dockPanel1.Size = new System.Drawing.Size(300, 316);
            this.dockPanel1.Text = "Thông tin kho";
            // 
            // dockPanel1_Container
            // 
            this.dockPanel1_Container.Controls.Add(this.layoutControl2);
            this.dockPanel1_Container.Location = new System.Drawing.Point(4, 23);
            this.dockPanel1_Container.Name = "dockPanel1_Container";
            this.dockPanel1_Container.Size = new System.Drawing.Size(292, 289);
            this.dockPanel1_Container.TabIndex = 0;
            // 
            // layoutControl2
            // 
            this.layoutControl2.Controls.Add(this.btn_Cancel);
            this.layoutControl2.Controls.Add(this.mmeNote);
            this.layoutControl2.Controls.Add(this.btn_Save);
            this.layoutControl2.Controls.Add(this.txtName);
            this.layoutControl2.Controls.Add(this.txtCode);
            this.layoutControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl2.Location = new System.Drawing.Point(0, 0);
            this.layoutControl2.Name = "layoutControl2";
            this.layoutControl2.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(301, 138, 250, 350);
            this.layoutControl2.Root = this.layoutControlGroup2;
            this.layoutControl2.Size = new System.Drawing.Size(292, 289);
            this.layoutControl2.TabIndex = 0;
            this.layoutControl2.Text = "layoutControl2";
            // 
            // btn_Cancel
            // 
            this.btn_Cancel.Image = ((System.Drawing.Image)(resources.GetObject("btn_Cancel.Image")));
            this.btn_Cancel.Location = new System.Drawing.Point(114, 122);
            this.btn_Cancel.Name = "btn_Cancel";
            this.btn_Cancel.Size = new System.Drawing.Size(81, 38);
            this.btn_Cancel.StyleController = this.layoutControl2;
            this.btn_Cancel.TabIndex = 8;
            this.btn_Cancel.Text = "Hủy";
            this.btn_Cancel.Click += new System.EventHandler(this.btn_Cancel_Click);
            // 
            // mmeNote
            // 
            this.mmeNote.Location = new System.Drawing.Point(50, 60);
            this.mmeNote.Name = "mmeNote";
            this.mmeNote.Properties.MaxLength = 255;
            this.mmeNote.Size = new System.Drawing.Size(230, 58);
            this.mmeNote.StyleController = this.layoutControl2;
            this.mmeNote.TabIndex = 7;
            // 
            // btn_Save
            // 
            this.btn_Save.Image = ((System.Drawing.Image)(resources.GetObject("btn_Save.Image")));
            this.btn_Save.Location = new System.Drawing.Point(199, 122);
            this.btn_Save.Name = "btn_Save";
            this.btn_Save.Size = new System.Drawing.Size(81, 38);
            this.btn_Save.StyleController = this.layoutControl2;
            this.btn_Save.TabIndex = 6;
            this.btn_Save.Text = "Lưu";
            this.btn_Save.Click += new System.EventHandler(this.btn_Save_Click);
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(50, 36);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(230, 20);
            this.txtName.StyleController = this.layoutControl2;
            this.txtName.TabIndex = 5;
            // 
            // txtCode
            // 
            this.txtCode.Location = new System.Drawing.Point(50, 12);
            this.txtCode.Name = "txtCode";
            this.txtCode.Size = new System.Drawing.Size(230, 20);
            this.txtCode.StyleController = this.layoutControl2;
            this.txtCode.TabIndex = 4;
            // 
            // layoutControlGroup2
            // 
            this.layoutControlGroup2.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup2.GroupBordersVisible = false;
            this.layoutControlGroup2.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.layoutControlItem2,
            this.layoutControlItem3,
            this.emptySpaceItem1,
            this.emptySpaceItem2,
            this.layoutControlItem5,
            this.layoutControlItem6});
            this.layoutControlGroup2.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup2.Name = "Root";
            this.layoutControlGroup2.Size = new System.Drawing.Size(292, 289);
            this.layoutControlGroup2.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.txtCode;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(272, 24);
            this.layoutControlItem1.Text = "Mã";
            this.layoutControlItem1.TextSize = new System.Drawing.Size(35, 13);
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.txtName;
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 24);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(272, 24);
            this.layoutControlItem2.Text = "Tên";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(35, 13);
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.btn_Save;
            this.layoutControlItem3.Location = new System.Drawing.Point(187, 110);
            this.layoutControlItem3.MaxSize = new System.Drawing.Size(85, 42);
            this.layoutControlItem3.MinSize = new System.Drawing.Size(85, 42);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(85, 42);
            this.layoutControlItem3.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem3.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem3.TextVisible = false;
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.Location = new System.Drawing.Point(0, 110);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(102, 42);
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // emptySpaceItem2
            // 
            this.emptySpaceItem2.AllowHotTrack = false;
            this.emptySpaceItem2.Location = new System.Drawing.Point(0, 152);
            this.emptySpaceItem2.Name = "emptySpaceItem2";
            this.emptySpaceItem2.Size = new System.Drawing.Size(272, 117);
            this.emptySpaceItem2.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlItem5
            // 
            this.layoutControlItem5.Control = this.mmeNote;
            this.layoutControlItem5.Location = new System.Drawing.Point(0, 48);
            this.layoutControlItem5.MaxSize = new System.Drawing.Size(0, 62);
            this.layoutControlItem5.MinSize = new System.Drawing.Size(52, 62);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.Size = new System.Drawing.Size(272, 62);
            this.layoutControlItem5.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem5.Text = "Ghi chú";
            this.layoutControlItem5.TextSize = new System.Drawing.Size(35, 13);
            // 
            // layoutControlItem6
            // 
            this.layoutControlItem6.Control = this.btn_Cancel;
            this.layoutControlItem6.Location = new System.Drawing.Point(102, 110);
            this.layoutControlItem6.MaxSize = new System.Drawing.Size(85, 42);
            this.layoutControlItem6.MinSize = new System.Drawing.Size(85, 42);
            this.layoutControlItem6.Name = "layoutControlItem6";
            this.layoutControlItem6.Size = new System.Drawing.Size(85, 42);
            this.layoutControlItem6.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem6.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem6.TextVisible = false;
            // 
            // frmWarehouse
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 361);
            this.Controls.Add(this.layoutControl1);
            this.Controls.Add(this.dockPanel1);
            this.Name = "frmWarehouse";
            this.Text = "frmWarehouse";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmWarehouse_FormClosing);
            this.Load += new System.EventHandler(this.frmWarehouse_Load);
            this.Controls.SetChildIndex(this.dockPanel1, 0);
            this.Controls.SetChildIndex(this.layoutControl1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.popGridMenu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gctWarehouse)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvWarehouse)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rbtnDelete)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dockManager1)).EndInit();
            this.dockPanel1.ResumeLayout(false);
            this.dockPanel1_Container.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl2)).EndInit();
            this.layoutControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.mmeNote.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraBars.Docking.DockManager dockManager1;
        private DevExpress.XtraBars.Docking.DockPanel dockPanel1;
        private DevExpress.XtraBars.Docking.ControlContainer dockPanel1_Container;
        private DevExpress.XtraLayout.LayoutControl layoutControl2;
        private DevExpress.XtraEditors.SimpleButton btn_Save;
        private DevExpress.XtraEditors.TextEdit txtName;
        private DevExpress.XtraEditors.TextEdit txtCode;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem2;
        private DevExpress.XtraGrid.GridControl gctWarehouse;
        private DevExpress.XtraGrid.Views.Grid.GridView grvWarehouse;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private System.Windows.Forms.BindingSource bindingSource1;
        private DevExpress.XtraGrid.Columns.GridColumn colKeyID;
        private DevExpress.XtraGrid.Columns.GridColumn colCode;
        private DevExpress.XtraGrid.Columns.GridColumn colName;
        private DevExpress.XtraGrid.Columns.GridColumn colCreatedDate;
        private DevExpress.XtraGrid.Columns.GridColumn colModifiedDate;
        private DevExpress.XtraGrid.Columns.GridColumn colNote;
        private DevExpress.XtraGrid.Columns.GridColumn colIsEnable;
        private DevExpress.XtraGrid.Columns.GridColumn colIDAgency;
        private DevExpress.XtraEditors.MemoEdit mmeNote;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
        private DevExpress.XtraGrid.Columns.GridColumn colDelete;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit rbtnDelete;
        private DevExpress.XtraEditors.SimpleButton btn_Cancel;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem6;
    }
}