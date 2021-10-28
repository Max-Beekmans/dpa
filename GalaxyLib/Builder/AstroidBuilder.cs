using GalaxyLib.Model;
using GalaxyLib.State;

namespace GalaxyLib.Builder
{
    public class AsteroidBuilder : BaseBodyBuilder
    {
        public AsteroidBuilder()
        {
            Current = new Asteroid {Type = typeof(Asteroid)};
        }

        public override ICelestialBodyBuilder AddStateContext(StateContext context)
        {
            ((Asteroid)Current).context = context;

            return this;
        }

        public override ICelestialBodyBuilder SetName(string name)
        {
            return this;
        }

        public override ICelestialBodyBuilder SetColor(string color)
        {
            return base.SetColor("Black");
        }

        public override ICelestialBodyBuilder SetRadius(int radius)
        {
            return base.SetRadius(5);
        }
    }
}
