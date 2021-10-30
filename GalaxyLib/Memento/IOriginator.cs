using System;
using System.Collections.Generic;
using System.Text;

namespace GalaxyLib.Memento
{
    public interface IOriginator
    {
        IMemento Save();

        void Restore(IMemento memento);
    }
}
