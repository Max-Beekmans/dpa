using GalaxyLib.Model;
using GalaxyLib.State;

namespace GalaxyLib.Builder 
{
    public class PlanetBuilder : BaseBodyBuilder
    {
        public PlanetBuilder()
        {
            Current = new Planet();
            Current.Type = typeof(Planet);
        }

        public override ICelestialBodyBuilder AddStateContext(StateContext context)
        {
            ((Planet) Current).StateContext = context;

            return this;
        }

        public override ICelestialBodyBuilder SetName(string name)
        {
            ((Planet) Current).Name = name;

            return this;
        }
    }
}