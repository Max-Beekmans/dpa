using GalaxyLib.Model;

namespace GalaxyLib.State.BodyStates
{
    public class DisappearState : BaseBodyState
    {
        private Galaxy _galaxy;

        public DisappearState(StateContext context, IStateActor actor, Galaxy galaxy) : base("disappear", context, actor)
        {
            _galaxy = galaxy;
        }

        public override void Execute()
        {
            _galaxy.RemoveBody(Actor.ActorBody);
        }
    }
}
