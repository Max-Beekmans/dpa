
using System;
using System.Collections.Generic;
using System.Text;

namespace GalaxyLib.AppCommands
{
    public class SpeedDownCommand : AppCommand
    {
        private readonly Simulation _simulation;

        public SpeedDownCommand(Simulation simulation) : base("SpeedDown")
        {
            _simulation = simulation;
        }

        public override void Execute()
        {
            _simulation.SpeedDown();
        }
    }
}
