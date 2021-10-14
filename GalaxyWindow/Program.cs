using System;

namespace GalaxyWindow
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
