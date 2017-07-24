namespace ChuongTrinhCan.GUI.CATE
{
    partial class frmVehicleEmpty
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmVehicleEmpty));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.txtNumber = new DevExpress.XtraEditors.TextEdit();
            this.btn_Save = new DevExpress.XtraEditors.SimpleButton();
            this.gctVehicle = new DevExpress.XtraGrid.GridControl();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.grvVehicle = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colKeyID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colVehicleNumber = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colEmptyWeight = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rsptNumber = new DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit();
            this.colIsEnable = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCreatedBy = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCreatedDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rdeDate = new DevExpress.XtraEditors.Repository.RepositoryItemDateEdit();
            this.colModifiedBy = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colModifiedDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNote = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colIDAgency = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rbtnDelete = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.sptWeight = new DevExpress.XtraEditors.SpinEdit();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem2 = new DevExpress.XtraLayout.EmptySpaceItem();
            ((System.ComponentModel.ISupportInitialize)(this.popGridMenu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtNumber.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gctVehicle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvVehicle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rsptNumber)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rdeDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rdeDate.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rbtnDelete)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sptWeight.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl1
            // 
            this.layoutControl1.Appearance.DisabledLayoutItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(31)))), ((int)(((byte)(53)))));
            this.layoutControl1.Appearance.DisabledLayoutItem.Options.UseForeColor = true;
            this.layoutControl1.Controls.Add(this.txtNumber);
            this.layoutControl1.Controls.Add(this.btn_Save);
            this.layoutControl1.Controls.Add(this.gctVehicle);
            this.layoutControl1.Controls.Add(this.sptWeight);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 24);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(539, 142, 250, 350);
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(784, 316);
            this.layoutControl1.TabIndex = 4;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // txtNumber
            // 
            this.txtNumber.Enabled = false;
            this.txtNumber.Location = new System.Drawing.Point(87, 12);
            this.txtNumber.Name = "txtNumber";
            this.txtNumber.Properties.Appearance.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNumber.Properties.Appearance.Options.UseFont = true;
            this.txtNumber.Properties.AppearanceDisabled.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(31)))), ((int)(((byte)(53)))));
            this.txtNumber.Properties.AppearanceDisabled.Options.UseForeColor = true;
            this.txtNumber.Size = new System.Drawing.Size(171, 24);
            this.txtNumber.StyleController = this.layoutControl1;
            this.txtNumber.TabIndex = 4;
            // 
            // btn_Save
            // 
            this.btn_Save.Appearance.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Save.Appearance.Options.UseFont = true;
            this.btn_Save.Image = ((System.Drawing.Image)(resources.GetObject("btn_Save.Image")));
            this.btn_Save.Location = new System.Drawing.Point(162, 68);
            this.btn_Save.Name = "btn_Save";
            this.btn_Save.Size = new System.Drawing.Size(96, 38);
            this.btn_Save.StyleController = this.layoutControl1;
            this.btn_Save.TabIndex = 7;
            this.btn_Save.Text = "Lưu";
            this.btn_Save.Click += new System.EventHandler(this.btn_Save_Click);
            // 
            // gctVehicle
            // 
            this.gctVehicle.DataSource = this.bindingSource1;
            this.gctVehicle.Location = new System.Drawing.Point(262, 12);
            this.gctVehicle.MainView = this.grvVehicle;
            this.gctVehicle.Name = "gctVehicle";
            this.gctVehicle.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.rsptNumber,
            this.rdeDate,
            this.rbtnDelete});
            this.gctVehicle.Size = new System.Drawing.Size(510, 292);
            this.gctVehicle.TabIndex = 6;
            this.gctVehicle.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvVehicle});
            // 
            // bindingSource1
            // 
            this.bindingSource1.DataSource = typeof(EntityModel.DataModel.eVehicleEmpty);
            // 
            // grvVehicle
            // 
            this.grvVehicle.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colKeyID,
            this.colVehicleNumber,
            this.colEmptyWeight,
            this.colIsEnable,
            this.colCreatedBy,
            this.colCreatedDate,
            this.colModifiedBy,
            this.colModifiedDate,
            this.colNote,
            this.colIDAgency,
            this.gridColumn1});
            this.grvVehicle.GridControl = this.gctVehicle;
            this.grvVehicle.Name = "grvVehicle";
            // 
            // colKeyID
            // 
            this.colKeyID.FieldName = "KeyID";
            this.colKeyID.Name = "colKeyID";
            // 
            // colVehicleNumber
            // 
            this.colVehicleNumber.Caption = "Số xe";
            this.colVehicleNumber.FieldName = "VehicleNumber";
            this.colVehicleNumber.Name = "colVehicleNumber";
            this.colVehicleNumber.OptionsColumn.AllowEdit = false;
            this.colVehicleNumber.Visible = true;
            this.colVehicleNumber.VisibleIndex = 0;
            this.colVehicleNumber.Width = 111;
            // 
            // colEmptyWeight
            // 
            this.colEmptyWeight.Caption = "Khối lượng";
            this.colEmptyWeight.ColumnEdit = this.rsptNumber;
            this.colEmptyWeight.FieldName = "EmptyWeight";
            this.colEmptyWeight.Name = "colEmptyWeight";
            this.colEmptyWeight.OptionsColumn.AllowEdit = false;
            this.colEmptyWeight.Visible = true;
            this.colEmptyWeight.VisibleIndex = 1;
            this.colEmptyWeight.Width = 128;
            // 
            // rsptNumber
            // 
            this.rsptNumber.AutoHeight = false;
            this.rsptNumber.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rsptNumber.Name = "rsptNumber";
            // 
            // colIsEnable
            // 
            this.colIsEnable.FieldName = "IsEnable";
            this.colIsEnable.Name = "colIsEnable";
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
            this.colCreatedDate.VisibleIndex = 2;
            this.colCreatedDate.Width = 116;
            // 
            // rdeDate
            // 
            this.rdeDate.AutoHeight = false;
            this.rdeDate.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rdeDate.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rdeDate.Mask.EditMask = "dd/MM/yyyy hh:mm tt";
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
            this.colModifiedDate.VisibleIndex = 3;
            this.colModifiedDate.Width = 117;
            // 
            // colNote
            // 
            this.colNote.FieldName = "Note";
            this.colNote.Name = "colNote";
            // 
            // colIDAgency
            // 
            this.colIDAgency.FieldName = "IDAgency";
            this.colIDAgency.Name = "colIDAgency";
            // 
            // gridColumn1
            // 
            this.gridColumn1.ColumnEdit = this.rbtnDelete;
            this.gridColumn1.MaxWidth = 20;
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 4;
            this.gridColumn1.Width = 20;
            // 
            // rbtnDelete
            // 
            this.rbtnDelete.AutoHeight = false;
            this.rbtnDelete.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleCenter, ((System.Drawing.Image)(resources.GetObject("rbtnDelete.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, "", null, null, true)});
            this.rbtnDelete.Name = "rbtnDelete";
            this.rbtnDelete.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
            this.rbtnDelete.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.rbtnDelete_ButtonClick);
            // 
            // sptWeight
            // 
            this.sptWeight.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.sptWeight.Enabled = false;
            this.sptWeight.Location = new System.Drawing.Point(87, 40);
            this.sptWeight.Name = "sptWeight";
            this.sptWeight.Properties.Appearance.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sptWeight.Properties.Appearance.Options.UseFont = true;
            this.sptWeight.Properties.AppearanceDisabled.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(31)))), ((int)(((byte)(53)))));
            this.sptWeight.Properties.AppearanceDisabled.Options.UseForeColor = true;
            this.sptWeight.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.sptWeight.Size = new System.Drawing.Size(171, 24);
            this.sptWeight.StyleController = this.layoutControl1;
            this.sptWeight.TabIndex = 5;
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem2,
            this.layoutControlItem4,
            this.emptySpaceItem1,
            this.layoutControlItem1,
            this.layoutControlItem3,
            this.emptySpaceItem2});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "Root";
            this.layoutControlGroup1.Size = new System.Drawing.Size(784, 316);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.AppearanceItemCaption.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.layoutControlItem2.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlItem2.Control = this.sptWeight;
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 28);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(250, 28);
            this.layoutControlItem2.Text = "Khối lượng";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(72, 17);
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.btn_Save;
            this.layoutControlItem4.Location = new System.Drawing.Point(150, 56);
            this.layoutControlItem4.MaxSize = new System.Drawing.Size(100, 42);
            this.layoutControlItem4.MinSize = new System.Drawing.Size(100, 42);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(100, 42);
            this.layoutControlItem4.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem4.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem4.TextVisible = false;
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.Location = new System.Drawing.Point(0, 56);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(150, 42);
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.AppearanceItemCaption.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.layoutControlItem1.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlItem1.Control = this.txtNumber;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(250, 28);
            this.layoutControlItem1.Text = "Số xe";
            this.layoutControlItem1.TextSize = new System.Drawing.Size(72, 17);
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.gctVehicle;
            this.layoutControlItem3.Location = new System.Drawing.Point(250, 0);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(514, 296);
            this.layoutControlItem3.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem3.TextVisible = false;
            // 
            // emptySpaceItem2
            // 
            this.emptySpaceItem2.AllowHotTrack = false;
            this.emptySpaceItem2.Location = new System.Drawing.Point(0, 98);
            this.emptySpaceItem2.MaxSize = new System.Drawing.Size(250, 0);
            this.emptySpaceItem2.MinSize = new System.Drawing.Size(250, 10);
            this.emptySpaceItem2.Name = "emptySpaceItem2";
            this.emptySpaceItem2.Size = new System.Drawing.Size(250, 198);
            this.emptySpaceItem2.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.emptySpaceItem2.TextSize = new System.Drawing.Size(0, 0);
            // 
            // frmVehicleEmpty
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 361);
            this.Controls.Add(this.layoutControl1);
            this.Name = "frmVehicleEmpty";
            this.Text = "frmVehicleEmpty";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmVehicleEmpty_Load);
            this.Controls.SetChildIndex(this.layoutControl1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.popGridMenu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtNumber.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gctVehicle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvVehicle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rsptNumber)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rdeDate.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rdeDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rbtnDelete)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sptWeight.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraGrid.GridControl gctVehicle;
        private DevExpress.XtraGrid.Views.Grid.GridView grvVehicle;
        private DevExpress.XtraEditors.SpinEdit sptWeight;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private System.Windows.Forms.BindingSource bindingSource1;
        private DevExpress.XtraGrid.Columns.GridColumn colKeyID;
        private DevExpress.XtraGrid.Columns.GridColumn colVehicleNumber;
        private DevExpress.XtraGrid.Columns.GridColumn colEmptyWeight;
        private DevExpress.XtraGrid.Columns.GridColumn colIsEnable;
        private DevExpress.XtraGrid.Columns.GridColumn colCreatedBy;
        private DevExpress.XtraGrid.Columns.GridColumn colCreatedDate;
        private DevExpress.XtraGrid.Columns.GridColumn colModifiedBy;
        private DevExpress.XtraGrid.Columns.GridColumn colModifiedDate;
        private DevExpress.XtraGrid.Columns.GridColumn colNote;
        private DevExpress.XtraGrid.Columns.GridColumn colIDAgency;
        private DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit rsptNumber;
        private DevExpress.XtraEditors.SimpleButton btn_Save;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private DevExpress.XtraEditors.TextEdit txtNumber;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraEditors.Repository.RepositoryItemDateEdit rdeDate;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit rbtnDelete;
    }
}