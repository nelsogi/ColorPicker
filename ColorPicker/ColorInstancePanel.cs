using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace ColorPicker
{
    public partial class ColorInstancePanel : UserControl
    {
        private string _hex;
        private string _rgb;

        /// <summary>
        /// Visualisation of the picked color
        /// </summary>
        /// <param name="rgb"></param>
        /// <param name="hex"></param>
        public ColorInstancePanel(string rgb, string hex)
        {
            InitializeComponent();
            
            Region = Region.FromHrgn(frmColorPicker.CreateRoundRectRgn(0, 0, Width, Height, 10, 10));

            _rgb = rgb;
            _hex = hex;

            this.Dock = DockStyle.Top;

            this.BackColor = ColorTranslator.FromHtml(hex);


        }

        /// <summary>
        /// Click event to copy the hex value to clipboard
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ColorInstancePanel_Click(object sender, System.EventArgs e)
        {
            if (_hex != null)
            {
                Clipboard.SetText(_hex);
            }
        }
    }
}
