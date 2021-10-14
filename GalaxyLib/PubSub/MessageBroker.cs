using System;
using System.Collections.Generic;
using System.Text;

namespace GalaxyLib.PubSub
{
    public static class MessageBroker
    {
        private static IDictionary<string, IEnumerable<ISubscriber>> _subscribers;     

        public static void Publish<T>(IPublisher<T> publisher, T args) where T : EventArgs
        {
            if (!_subscribers.TryGetValue(publisher.Id, out var subscribers))
                return;

            foreach (var sub in subscribers)
            {
            }
        }

        public static void Subscribe()
        {

        }
    }
}
