using GalaxyLib.Builder;
using GalaxyLib.Movement;
using GalaxyLib.Msg;
using GalaxyLib.State;
using System.Collections.Generic;
using System.Linq;

namespace GalaxyLib.Model
{
    public class Galaxy : BaseSubject
    {
        private List<ICelestialBody> _bodies = new List<ICelestialBody>();

        public List<ICelestialBody> Bodies
        {
            get
            {
                return _bodies;
            }
            set
            {
                _bodies = value;
            }
        }

        public IEnumerable<IMovementActor> MovementActors
        {
            get
            {
                var actorList = new List<IMovementActor>();
                foreach (ICelestialBody body in Bodies)
                {
                    if (body is IMovementActor actor)
                        actorList.Add(actor);
                }
                return actorList;
            }
        }

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

        public void RemoveBody(ICelestialBody body)
        {
            if (Bodies.Contains(body))
                Bodies.Remove(body);
        }

        public Galaxy DeepCopy()
        {
            var newList = new List<ICelestialBody>();
            var buildDirector = new BuildDirector();

            foreach (var body in Bodies)
            {
                IStateActor stateActor = null;

                if (body is IStateActor actor)
                {
                    stateActor = actor;
                }

                if (stateActor != null)
                {
                    switch (body.Type.Name)
                    {
                        case "Asteroid":
                            buildDirector.BuildAsteroid(
                                body.XPos,
                                body.YPos,
                                body.Vx,
                                body.Vy,
                                stateActor.Context.State.Name);

                            break;
                        case "Planet":
                            var planet = (Planet)body;
                            buildDirector.BuildPlanet(
                                planet.Name,
                                body.XPos,
                                body.YPos,
                                body.Vx,
                                body.Vy,
                                stateActor.Context.State.Name,
                                body.Radius,
                                body.Color,
                                planet.Neighbours.Select(x => x.Name).ToList());
                            break;

                    }
                }
                else
                {
                    // Maybe build object without state?
                }
            }

            return buildDirector.GetGalaxy();
        }
    }
}
