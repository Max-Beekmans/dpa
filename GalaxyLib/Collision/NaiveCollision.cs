using GalaxyLib.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace GalaxyLib.Collision
{
    public class NaiveCollision : ICollisionStrategy
    {
        public bool Collides(ICelestialBody body, IEnumerable<ICelestialBody> celestialBodies, out ICelestialBody collidedBody)
        {
            collidedBody = null;

            foreach (var otherBody in celestialBodies)
            {
                if (otherBody == body)
                    continue;

                var dx = body.XPos + body.Radius - (otherBody.XPos + otherBody.Radius);
                var dy = body.YPos + body.Radius - (otherBody.YPos + otherBody.Radius);
                var distance = Math.Sqrt(dx * dx + dy * dy);

                if(distance < body.Radius + otherBody.Radius)
                {
                    collidedBody = otherBody;
                    return true;
                }
            }

            return false;
        }
    }
}
