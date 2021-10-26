using System.Collections.Generic;

namespace GalaxyLib.Msg
{
    public class BaseSubject : ISubject
    {
        public List<IObserver> Observers { get; set; }

        public BaseSubject()
        {
            Observers = new List<IObserver>();
        }

        public void Attach(IObserver observer)
        {
            Observers.Add(observer);
        }

        public void Detach(IObserver observer)
        {
            Observers.Remove(observer);
        }

        public void Notify()
        {
            Observers.ForEach(obs => obs.Update(this));
        }
    }
}
