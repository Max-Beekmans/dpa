using System;
using GalaxyLib.Movement;
using GalaxyLib.State;

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

        public StateContext context { get; set; }

        protected Body()
        {
        }

        protected Body(
            int xpos,
            int ypos,
            double vx,
            double vy,
            int radius,
            StateContext stateContext,
            string color,
            Type type
        )
        {
            XPos = xpos;
            YPos = ypos;
            Vx = vx;
            Vy = vy;
            Radius = radius;
            context = stateContext;
            Color = color;
            Type = type;
        }

        public void ExecuteState()
        {
            context.State.Execute();
        }

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
    }
}
