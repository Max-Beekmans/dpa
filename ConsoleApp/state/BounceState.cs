using System;

namespace State
{
    public class BounceState : IState
    {
        public void Execute()
        {
            Console.WriteLine($"I'm a {typeof (BounceState)}");
        }
    }
}
