using GalaxyLib.Model;

namespace GalaxyLib.Builder
{
    public class AsteroidBuilder : BaseBodyBuilder
    {
        public AsteroidBuilder(Galaxy parent) : base(parent)
        {
            Current = new Asteroid { Type = typeof(Asteroid) };
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
