using System;
using System.Collections.Generic;
using System.Linq;
using GalaxyLib.Model;

namespace GalaxyLib.Builder
{
    public class BuildDirector
    {
        private ICelestialBodyBuilder _builder;

        private Galaxy _galaxy;

        private List<Tuple<Planet, List<string>>> _neighbourList;

        private List<ICelestialBody> _bodies;

        public BuildDirector() {
            _neighbourList = new List<Tuple<Planet, List<string>>>();
            _bodies = new List<ICelestialBody>();
            _galaxy = new Galaxy();
        }

        public BuildDirector(ICelestialBodyBuilder builder)
        {
            _builder = builder;
            _neighbourList = new List<Tuple<Planet, List<string>>>();
            _bodies = new List<ICelestialBody>();
            _galaxy = new Galaxy();
        }

        public void ChangeBuilder(ICelestialBodyBuilder builder)
        {
            _builder = builder;
        }

        /// <summary>
        ///     Clears neighbourList and builder.
        ///     Should be done before building a new galaxy.
        /// </summary>
        public void Clear()
        {
            _neighbourList = new List<Tuple<Planet, List<string>>>();
            _bodies = new List<ICelestialBody>();
            _builder = null;
            _galaxy = new Galaxy();

        }

        public Planet
            BuildPlanet(
                string name,
                double xpos,
                double ypos,
                double vx,
                double vy,
                string startState,
                int radius,
                string color,
                List<string> neighbours
            )
        {
            ChangeBuilder(new PlanetBuilder());

            _builder.SetId()
                .SetCoords(xpos, ypos)
                .SetSpeed(vx, vy)
                .SetName(name)
                .SetRadius(radius)
                .SetColor(color)
                .BuildStateContext(_galaxy, startState);

            var planet = (Planet)_builder.GetResult();

            _neighbourList.Add(new Tuple<Planet, List<string>>(planet, neighbours));
            _bodies.Add(planet);

            return planet;
        }

        public Asteroid
            BuildAsteroid(
                double xpos,
                double ypos,
                double vx,
                double vy,
                string startState)
        {
            ChangeBuilder(new AsteroidBuilder());

            var asteroidBuilderRef = (AsteroidBuilder)_builder;

            asteroidBuilderRef.SetColor();
            asteroidBuilderRef.SetRadius();

            _builder.SetId()
                .SetCoords(xpos, ypos)
                .SetSpeed(vx, vy)
                .BuildStateContext(_galaxy, startState);
            
            var asteroid = (Asteroid)_builder.GetResult();

            _bodies.Add(asteroid);
            
            return asteroid;
        }

        public Galaxy GetGalaxy()
        {
            ReferenceNeighbours();
            _galaxy.Bodies = _bodies;
            return _galaxy;
        }

        public void ReferenceNeighbours()
        {
            var planetList = _neighbourList.Select(x => x.Item1).ToList();

            foreach ((var planet, var nameList) in _neighbourList)
            {
                planet.Neighbours = GetNeighbours(nameList, planetList);
            }
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

        private List<Planet> GetNeighbours(List<string> nameList, List<Planet> bodyList)
        {
            var neighbourList = new List<Planet>();

            foreach (var name in nameList)
            {
                var neighbour = bodyList.FirstOrDefault(x => x.Name.Equals(name, StringComparison.InvariantCultureIgnoreCase));

                if (neighbour == null)
                    Console.WriteLine($"Couldn't find neighbour with name: {name}");

                neighbourList.Add(neighbour);
            }

            return neighbourList;
        }
    }
}
