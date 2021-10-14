using GalaxyLib.Model;
using GalaxyLib.State;

namespace GalaxyLib.Builder
{
    public interface ICelestialBodyBuilder
    {
        ICelestialBody GetResult();

        ICelestialBodyBuilder AddStateContext(StateContext context);

        ICelestialBodyBuilder SetName(string name);

        ICelestialBodyBuilder SetCoords(int xpos, int ypos);

        ICelestialBodyBuilder SetSpeed(double vx, double vy);

        ICelestialBodyBuilder SetColor(string color);

        ICelestialBodyBuilder SetRadius(int radius);
    }
}
