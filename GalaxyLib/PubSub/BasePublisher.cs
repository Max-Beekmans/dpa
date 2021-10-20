using System;
using System.Collections.Generic;
using System.Text;

namespace GalaxyLib.PubSub
{
    public abstract class BasePublisher<T> : IPublisher where T : EventArgs
    {
        public string Id { get; }

        public event EventHandler<T> OnPublish;

        protected T Args;

        protected BasePublisher(string id)
        {
            Id = id;
        }

        public void Raise()
        {
            OnPublish?.Invoke(this, Args);
        }
    }
}
