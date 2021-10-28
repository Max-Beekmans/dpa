using GalaxyLib.AppCommands;

namespace GalaxyLib.Msg
{
    public class GestureObserver : IObserver
    {
        private string _gesture;

        public void Update(ISubject subject)
        {
            if (!(subject is KeyMap keyMap))
                return;

            keyMap.GesturePressed(_gesture);
        }

        public void SetGesture(string gesture)
        {
            _gesture = gesture;
        }
    }
}
