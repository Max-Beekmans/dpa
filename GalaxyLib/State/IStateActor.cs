using System;
using System.Collections.Generic;
using System.Text;

namespace GalaxyLib.State
{
    /// <summary>
    ///     Actor of the state pattern.
    ///     Participant of the collision logic.
    /// </summary>
    public interface IStateActor
    {
        StateContext context { get; set; }

        void ExecuteState();
    }
}
