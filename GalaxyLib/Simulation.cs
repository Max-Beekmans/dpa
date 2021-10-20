using System;
using System.Collections.Generic;
using System.Threading;
using GalaxyLib.AppCommands;
using GalaxyLib.IOCommands;
using GalaxyLib.Msg;
using GalaxyLib.PubSub;
using GalaxyLib.PubSub.KeyMap;

namespace GalaxyLib
{
    public class Simulation : ISubject
    {
        private static bool _running = true;
        private bool _paused = false;
        private Thread _simThread;

        public IDictionary<AppCommand, string> AppCmdDictionary;

        private List<IObserver> _observers = new List<IObserver>();

        public Simulation()
        {
            _simThread = new Thread(Start) {IsBackground = true, Name = "SimulationThread"};
            _simThread.Start();

            AppCmdDictionary = new Dictionary<AppCommand, string>
            {
                {
                    new PauseCommand(this),
                    "P"
                },
                {
                    new ResumeCommand(this),
                    "S"
                }
            };

            MessageBroker.AddChannel("KeyMap", new KeyMapPublisher(());
        }

        private void Start()
        {
            var count = 0;

            while(_running)
            {
                if (count > 10)
                {
                    Notify();
                    count = 0;
                }

                Console.WriteLine("Something: " + _simThread.Name);
                Thread.Sleep(1000);
                count++;
            }
        }

        public void Stop()
        {
            //cleanup
            _running = false;
        }

        public void Pause()
        {
            if (!_paused) 
                _paused = true;
        }

        public void Resume()
        {
            if (_paused)
                _paused = false;
        }

        public void Attach(IObserver observer)
        {
            _observers.Add(observer);
        }

        public void Detach(IObserver observer)
        {
            _observers.Remove(observer);
        }

        public void Notify()
        {
            foreach (var obs in _observers)
            {
                obs.Update(this);
            }
        }

        public void SetKeyBindings(Dictionary<AppCommand, string> bindings)
        {
            AppCmdDictionary = bindings;
        }
    }
}
