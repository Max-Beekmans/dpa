using System;
using System.Collections.Generic;
using System.Text;

namespace GalaxyLib.PubSub
{
    public static class MessageBroker
    {
        private static readonly IDictionary<string, IPublisher> Publishers
            = new Dictionary<string, IPublisher>();

        public static void AddChannel(string e, IPublisher pub)
        {
            if (Publishers.TryGetValue(e, out _))
                return;

            Publishers.Add(e, pub);
        }

        public static void Publish(string pub)
        {
            if (!Publishers.TryGetValue(pub, out var publisher))
                return;

            publisher.Raise();
        }

        public static void Subscribe<T>(string e, EventHandler<T> handler)
        {
            if (!Publishers.TryGetValue(e, out var publisher))
                return;

            publisher.Raise();
        }
    }
}
