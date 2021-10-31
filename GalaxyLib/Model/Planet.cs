using System.Collections.Generic;

namespace GalaxyLib.Model
{
    public class Planet : Body
    {
        public string Name { get; set; }

        public List<Planet> Neighbours { get; set; }

        public Planet()
        {
            Neighbours = new List<Planet>();
        }
    }
}
