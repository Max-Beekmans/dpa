using GalaxyLib.AppCommands;
using GalaxyLib.Mediator;

namespace GalaxyLib.IOCommands
{
    public class SetConfigCmd : IOCommand
    {
        private readonly IMediator _mediator;
        private readonly EventCmdEnum _ev;
        private readonly string _gesture;

        public SetConfigCmd(IMediator mediator, EventCmdEnum ev, string gesture)
        {
            _mediator = mediator;
            _ev = ev;
            _gesture = gesture;
        }

        public override void Execute()
        {
            _mediator.Notify(_gesture, _ev);
        }
    }
}
