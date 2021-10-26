using System.Collections.Generic;
using GalaxyLib.Msg;

namespace GalaxyLib.Model
{
    public class Galaxy : BaseSubject
    {
        public IEnumerable<ICelestialBody> Bodies { get; set; }

        public Galaxy(IEnumerable<ICelestialBody> bodies)
        {
            Bodies = bodies;
        }
    }
}
