using System.Collections.Generic;
using System.Linq;
using GalaxyLib.Movement;
using GalaxyLib.Msg;
using GalaxyLib.State;

namespace GalaxyLib.Model
{
    public class Galaxy : BaseSubject
    {
        public List<ICelestialBody> Bodies { get; set; }

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

        public IEnumerable<Planet> Planets
        {
            get
            {
                var planets = new List<Planet>();
                foreach (ICelestialBody body in Bodies)
                {
                    if (body is Planet planet)
                        planets.Add(planet);
                }
                return planets;
            }
        }
        
        public Galaxy() { }

        public Galaxy(List<ICelestialBody> bodies)
        {
            Bodies = bodies;
        }

        public void RemoveBody(ICelestialBody body)
        {
            if (Bodies.Contains(body))
                Bodies.Remove(body);
        }
    }
}
