using Model;

namespace Builder
{
    public class BodyBuilderContext
    {
        public BodyBuilderContext()
        {
        }

        public Planet
        BuildPlanet(
            int xpos,
            int ypos,
            double vx,
            double vy,
            int radius,
            string color
        )
        {
            return (Planet)
            new PlanetBuilder()
                .SetCoords(xpos, ypos)
                .SetSpeed(vx, vy)
                .SetRadius(radius)
                .SetColor(color)
                .GetResult();
        }

        public Astroid BuildAstroid(int xpos, int ypos, double vx, double vy)
        {
            return (Astroid)
            new AstroidBuilder()
                .SetCoords(xpos, ypos)
                .SetSpeed(vx, vy)
                .SetRadius(5)
                .SetColor("Black")
                .GetResult();
        }
    }
}
