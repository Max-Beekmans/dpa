namespace State
{
    public class StateContext
    {
        public IState State { get; set; }

        public StateContext(IState state)
        {
            State = state;
        }

        public void ChangeState(IState state)
        {
            this.State = state;
        }
    }
}
