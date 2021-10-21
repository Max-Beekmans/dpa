using System;
using System.Collections.Generic;
using System.Text;
using GalaxyLib;
using GalaxyLib.AppCommands;
using GalaxyLib.Mediator;

namespace GalaxyConsole
{
    public class GalaxyContext : CommandContext
    {
        public override void Pause()
        {
        }

        public override void SetKeyConfig(EventCmdEnum ev, string gesture)
        {
            this.Mediator.Notify(gesture, ev);
        }
    }
}
