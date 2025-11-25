using System.Drawing;
using System.Windows.Forms;

namespace ColorPicker
{
    public partial class ColorPickerOverlayForm : Form
    {
        /// <summary>
        /// Color selected by the user
        /// </summary>
        public Color SelectedColor { get; private set; } = Color.Empty;

        private OverlayFormControler _overlayFormControler;

        /// <summary>
        /// Constructor
        /// </summary>
        public ColorPickerOverlayForm(OverlayFormControler overlayFormControler)
        {
            InitializeComponent();
            ConfigureOverlay();
            _overlayFormControler = overlayFormControler;
        }

        /// <summary>
        /// Configure the overlay form properties
        /// </summary>
        private void ConfigureOverlay()
        {
            
            this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;
            this.TopMost = true;
            this.ShowInTaskbar = false;

            // Put the form to be almost invisible
            this.Opacity = 0.01;

            // Change the cursor to a crosshair
            this.Cursor = Cursors.Cross;
        }

        /// <summary>
        /// Mouse click event to capture the color at the mouse position
        /// </summary>
        /// <param name="e"></param>
        protected override void OnMouseClick(MouseEventArgs e)
        {
            base.OnMouseClick(e);

            if (e.Button == MouseButtons.Left)
            {
                // Mouse position in screen coordinates
                Point mousePos = Cursor.Position;
                SelectedColor = GetColorAtScreenPoint(mousePos);

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        /// <summary>
        /// Capture the color at a specific screen point
        /// </summary>
        /// <param name="screenPoint"></param>
        /// <returns></returns>
        private Color GetColorAtScreenPoint(Point screenPoint)
        {
            using (Bitmap bmp = new Bitmap(1, 1))
            using (Graphics g = Graphics.FromImage(bmp))
            {
                // Copy the pixel from the screen
                g.CopyFromScreen(screenPoint, Point.Empty, new Size(1, 1));
                return bmp.GetPixel(0, 0);
            }
        }

        /// <summary>
        /// Event to handle key presses for cancelling the color picking
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
