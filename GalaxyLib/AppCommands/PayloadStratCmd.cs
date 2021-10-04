using System;
using System.Collections.Generic;
using System.Text;
using GalaxyLib.PayloadStrategy;

namespace GalaxyLib.AppCommands
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
