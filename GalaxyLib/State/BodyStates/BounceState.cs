using System;

namespace GalaxyLib.State
{
    public class BounceState : IState
    {
        public StateContext context { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public void Execute()
        {
            Console.WriteLine($"I'm a {typeof (BounceState)}");
        }
    }
}
