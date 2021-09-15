using Model;
using State;

namespace Builder {
    public abstract class BaseBodyBuilder : ICelestialBodyBuilder
    {
        protected ICelestialBody Current { get; set; }

        public abstract ICelestialBodyBuilder AddStateContext(StateContext context);

        public ICelestialBody GetResult() {
            return Current;
        }
        
        public virtual ICelestialBodyBuilder SetColor(string color) {
            Current.Color = color;

            return this;
        }

        public virtual ICelestialBodyBuilder SetCoords(int xpos, int ypos) {
            Current.XPos = xpos;
            Current.YPos = ypos;

            return this;
        }

        public virtual ICelestialBodyBuilder SetRadius(int radius) {
            Current.Radius = radius;

            return this;
        }

        public virtual ICelestialBodyBuilder SetSpeed(double vx, double vy) {
            Current.Vx = vx;
            Current.Vy = vy;

            return this;
        }
    }
}