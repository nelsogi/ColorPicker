/// Nelson Rossi
/// Color Picker Application

using System;
using System.Drawing;
using System.Runtime.InteropServices;
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

        public frmColorPicker(FormControler formControler)
        {
            InitializeComponent();
            _formControler = formControler;

            // Arrondis
            Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
            pnlColorInfoBorder.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, pnlColorInfoBorder.Width, pnlColorInfoBorder.Height, 15, 15));
            pnlColorInfo.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, pnlColorInfo.Width, pnlColorInfo.Height, 15, 15));
            pnlShowHistory.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, pnlShowHistory.Width, pnlShowHistory.Height, 15, 15));
            pnlShowHistoryBorder.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, pnlShowHistoryBorder.Width, pnlShowHistoryBorder.Height, 15, 15));
            btnPickColor.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, btnPickColor.Width, btnPickColor.Height, 20, 20));
            btnReturn.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, btnReturn.Width, btnReturn.Height, 20, 20));
            pnlColorShow.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, pnlColorShow.Width, pnlColorShow.Height, 15, 15));

            // Layout
            pnlMain.Location = new Point(10, 93);
            pnlHistory.Visible = false;
            pnlHistory.Location = new Point(10, 93);

            // Chargement initial via le contrôleur
            _formControler.LoadHistoryPanels(pnlShowHistory);
            _formControler.LoadLastPickedColor(lblColorHexa, pnlColorShow);
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
            notifyIcon.Visible = true;
        }

        private void quitAppToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pickColorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _formControler.PickColor(lblColorHexa, pnlColorShow);
        }

        private void btnPickColor_Click(object sender, EventArgs e)
        {
            _formControler.PickColor(lblColorHexa, pnlColorShow);
        }

        private void notifyIcon_Click(object sender, EventArgs e)
        {
            this.Visible = true;
            this.WindowState = FormWindowState.Normal;
            this.Activate();
            _formControler.LoadHistoryPanels(pnlShowHistory);
        }

        private void frmColorPicker_Deactivate(object sender, EventArgs e)
        {
            this.Hide();
        }

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
                await Task.Delay(2000);
                lblColorCopied.Visible = false;
            }
        }

        private void historyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _formControler.LoadHistoryPanels(pnlShowHistory);
            pnlHistory.Visible = !pnlHistory.Visible;
            pnlMain.Visible = !pnlHistory.Visible;
        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            _formControler.LoadHistoryPanels(pnlShowHistory);
            pnlHistory.Visible = !pnlHistory.Visible;
            pnlMain.Visible = !pnlHistory.Visible;
        }

        private void optionsToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}