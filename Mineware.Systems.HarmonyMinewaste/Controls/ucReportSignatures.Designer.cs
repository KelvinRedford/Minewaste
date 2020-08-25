namespace Mineware.Systems.Minewaste.Controls
{
    partial class ucReportSignatures
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucReportSignatures));
            this.GCEmp = new DevExpress.XtraGrid.GridControl();
            this.GVEmp = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.GCStatus = new DevExpress.XtraGrid.Columns.GridColumn();
            this.GCName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.cardView9 = new DevExpress.XtraGrid.Views.Card.CardView();
            this.gridColumn35 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn36 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn37 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn38 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.panel2 = new System.Windows.Forms.Panel();
            this.saveBtn = new DevExpress.XtraEditors.SimpleButton();
            this.layoutControl7 = new DevExpress.XtraLayout.LayoutControl();
            this.StatusCmb = new System.Windows.Forms.ComboBox();
            this.NameTxt = new System.Windows.Forms.TextBox();
            this.layoutControlGroup11 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.Tiltle = new DevExpress.XtraLayout.LayoutControlItem();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.GCEmp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GVEmp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cardView9)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl7)).BeginInit();
            this.layoutControl7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Tiltle)).BeginInit();
            this.SuspendLayout();
            // 
            // GCEmp
            // 
            this.GCEmp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GCEmp.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(4);
            this.GCEmp.Location = new System.Drawing.Point(0, 0);
            this.GCEmp.MainView = this.GVEmp;
            this.GCEmp.Margin = new System.Windows.Forms.Padding(10);
            this.GCEmp.Name = "GCEmp";
            this.GCEmp.Size = new System.Drawing.Size(398, 535);
            this.GCEmp.TabIndex = 31;
            this.GCEmp.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.GVEmp,
            this.cardView9});
            // 
            // GVEmp
            // 
            this.GVEmp.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.GCStatus,
            this.GCName});
            this.GVEmp.GridControl = this.GCEmp;
            this.GVEmp.Name = "GVEmp";
            this.GVEmp.OptionsBehavior.AllowGroupExpandAnimation = DevExpress.Utils.DefaultBoolean.True;
            this.GVEmp.OptionsBehavior.AutoExpandAllGroups = true;
            this.GVEmp.OptionsBehavior.Editable = false;
            this.GVEmp.OptionsDetail.SmartDetailExpandButtonMode = DevExpress.XtraGrid.Views.Grid.DetailExpandButtonMode.AlwaysEnabled;
            this.GVEmp.OptionsNavigation.AutoFocusNewRow = true;
            this.GVEmp.OptionsSelection.MultiSelect = true;
            this.GVEmp.OptionsSelection.ShowCheckBoxSelectorInGroupRow = DevExpress.Utils.DefaultBoolean.True;
            this.GVEmp.OptionsView.EnableAppearanceEvenRow = true;
            this.GVEmp.OptionsView.ShowDetailButtons = false;
            this.GVEmp.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.GVEmp.OptionsView.ShowGroupPanel = false;
            this.GVEmp.RowCellClick += new DevExpress.XtraGrid.Views.Grid.RowCellClickEventHandler(this.GVEmp_RowCellClick);
            // 
            // GCStatus
            // 
            this.GCStatus.AppearanceHeader.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GCStatus.AppearanceHeader.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.GCStatus.AppearanceHeader.Options.UseFont = true;
            this.GCStatus.AppearanceHeader.Options.UseForeColor = true;
            this.GCStatus.Caption = "Title";
            this.GCStatus.Name = "GCStatus";
            this.GCStatus.OptionsColumn.AllowEdit = false;
            this.GCStatus.OptionsColumn.AllowSize = false;
            this.GCStatus.Visible = true;
            this.GCStatus.VisibleIndex = 0;
            this.GCStatus.Width = 165;
            // 
            // GCName
            // 
            this.GCName.AppearanceHeader.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GCName.AppearanceHeader.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.GCName.AppearanceHeader.Options.UseFont = true;
            this.GCName.AppearanceHeader.Options.UseForeColor = true;
            this.GCName.Caption = "Name";
            this.GCName.Name = "GCName";
            this.GCName.OptionsColumn.AllowEdit = false;
            this.GCName.OptionsColumn.AllowSize = false;
            this.GCName.Visible = true;
            this.GCName.VisibleIndex = 1;
            this.GCName.Width = 215;
            // 
            // cardView9
            // 
            this.cardView9.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn35,
            this.gridColumn36,
            this.gridColumn37,
            this.gridColumn38});
            this.cardView9.FocusedCardTopFieldIndex = 0;
            this.cardView9.GridControl = this.GCEmp;
            this.cardView9.Name = "cardView9";
            this.cardView9.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.cardView9.VertScrollVisibility = DevExpress.XtraGrid.Views.Base.ScrollVisibility.Auto;
            // 
            // gridColumn35
            // 
            this.gridColumn35.Caption = "User ID";
            this.gridColumn35.FieldName = "USERID";
            this.gridColumn35.Name = "gridColumn35";
            this.gridColumn35.OptionsColumn.AllowEdit = false;
            this.gridColumn35.Visible = true;
            this.gridColumn35.VisibleIndex = 0;
            // 
            // gridColumn36
            // 
            this.gridColumn36.Caption = "Name ";
            this.gridColumn36.FieldName = "Name";
            this.gridColumn36.Name = "gridColumn36";
            this.gridColumn36.OptionsColumn.AllowEdit = false;
            this.gridColumn36.Visible = true;
            this.gridColumn36.VisibleIndex = 1;
            // 
            // gridColumn37
            // 
            this.gridColumn37.Caption = "Last Name";
            this.gridColumn37.FieldName = "LastName";
            this.gridColumn37.Name = "gridColumn37";
            this.gridColumn37.OptionsColumn.AllowEdit = false;
            this.gridColumn37.Visible = true;
            this.gridColumn37.VisibleIndex = 2;
            // 
            // gridColumn38
            // 
            this.gridColumn38.Caption = "E-Mail";
            this.gridColumn38.FieldName = "EMail";
            this.gridColumn38.Name = "gridColumn38";
            this.gridColumn38.OptionsColumn.AllowEdit = false;
            this.gridColumn38.Visible = true;
            this.gridColumn38.VisibleIndex = 3;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Controls.Add(this.saveBtn);
            this.panel2.Controls.Add(this.layoutControl7);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel2.Location = new System.Drawing.Point(398, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(536, 535);
            this.panel2.TabIndex = 33;
            // 
            // saveBtn
            // 
            this.saveBtn.Enabled = false;
            this.saveBtn.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("saveBtn.ImageOptions.Image")));
            this.saveBtn.Location = new System.Drawing.Point(144, 105);
            this.saveBtn.Name = "saveBtn";
            this.saveBtn.Size = new System.Drawing.Size(75, 33);
            this.saveBtn.TabIndex = 6;
            this.saveBtn.Text = "Save";
            this.saveBtn.Click += new System.EventHandler(this.saveBtn_Click);
            // 
            // layoutControl7
            // 
            this.layoutControl7.Controls.Add(this.StatusCmb);
            this.layoutControl7.Controls.Add(this.NameTxt);
            this.layoutControl7.Location = new System.Drawing.Point(8, 5);
            this.layoutControl7.Name = "layoutControl7";
            this.layoutControl7.Root = this.layoutControlGroup11;
            this.layoutControl7.Size = new System.Drawing.Size(349, 94);
            this.layoutControl7.TabIndex = 0;
            this.layoutControl7.Text = "Supplier Details";
            // 
            // StatusCmb
            // 
            this.StatusCmb.Enabled = false;
            this.StatusCmb.FormattingEnabled = true;
            this.StatusCmb.Location = new System.Drawing.Point(42, 37);
            this.StatusCmb.Name = "StatusCmb";
            this.StatusCmb.Size = new System.Drawing.Size(295, 21);
            this.StatusCmb.TabIndex = 16;
            // 
            // NameTxt
            // 
            this.NameTxt.Enabled = false;
            this.NameTxt.Location = new System.Drawing.Point(42, 62);
            this.NameTxt.Name = "NameTxt";
            this.NameTxt.Size = new System.Drawing.Size(295, 20);
            this.NameTxt.TabIndex = 15;
            // 
            // layoutControlGroup11
            // 
            this.layoutControlGroup11.AppearanceGroup.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.layoutControlGroup11.AppearanceGroup.Options.UseFont = true;
            this.layoutControlGroup11.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup11.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.Tiltle});
            this.layoutControlGroup11.Name = "layoutControlGroup11";
            this.layoutControlGroup11.Size = new System.Drawing.Size(349, 94);
            this.layoutControlGroup11.Text = "Page Footer Details";
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.NameTxt;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 25);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(329, 24);
            this.layoutControlItem1.Text = "Name";
            this.layoutControlItem1.TextSize = new System.Drawing.Size(27, 13);
            // 
            // Tiltle
            // 
            this.Tiltle.Control = this.StatusCmb;
            this.Tiltle.Location = new System.Drawing.Point(0, 0);
            this.Tiltle.Name = "Tiltle";
            this.Tiltle.Size = new System.Drawing.Size(329, 25);
            this.Tiltle.TextSize = new System.Drawing.Size(27, 13);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // ucReportSignatures
            // 
            this.Appearance.ForeColor = System.Drawing.Color.Black;
            this.Appearance.Options.UseForeColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.GCEmp);
            this.Controls.Add(this.panel2);
            this.Name = "ucReportSignatures";
            this.ShowIInfo = false;
            this.Size = new System.Drawing.Size(934, 535);
            this.Load += new System.EventHandler(this.ucReportSignatures_Load);
            this.Controls.SetChildIndex(this.panel2, 0);
            this.Controls.SetChildIndex(this.GCEmp, 0);
            ((System.ComponentModel.ISupportInitialize)(this.GCEmp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GVEmp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cardView9)).EndInit();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl7)).EndInit();
            this.layoutControl7.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Tiltle)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraGrid.GridControl GCEmp;
        private DevExpress.XtraGrid.Views.Grid.GridView GVEmp;
        private DevExpress.XtraGrid.Columns.GridColumn GCStatus;
        private DevExpress.XtraGrid.Columns.GridColumn GCName;
        private DevExpress.XtraGrid.Views.Card.CardView cardView9;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn35;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn36;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn37;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn38;
        private System.Windows.Forms.Panel panel2;
        private DevExpress.XtraEditors.SimpleButton saveBtn;
        private DevExpress.XtraLayout.LayoutControl layoutControl7;
        private System.Windows.Forms.ComboBox StatusCmb;
        private System.Windows.Forms.TextBox NameTxt;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup11;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlItem Tiltle;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
    }
}
