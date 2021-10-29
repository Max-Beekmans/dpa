﻿using System;
using System.Threading;
using GalaxyLib.AppCommands;
using GalaxyLib.Collision;
using GalaxyLib.Model;
using GalaxyLib.Movement;
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
        
        public MovementContext MovementContext { get; set; }

        public CollisionContext CollisionContext { get; set; }

        private static Simulation _instance;
        private static object _lock = new object();
        private static bool _running = true;
        private static bool _paused = false;
        
        private const int FPS = 60;
        private int _msPerTick;

        private Simulation()
        {   
            KeyMap = new KeyMap(this);
            double tick = 1000 / FPS;
            _msPerTick = (int) Math.Round(tick);
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
            if (string.IsNullOrWhiteSpace(PayloadLocation))
                throw new Exception("Can't start without payload location");

            if (ParseStrategy == null)
                throw new Exception("Can't start without Payload strategy");

            if (FileStrategy == null)
                throw new Exception("Can't start without File strategy");

            var payload = FileStrategy.GetPayload(PayloadLocation);
            Galaxy = ParseStrategy.ParsePayload(payload);
            MovementContext = new MovementContext();
            CollisionContext = new CollisionContext(new NaiveCollision());
            Galaxy.Attach(MovementContext);
            Galaxy.Attach(CollisionContext);

            var count = 0;

            while(_running)
            {
                var start = DateTime.UtcNow;

                if (!_paused)
                {
                    if (count == 1)
                    {
                        Galaxy.Notify();
                        count = 0;
                    } else
                    {
                        count++;
                    }
                }

                var dt = DateTime.UtcNow - start;

                int sleep = (int)(_msPerTick - dt.TotalMilliseconds);

                if (sleep > 0)
                    Thread.Sleep(sleep);
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
