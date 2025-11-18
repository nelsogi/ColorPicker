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
            // Rendre le formulaire sans bordure et toujours au-dessus
            this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized; // Couvre tout l'écran
            this.TopMost = true;
            this.ShowInTaskbar = false;

            // Rendre le formulaire complètement transparent pour que l'utilisateur voie ce qu'il y a derrière
            this.Opacity = 0.01; // Presque transparent, mais capte les événements de clic
                                 // Alternative pour une transparence totale si vous gérez le dessin manuellement:
                                 // this.BackColor = Color.Magenta;
                                 // this.TransparencyKey = Color.Magenta; 

            // Changez le curseur pour indiquer qu'un choix est attendu
            this.Cursor = Cursors.Cross;
        }
        protected override void OnMouseClick(MouseEventArgs e)
        {
            base.OnMouseClick(e);

            if (e.Button == MouseButtons.Left)
            {
                // Position de la souris sur l'écran entier
                Point mousePos = Cursor.Position;
                SelectedColor = GetColorAtScreenPoint(mousePos);

                // Fermer ce formulaire de superposition et retourner à l'application principale
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        // Méthode pour capturer la couleur du pixel à une position donnée
        private Color GetColorAtScreenPoint(Point screenPoint)
        {
            using (Bitmap bmp = new Bitmap(1, 1))
            using (Graphics g = Graphics.FromImage(bmp))
            {
                // Copie le pixel exact à la position de l'écran dans le bitmap 1x1
                g.CopyFromScreen(screenPoint, Point.Empty, new Size(1, 1));
                return bmp.GetPixel(0, 0);
            }
        }
    }
}
