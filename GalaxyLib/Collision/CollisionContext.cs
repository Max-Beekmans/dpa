using GalaxyLib.Model;
using GalaxyLib.Msg;
using GalaxyLib.State;
using System.Collections.Generic;

namespace GalaxyLib.Collision
{
    public class CollisionContext: IObserver
    {
        private ICollisionStrategy _collisionStrategy;
        private List<IStateActor> _collided;

        public CollisionContext(ICollisionStrategy strategy)
        {
            _collisionStrategy = strategy;
            _collided = new List<IStateActor>();
        }

        public void Update(ISubject subject)
        {
            var collided = _collided;

            if (subject is Galaxy galaxy)
            {
                foreach (var stateActor in galaxy.StateActors)
                {
                    if (_collisionStrategy.Collides(stateActor.ActorBody, galaxy.Bodies, out var collidedBody) && !collided.Contains(stateActor))
                    {
                        stateActor.EnterCollision();

                        collided.Add(stateActor);
                    }
                }

                for (int i = 0; i < collided.Count; i++)
                {
                    var stateActor = collided[i];

                    if (!_collisionStrategy.Collides(stateActor.ActorBody, galaxy.Bodies, out var collidedBody))
                    {
                        stateActor.LeaveCollision();

                        collided.Remove(stateActor);
                    }
                }
            }
        }
    }
}
