using System;

namespace GalaxyLib.Model
{
    public interface ICelestialBody
    {
        Guid Id { get; set; }

        [Parse("x")]
        int XPos { get; set; }

        [Parse("y")]
        int YPos { get; set; }

        double Vx { get; set; }

        double Vy { get; set; }

        int Radius { get; set; }

        string Color { get; set; }

        Type Type { get; set; }

        void Introduce();
    }
}
