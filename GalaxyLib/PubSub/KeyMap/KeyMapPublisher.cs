using System;

namespace GalaxyLib.PubSub.KeyMap
{
    public class KeyMapPublisher : BasePublisher<KeyMapPayload>
    {
        public KeyMapPublisher(EventHandler<KeyMapPayload> eventHandler) : base(eventHandler)
        {
        }

        public KeyMapPublisher(EventHandler<KeyMapPayload> eventHandler, KeyMapPayload args) : base(eventHandler, args)
        {
        }
    }
}
