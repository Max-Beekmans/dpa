using System;
using System.Collections.Generic;
using System.Threading;
using GalaxyLib.AppCommands;
using GalaxyLib.Model;
using GalaxyLib.Msg;
using GalaxyLib.Parser;
using GalaxyLib.PayloadStrategy;

namespace GalaxyLib
{
    public class Simulation : BaseSubject
    {
        public KeyMap KeyMap { get; set; }
        public Galaxy Galaxy { get; set; }
        public string PayloadLocation { get; set; }
        public IParseStrategy ParseStrategy { get; set; }
        public IFileStrategy FileStrategy { get; set; }

        private static Simulation _instance;
        private static object _lock = new object();
        private static bool _running = true;
        private static bool _paused = false;

        private Simulation()
        {   
            KeyMap = new KeyMap(this);
        }

        public static Simulation GetInstance()
        {
            lock(_lock)
            {
                if (_instance != null) return _instance;

                _instance ??= new Simulation();

                return _instance;
            }
        }

        public void Start()
        {
            var count = 0;

            if (string.IsNullOrWhiteSpace(PayloadLocation))
                throw new Exception("Can't start without payload location");

            if (ParseStrategy == null)
                throw new Exception("Can't start without Payload strategy");

            if (FileStrategy == null)
                throw new Exception("Can't start without File strategy");

            var payload = FileStrategy.GetPayload(PayloadLocation);
            Galaxy = ParseStrategy.ParsePayload(payload);

            while(_running)
            {
                if (count > 10)
                {
                    Notify();
                    count = 0;
                }

                if (!_paused)
                {
                    Galaxy.Notify();
                    Console.WriteLine("Something");
                }
                
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
    }
}
