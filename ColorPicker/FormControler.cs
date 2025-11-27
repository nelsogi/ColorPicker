using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Windows.Forms;

namespace ColorPicker
{
    public class FormControler
    {
        private MainControler _mainControler;
        private frmColorPicker _mainView;

        private static string historyFile = "colors.json";
        private List<ColorPicked> history;

        public FormControler(MainControler mainControler)
        {
            _mainControler = mainControler;
            history = LoadHistory();
            _mainView = new frmColorPicker(this);
        }

        public Form MainView => _mainView;

        public void ShowMainForm()
        {
            _mainView.WindowState = FormWindowState.Minimized;
            _mainView.ShowInTaskbar = false;

            var screenWorkingArea = Screen.PrimaryScreen.WorkingArea;
            _mainView.Location = new Point(
                (screenWorkingArea.Right - _mainView.Width) - 15,
                (screenWorkingArea.Bottom - _mainView.Height) - 15
            );
        }

        private static List<ColorPicked> LoadHistory()
        {
            if (!File.Exists(historyFile))
            {
                return new List<ColorPicked>();
            }

            string json = File.ReadAllText(historyFile);
            var list = JsonSerializer.Deserialize<List<ColorPicked>>(json);
            return list ?? new List<ColorPicked>();
        }

        private static void SaveHistory(List<ColorPicked> history)
        {
            var options = new JsonSerializerOptions { WriteIndented = true };
            string json = JsonSerializer.Serialize(history, options);
            File.WriteAllText(historyFile, json);
        }

        public void PickColor(Label lblColorHexa, Panel pnlColorShow)
        {
            using (ColorPickerOverlayForm pickerOverlay = new ColorPickerOverlayForm())
            {
                if (pickerOverlay.ShowDialog() == DialogResult.OK)
                {
                    Color selectedColor = pickerOverlay.SelectedColor;

                    string hex = "#" + (selectedColor.ToArgb() & 0x00FFFFFF).ToString("X6");
                    string rgb = $"{selectedColor.R}, {selectedColor.G}, {selectedColor.B}";

                    ColorPicked colorPicked = new ColorPicked(hex, rgb);
                    history.Add(colorPicked);
                    SaveHistory(history);

                    lblColorHexa.Text = hex;
                    pnlColorShow.BackColor = ColorTranslator.FromHtml(hex);

                    Clipboard.SetText(hex);
                }
            }
        }

        public void LoadHistoryPanels(FlowLayoutPanel pnlShowHistory)
        {
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
            if (history != null && history.Count > 0)
            {
                ColorPicked last = history[history.Count - 1];
                lblColorHexa.Text = last.Hex;
                pnlColorShow.BackColor = ColorTranslator.FromHtml(last.Hex);
            }
        }
    }
}