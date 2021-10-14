using System;
using System.Collections.Generic;
using System.Text;
using GalaxyLib.AppCommands;
using GalaxyLib.Msg;

namespace GalaxyLib.Mediator
{
    public class AppObsMediator : IMediator
    {
        private Dictionary<EventCmdEnum, IObserver> _cmdObservers;

        private Simulation _simulation;

        public AppObsMediator(Simulation simulation)
        {
            _cmdObservers = new Dictionary<EventCmdEnum, IObserver>
            {
                {
                    EventCmdEnum.SETKEYCONFIG,
                    new SetConfigObs()
                }
            };

            _simulation = simulation;
        }

        public void Notify(object sender, EventCmdEnum ev)
        {
            switch (ev)
            {
                case EventCmdEnum.SETKEYCONFIG:
                        _simulation.SetKeyBindings((Dictionary<AppCommand, string>) sender);
                    break;
                case EventCmdEnum.PAUSEAPP:
                    break;
                case EventCmdEnum.RESUMEAPP:
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(ev), ev, null);
            }
        }
    }
}
