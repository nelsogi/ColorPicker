using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ColorPicker
{
    public partial class frmColorPicker : Form
    {
        #region Form Radius Button       
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn
        (
            int nLeftRect,
            int nTopRect,
            int nRightRect,
            int nBottomRect,
            int nWidthEllipse,
            int nHeightEllipse
        );
        #endregion

        static string historyFile = "colors.json";

        List<ColorPicked> history = LoadHistory();

        public frmColorPicker()
        {
            InitializeComponent();
            Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
            pnlColorInfoBorder.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, pnlColorInfoBorder.Width, pnlColorInfoBorder.Height, 15, 15));
            pnlColorInfo.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, pnlColorInfo.Width, pnlColorInfo.Height, 15, 15));
            btnPickColor.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, btnPickColor.Width, btnPickColor.Height, 20, 20));


            pnlMain.Location = new Point(10, 93);

            this.WindowState = FormWindowState.Minimized;
            this.ShowInTaskbar = false;

            // Calculate the position
            var screenWorkingArea = Screen.PrimaryScreen.WorkingArea;
            this.Location = new Point((screenWorkingArea.Right - this.Width) - 15, (screenWorkingArea.Bottom - this.Height) - 15);

            if (history != null && history.Count > 0)
            {
                ColorPicked last = history[history.Count - 1]; // dernier élément
                lblColorHexa.Text = last.Hex;
                pnlColorShow.BackColor = ColorTranslator.FromHtml(last.Hex);
            }

        }

        /// <summary>
        /// Event for form closing to hide it instead of closing.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
            notifyIcon.Visible = true;
        }

        /// <summary>
        /// Quit the application when the "Quit App" menu item is clicked.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void quitAppToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        /// <summary>
        /// Click event handler for the "Pick Color" menu item.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pickColorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pickColor();
        }

        private void btnPickColor_Click(object sender, EventArgs e)
        {
            pickColor();
        }

        private void pickColor()
        {
            ColorPickerOverlayForm pickerOverlay = new ColorPickerOverlayForm();

            // Afficher le formulaire en mode dialogue (bloque Form1 jusqu'à la fermeture de l'overlay)
            if (pickerOverlay.ShowDialog() == DialogResult.OK)
            {
                // Récupérer la couleur sélectionnée une fois le formulaire fermé
                Color selectedColor = pickerOverlay.SelectedColor;

                
                // Convertir en hexadécimal (format #RRGGBB)
                string hex = "#" + (selectedColor.ToArgb() & 0x00FFFFFF).ToString("X6");
                string rgb = $"{selectedColor.R}, {selectedColor.G}, {selectedColor.B}";

                ColorPicked colorPicked = new ColorPicked(hex, rgb);

                history.Add(colorPicked);

                SaveHistory(history);

                lblColorHexa.Text = hex;
                pnlColorShow.BackColor = ColorTranslator.FromHtml(hex);

                Clipboard.SetText(hex);
            }

            // Nettoyer l'objet overlay
            pickerOverlay.Dispose();
        }

        static List<ColorPicked> LoadHistory()
        {
            if (!File.Exists(historyFile))
            {
                return new List<ColorPicked>();
            }

            string json = File.ReadAllText(historyFile);
            var list = JsonSerializer.Deserialize<List<ColorPicked>>(json);
            return list ?? new List<ColorPicked>();
        }

        static void SaveHistory(List<ColorPicked> history)
        {
            var options = new JsonSerializerOptions { WriteIndented = true };
            string json = JsonSerializer.Serialize(history, options);
            File.WriteAllText(historyFile, json);
        }

        /// <summary>
        /// Show the main form when the notify icon is clicked.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void notifyIcon_Click(object sender, EventArgs e)
        {
            this.Visible = true;
            this.WindowState = FormWindowState.Normal;
            this.Activate();
        }

        /// <summary>
        /// Hide when the form loses focus.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmColorPicker_Deactivate(object sender, EventArgs e)
        {
            this.Hide();
        }

        /// <summary>
        /// Event for the options button to show the context menu.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOptions_Click(object sender, EventArgs e)
        {
            ContextMenuOptions.Show(btnOptions, new Point(0, -ContextMenuOptions.Height));
        }

        private async void placeColor_Click(object sender, EventArgs e)
        {
            if (pnlColorShow.BackColor != SystemColors.ControlLight)
            {
                Clipboard.SetText(lblColorHexa.Text);

                lblColorCopied.Visible = true;
                await Task.Delay(2000);   // 2 secondes
                lblColorCopied.Visible = false;
            }
        }
    }
}
