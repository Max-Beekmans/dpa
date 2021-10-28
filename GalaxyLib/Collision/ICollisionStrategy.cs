using GalaxyLib.Model;
using System.Collections.Generic;

namespace GalaxyLib.Collision
{
    public interface ICollisionStrategy
    {
        bool Collides(ICelestialBody body, IEnumerable<ICelestialBody> celestialBodies);
    }
}
