using System;
using GalaxyLib.State;

namespace GalaxyLib.Model
{
    public abstract class Body : StateActor, ICelestialBody
    {
        public int XPos { get; set; }

        public int YPos { get; set; }

        public double Vx { get; set; }

        public double Vy { get; set; }

        public int Radius { get; set; }

        public string Color { get; set; }

        public Type Type { get; set; }

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
        ) :
            base(stateContext)
        {
            XPos = xpos;
            YPos = ypos;
            Vx = vx;
            Vy = vy;
            Radius = radius;
            Color = color;
            Type = type;
        }

        public abstract void Introduce();
    }
}
