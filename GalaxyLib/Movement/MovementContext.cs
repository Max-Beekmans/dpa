using GalaxyLib.Collision;
using GalaxyLib.Model;
using GalaxyLib.State;

namespace GalaxyLib.Movement
{
    public class MovementContext
    {
        private Galaxy _galaxy;

        public MovementContext(Galaxy galaxy)
        {
            _galaxy = galaxy;
        }

        public void MoveGalaxy()
        {
            foreach (var body in _galaxy.Bodies)
            {
                IMovementActor actor = (IMovementActor) body;

                if (body.XPos <= 0 || body.XPos >= 800)
                    actor.BounceOfVertical();

                if (body.YPos <= 0 || body.YPos >= 600)
                    actor.BounceOfHorizontal();

                actor.Move();
            }
        }
    }
}
