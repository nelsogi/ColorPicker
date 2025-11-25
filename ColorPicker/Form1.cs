/// Nelson Rossi 
/// Color Picker Application

using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ColorPicker
{
    public partial class frmColorPicker : Form
    {
        #region Form Radius Button       
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        public static extern IntPtr CreateRoundRectRgn
        (
            int nLeftRect,
            int nTopRect,
            int nRightRect,
            int nBottomRect,
            int nWidthEllipse,
            int nHeightEllipse
        );
        #endregion


        

        private FormControler _formControler;

        /// <summary>
        /// Constructor for the main form.
        /// </summary>
        public frmColorPicker(FormControler formControler)
        {
            InitializeComponent();
            _formControler = formControler;

            // Apply rounded corners to various panels and buttons
            Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
            pnlColorInfoBorder.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, pnlColorInfoBorder.Width, pnlColorInfoBorder.Height, 15, 15));
            pnlColorInfo.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, pnlColorInfo.Width, pnlColorInfo.Height, 15, 15));
            pnlShowHistory.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, pnlShowHistory.Width, pnlShowHistory.Height, 15, 15));
            pnlShowHistoryBorder.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, pnlShowHistoryBorder.Width, pnlShowHistoryBorder.Height, 15, 15));
            btnPickColor.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, btnPickColor.Width, btnPickColor.Height, 20, 20));
            btnReturn.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, btnReturn.Width, btnReturn.Height, 20, 20));
            pnlColorShow.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, pnlColorShow.Width, pnlColorShow.Height, 15, 15));

            
            

            // Initial visibility and location settings
            pnlMain.Location = new Point(10, 93);
            pnlHistory.Visible = false;
            pnlHistory.Location = new Point(10, 93);


            _formControler.loadHistoryPanels(pnlShowHistory);
            _formControler.LoadLastPickedColor(lblColorHexa, pnlColorShow);


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

        /// <summary>
        /// Click event handler for the "Pick Color" button.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPickColor_Click(object sender, EventArgs e)
        {
            pickColor();
        }

        /// <summary>
        /// Opens a color picker overlay, allowing the user to select a color, and processes the selected color.
        /// </summary>
        private void pickColor()
        {
            //ColorPickerOverlayForm pickerOverlay = new ColorPickerOverlayForm();

            //// Afficher le formulaire en mode dialogue (bloque Form1 jusqu'à la fermeture de l'overlay)
            //if (pickerOverlay.ShowDialog() == DialogResult.OK)
            //{
            //    // Récupérer la couleur sélectionnée une fois le formulaire fermé
            //    Color selectedColor = pickerOverlay.SelectedColor;


            //    // Convertir en hexadécimal (format #RRGGBB)
            //    string hex = "#" + (selectedColor.ToArgb() & 0x00FFFFFF).ToString("X6");
            //    string rgb = $"{selectedColor.R}, {selectedColor.G}, {selectedColor.B}";

            //    ColorPicked colorPicked = new ColorPicked(hex, rgb);

            //    history.Add(colorPicked);

            //    SaveHistory(history);

            //    lblColorHexa.Text = hex;
            //    pnlColorShow.BackColor = ColorTranslator.FromHtml(hex);

            //    Clipboard.SetText(hex);
            //}

            //// Nettoyer l'objet overlay
            //pickerOverlay.Dispose();
        }

        

        /// <summary>
        /// Save the color picking history to a JSON file.
        /// </summary>
        /// <param name="history"></param>
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

        /// <summary>
        /// Click event to copy the color hexa code to clipboard.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// Change view to history panel.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void historyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            loadHistoryPanels();
            pnlHistory.Visible = !pnlHistory.Visible;
            pnlMain.Visible = !pnlHistory.Visible;
        }

        /// <summary>
        /// Change view back to main panel.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnReturn_Click(object sender, EventArgs e)
        {
            loadHistoryPanels();
            pnlHistory.Visible = !pnlHistory.Visible;
            pnlMain.Visible = !pnlHistory.Visible;
        }
    }
}
