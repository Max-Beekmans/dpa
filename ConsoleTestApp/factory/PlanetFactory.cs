using Model;

namespace Factory
{
    public class PlanetFactory : ICelestialBodyFactory
    {
        public ICelestialBody CreateBody()
        {
            return new Planet();
        }
    }
}
