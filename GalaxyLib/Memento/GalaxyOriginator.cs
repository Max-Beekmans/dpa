using GalaxyLib.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace GalaxyLib.Memento
{
    public class GalaxyOriginator : IOriginator
    {
        private List<ICelestialBody> _state;

        public GalaxyOriginator(List<ICelestialBody> state)
        {
            _state = state;
        }

        public void Restore(IMemento memento)
        {
            if (!(memento is GalaxyMemento galaxyMemento))
            {
                throw new Exception($"Unknown memento class {memento}");
            }

            _state = galaxyMemento.GetState();
        }

        public IMemento Save()
        {
            return new GalaxyMemento(_state);
        }
    }
}
