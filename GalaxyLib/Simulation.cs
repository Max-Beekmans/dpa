using System;

namespace GalaxyLib
{
    public class Simulation
    {
        private bool _running = true;

        public Simulation()
        {

        }

        public void Start()
        {
            while(_running)
            {

            }
        }

        public void Stop()
        {
            //cleanup
            _running = false;
        }
    }
}
