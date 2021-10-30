using System;
using System.Collections.Generic;
using System.Text;

namespace GalaxyLib.AppCommands
{
    public class SpeedUpCommand : AppCommand
    {
        private readonly Simulation _simulation;

        public SpeedUpCommand(Simulation simulation) : base("SpeedUp")
        {
            _simulation = simulation;
        }

        public override void Execute()
        {
            _simulation.SpeedUp();
        }
    }
}
