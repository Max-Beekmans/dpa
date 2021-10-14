using GalaxyLib.PayloadStrategy;

namespace GalaxyLib.IOCommands
{
    public class PayloadStratCmd : ICommand
    {
        private readonly IFileStrategy _strategy;
        private readonly string _loc;

        public PayloadStratCmd(IFileStrategy fileStrategy, string location)
        {
            _strategy = fileStrategy;
            _loc = location;
        }

        public void Execute()
        {
            var payload = _strategy.GetPayload(_loc);
        }
    }
}
