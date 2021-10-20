using System;

namespace GalaxyLib.PubSub.KeyMap
{
    public class KeyMapPublisher : IPublisher<KeyMapPayload>
    {
        public string Id { get; }

        public event EventHandler<KeyMapPayload> OnPublish;

        public KeyMapPublisher()
        {
            Id = "KeyMap";
        }

        public void Raise()
        {
            
        }
    }
}
