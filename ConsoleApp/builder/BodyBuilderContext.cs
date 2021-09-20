using System.Collections.Generic;
using System.Reflection;
using Model;

namespace Builder
{
    public class BodyBuilderContext
    {
        private BuildDirector _director;

        public BodyBuilderContext()
        {
            _director = new BuildDirector();
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
            _director.ChangeBuilder(new PlanetBuilder());

            return (Planet)
            _director
                .Make(nameof(Planet), name, xpos, ypos, vx, vy, radius, color);
        }

        public Astroid BuildAstroid(int xpos, int ypos, double vx, double vy)
        {
            _director.ChangeBuilder(new AstroidBuilder());

            return (Astroid)
            _director
                .Make(nameof(Astroid), null, xpos, ypos, vx, vy, 0, null);
        }
    }
}
