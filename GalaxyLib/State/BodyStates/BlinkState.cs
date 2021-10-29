using System;
using System.Collections.Generic;

namespace GalaxyLib.State.BodyStates
{
    public class BlinkState : BaseBodyState
    {
        private List<string> _colors = new List<string>
        {
            "blue", "orange", "grey", "brown", "pink", "purple", "black"
        };

        private string _ogColor;

        public BlinkState(StateContext context, IStateActor actor) : base("blink", context, actor)
        {
            _ogColor = actor.ActorBody.Color;
        }

        public override void Execute()
        {
            var i = new Random().Next(0, _colors.Count - 1);
            Actor.ActorBody.Color = _colors[i];
        }

        public override void ExecuteOnLeave()
        {
            Actor.ActorBody.Color = _ogColor;
        }
    }
}
