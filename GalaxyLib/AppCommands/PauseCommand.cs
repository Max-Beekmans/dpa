namespace GalaxyLib.AppCommands
{
    public class PauseCommand : AppCommand
    {
        private readonly Simulation _simulation;

        public PauseCommand(Simulation simulation) : base("Pause")
        {
            _simulation = simulation;
        }

        public override void Execute()
        {
            _simulation.TogglePause();
        }
    }
}
