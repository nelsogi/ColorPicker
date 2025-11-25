using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ColorPicker
{
    public class MainControler
    {
        private AppContext _appContext;
        private FormControler _formControler;
        private OverlayFormControler _overlayFormControler;

        public MainControler(AppContext appContext)
        {
            _appContext = appContext;
            _formControler = new FormControler(this);
            _overlayFormControler = new OverlayFormControler(this);
        }

        public void Run()
        {
            _formControler.ShowMainForm();
        }
    }
}
