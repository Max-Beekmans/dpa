namespace GalaxyLib.State.BodyStates
{
    public class OtherColorState : BaseBodyState
    {
        private string _ogColor;

        public OtherColorState(StateContext context, IStateActor actor) : base("othercolor", context, actor)
        {
            _ogColor = actor.ActorBody.Color;
        }

        public override void Execute()
        {
            Actor.ActorBody.Color = _ogColor;
            Context.ChangeState("blink");
        }
    }
}
