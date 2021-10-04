using System;

namespace GalaxyMsgLib
{
    public interface IObserver
    {
        void Update(ISubject subject);
    }
}
