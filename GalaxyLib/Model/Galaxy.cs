using System.Collections.Generic;
using GalaxyLib.Movement;
using GalaxyLib.Msg;
using GalaxyLib.State;

namespace GalaxyLib.Model
{
    public class Galaxy : BaseSubject
    {
        public IEnumerable<ICelestialBody> Bodies { get; set; }

        public IEnumerable<IMovementActor> MovementActors { get
            {
                var actorList = new List<IMovementActor>();
                foreach (ICelestialBody body in Bodies)
                {
                    if (body is IMovementActor actor)
                        actorList.Add(actor);
                }
                return actorList;
            } }

        public IEnumerable<IStateActor> StateActors
        {
            get
            {
                var actorList = new List<IStateActor>();
                foreach (ICelestialBody body in Bodies)
                {
                    if (body is IStateActor actor)
                        actorList.Add(actor);
                }
                return actorList;
            }
        }

        public Galaxy(IEnumerable<ICelestialBody> bodies)
        {
            Bodies = bodies;
        }
    }
}
