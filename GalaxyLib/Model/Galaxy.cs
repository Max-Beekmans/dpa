using System.Collections.Generic;

namespace GalaxyLib.Model
{
    public class Galaxy
    {
        public IEnumerable<ICelestialBody> Bodies { get; set; }

        public Galaxy(IEnumerable<ICelestialBody> bodies)
        {
            this.Bodies = bodies;
        }
    }
}