namespace GalaxyLib.State
{
    public interface IState
    {
        StateContext context { get; set; }

        void Execute();
    }
}
