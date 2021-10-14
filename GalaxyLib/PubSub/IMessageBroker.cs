using System;
using System.Collections.Generic;
using System.Text;

namespace GalaxyLib.PubSub
{
    public interface IMessageBroker
    {
        void Publish<T>(IPublisher<T> publisher, T args) where T : EventArgs;

        void Subscribe(ISubscriber subscriber);

    }
}
