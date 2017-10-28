namespace ChuongTrinhCan.GUI.CATE
{
    partial class frmProduct
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
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.sptPriceCus = new DevExpress.XtraEditors.SpinEdit();
            this.mmoNote = new DevExpress.XtraEditors.MemoEdit();
            this.spnPrice = new DevExpress.XtraEditors.SpinEdit();
            this.txtName = new DevExpress.XtraEditors.TextEdit();
            this.txtCode = new DevExpress.XtraEditors.TextEdit();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.lciCode = new DevExpress.XtraLayout.LayoutControlItem();
            this.lciName = new DevExpress.XtraLayout.LayoutControlItem();
            this.lciPrice = new DevExpress.XtraLayout.LayoutControlItem();
            this.lciNote = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.popGridMenu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sptPriceCus.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mmoNote.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spnPrice.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciPrice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciNote)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.sptPriceCus);
            this.layoutControl1.Controls.Add(this.mmoNote);
            this.layoutControl1.Controls.Add(this.spnPrice);
            this.layoutControl1.Controls.Add(this.txtName);
            this.layoutControl1.Controls.Add(this.txtCode);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 24);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(389, 63, 250, 350);
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(484, 166);
            this.layoutControl1.TabIndex = 4;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // sptPriceCus
            // 
            this.sptPriceCus.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.sptPriceCus.Location = new System.Drawing.Point(314, 60);
            this.sptPriceCus.Name = "sptPriceCus";
            this.sptPriceCus.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.sptPriceCus.Size = new System.Drawing.Size(158, 20);
            this.sptPriceCus.StyleController = this.layoutControl1;
            this.sptPriceCus.TabIndex = 9;
            // 
            // mmoNote
            // 
            this.mmoNote.Location = new System.Drawing.Point(82, 84);
            this.mmoNote.Name = "mmoNote";
            this.mmoNote.Size = new System.Drawing.Size(390, 70);
            this.mmoNote.StyleController = this.layoutControl1;
            this.mmoNote.TabIndex = 7;
            // 
            // spnPrice
            // 
            this.spnPrice.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.spnPrice.Location = new System.Drawing.Point(82, 60);
            this.spnPrice.Name = "spnPrice";
            this.spnPrice.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.spnPrice.Size = new System.Drawing.Size(158, 20);
            this.spnPrice.StyleController = this.layoutControl1;
            this.spnPrice.TabIndex = 6;
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(82, 36);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(390, 20);
            this.txtName.StyleController = this.layoutControl1;
            this.txtName.TabIndex = 5;
            // 
            // txtCode
            // 
            this.txtCode.Location = new System.Drawing.Point(82, 12);
            this.txtCode.Name = "txtCode";
            this.txtCode.Size = new System.Drawing.Size(390, 20);
            this.txtCode.StyleController = this.layoutControl1;
            this.txtCode.TabIndex = 4;
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.lciCode,
            this.lciName,
            this.lciPrice,
            this.lciNote,
            this.layoutControlItem1});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "Root";
            this.layoutControlGroup1.Size = new System.Drawing.Size(484, 166);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // lciCode
            // 
            this.lciCode.Control = this.txtCode;
            this.lciCode.Location = new System.Drawing.Point(0, 0);
            this.lciCode.Name = "lciCode";
            this.lciCode.Size = new System.Drawing.Size(464, 24);
            this.lciCode.Text = "Mã sản phẩm";
            this.lciCode.TextSize = new System.Drawing.Size(67, 13);
            // 
            // lciName
            // 
            this.lciName.Control = this.txtName;
            this.lciName.Location = new System.Drawing.Point(0, 24);
            this.lciName.Name = "lciName";
            this.lciName.Size = new System.Drawing.Size(464, 24);
            this.lciName.Text = "Tên sản phẩm";
            this.lciName.TextSize = new System.Drawing.Size(67, 13);
            // 
            // lciPrice
            // 
            this.lciPrice.Control = this.spnPrice;
            this.lciPrice.Location = new System.Drawing.Point(0, 48);
            this.lciPrice.Name = "lciPrice";
            this.lciPrice.Size = new System.Drawing.Size(232, 24);
            this.lciPrice.Text = "Giá sấy";
            this.lciPrice.TextSize = new System.Drawing.Size(67, 13);
            // 
            // lciNote
            // 
            this.lciNote.Control = this.mmoNote;
            this.lciNote.Location = new System.Drawing.Point(0, 72);
            this.lciNote.Name = "lciNote";
            this.lciNote.Size = new System.Drawing.Size(464, 74);
            this.lciNote.Text = "Ghi chú";
            this.lciNote.TextSize = new System.Drawing.Size(67, 13);
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.sptPriceCus;
            this.layoutControlItem1.Location = new System.Drawing.Point(232, 48);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(232, 24);
            this.layoutControlItem1.Text = "Giá KH";
            this.layoutControlItem1.TextSize = new System.Drawing.Size(67, 13);
            // 
            // frmProduct
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 211);
            this.Controls.Add(this.layoutControl1);
            this.MaximizeBox = false;
            this.Name = "frmProduct";
            this.Text = "frmProduct";
            this.Load += new System.EventHandler(this.frmProduct_Load);
            this.Controls.SetChildIndex(this.layoutControl1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.popGridMenu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.sptPriceCus.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mmoNote.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spnPrice.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciPrice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciNote)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraEditors.MemoEdit mmoNote;
        private DevExpress.XtraEditors.SpinEdit spnPrice;
        private DevExpress.XtraEditors.TextEdit txtName;
        private DevExpress.XtraEditors.TextEdit txtCode;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.LayoutControlItem lciCode;
        private DevExpress.XtraLayout.LayoutControlItem lciName;
        private DevExpress.XtraLayout.LayoutControlItem lciPrice;
        private DevExpress.XtraLayout.LayoutControlItem lciNote;
        private DevExpress.XtraEditors.SpinEdit sptPriceCus;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
    }
}