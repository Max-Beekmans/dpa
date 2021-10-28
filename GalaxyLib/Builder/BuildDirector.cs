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

        public Planet
            BuildPlanet(
                string name,
                int xpos,
                int ypos,
                double vx,
                double vy,
                int radius,
                string color
            )
        {
            ChangeBuilder(new PlanetBuilder());

            return (Planet) Make("planet", name, xpos, ypos, vx, vy, radius, color);
        }

        public Asteroid
            BuildAsteroid(
                int xpos,
                int ypos,
                double vx,
                double vy)
        {
            ChangeBuilder(new PlanetBuilder());

            return (Asteroid) Make("asteroid", null, xpos, ypos, vx, vy, 5, "black");
        }

        public ICelestialBody
        Make(
            string type,
            string name,
            double xpos,
            double ypos,
            double vx,
            double vy,
            int radius,
            string color
        )
        {
            if (_builder == null)
            {
                throw new Exception("Builder is not set. Can't build body.");
            }

            ICelestialBody body =
                _builder
                    .SetId()
                    .SetName(name)
                    .SetCoords(xpos, ypos)
                    .SetSpeed(vx, vy)
                    .SetRadius(radius)
                    .SetColor(color)
                    .GetResult();

            return type.ToLower() switch
            {
                "planet" => (Planet)body,
                "asteroid" => (Asteroid)body,
                _ => throw new Exception($"Unknown type: {type}"),
            };
        }
    }
}
