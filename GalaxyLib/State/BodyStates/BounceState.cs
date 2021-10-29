using GalaxyLib.Model;
using System;

namespace GalaxyLib.State
{
    public class BounceState : BaseBodyState
    {
        private int _count;

        public BounceState(StateContext context, IStateActor actor) : base("bounce", context, actor)
        {
        }

        public override void Execute()
        {
            _count++;
            if (_count > 4)
            {
                Context.ChangeState("blink");
            }

            Actor.ActorBody.Vx *= -1;
            Actor.ActorBody.Vy *= -1;
        }
    }
}
