using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GalaxyApp
{
    public class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            App a = new App();
            a.StartupUri = new Uri("/MainWindow.xaml", UriKind.Relative);
            a.Run();
        }
    }
}
