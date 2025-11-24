namespace ColorPicker
{
    partial class frmColorPicker
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmColorPicker));
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.ContextMenuOptions = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.pickColorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quitAppToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pnlTitleBar = new System.Windows.Forms.Panel();
            this.btnOptions = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.pnlMain = new System.Windows.Forms.Panel();
            this.lblColorCopied = new System.Windows.Forms.Label();
            this.btnPickColor = new System.Windows.Forms.Button();
            this.pnlColorInfoBorder = new System.Windows.Forms.Panel();
            this.pnlColorInfo = new System.Windows.Forms.Panel();
            this.lblColorHexa = new System.Windows.Forms.Label();
            this.pnlColorShow = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.historyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pnlHistory = new System.Windows.Forms.Panel();
            this.btnReturn = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.pnlShowHistory = new System.Windows.Forms.Panel();
            this.ContextMenuOptions.SuspendLayout();
            this.pnlTitleBar.SuspendLayout();
            this.pnlMain.SuspendLayout();
            this.pnlColorInfoBorder.SuspendLayout();
            this.pnlColorInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.pnlHistory.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // notifyIcon
            // 
            this.notifyIcon.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            resources.ApplyResources(this.notifyIcon, "notifyIcon");
            this.notifyIcon.Click += new System.EventHandler(this.notifyIcon_Click);
            // 
            // ContextMenuOptions
            // 
            this.ContextMenuOptions.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.pickColorToolStripMenuItem,
            this.historyToolStripMenuItem,
            this.quitAppToolStripMenuItem});
            this.ContextMenuOptions.Name = "ntfiContextMenu";
            resources.ApplyResources(this.ContextMenuOptions, "ContextMenuOptions");
            // 
            // pickColorToolStripMenuItem
            // 
            this.pickColorToolStripMenuItem.Name = "pickColorToolStripMenuItem";
            resources.ApplyResources(this.pickColorToolStripMenuItem, "pickColorToolStripMenuItem");
            this.pickColorToolStripMenuItem.Click += new System.EventHandler(this.pickColorToolStripMenuItem_Click);
            // 
            // quitAppToolStripMenuItem
            // 
            this.quitAppToolStripMenuItem.Name = "quitAppToolStripMenuItem";
            resources.ApplyResources(this.quitAppToolStripMenuItem, "quitAppToolStripMenuItem");
            this.quitAppToolStripMenuItem.Click += new System.EventHandler(this.quitAppToolStripMenuItem_Click);
            // 
            // pnlTitleBar
            // 
            this.pnlTitleBar.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.pnlTitleBar.Controls.Add(this.btnOptions);
            this.pnlTitleBar.Controls.Add(this.label1);
            this.pnlTitleBar.Controls.Add(this.label2);
            resources.ApplyResources(this.pnlTitleBar, "pnlTitleBar");
            this.pnlTitleBar.Name = "pnlTitleBar";
            // 
            // btnOptions
            // 
            resources.ApplyResources(this.btnOptions, "btnOptions");
            this.btnOptions.FlatAppearance.BorderSize = 0;
            this.btnOptions.Name = "btnOptions";
            this.btnOptions.UseVisualStyleBackColor = true;
            this.btnOptions.Click += new System.EventHandler(this.btnOptions_Click);
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // pnlMain
            // 
            this.pnlMain.Controls.Add(this.lblColorCopied);
            this.pnlMain.Controls.Add(this.btnPickColor);
            this.pnlMain.Controls.Add(this.pnlColorInfoBorder);
            resources.ApplyResources(this.pnlMain, "pnlMain");
            this.pnlMain.Name = "pnlMain";
            // 
            // lblColorCopied
            // 
            resources.ApplyResources(this.lblColorCopied, "lblColorCopied");
            this.lblColorCopied.Name = "lblColorCopied";
            // 
            // btnPickColor
            // 
            this.btnPickColor.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnPickColor.FlatAppearance.BorderSize = 0;
            resources.ApplyResources(this.btnPickColor, "btnPickColor");
            this.btnPickColor.Name = "btnPickColor";
            this.btnPickColor.UseVisualStyleBackColor = false;
            this.btnPickColor.Click += new System.EventHandler(this.btnPickColor_Click);
            // 
            // pnlColorInfoBorder
            // 
            this.pnlColorInfoBorder.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.pnlColorInfoBorder.Controls.Add(this.pnlColorInfo);
            resources.ApplyResources(this.pnlColorInfoBorder, "pnlColorInfoBorder");
            this.pnlColorInfoBorder.Name = "pnlColorInfoBorder";
            // 
            // pnlColorInfo
            // 
            this.pnlColorInfo.BackColor = System.Drawing.SystemColors.ControlLight;
            this.pnlColorInfo.Controls.Add(this.lblColorHexa);
            this.pnlColorInfo.Controls.Add(this.pnlColorShow);
            resources.ApplyResources(this.pnlColorInfo, "pnlColorInfo");
            this.pnlColorInfo.Name = "pnlColorInfo";
            this.pnlColorInfo.Click += new System.EventHandler(this.placeColor_Click);
            // 
            // lblColorHexa
            // 
            resources.ApplyResources(this.lblColorHexa, "lblColorHexa");
            this.lblColorHexa.Name = "lblColorHexa";
            this.lblColorHexa.Click += new System.EventHandler(this.placeColor_Click);
            // 
            // pnlColorShow
            // 
            resources.ApplyResources(this.pnlColorShow, "pnlColorShow");
            this.pnlColorShow.Name = "pnlColorShow";
            this.pnlColorShow.Click += new System.EventHandler(this.placeColor_Click);
            // 
            // pictureBox1
            // 
            resources.ApplyResources(this.pictureBox1, "pictureBox1");
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.TabStop = false;
            // 
            // historyToolStripMenuItem
            // 
            this.historyToolStripMenuItem.Name = "historyToolStripMenuItem";
            resources.ApplyResources(this.historyToolStripMenuItem, "historyToolStripMenuItem");
            this.historyToolStripMenuItem.Click += new System.EventHandler(this.historyToolStripMenuItem_Click);
            // 
            // pnlHistory
            // 
            this.pnlHistory.Controls.Add(this.btnReturn);
            this.pnlHistory.Controls.Add(this.panel2);
            resources.ApplyResources(this.pnlHistory, "pnlHistory");
            this.pnlHistory.Name = "pnlHistory";
            // 
            // btnReturn
            // 
            this.btnReturn.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnReturn.FlatAppearance.BorderSize = 0;
            resources.ApplyResources(this.btnReturn, "btnReturn");
            this.btnReturn.Name = "btnReturn";
            this.btnReturn.UseVisualStyleBackColor = false;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.panel2.Controls.Add(this.pnlShowHistory);
            resources.ApplyResources(this.panel2, "panel2");
            this.panel2.Name = "panel2";
            // 
            // pnlShowHistory
            // 
            this.pnlShowHistory.BackColor = System.Drawing.SystemColors.ControlLight;
            resources.ApplyResources(this.pnlShowHistory, "pnlShowHistory");
            this.pnlShowHistory.Name = "pnlShowHistory";
            // 
            // frmColorPicker
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.Controls.Add(this.pnlHistory);
            this.Controls.Add(this.pnlMain);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.pnlTitleBar);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Name = "frmColorPicker";
            this.ShowIcon = false;
            this.Deactivate += new System.EventHandler(this.frmColorPicker_Deactivate);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.ContextMenuOptions.ResumeLayout(false);
            this.pnlTitleBar.ResumeLayout(false);
            this.pnlTitleBar.PerformLayout();
            this.pnlMain.ResumeLayout(false);
            this.pnlMain.PerformLayout();
            this.pnlColorInfoBorder.ResumeLayout(false);
            this.pnlColorInfo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.pnlHistory.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.NotifyIcon notifyIcon;
        private System.Windows.Forms.ContextMenuStrip ContextMenuOptions;
        private System.Windows.Forms.ToolStripMenuItem quitAppToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pickColorToolStripMenuItem;
        private System.Windows.Forms.Panel pnlTitleBar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnOptions;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.Panel pnlColorInfoBorder;
        private System.Windows.Forms.Panel pnlColorInfo;
        private System.Windows.Forms.Button btnPickColor;
        private System.Windows.Forms.Panel pnlColorShow;
        private System.Windows.Forms.Label lblColorHexa;
        private System.Windows.Forms.Label lblColorCopied;
        private System.Windows.Forms.ToolStripMenuItem historyToolStripMenuItem;
        private System.Windows.Forms.Panel pnlHistory;
        private System.Windows.Forms.Button btnReturn;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel pnlShowHistory;
    }
}

