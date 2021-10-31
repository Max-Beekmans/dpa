using GalaxyLib;
using GalaxyLib.Parser;
using GalaxyLib.PayloadStrategy;
using GalaxyWindow;
using System;
using System.Threading;

namespace GalaxyConsole
{
    class Program
    {
        private static Thread _simThread;

        [STAThread]
        static void Main(string[] args)
        {
            const string csvRemoteLocation = "https://firebasestorage.googleapis.com/v0/b/dpa-files.appspot.com/o/planetsExtended.csv?alt=media";
            const string xmlRemoteLocation = "https://firebasestorage.googleapis.com/v0/b/dpa-files.appspot.com/o/planetsExtended.xml?alt=media";
            const string csvFileLocation = "./input/planets.csv";
            const string xmlFileLocation = "./input/planets.xml";

            var sim = Simulation.GetInstance();
            sim.PayloadLocation = xmlFileLocation;
            sim.FileStrategy = new DriveFileStrategy();
            sim.ParseStrategy = new XmlParser();

            _simThread = new Thread(sim.Start) { IsBackground = false, Name = "SimulationThread" };
            _simThread.Start();

            //sim.Start();

            //Handle obs logic

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
