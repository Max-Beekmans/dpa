using System;
using System.Collections.Generic;
using System.Text;

namespace GalaxyLib.AppCommands
{
    public abstract class AppCommand : ICommand
    {
        public abstract void Execute();
    }
}
