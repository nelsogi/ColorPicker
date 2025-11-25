using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ColorPicker
{
    public class OverlayFormControler
    {
        private MainControler _mainControler;
        private frmColorPicker _mainView;
        private ColorPickerOverlayForm _overlayView;

        public OverlayFormControler(MainControler mainControler)
        {
            _mainControler = mainControler;
            _overlayView = new ColorPickerOverlayForm(this);
        }
    }
}
