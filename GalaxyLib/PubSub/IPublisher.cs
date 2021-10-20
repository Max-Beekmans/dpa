using System;

namespace GalaxyLib.PubSub
{
    public interface IPublisher
    {
        public string Id { get; }

        public void Raise();
    }
}
