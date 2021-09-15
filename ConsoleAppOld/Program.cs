using System;

namespace dpa
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            ICelestialBody planet = new Planet(45, 310, 0.3, -0.6, 7, "Blue", null);
            ICelestialBody planet2 = new Planet(60, 102, 0.1, 0.2, 15, "Orange", null);
            ICelestialBody astroid = new Astroid(85, 56, 0, -1.5);

            Nameable planetName = new Nameable(planet, "Kobol");
            Nameable planetName2 = new Nameable(planet2, "Namek");

            List<Nameable> names = new List<Nameable> {
                planetName, planetName2
            };

            foreach (var item in names)
            {
                names.Introduce();
            }
        }
    }
}
