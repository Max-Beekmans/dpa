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

        public override ICelestialBodyBuilder SetName(string name)
        {
            return this;
        }

        public ICelestialBodyBuilder SetColor()
        {
            return base.SetColor("black");
        }

        public ICelestialBodyBuilder SetRadius()
        {
            return base.SetRadius(5);
        }
    }
}
