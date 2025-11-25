using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ColorPicker
{
    public class FormControler
    {
        private MainControler _mainControler;
        private frmColorPicker _mainView;
        private OverlayFormControler _overlayView;

        static string historyFile = "colors.json";

        List<ColorPicked> history = LoadHistory();

        public FormControler(MainControler mainControler)
        {
            _mainControler = mainControler;
            _mainView = new frmColorPicker(this);
        }

        public void ShowMainForm()
        {
            _mainView.WindowState = FormWindowState.Minimized;
            _mainView.ShowInTaskbar = false;

            // Calculate the position
            var screenWorkingArea = Screen.PrimaryScreen.WorkingArea;
            _mainView.Location = new Point((screenWorkingArea.Right - _mainView.Width) - 15, (screenWorkingArea.Bottom - _mainView.Height) - 15);

            
        }

        /// <summary>
        /// Load the color picking history from a JSON file.
        /// </summary>
        /// <returns></returns>
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

        /// <summary>
        /// Load the history panels into the history display panel.
        /// </summary>
        public void loadHistoryPanels(FlowLayoutPanel pnlShowHistory)
        {
            // Configure the history panel for auto-scrolling and wrapping
            pnlShowHistory.AutoScroll = true;
            pnlShowHistory.WrapContents = true;


            pnlShowHistory.Controls.Clear();

            foreach (var color in history.AsEnumerable().Reverse())
            {
                ColorInstancePanel colorPanel = new ColorInstancePanel(color.Rgb, color.Hex);
                pnlShowHistory.Controls.Add(colorPanel);
            }

        }

        public void LoadLastPickedColor(Label lblColorHexa, Panel pnlColorShow)
        {
            // Load the last picked color from history
            if (history != null && history.Count > 0)
            {
                ColorPicked last = history[history.Count - 1]; // Last
                lblColorHexa.Text = last.Hex;
                pnlColorShow.BackColor = ColorTranslator.FromHtml(last.Hex);
            }
        }
    }
}
