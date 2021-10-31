using GalaxyLib.Model;
using GalaxyLib.Msg;

namespace GalaxyLib.Movement
{
    public class MovementContext : IObserver
    {
        public void Update(ISubject subject)
        {
            if (subject is Galaxy galaxy)
            {
                foreach (var body in galaxy.Bodies)
                {
                    IMovementActor actor = (IMovementActor)body;

                    if (body.XPos <= 0 || body.XPos >= 800)
                        actor.BounceOfVertical();

                    if (body.YPos <= 0 || body.YPos >= 600)
                        actor.BounceOfHorizontal();

                    actor.Move();
                }
            }
        }
    }
}
