using System;
using System.Collections.Generic;
using System.Text;

namespace GalaxyLib.PubSub
{
    public abstract class BasePublisher<T> : IPublisher<T> where T : EventArgs
    {
        public string Id { get; }

        public event EventHandler<T> OnPublish;

        protected T Args;

        protected BasePublisher(string id, EventHandler<T> eventHandler)
        {
            Id = id;
            OnPublish += eventHandler;
        }

        protected BasePublisher(string id, EventHandler<T> eventHandler, T args)
        {
            Id = id;
            OnPublish += eventHandler;
            Args = args;
        }

        public void Raise()
        {
            OnPublish?.Invoke(this, Args);
        }
    }
}
