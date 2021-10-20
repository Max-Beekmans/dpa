using System;
using System.Threading;
using System.Windows.Input;
using GalaxyLib;
using GalaxyLib.Msg;
using GalaxyLib.PubSub;
using GalaxyLib.PubSub.KeyMap;
using GalaxyWindow;

namespace GalaxyConsole
{
    class Program
    {
        private static bool running = true;

        [STAThread]
        static void Main(string[] args)
        {
            const string csvRemoteLocation = "https://firebasestorage.googleapis.com/v0/b/dpa-files.appspot.com/o/planetsExtended.csv?alt=media";
            const string xmlRemoteLocation = "https://firebasestorage.googleapis.com/v0/b/dpa-files.appspot.com/o/planetsExtended.xml?alt=media";
            const string csvFileLocation = "./input/planets.csv";
            const string xmlFileLocation = "./input/planets.xml";

            var sim = new Simulation();

            MessageBroker.Subscribe("");

            //Handle obs logic
            var obs = new AppCmdObserver();
            sim.Attach(obs);

            App a = new App();
            a.Run(new MainWindow());
        }
    }
}
