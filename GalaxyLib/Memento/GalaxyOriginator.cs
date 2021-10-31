using GalaxyLib.Model;
using GalaxyLib.Msg;
using System;
using System.Collections.Generic;

namespace GalaxyLib.Memento
{
    public class GalaxyOriginator : IOriginator
    {
        private Galaxy _state;

        public GalaxyOriginator(Galaxy galaxy)
        {
            _state = galaxy;
        }

        public void Restore(IMemento memento)
        {
            if (!(memento is GalaxyMemento galaxyMemento))
            {
                throw new Exception($"Unknown memento class {memento}");
            }

            _state.Bodies = galaxyMemento.GetState();
        }

        public IMemento Save()
        {
            return new GalaxyMemento(_state.DeepCopy().Bodies);
        }
    }
}
