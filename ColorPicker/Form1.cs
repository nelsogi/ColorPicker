using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ColorPicker
{
    public partial class frmColorPicker : Form
    {
        public frmColorPicker()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Minimized;
            this.ShowInTaskbar = false;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
            notifyIcon.Visible = true;
        }

        private void btnHide_Click(object sender, EventArgs e)
        {
            
            Application.Exit();
        }

        private void btnMinimize_Click(object sender, EventArgs e)
        {
            this.Hide();
            notifyIcon.Visible = true;
        }

        private void quitAppToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void ntfiContextMenu_Click(object sender, EventArgs e)
        {
            ntfiContextMenu.Show();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Visible = true;
            this.WindowState = FormWindowState.Normal;
            this.ShowInTaskbar = true;
        }

        private void pickColorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ColorPickerOverlayForm pickerOverlay = new ColorPickerOverlayForm();

            // Afficher le formulaire en mode dialogue (bloque Form1 jusqu'à la fermeture de l'overlay)
            if (pickerOverlay.ShowDialog() == DialogResult.OK)
            {
                // Récupérer la couleur sélectionnée une fois le formulaire fermé
                Color selectedColor = pickerOverlay.SelectedColor;

                
                // Convertir en hexadécimal (format #RRGGBB)
                string hex = "#" + (selectedColor.ToArgb() & 0x00FFFFFF).ToString("X6");

                MessageBox.Show(hex);
                Clipboard.SetText(hex);
            }

            // Nettoyer l'objet overlay
            pickerOverlay.Dispose();
        }

        
    }
}
