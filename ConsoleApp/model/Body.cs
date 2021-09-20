using System;
using State;

namespace Model
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
            this.XPos = xpos;
            this.YPos = ypos;
            this.Vx = vx;
            this.Vy = vy;
            this.Radius = radius;
            this.Color = color;
            this.Type = type;
        }

        public abstract void Introduce();
    }
}
