using System;
using System.Collections.Generic;
using Builder;
using Model;

namespace ConsoleTestApp
{
    class Program
    {
        static void Main(string[] args)
        {
            BodyBuilderContext context = new BodyBuilderContext();

            ICelestialBody planet = context.BuildPlanet(45, 310, 0.3, -0.6, 7, "Blue");
            ICelestialBody astroid = context.BuildAstroid(85, 56, 0, -1.5);
        }
    }
}
