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
            this.pnlTitleBar = new System.Windows.Forms.Panel();
            this.btnHide = new System.Windows.Forms.Button();
            this.ntfiContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quitAppToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pnlTitleBar.SuspendLayout();
            this.ntfiContextMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // notifyIcon
            // 
            this.notifyIcon.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.notifyIcon.ContextMenuStrip = this.ntfiContextMenu;
            resources.ApplyResources(this.notifyIcon, "notifyIcon");
            // 
            // pnlTitleBar
            // 
            this.pnlTitleBar.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.pnlTitleBar.Controls.Add(this.btnHide);
            resources.ApplyResources(this.pnlTitleBar, "pnlTitleBar");
            this.pnlTitleBar.Name = "pnlTitleBar";
            // 
            // btnHide
            // 
            resources.ApplyResources(this.btnHide, "btnHide");
            this.btnHide.FlatAppearance.BorderSize = 0;
            this.btnHide.Name = "btnHide";
            this.btnHide.UseVisualStyleBackColor = true;
            this.btnHide.Click += new System.EventHandler(this.btnHide_Click);
            // 
            // ntfiContextMenu
            // 
            this.ntfiContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.quitAppToolStripMenuItem});
            this.ntfiContextMenu.Name = "ntfiContextMenu";
            resources.ApplyResources(this.ntfiContextMenu, "ntfiContextMenu");
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            resources.ApplyResources(this.openToolStripMenuItem, "openToolStripMenuItem");
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // quitAppToolStripMenuItem
            // 
            this.quitAppToolStripMenuItem.Name = "quitAppToolStripMenuItem";
            resources.ApplyResources(this.quitAppToolStripMenuItem, "quitAppToolStripMenuItem");
            this.quitAppToolStripMenuItem.Click += new System.EventHandler(this.quitAppToolStripMenuItem_Click);
            // 
            // frmColorPicker
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Controls.Add(this.pnlTitleBar);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Name = "frmColorPicker";
            this.ShowIcon = false;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.pnlTitleBar.ResumeLayout(false);
            this.ntfiContextMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.NotifyIcon notifyIcon;
        private System.Windows.Forms.Panel pnlTitleBar;
        private System.Windows.Forms.Button btnHide;
        private System.Windows.Forms.ContextMenuStrip ntfiContextMenu;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem quitAppToolStripMenuItem;
    }
}

