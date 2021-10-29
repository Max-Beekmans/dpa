using System;
using GalaxyLib.Model;
using GalaxyLib.State;

namespace GalaxyLib.Builder
{
    public interface ICelestialBodyBuilder
    {
        ICelestialBody GetResult();

        ICelestialBodyBuilder BuildStateContext(Galaxy galaxy, string startState);

        ICelestialBodyBuilder SetId();

        ICelestialBodyBuilder SetName(string name);

        ICelestialBodyBuilder SetCoords(double xpos, double ypos);

        ICelestialBodyBuilder SetSpeed(double vx, double vy);

        ICelestialBodyBuilder SetColor(string color);

        ICelestialBodyBuilder SetRadius(int radius);
    }
}
