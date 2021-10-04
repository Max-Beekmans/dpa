using System;

namespace GalaxyLib.Msg
{
    public interface IObserver
    {
        void Update(ISubject subject);
    }
}
