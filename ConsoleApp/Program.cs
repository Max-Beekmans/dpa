using Builder;
using Model;

namespace ConsoleTestApp
{
    class Program
    {
        static void Main(string[] args)
        {
            const string csvRemoteLocation = "https://firebasestorage.googleapis.com/v0/b/dpa-files.appspot.com/o/planetsExtended.csv?alt=media";
            const string xmlRemoteLocation = "https://firebasestorage.googleapis.com/v0/b/dpa-files.appspot.com/o/planetsExtended.xml?alt=media";
            const string csvFileLocation = "./InputFiles/planets.csv";
            const string xmlFileLocation = "./InputFiles/planets.xml";

            BodyBuilderContext context = new BodyBuilderContext();

            ICelestialBody planet = context.BuildPlanet(45, 310, 0.3, -0.6, 7, "Blue");
            ICelestialBody astroid = context.BuildAstroid(85, 56, 0, -1.5);
        }
    }
}
