using System;
using System.Collections.Generic;
using System.Text;

namespace GalaxyLib.Memento
{
    public class GalaxyCareTaker
    {
        private Stack<IMemento> _history;

        private GalaxyOriginator _originator;

        public GalaxyCareTaker(GalaxyOriginator originator)
        {
            _history = new Stack<IMemento>();
            _originator = originator;
        }

        public void Bookmark()
        {
            _history.Push(_originator.Save());
        }

        public void Restore()
        {
            if (_history.Count == 0)
                return;

            var memento = _history.Pop();
            _originator.Restore(memento);
        }
    }
}
