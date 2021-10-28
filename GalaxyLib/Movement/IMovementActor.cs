using System;
using System.Collections.Generic;
using System.Text;

namespace GalaxyLib.Movement
{
    public interface IMovementActor
    {
        public void Move();

        public void BounceOfVertical();

        public void BounceOfHorizontal();
    }
}
