using GalaxyLib.Model;

namespace GalaxyLib.State
{
    /// <summary>
    ///     Actor of the state pattern.
    ///     Participant of the collision logic.
    ///     <para>
    ///     Force abstract class below me to carry a class to itself (given it's a ICelestialBody)
    ///     I struggled allot between downcasting or presenting this reference 
    ///     or doing an entirely different way of communicating to different 'kind' of body.
    ///     </para>
    /// </summary>
    public interface IStateActor
    {
        StateContext Context { get; set; }

        ICelestialBody ActorBody { get; }

        void EnterCollision();

        void LeaveCollision();
    }
}
