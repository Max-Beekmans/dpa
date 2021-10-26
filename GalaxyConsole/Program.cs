using System;
using System.Threading;
using System.Windows.Input;
using GalaxyLib;
using GalaxyLib.Msg;
using GalaxyLib.Parser;
using GalaxyLib.PayloadStrategy;
using GalaxyWindow;

namespace GalaxyConsole
{
    class Program
    {
        private static bool running = true;
        private static Thread _simThread;

        [STAThread]
        static void Main(string[] args)
        {
            const string csvRemoteLocation = "https://firebasestorage.googleapis.com/v0/b/dpa-files.appspot.com/o/planetsExtended.csv?alt=media";
            const string xmlRemoteLocation = "https://firebasestorage.googleapis.com/v0/b/dpa-files.appspot.com/o/planetsExtended.xml?alt=media";
            const string csvFileLocation = "./input/planets.csv";
            const string xmlFileLocation = "./input/planets.xml";

            var sim = Simulation.GetInstance();
            sim.PayloadLocation = csvFileLocation;
            sim.FileStrategy = new DriveFileStrategy();
            sim.ParseStrategy = new CsvParser();

            _simThread = new Thread(sim.Start) { IsBackground = false, Name = "SimulationThread" };
            _simThread.Start();

            //sim.Start();

            //Handle obs logic
            var obs = new AppCmdObserver();
            sim.Attach(obs);

            /*var consoleLine = Console.ReadLine();

            while (!consoleLine.Equals("q", StringComparison.OrdinalIgnoreCase))
            {
                obs.Update(sim.KeyMap);

                Console.WriteLine($"Pressed: {consoleLine}");
                consoleLine = Console.ReadLine();
            }*/

            App a = new App();
            a.Run(new MainWindow());
        }
    }
}
