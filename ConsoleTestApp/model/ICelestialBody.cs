using System;

namespace Model
{
    public interface ICelestialBody
    {
        int XPos { get; set; }

        int YPos { get; set; }

        double Vx { get; set; }

        double Vy { get; set; }

        int Radius { get; set; }

        string Color { get; set; }

        Type SubType { get; set; }

        void Introduce();
    }
}
