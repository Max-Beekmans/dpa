using System;

namespace GalaxyLib.PubSub
{
    public interface IPublisher<T> where T : EventArgs
    {
        public string Id { get; }

        public event EventHandler<T> OnPublish;

        public void Raise();
    }
}
