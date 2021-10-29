using GalaxyLib.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace GalaxyLib.State
{
    public abstract class BaseBodyState : IState
    {
        public StateContext Context { get; set; }
        public IStateActor Actor { get; set; }
        public string Name { get; }

        public BaseBodyState(string name, StateContext context, IStateActor actor)
        {
            Context = context;
            Actor = actor;
            Name = name;
        }

        public abstract void Execute();

        public virtual void ExecuteOnLeave()
        {
        }
    }
}
