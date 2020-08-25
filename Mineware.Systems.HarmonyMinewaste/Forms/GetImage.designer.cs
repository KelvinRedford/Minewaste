namespace Mineware.Systems.Minewaste
{
    partial class GetImage
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GetImage));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.aaaaaaaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panPic = new System.Windows.Forms.Panel();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.OpenFormtxt = new System.Windows.Forms.Label();
            this.DDLetterlabel = new System.Windows.Forms.Label();
            this.ProdmonthLbl = new System.Windows.Forms.Label();
            this.SectionLbl = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.SteelBlue;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aaaaaaaToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(662, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // aaaaaaaToolStripMenuItem
            // 
            this.aaaaaaaToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("aaaaaaaToolStripMenuItem.Image")));
            this.aaaaaaaToolStripMenuItem.Name = "aaaaaaaToolStripMenuItem";
            this.aaaaaaaToolStripMenuItem.Size = new System.Drawing.Size(113, 20);
            this.aaaaaaaToolStripMenuItem.Text = "Capture Image";
            this.aaaaaaaToolStripMenuItem.Click += new System.EventHandler(this.aaaaaaaToolStripMenuItem_Click);
            // 
            // panPic
            // 
            this.panPic.BackColor = System.Drawing.Color.LightSteelBlue;
            this.panPic.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panPic.Location = new System.Drawing.Point(0, 24);
            this.panPic.Name = "panPic";
            this.panPic.Size = new System.Drawing.Size(662, 410);
            this.panPic.TabIndex = 2;
            this.panPic.Visible = false;
            this.panPic.Paint += new System.Windows.Forms.PaintEventHandler(this.panPic_Paint);
            // 
            // OpenFormtxt
            // 
            this.OpenFormtxt.AutoSize = true;
            this.OpenFormtxt.Location = new System.Drawing.Point(543, 8);
            this.OpenFormtxt.Name = "OpenFormtxt";
            this.OpenFormtxt.Size = new System.Drawing.Size(35, 13);
            this.OpenFormtxt.TabIndex = 0;
            this.OpenFormtxt.Text = "label1";
            this.OpenFormtxt.Visible = false;
            // 
            // DDLetterlabel
            // 
            this.DDLetterlabel.AutoSize = true;
            this.DDLetterlabel.Location = new System.Drawing.Point(425, 6);
            this.DDLetterlabel.Name = "DDLetterlabel";
            this.DDLetterlabel.Size = new System.Drawing.Size(35, 13);
            this.DDLetterlabel.TabIndex = 3;
            this.DDLetterlabel.Text = "label1";
            this.DDLetterlabel.Visible = false;
            // 
            // ProdmonthLbl
            // 
            this.ProdmonthLbl.AutoSize = true;
            this.ProdmonthLbl.Location = new System.Drawing.Point(329, 6);
            this.ProdmonthLbl.Name = "ProdmonthLbl";
            this.ProdmonthLbl.Size = new System.Drawing.Size(72, 13);
            this.ProdmonthLbl.TabIndex = 4;
            this.ProdmonthLbl.Text = "ProdmonthLbl";
            this.ProdmonthLbl.Visible = false;
            // 
            // SectionLbl
            // 
            this.SectionLbl.AutoSize = true;
            this.SectionLbl.Location = new System.Drawing.Point(466, 8);
            this.SectionLbl.Name = "SectionLbl";
            this.SectionLbl.Size = new System.Drawing.Size(37, 13);
            this.SectionLbl.TabIndex = 5;
            this.SectionLbl.Text = "SecLbl";
            this.SectionLbl.Visible = false;
            // 
            // GetImage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(662, 434);
            this.Controls.Add(this.SectionLbl);
            this.Controls.Add(this.ProdmonthLbl);
            this.Controls.Add(this.DDLetterlabel);
            this.Controls.Add(this.OpenFormtxt);
            this.Controls.Add(this.panPic);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "GetImage";
            this.Text = "Get Image";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.GetImage_Load);
            this.SizeChanged += new System.EventHandler(this.GetImage_SizeChanged);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem aaaaaaaToolStripMenuItem;
        private System.Windows.Forms.Panel panPic;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        public System.Windows.Forms.Label OpenFormtxt;
        public System.Windows.Forms.Label DDLetterlabel;
        public System.Windows.Forms.Label ProdmonthLbl;
        public System.Windows.Forms.Label SectionLbl;
    }
}