using System;
using System.Collections.Generic;
using System.Text;

namespace GalaxyLib.IOCommands
{
    public abstract class IOCommand : ICommand
    {
        public abstract void Execute();
    }
}
