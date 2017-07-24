namespace ChuongTrinhCan.GUI.CATE
{
    partial class frmCustomer
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
            this.lcMain = new DevExpress.XtraLayout.LayoutControl();
            this.mmoNote = new DevExpress.XtraEditors.MemoEdit();
            this.txtContact = new DevExpress.XtraEditors.TextEdit();
            this.txtAddress = new DevExpress.XtraEditors.TextEdit();
            this.txtName = new DevExpress.XtraEditors.TextEdit();
            this.txtCode = new DevExpress.XtraEditors.TextEdit();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.lciCode = new DevExpress.XtraLayout.LayoutControlItem();
            this.lciName = new DevExpress.XtraLayout.LayoutControlItem();
            this.lciAddress = new DevExpress.XtraLayout.LayoutControlItem();
            this.lciContact = new DevExpress.XtraLayout.LayoutControlItem();
            this.lciNote = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.popGridMenu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcMain)).BeginInit();
            this.lcMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mmoNote.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtContact.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAddress.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciAddress)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciContact)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciNote)).BeginInit();
            this.SuspendLayout();
            // 
            // lcMain
            // 
            this.lcMain.Controls.Add(this.mmoNote);
            this.lcMain.Controls.Add(this.txtContact);
            this.lcMain.Controls.Add(this.txtAddress);
            this.lcMain.Controls.Add(this.txtName);
            this.lcMain.Controls.Add(this.txtCode);
            this.lcMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lcMain.Location = new System.Drawing.Point(0, 24);
            this.lcMain.Name = "lcMain";
            this.lcMain.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(389, 63, 250, 350);
            this.lcMain.Root = this.layoutControlGroup1;
            this.lcMain.Size = new System.Drawing.Size(484, 166);
            this.lcMain.TabIndex = 4;
            this.lcMain.Text = "layoutControl1";
            // 
            // mmoNote
            // 
            this.mmoNote.Location = new System.Drawing.Point(91, 108);
            this.mmoNote.Name = "mmoNote";
            this.mmoNote.Size = new System.Drawing.Size(381, 46);
            this.mmoNote.StyleController = this.lcMain;
            this.mmoNote.TabIndex = 8;
            // 
            // txtContact
            // 
            this.txtContact.Location = new System.Drawing.Point(91, 84);
            this.txtContact.Name = "txtContact";
            this.txtContact.Size = new System.Drawing.Size(381, 20);
            this.txtContact.StyleController = this.lcMain;
            this.txtContact.TabIndex = 7;
            // 
            // txtAddress
            // 
            this.txtAddress.Location = new System.Drawing.Point(91, 60);
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(381, 20);
            this.txtAddress.StyleController = this.lcMain;
            this.txtAddress.TabIndex = 6;
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(91, 36);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(381, 20);
            this.txtName.StyleController = this.lcMain;
            this.txtName.TabIndex = 5;
            // 
            // txtCode
            // 
            this.txtCode.Location = new System.Drawing.Point(91, 12);
            this.txtCode.Name = "txtCode";
            this.txtCode.Size = new System.Drawing.Size(381, 20);
            this.txtCode.StyleController = this.lcMain;
            this.txtCode.TabIndex = 4;
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.lciCode,
            this.lciName,
            this.lciAddress,
            this.lciContact,
            this.lciNote});
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
            this.lciCode.Text = "Mã khách hàng";
            this.lciCode.TextSize = new System.Drawing.Size(76, 13);
            // 
            // lciName
            // 
            this.lciName.Control = this.txtName;
            this.lciName.Location = new System.Drawing.Point(0, 24);
            this.lciName.Name = "lciName";
            this.lciName.Size = new System.Drawing.Size(464, 24);
            this.lciName.Text = "Tên khách hàng";
            this.lciName.TextSize = new System.Drawing.Size(76, 13);
            // 
            // lciAddress
            // 
            this.lciAddress.Control = this.txtAddress;
            this.lciAddress.Location = new System.Drawing.Point(0, 48);
            this.lciAddress.Name = "lciAddress";
            this.lciAddress.Size = new System.Drawing.Size(464, 24);
            this.lciAddress.Text = "Địa chỉ";
            this.lciAddress.TextSize = new System.Drawing.Size(76, 13);
            // 
            // lciContact
            // 
            this.lciContact.Control = this.txtContact;
            this.lciContact.Location = new System.Drawing.Point(0, 72);
            this.lciContact.Name = "lciContact";
            this.lciContact.Size = new System.Drawing.Size(464, 24);
            this.lciContact.Text = "Liên lạc";
            this.lciContact.TextSize = new System.Drawing.Size(76, 13);
            // 
            // lciNote
            // 
            this.lciNote.Control = this.mmoNote;
            this.lciNote.Location = new System.Drawing.Point(0, 96);
            this.lciNote.Name = "lciNote";
            this.lciNote.Size = new System.Drawing.Size(464, 50);
            this.lciNote.Text = "Ghi chú";
            this.lciNote.TextSize = new System.Drawing.Size(76, 13);
            // 
            // frmCustomer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 211);
            this.Controls.Add(this.lcMain);
            this.MaximizeBox = false;
            this.Name = "frmCustomer";
            this.Text = "frmCustomer";
            this.Load += new System.EventHandler(this.frmCustomer_Load);
            this.Controls.SetChildIndex(this.lcMain, 0);
            ((System.ComponentModel.ISupportInitialize)(this.popGridMenu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcMain)).EndInit();
            this.lcMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.mmoNote.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtContact.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAddress.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciAddress)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciContact)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciNote)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl lcMain;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraEditors.MemoEdit mmoNote;
        private DevExpress.XtraEditors.TextEdit txtContact;
        private DevExpress.XtraEditors.TextEdit txtAddress;
        private DevExpress.XtraEditors.TextEdit txtName;
        private DevExpress.XtraEditors.TextEdit txtCode;
        private DevExpress.XtraLayout.LayoutControlItem lciCode;
        private DevExpress.XtraLayout.LayoutControlItem lciName;
        private DevExpress.XtraLayout.LayoutControlItem lciAddress;
        private DevExpress.XtraLayout.LayoutControlItem lciContact;
        private DevExpress.XtraLayout.LayoutControlItem lciNote;
    }
}