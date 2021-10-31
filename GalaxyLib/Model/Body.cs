using GalaxyLib.Movement;
using GalaxyLib.State;
using System;

namespace GalaxyLib.Model
{
    public abstract class Body : IStateActor, IMovementActor, ICelestialBody
    {
        public Guid Id { get; set; }

        public double XPos { get; set; }

        public double YPos { get; set; }

        public double Vx { get; set; }

        public double Vy { get; set; }

        public int Radius { get; set; }

        public string Color { get; set; }

        public Type Type { get; set; }

        public Galaxy Parent { get; set; }

        public StateContext Context { get; set; }

        public ICelestialBody ActorBody { get => this; }

        public ICelestialBody MovementActor { get => this; }

        public void Move()
        {
            XPos += Vx;
            YPos += Vy;
        }

        public void BounceOfVertical()
        {
            Vx *= -1;
        }

        public void BounceOfHorizontal()
        {
            Vy *= -1;
        }

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
