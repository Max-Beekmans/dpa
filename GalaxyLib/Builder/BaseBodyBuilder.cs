using GalaxyLib.Model;
using GalaxyLib.State;
using System;

namespace GalaxyLib.Builder
{
    public abstract class BaseBodyBuilder : ICelestialBodyBuilder
    {
        protected ICelestialBody Current { get; set; }

        private Galaxy _galaxy { get; set; }

        protected BaseBodyBuilder(Galaxy parent)
        {
            _galaxy = parent;
        }

        public abstract ICelestialBodyBuilder SetName(string name);

        public ICelestialBodyBuilder BuildStateContext(string startState)
        {
            var stateActor = (IStateActor)Current;

            stateActor.Context = new StateContext(stateActor, startState, _galaxy);

            return this;
        }

        public ICelestialBodyBuilder SetId()
        {
            Current.Id = Guid.NewGuid();

            return this;
        }

        public ICelestialBody GetResult()
        {
            return Current;
        }

        public virtual ICelestialBodyBuilder SetColor(string color)
        {
            Current.Color = color;

            return this;
        }

        public virtual ICelestialBodyBuilder SetCoords(double xpos, double ypos)
        {
            Current.XPos = xpos;
            Current.YPos = ypos;

            return this;
        }

        public virtual ICelestialBodyBuilder SetRadius(int radius)
        {
            Current.Radius = radius;

            return this;
        }

        public virtual ICelestialBodyBuilder SetSpeed(double vx, double vy)
        {
            Current.Vx = vx;
            Current.Vy = vy;

            return this;
        }
    }
}