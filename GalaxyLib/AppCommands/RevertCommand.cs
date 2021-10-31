using GalaxyLib.Memento;

namespace GalaxyLib.AppCommands
{
    public class RevertCommand : AppCommand
    {
        private GalaxyCareTaker _careTaker;

        public RevertCommand(GalaxyCareTaker galaxyCareTaker) : base("Revert")
        {
            _careTaker = galaxyCareTaker;
        }

        public override void Execute()
        {
            _careTaker.Restore();
        }
    }
}
