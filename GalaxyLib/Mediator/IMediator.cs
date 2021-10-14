using System;
using System.Collections.Generic;
using System.Text;
using GalaxyLib.AppCommands;

namespace GalaxyLib.Mediator
{
    public interface IMediator
    {
        void Notify(object sender, EventCmdEnum ev);
    }
}
