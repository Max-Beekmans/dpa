using System;
using GalaxyLib.Model;

namespace GalaxyLib.Builder
{
    public class BuildDirector
    {
        private ICelestialBodyBuilder _builder;

        public BuildDirector() { }

        public BuildDirector(ICelestialBodyBuilder builder)
        {
            _builder = builder;
        }

        public void ChangeBuilder(ICelestialBodyBuilder builder)
        {
            _builder = builder;
        }

        public ICelestialBody
        Make(
            string type,
            string name,
            int xpos,
            int ypos,
            double vx,
            double vy,
            int radius,
            string color
        )
        {
            var body =
                _builder
                    .SetName(name)
                    .SetCoords(xpos, ypos)
                    .SetSpeed(vx, vy)
                    .SetRadius(radius)
                    .SetColor(color)
                    .GetResult();

            switch (type.ToLower())
            {
                case "planet":
                    return (Planet) body;
                case "asteroid":
                    return (Asteroid) body;
                default:
                    throw new Exception($"Unknown type: {type}");
            }
        }
    }
}
