using GalaxyLib.Model;

namespace GalaxyLib.Movement
{
    public interface IMovementActor
    {

        /// <summary>
        ///     Force abstract class below me to carry a class to itself (given it's a ICelestialBody).
        ///     I struggled allot between downcasting or presenting this reference
        ///     or doing an entirely different way of communicating to different 'kind' of body.
        /// </summary>
        public ICelestialBody MovementActor { get; }

        public void Move();

        public void BounceOfVertical();

        public void BounceOfHorizontal();
    }
}
