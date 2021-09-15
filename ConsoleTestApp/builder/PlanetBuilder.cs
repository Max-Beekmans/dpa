using Model;
using State;

namespace Builder {
    public class PlanetBuilder : BaseBodyBuilder
    {
        public PlanetBuilder()
        {
            Current = new Planet();
            Current.SubType = typeof(Astroid);
        }

        public override ICelestialBodyBuilder AddStateContext(StateContext context)
        {
            ((Planet) Current).StateContext = context;

            return this;
        }

        public override ICelestialBodyBuilder SetColor(string color)
        {
            Current.Color = color;

            return this;
        }

        public override ICelestialBodyBuilder SetRadius(int radius)
        {
            Current.Radius = radius;

            return this;
        }

        public override ICelestialBodyBuilder SetSpeed(double vx, double vy)
        {
            Current.Vx = vx;
            Current.Vy = vy;

            return this;
        }
    }
}