using GalaxyLib.Model;

namespace GalaxyLib.State.BodyStates
{
    public class GrowState : BaseBodyState
    {
        public GrowState(StateContext context, IStateActor actor) : base("grow", context, actor)
        {
        }

        public override void Execute()
        {
            Actor.ActorBody.Radius++;

            if (Actor.ActorBody.Radius > 20)
                Context.ChangeState("explode");
        }
    }
}
