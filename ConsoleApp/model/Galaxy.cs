using System.Collections.Generic;

namespace Model
{
    public class Galaxy
    {
        public IEnumerable<ICelestialBody> bodies { get; set; }
    }
}
