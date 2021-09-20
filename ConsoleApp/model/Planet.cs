using System;

namespace Model
{
    public class Planet : Body
    {
        public string Name { get; set; }

        public Planet()
        {
        }

        // public Planet(
        //     int xpos,
        //     int ypos,
        //     double vx,
        //     double vy,
        //     int radius,
        //     string color
        // ) :
        //     base(xpos, ypos, vx, vy, radius, color, typeof(Planet))
        // {
        // }
        public override void Introduce()
        {
            Console.WriteLine($"I'm a {typeof (Planet)}");
        }
    }
}
