using GalaxyLib.Builder;
using GalaxyLib.Model;
using System;
using System.Collections.Generic;

namespace GalaxyLib.State.BodyStates
{
    public class ExplodeState : BaseBodyState
    {
        private Galaxy _galaxy;
        private BuildDirector _buildDirector;

        public ExplodeState(StateContext context, IStateActor actor, Galaxy galaxy) : base("explode", context, actor)
        {
            _galaxy = galaxy;
            _buildDirector = new BuildDirector();
        }

        public override void Execute()
        {
            for (int i = 0; i < 5; i++)
            {
                var rand = new Random();
                var coin = rand.Next(0, 100);
                var newVx = rand.NextDouble();
                var newVy = rand.NextDouble();
                var radius = rand.Next(7, 15);
                var colorValues = Enum.GetValues(typeof(Colors));
                var colorIndex = rand.Next(0, colorValues.Length - 1);
                var color = (Colors)colorValues.GetValue(colorIndex);


                ICelestialBody body;

                if (coin >= 50)
                {
                    body = _buildDirector.BuildAsteroid(
                        Actor.ActorBody.XPos + (Actor.ActorBody.Radius / 2),
                        Actor.ActorBody.XPos + (Actor.ActorBody.Radius / 2),
                        newVx,
                        newVy,
                        "bounce");
                }
                else
                {
                    body = _buildDirector.BuildPlanet(
                        $"Frits {i}",
                        Actor.ActorBody.XPos + (Actor.ActorBody.Radius / 2),
                        Actor.ActorBody.XPos + (Actor.ActorBody.Radius / 2),
                        newVx,
                        newVy,
                        "bounce",
                        radius,
                        color.ToString(),
                        new List<string>());
                }

                _galaxy.Bodies.Add(body);
            }

            Context.ChangeState("disappear");
        }
    }
}
