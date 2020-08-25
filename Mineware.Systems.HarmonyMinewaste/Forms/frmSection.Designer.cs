namespace Mineware.Systems.Minewaste
{
    partial class frmSection
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSection));
            this.ribbonControl1 = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.icPlanning16x16 = new DevExpress.Utils.ImageCollection(this.components);
            this.btnSave = new DevExpress.XtraBars.BarButtonItem();
            this.btnCancel = new DevExpress.XtraBars.BarButtonItem();
            this.icPlanning32x32 = new DevExpress.Utils.ImageCollection(this.components);
            this.rpUser = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.rpgActions = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.DailyDSRepBtn = new DevExpress.XtraBars.BarButtonItem();
            this.barEditItem1 = new DevExpress.XtraBars.BarEditItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.Reptolbl = new System.Windows.Forms.Label();
            this.Heirlbl = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.SecNameTxt = new DevExpress.XtraEditors.TextEdit();
            this.PM1lbl = new System.Windows.Forms.Label();
            this.PMlbl = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.Reporttocmd = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.HierLst = new System.Windows.Forms.ListBox();
            this.label9 = new System.Windows.Forms.Label();
            this.SecIDTxt = new DevExpress.XtraEditors.TextEdit();
            this.toastNotificationsManager1 = new DevExpress.XtraBars.ToastNotifications.ToastNotificationsManager(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.icPlanning16x16)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.icPlanning32x32)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SecNameTxt.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SecIDTxt.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.toastNotificationsManager1)).BeginInit();
            this.SuspendLayout();
            // 
            // ribbonControl1
            // 
            this.ribbonControl1.AutoSizeItems = true;
            this.ribbonControl1.ColorScheme = DevExpress.XtraBars.Ribbon.RibbonControlColorScheme.Blue;
            this.ribbonControl1.ExpandCollapseItem.Id = 0;
            this.ribbonControl1.Images = this.icPlanning16x16;
            this.ribbonControl1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbonControl1.ExpandCollapseItem,
            this.btnSave,
            this.btnCancel});
            this.ribbonControl1.LargeImages = this.icPlanning32x32;
            this.ribbonControl1.Location = new System.Drawing.Point(0, 0);
            this.ribbonControl1.MaxItemId = 8;
            this.ribbonControl1.MdiMergeStyle = DevExpress.XtraBars.Ribbon.RibbonMdiMergeStyle.Never;
            this.ribbonControl1.Name = "ribbonControl1";
            this.ribbonControl1.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.rpUser});
            this.ribbonControl1.PopupShowMode = DevExpress.XtraBars.PopupShowMode.Inplace;
            this.ribbonControl1.ShowApplicationButton = DevExpress.Utils.DefaultBoolean.False;
            this.ribbonControl1.ShowCategoryInCaption = false;
            this.ribbonControl1.ShowExpandCollapseButton = DevExpress.Utils.DefaultBoolean.False;
            this.ribbonControl1.ShowPageHeadersMode = DevExpress.XtraBars.Ribbon.ShowPageHeadersMode.Hide;
            this.ribbonControl1.ShowToolbarCustomizeItem = false;
            this.ribbonControl1.Size = new System.Drawing.Size(449, 102);
            this.ribbonControl1.Toolbar.ShowCustomizeItem = false;
            this.ribbonControl1.ToolbarLocation = DevExpress.XtraBars.Ribbon.RibbonQuickAccessToolbarLocation.Hidden;
            this.ribbonControl1.TransparentEditorsMode = DevExpress.Utils.DefaultBoolean.True;
            // 
            // icPlanning16x16
            // 
            this.icPlanning16x16.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("icPlanning16x16.ImageStream")));
            // 
            // btnSave
            // 
            this.btnSave.Caption = "Save";
            this.btnSave.Id = 13;
            this.btnSave.ImageOptions.ImageIndex = 1;
            this.btnSave.ImageOptions.LargeImageIndex = 0;
            this.btnSave.ImageOptions.SvgImage = global::Mineware.Systems.Minewaste.Properties.Resources.SaveBlue;
            this.btnSave.Name = "btnSave";
            this.btnSave.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.btnSave.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnSave_ItemClick);
            // 
            // btnCancel
            // 
            this.btnCancel.Caption = "Close";
            this.btnCancel.Id = 14;
            this.btnCancel.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnCancel.ImageOptions.Image")));
            this.btnCancel.ImageOptions.LargeImageIndex = 2;
            this.btnCancel.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnCancel.ImageOptions.SvgImage")));
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnCancel_ItemClick);
            // 
            // icPlanning32x32
            // 
            this.icPlanning32x32.ImageSize = new System.Drawing.Size(32, 32);
            this.icPlanning32x32.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("icPlanning32x32.ImageStream")));
            this.icPlanning32x32.TransparentColor = System.Drawing.Color.Transparent;
            this.icPlanning32x32.InsertGalleryImage("save_32x32.png", "images/save/save_32x32.png", DevExpress.Images.ImageResourceCache.Default.GetImage("images/save/save_32x32.png"), 0);
            this.icPlanning32x32.Images.SetKeyName(0, "save_32x32.png");
            this.icPlanning32x32.InsertGalleryImage("delete_32x32.png", "images/edit/delete_32x32.png", DevExpress.Images.ImageResourceCache.Default.GetImage("images/edit/delete_32x32.png"), 1);
            this.icPlanning32x32.Images.SetKeyName(1, "delete_32x32.png");
            this.icPlanning32x32.InsertGalleryImage("close_32x32.png", "images/actions/close_32x32.png", DevExpress.Images.ImageResourceCache.Default.GetImage("images/actions/close_32x32.png"), 2);
            this.icPlanning32x32.Images.SetKeyName(2, "close_32x32.png");
            // 
            // rpUser
            // 
            this.rpUser.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.rpgActions});
            this.rpUser.Name = "rpUser";
            this.rpUser.Text = "--";
            // 
            // rpgActions
            // 
            this.rpgActions.ItemLinks.Add(this.btnSave);
            this.rpgActions.ItemLinks.Add(this.btnCancel);
            this.rpgActions.Name = "rpgActions";
            this.rpgActions.Text = "Actions";
            // 
            // DailyDSRepBtn
            // 
            this.DailyDSRepBtn.Caption = "Daily Report D/Shift";
            this.DailyDSRepBtn.Id = 6;
            this.DailyDSRepBtn.ImageOptions.LargeImageIndex = 4;
            this.DailyDSRepBtn.Name = "DailyDSRepBtn";
            this.DailyDSRepBtn.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            // 
            // barEditItem1
            // 
            this.barEditItem1.Caption = "barEditItem1";
            this.barEditItem1.Edit = null;
            this.barEditItem1.Id = 5;
            this.barEditItem1.Name = "barEditItem1";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.Reptolbl);
            this.panel1.Controls.Add(this.Heirlbl);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.SecNameTxt);
            this.panel1.Controls.Add(this.PM1lbl);
            this.panel1.Controls.Add(this.PMlbl);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.Reporttocmd);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.HierLst);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.SecIDTxt);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 102);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(449, 333);
            this.panel1.TabIndex = 3;
            // 
            // Reptolbl
            // 
            this.Reptolbl.AutoSize = true;
            this.Reptolbl.Location = new System.Drawing.Point(326, 67);
            this.Reptolbl.Name = "Reptolbl";
            this.Reptolbl.Size = new System.Drawing.Size(46, 13);
            this.Reptolbl.TabIndex = 81;
            this.Reptolbl.Text = "Reptolbl";
            this.Reptolbl.Visible = false;
            // 
            // Heirlbl
            // 
            this.Heirlbl.AutoSize = true;
            this.Heirlbl.Location = new System.Drawing.Point(326, 54);
            this.Heirlbl.Name = "Heirlbl";
            this.Heirlbl.Size = new System.Drawing.Size(35, 13);
            this.Heirlbl.TabIndex = 80;
            this.Heirlbl.Text = "label4";
            this.Heirlbl.Visible = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.label3.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label3.Location = new System.Drawing.Point(27, 92);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(36, 13);
            this.label3.TabIndex = 79;
            this.label3.Text = "Name";
            // 
            // SecNameTxt
            // 
            this.SecNameTxt.Location = new System.Drawing.Point(150, 89);
            this.SecNameTxt.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.SecNameTxt.Name = "SecNameTxt";
            this.SecNameTxt.Properties.MaxLength = 145;
            this.SecNameTxt.Size = new System.Drawing.Size(247, 20);
            this.SecNameTxt.TabIndex = 78;
            this.SecNameTxt.Tag = "0";
            // 
            // PM1lbl
            // 
            this.PM1lbl.AutoSize = true;
            this.PM1lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PM1lbl.ForeColor = System.Drawing.Color.Blue;
            this.PM1lbl.Location = new System.Drawing.Point(193, 41);
            this.PM1lbl.Name = "PM1lbl";
            this.PM1lbl.Size = new System.Drawing.Size(13, 13);
            this.PM1lbl.TabIndex = 77;
            this.PM1lbl.Text = "0";
            this.PM1lbl.Visible = false;
            // 
            // PMlbl
            // 
            this.PMlbl.AutoSize = true;
            this.PMlbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PMlbl.ForeColor = System.Drawing.Color.DarkSlateBlue;
            this.PMlbl.Location = new System.Drawing.Point(27, 19);
            this.PMlbl.Name = "PMlbl";
            this.PMlbl.Size = new System.Drawing.Size(253, 13);
            this.PMlbl.TabIndex = 76;
            this.PMlbl.Text = "This will enable you to set working days for Calendar";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.label2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label2.Location = new System.Drawing.Point(27, 273);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(112, 13);
            this.label2.TabIndex = 42;
            this.label2.Text = "Report To Section ID";
            // 
            // Reporttocmd
            // 
            this.Reporttocmd.BackColor = System.Drawing.Color.White;
            this.Reporttocmd.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Reporttocmd.FormattingEnabled = true;
            this.Reporttocmd.Location = new System.Drawing.Point(150, 270);
            this.Reporttocmd.Name = "Reporttocmd";
            this.Reporttocmd.Size = new System.Drawing.Size(247, 21);
            this.Reporttocmd.TabIndex = 41;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.label1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label1.Location = new System.Drawing.Point(27, 132);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 13);
            this.label1.TabIndex = 40;
            this.label1.Text = "Heirarchical Level";
            // 
            // HierLst
            // 
            this.HierLst.FormattingEnabled = true;
            this.HierLst.Location = new System.Drawing.Point(150, 132);
            this.HierLst.Name = "HierLst";
            this.HierLst.Size = new System.Drawing.Size(247, 121);
            this.HierLst.TabIndex = 39;
            this.HierLst.SelectedIndexChanged += new System.EventHandler(this.HierLst_SelectedIndexChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.label9.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label9.Location = new System.Drawing.Point(27, 62);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(59, 13);
            this.label9.TabIndex = 37;
            this.label9.Text = "Section ID";
            // 
            // SecIDTxt
            // 
            this.SecIDTxt.Location = new System.Drawing.Point(150, 59);
            this.SecIDTxt.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.SecIDTxt.Name = "SecIDTxt";
            this.SecIDTxt.Properties.MaxLength = 145;
            this.SecIDTxt.Size = new System.Drawing.Size(104, 20);
            this.SecIDTxt.TabIndex = 38;
            this.SecIDTxt.Tag = "0";
            // 
            // toastNotificationsManager1
            // 
            this.toastNotificationsManager1.ApplicationId = "bc2835eb-a12e-4872-9869-c69533cd0d12";
            this.toastNotificationsManager1.ApplicationName = "--";
            this.toastNotificationsManager1.Notifications.AddRange(new DevExpress.XtraBars.ToastNotifications.IToastNotificationProperties[] {
            new DevExpress.XtraBars.ToastNotifications.ToastNotification("33ad81ee-21c1-4d71-8114-0d6875816035", ((System.Drawing.Image)(resources.GetObject("toastNotificationsManager1.Notifications"))), "Notification", "Your record has been saved successfully.", "                             ", DevExpress.XtraBars.ToastNotifications.ToastNotificationTemplate.Text02)});
            // 
            // frmSection
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(449, 435);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.ribbonControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmSection";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Sections";
            this.Load += new System.EventHandler(this.frmSection_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.icPlanning16x16)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.icPlanning32x32)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SecNameTxt.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SecIDTxt.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.toastNotificationsManager1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.Ribbon.RibbonControl ribbonControl1;
        private DevExpress.Utils.ImageCollection icPlanning16x16;
        private DevExpress.XtraBars.BarButtonItem btnSave;
        public DevExpress.XtraBars.BarButtonItem btnCancel;
        private DevExpress.Utils.ImageCollection icPlanning32x32;
        private DevExpress.XtraBars.Ribbon.RibbonPage rpUser;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup rpgActions;
        private DevExpress.XtraBars.BarButtonItem DailyDSRepBtn;
        private DevExpress.XtraBars.BarEditItem barEditItem1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox HierLst;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox Reporttocmd;
        public System.Windows.Forms.Label PM1lbl;
        public System.Windows.Forms.Label PMlbl;
        private System.Windows.Forms.Label label3;
        public DevExpress.XtraEditors.TextEdit SecNameTxt;
        private DevExpress.XtraBars.ToastNotifications.ToastNotificationsManager toastNotificationsManager1;
        public DevExpress.XtraEditors.TextEdit SecIDTxt;
        public System.Windows.Forms.Label Heirlbl;
        public System.Windows.Forms.Label Reptolbl;
    }
}