namespace GalaxyLib.State
{
    public abstract class StateActor
    {
        public StateContext StateContext { get; set; }

        public StateActor() { }

        public StateActor(StateContext stateContext)
        {
            StateContext = stateContext;
        }
    }
}
