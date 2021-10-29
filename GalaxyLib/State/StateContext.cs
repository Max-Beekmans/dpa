using GalaxyLib.Builder;
using GalaxyLib.Model;
using GalaxyLib.State.BodyStates;
using System;
using System.Collections.Generic;

namespace GalaxyLib.State
{
    public class StateContext
    {
        public IState State { get; set; }

        private readonly Dictionary<string, IState> _stateDictionary;

        public StateContext(IStateActor actor, string startState, Galaxy galaxy)
        {
            var blink = new BlinkState(this, actor);
            var bounce = new BounceState(this, actor);
            var disappear = new DisappearState(this, actor, galaxy);
            var explode = new ExplodeState(this, actor, galaxy);
            var grow = new GrowState(this, actor);
            var otherColor = new OtherColorState(this, actor);
            
            _stateDictionary = new Dictionary<string, IState>
            {
                { blink.Name, blink },
                { bounce.Name, bounce },
                { disappear.Name, disappear },
                { explode.Name, explode },
                { grow.Name, grow },
                { otherColor.Name, otherColor }
            };

            ChangeState(startState);
        }

        public void ChangeState(string state)
        {
            if (_stateDictionary.TryGetValue(state, out var stateObj))
            {
                State = stateObj;
            } else
            {
                Console.WriteLine("Couldn't find state");
            }
        }
    }
}
