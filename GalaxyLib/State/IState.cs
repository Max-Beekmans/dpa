using GalaxyLib.Model;

namespace GalaxyLib.State
{
    public interface IState
    {
        string Name { get; }

        StateContext Context { get; set; }

        IStateActor Actor { get; set; }

        void Execute();

        void ExecuteOnLeave();
    }
}
