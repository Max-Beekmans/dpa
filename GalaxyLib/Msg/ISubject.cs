using System.Collections.Generic;

namespace GalaxyLib.Msg
{
    public interface ISubject
    {
        List<IObserver> Observers { get; set; }

        void Attach(IObserver observer);

        void Detach(IObserver observer);

        void Notify();
    }
}
