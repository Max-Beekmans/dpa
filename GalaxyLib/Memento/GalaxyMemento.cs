using GalaxyLib.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace GalaxyLib.Memento
{
    public class GalaxyMemento : IMemento
    {
        List<ICelestialBody> _state;

        public GalaxyMemento(List<ICelestialBody> state)
        {
            _state = state;
            Name = "GalaxyMemento";
        }

        public string Name { get; set; }

        public List<ICelestialBody> GetState()
        {
            return _state;
        }
    }
}
