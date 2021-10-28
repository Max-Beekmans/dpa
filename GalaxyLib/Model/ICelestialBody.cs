using System;

namespace GalaxyLib.Model
{
    public interface ICelestialBody
    {
        Guid Id { get; set; }

        double XPos { get; set; }

        double YPos { get; set; }

        double Vx { get; set; }

        double Vy { get; set; }

        int Radius { get; set; }

        string Color { get; set; }

        Type Type { get; set; }
    }
}
