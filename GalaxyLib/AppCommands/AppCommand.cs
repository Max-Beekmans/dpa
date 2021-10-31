namespace GalaxyLib.AppCommands
{
    public abstract class AppCommand : ICommand
    {
        public string Feature { get; set; }

        protected AppCommand(string feature)
        {
            Feature = feature;
        }

        public abstract void Execute();
    }
}
