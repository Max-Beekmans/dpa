using GalaxyLib.Model;

namespace GalaxyLib.Builder
{
    public interface ICelestialBodyBuilder
    {
        ICelestialBody GetResult();

        ICelestialBodyBuilder BuildStateContext(string startState);

        ICelestialBodyBuilder SetId();

        ICelestialBodyBuilder SetName(string name);

        ICelestialBodyBuilder SetCoords(double xpos, double ypos);

        ICelestialBodyBuilder SetSpeed(double vx, double vy);

        ICelestialBodyBuilder SetColor(string color);

        ICelestialBodyBuilder SetRadius(int radius);
    }
}
