using System;
using System.Collections.Generic;
using System.Text;
using GalaxyLib.AppCommands;
using GalaxyLib.Mediator;

namespace GalaxyLib
{
    public abstract class CommandContext
    {
        protected IMediator Mediator;

        public void SetMediator(IMediator mediator)
        {
            Mediator = mediator;
        }

        public abstract void Pause();

        public abstract void SetKeyConfig(EventCmdEnum ev, string gesture);
    }
}
