namespace Mineware.Systems.Minewaste
{
    partial class AddPumpStationFrm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddPumpStationFrm));
            this.rcMenu = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.btnClose = new DevExpress.XtraBars.BarButtonItem();
            this.btnBack = new DevExpress.XtraBars.BarButtonItem();
            this.btnSave = new DevExpress.XtraBars.BarButtonItem();
            this.btnShow = new DevExpress.XtraBars.BarButtonItem();
            this.biPlant = new DevExpress.XtraBars.BarEditItem();
            this.btnLock = new DevExpress.XtraBars.BarButtonItem();
            this.rgPlan = new DevExpress.XtraBars.BarEditItem();
            this.biSelectionType = new DevExpress.XtraBars.BarEditItem();
            this.biStartDate = new DevExpress.XtraBars.BarEditItem();
            this.biEndDate = new DevExpress.XtraBars.BarEditItem();
            this.biTotalShifts = new DevExpress.XtraBars.BarEditItem();
            this.btnReset = new DevExpress.XtraBars.BarButtonItem();
            this.biMillMonth = new DevExpress.XtraBars.BarEditItem();
            this.biMillMonthNew = new DevExpress.XtraBars.BarEditItem();
            this.barEditItem2 = new DevExpress.XtraBars.BarEditItem();
            this.barButtonItem1 = new DevExpress.XtraBars.BarButtonItem();
            this.ImportBtn = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem2 = new DevExpress.XtraBars.BarButtonItem();
            this.PrintBtn = new DevExpress.XtraBars.BarButtonItem();
            this.rpSelection = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.rpgShow = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.DescTxt = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.toastNotificationsManager1 = new DevExpress.XtraBars.ToastNotifications.ToastNotificationsManager(this.components);
            this.SecCmb = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.PumpLbl = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.rcMenu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.toastNotificationsManager1)).BeginInit();
            this.SuspendLayout();
            // 
            // rcMenu
            // 
            this.rcMenu.AllowKeyTips = false;
            this.rcMenu.AllowMdiChildButtons = false;
            this.rcMenu.AllowMinimizeRibbon = false;
            this.rcMenu.AllowTrimPageText = false;
            this.rcMenu.AutoSizeItems = true;
            this.rcMenu.ColorScheme = DevExpress.XtraBars.Ribbon.RibbonControlColorScheme.Blue;
            this.rcMenu.DrawGroupCaptions = DevExpress.Utils.DefaultBoolean.False;
            this.rcMenu.ExpandCollapseItem.Id = 0;
            this.rcMenu.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.rcMenu.ExpandCollapseItem,
            this.btnClose,
            this.btnBack,
            this.btnSave,
            this.btnShow,
            this.biPlant,
            this.btnLock,
            this.rgPlan,
            this.biSelectionType,
            this.biStartDate,
            this.biEndDate,
            this.biTotalShifts,
            this.btnReset,
            this.biMillMonth,
            this.biMillMonthNew,
            this.barEditItem2,
            this.barButtonItem1,
            this.ImportBtn,
            this.barButtonItem2,
            this.PrintBtn});
            this.rcMenu.Location = new System.Drawing.Point(0, 0);
            this.rcMenu.MaxItemId = 81;
            this.rcMenu.Name = "rcMenu";
            this.rcMenu.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.rpSelection});
            this.rcMenu.ShowApplicationButton = DevExpress.Utils.DefaultBoolean.False;
            this.rcMenu.ShowCategoryInCaption = false;
            this.rcMenu.ShowDisplayOptionsMenuButton = DevExpress.Utils.DefaultBoolean.False;
            this.rcMenu.ShowExpandCollapseButton = DevExpress.Utils.DefaultBoolean.False;
            this.rcMenu.ShowPageHeadersInFormCaption = DevExpress.Utils.DefaultBoolean.False;
            this.rcMenu.ShowPageHeadersMode = DevExpress.XtraBars.Ribbon.ShowPageHeadersMode.Hide;
            this.rcMenu.ShowQatLocationSelector = false;
            this.rcMenu.ShowToolbarCustomizeItem = false;
            this.rcMenu.Size = new System.Drawing.Size(321, 83);
            this.rcMenu.Toolbar.ShowCustomizeItem = false;
            this.rcMenu.ToolbarLocation = DevExpress.XtraBars.Ribbon.RibbonQuickAccessToolbarLocation.Hidden;
            // 
            // btnClose
            // 
            this.btnClose.Caption = "Close";
            this.btnClose.Id = 6;
            this.btnClose.ImageOptions.ImageUri.Uri = "Delete";
            this.btnClose.Name = "btnClose";
            // 
            // btnBack
            // 
            this.btnBack.Caption = "Back";
            this.btnBack.Id = 23;
            this.btnBack.ImageOptions.ImageUri.Uri = "Backward";
            this.btnBack.Name = "btnBack";
            // 
            // btnSave
            // 
            this.btnSave.Caption = "Save";
            this.btnSave.Id = 29;
            this.btnSave.ImageOptions.ImageUri.Uri = "Save";
            this.btnSave.ImageOptions.SvgImage = global::Mineware.Systems.Minewaste.Properties.Resources.SaveBlue;
            this.btnSave.Name = "btnSave";
            this.btnSave.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnSave_ItemClick);
            // 
            // btnShow
            // 
            this.btnShow.Caption = "Show";
            this.btnShow.Id = 48;
            this.btnShow.ImageOptions.ImageUri.Uri = "Zoom";
            this.btnShow.ItemAppearance.Disabled.Font = new System.Drawing.Font("Tahoma", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnShow.ItemAppearance.Disabled.Options.UseFont = true;
            this.btnShow.Name = "btnShow";
            // 
            // biPlant
            // 
            this.biPlant.Caption = "Plant";
            this.biPlant.Edit = null;
            this.biPlant.EditWidth = 80;
            this.biPlant.Id = 50;
            this.biPlant.Name = "biPlant";
            // 
            // btnLock
            // 
            this.btnLock.Caption = "Lock";
            this.btnLock.Id = 51;
            this.btnLock.ImageOptions.ImageUri.Uri = "Customization";
            this.btnLock.Name = "btnLock";
            // 
            // rgPlan
            // 
            this.rgPlan.AutoFillWidthInMenu = DevExpress.Utils.DefaultBoolean.True;
            this.rgPlan.Caption = "Plan";
            this.rgPlan.Edit = null;
            this.rgPlan.EditValue = 0;
            this.rgPlan.EditWidth = 200;
            this.rgPlan.Id = 52;
            this.rgPlan.ItemAppearance.Normal.BackColor = System.Drawing.Color.White;
            this.rgPlan.ItemAppearance.Normal.Options.UseBackColor = true;
            this.rgPlan.Name = "rgPlan";
            this.rgPlan.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText;
            // 
            // biSelectionType
            // 
            this.biSelectionType.Caption = "Selection Type";
            this.biSelectionType.Edit = null;
            this.biSelectionType.EditValue = "";
            this.biSelectionType.EditWidth = 200;
            this.biSelectionType.Id = 56;
            this.biSelectionType.Name = "biSelectionType";
            // 
            // biStartDate
            // 
            this.biStartDate.Caption = "Start Date";
            this.biStartDate.Edit = null;
            this.biStartDate.EditWidth = 80;
            this.biStartDate.Id = 57;
            this.biStartDate.Name = "biStartDate";
            // 
            // biEndDate
            // 
            this.biEndDate.Caption = "End Date";
            this.biEndDate.Edit = null;
            this.biEndDate.EditWidth = 80;
            this.biEndDate.Id = 58;
            this.biEndDate.Name = "biEndDate";
            // 
            // biTotalShifts
            // 
            this.biTotalShifts.Caption = "Total Shifts";
            this.biTotalShifts.Edit = null;
            this.biTotalShifts.EditWidth = 80;
            this.biTotalShifts.Id = 59;
            this.biTotalShifts.Name = "biTotalShifts";
            // 
            // btnReset
            // 
            this.btnReset.Caption = "Reset";
            this.btnReset.Id = 62;
            this.btnReset.ImageOptions.ImageUri.Uri = "Refresh";
            this.btnReset.Name = "btnReset";
            // 
            // biMillMonth
            // 
            this.biMillMonth.Caption = "Mill Month";
            this.biMillMonth.Edit = null;
            this.biMillMonth.EditWidth = 80;
            this.biMillMonth.Id = 65;
            this.biMillMonth.Name = "biMillMonth";
            // 
            // biMillMonthNew
            // 
            this.biMillMonthNew.Caption = "Mill Month";
            this.biMillMonthNew.Edit = null;
            this.biMillMonthNew.EditWidth = 140;
            this.biMillMonthNew.Id = 72;
            this.biMillMonthNew.Name = "biMillMonthNew";
            // 
            // barEditItem2
            // 
            this.barEditItem2.Edit = null;
            this.barEditItem2.EditWidth = 230;
            this.barEditItem2.Id = 73;
            this.barEditItem2.Name = "barEditItem2";
            // 
            // barButtonItem1
            // 
            this.barButtonItem1.Caption = "                                                                  ";
            this.barButtonItem1.Id = 76;
            this.barButtonItem1.Name = "barButtonItem1";
            // 
            // ImportBtn
            // 
            this.ImportBtn.Caption = "Copy From Clipboard";
            this.ImportBtn.Id = 77;
            this.ImportBtn.Name = "ImportBtn";
            // 
            // barButtonItem2
            // 
            this.barButtonItem2.Caption = "barButtonItem2";
            this.barButtonItem2.Id = 78;
            this.barButtonItem2.Name = "barButtonItem2";
            // 
            // PrintBtn
            // 
            this.PrintBtn.Caption = "Print";
            this.PrintBtn.Id = 79;
            this.PrintBtn.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("PrintBtn.ImageOptions.Image")));
            this.PrintBtn.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("PrintBtn.ImageOptions.LargeImage")));
            this.PrintBtn.Name = "PrintBtn";
            // 
            // rpSelection
            // 
            this.rpSelection.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.rpgShow});
            this.rpSelection.Name = "rpSelection";
            this.rpSelection.Text = "Selection";
            // 
            // rpgShow
            // 
            this.rpgShow.ItemLinks.Add(this.btnSave);
            this.rpgShow.Name = "rpgShow";
            // 
            // DescTxt
            // 
            this.DescTxt.Location = new System.Drawing.Point(91, 110);
            this.DescTxt.Name = "DescTxt";
            this.DescTxt.Size = new System.Drawing.Size(185, 21);
            this.DescTxt.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.label1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label1.Location = new System.Drawing.Point(25, 113);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Description";
            // 
            // toastNotificationsManager1
            // 
            this.toastNotificationsManager1.ApplicationId = "Mineware.Systems.Minewaste";
            this.toastNotificationsManager1.ApplicationName = "Mineware.Systems.Minewaste";
            this.toastNotificationsManager1.Notifications.AddRange(new DevExpress.XtraBars.ToastNotifications.IToastNotificationProperties[] {
            new DevExpress.XtraBars.ToastNotifications.ToastNotification("33ad81ee-21c1-4d71-8114-0d6875816035", ((System.Drawing.Image)(resources.GetObject("toastNotificationsManager1.Notifications"))), "Notification", "Your record has been saved successfully.", "                             ", DevExpress.XtraBars.ToastNotifications.ToastNotificationTemplate.ImageAndText01)});
            // 
            // SecCmb
            // 
            this.SecCmb.FormattingEnabled = true;
            this.SecCmb.Location = new System.Drawing.Point(91, 136);
            this.SecCmb.Name = "SecCmb";
            this.SecCmb.Size = new System.Drawing.Size(185, 21);
            this.SecCmb.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.label2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label2.Location = new System.Drawing.Point(25, 139);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Section";
            // 
            // PumpLbl
            // 
            this.PumpLbl.AutoSize = true;
            this.PumpLbl.Location = new System.Drawing.Point(263, 24);
            this.PumpLbl.Name = "PumpLbl";
            this.PumpLbl.Size = new System.Drawing.Size(35, 13);
            this.PumpLbl.TabIndex = 7;
            this.PumpLbl.Text = "label3";
            this.PumpLbl.Visible = false;
            // 
            // AddPumpStationFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(321, 233);
            this.Controls.Add(this.PumpLbl);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.SecCmb);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.DescTxt);
            this.Controls.Add(this.rcMenu);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "AddPumpStationFrm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Add Pump Station";
            this.Load += new System.EventHandler(this.AddPumpStationFrm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.rcMenu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.toastNotificationsManager1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.Ribbon.RibbonControl rcMenu;
        private DevExpress.XtraBars.BarButtonItem btnClose;
        private DevExpress.XtraBars.BarButtonItem btnBack;
        private DevExpress.XtraBars.BarButtonItem btnSave;
        private DevExpress.XtraBars.BarButtonItem btnShow;
        private DevExpress.XtraBars.BarEditItem biPlant;
        private DevExpress.XtraBars.BarButtonItem btnLock;
        private DevExpress.XtraBars.BarEditItem rgPlan;
        private DevExpress.XtraBars.BarEditItem biSelectionType;
        private DevExpress.XtraBars.BarEditItem biStartDate;
        private DevExpress.XtraBars.BarEditItem biEndDate;
        private DevExpress.XtraBars.BarEditItem biTotalShifts;
        private DevExpress.XtraBars.BarButtonItem btnReset;
        private DevExpress.XtraBars.BarEditItem biMillMonth;
        private DevExpress.XtraBars.BarEditItem biMillMonthNew;
        private DevExpress.XtraBars.BarEditItem barEditItem2;
        private DevExpress.XtraBars.BarButtonItem barButtonItem1;
        private DevExpress.XtraBars.BarButtonItem ImportBtn;
        private DevExpress.XtraBars.BarButtonItem barButtonItem2;
        private DevExpress.XtraBars.BarButtonItem PrintBtn;
        private DevExpress.XtraBars.Ribbon.RibbonPage rpSelection;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup rpgShow;
        private System.Windows.Forms.TextBox DescTxt;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraBars.ToastNotifications.ToastNotificationsManager toastNotificationsManager1;
        private System.Windows.Forms.ComboBox SecCmb;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.Label PumpLbl;
    }
}