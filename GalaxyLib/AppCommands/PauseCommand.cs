using System;
using System.Collections.Generic;
using System.Text;

namespace GalaxyLib.AppCommands
{
    public class PauseCommand : AppCommand
    {
        private readonly Simulation _simulation;

        public PauseCommand(Simulation simulation)
        {
            _simulation = simulation;
        }

        public override void Execute()
        {
            _simulation.Pause();
        }
    }
}
