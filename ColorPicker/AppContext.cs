using System.Windows.Forms;

namespace ColorPicker
{
    public class AppContext : ApplicationContext
    {
        private MainControler _MainControler;

        public AppContext()
        {
            _MainControler = new MainControler(this);
            _MainControler.Run();
        }

        public void ExitApp()
        {
            ExitThread();
        }
    }
}
