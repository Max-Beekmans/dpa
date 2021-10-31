using GalaxyLib.Model;

namespace GalaxyLib.Builder
{
    public class PlanetBuilder : BaseBodyBuilder
    {
        public PlanetBuilder(Galaxy parent) : base(parent)
        {
            Current = new Planet();
            Current.Type = typeof(Planet);
        }

        public override ICelestialBodyBuilder SetName(string name)
        {
            ((Planet)Current).Name = name;

            return this;
        }
    }
}