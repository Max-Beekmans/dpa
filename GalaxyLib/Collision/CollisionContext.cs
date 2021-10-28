using GalaxyLib.Model;
using GalaxyLib.State;
using System;
using System.Collections.Generic;
using System.Text;

namespace GalaxyLib.Collision
{
    public class CollisionContext
    {
        private ICollisionStrategy _collisionStrategy;

        private Galaxy _galaxy;

        public CollisionContext(Galaxy galaxy, ICollisionStrategy strategy)
        {
            _collisionStrategy = strategy;
            _galaxy = galaxy;
        }

        public void HandleCollisions()
        {
            foreach (var celBody in _galaxy.Bodies)
            {
                if(_collisionStrategy.Collides(celBody, _galaxy.Bodies))
                {
                    if (celBody is IStateActor actor)
                    {
                        //actor.ExecuteState();
                    }
                }
            }
        }
    }
}
