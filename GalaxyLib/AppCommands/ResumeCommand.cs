using System;
using System.Collections.Generic;
using System.Text;

namespace GalaxyLib.AppCommands
{
    public class ResumeCommand : AppCommand
    {
        private readonly Simulation _simulation;

        public ResumeCommand(Simulation simulation)
        {
            _simulation = simulation;
        }

        public override void Execute()
        {
            _simulation.Resume();
        }
    }
}
