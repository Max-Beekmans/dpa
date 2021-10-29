using GalaxyLib.State;
using System;

namespace GalaxyLib.Model
{
    /// <summary>
    ///     Abstract class for entities which participate in the collison
    ///     but don't participate in the movement.
    /// </summary>
    public abstract class IdleBody : IStateActor, ICelestialBody
    {
        public StateContext Context { get; set; }
        public Guid Id { get; set; }
        public double XPos { get; set; }
        public double YPos { get; set; }
        public double Vx { get; set; }
        public double Vy { get; set; }
        public int Radius { get; set; }
        public string Color { get; set; }
        public Type Type { get; set; }

        public ICelestialBody ActorBody { get => this; }

        public void EnterCollision()
        {
            Context.State.Execute();
        }

        public void LeaveCollision()
        {
            Context.State.ExecuteOnLeave();
        }
    }
}
