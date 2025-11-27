using System;
using System.Drawing;
using System.Windows.Forms;

namespace ColorPicker
{
    public partial class ColorPickerOverlayForm : Form
    {
        public Color SelectedColor { get; private set; } = Color.Empty;

        public ColorPickerOverlayForm()
        {
            InitializeComponent();
            ConfigureOverlay();
        }

        private void ConfigureOverlay()
        {
            this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;
            this.TopMost = true;
            this.ShowInTaskbar = false;

            this.Opacity = 0.01;
            this.Cursor = Cursors.Cross;
        }

        protected override void OnMouseClick(MouseEventArgs e)
        {
            base.OnMouseClick(e);

            if (e.Button == MouseButtons.Left)
            {
                Point mousePos = Cursor.Position;
                SelectedColor = GetColorAtScreenPoint(mousePos);

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private Color GetColorAtScreenPoint(Point screenPoint)
        {
            using (Bitmap bmp = new Bitmap(1, 1))
            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.CopyFromScreen(screenPoint, Point.Empty, new Size(1, 1));
                return bmp.GetPixel(0, 0);
            }
        }

        private void ColorPickerOverlayForm_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Escape)
            {
                this.DialogResult = DialogResult.Cancel;
                this.Close();
            }
        }
    }
}