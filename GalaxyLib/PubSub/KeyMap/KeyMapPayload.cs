
using System;
using System.Collections.Generic;
using System.Text;

namespace GalaxyLib.PubSub.KeyMap
{
    public class KeyMapPayload : EventArgs
    {
        public int Value { get; set; }

        public KeyMapPayload(int dict)
        {
            Value = dict;
        }
    }
}
