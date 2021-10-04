
using ParserStrategy;
using PayloadStrategy;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            const string csvRemoteLocation = "https://firebasestorage.googleapis.com/v0/b/dpa-files.appspot.com/o/planetsExtended.csv?alt=media";
            const string xmlRemoteLocation = "https://firebasestorage.googleapis.com/v0/b/dpa-files.appspot.com/o/planetsExtended.xml?alt=media";
            const string csvFileLocation = "./input/planets.csv";
            const string xmlFileLocation = "./input/planets.xml";

            IFileStrategy fileStrategy = new DriveFileStrategy();
            IFileStrategy fileStrategy2 = new HttpFilterStrategy();

            var payload = fileStrategy.GetPayload(csvFileLocation);
            var payload2 = fileStrategy2.GetPayload(csvRemoteLocation);

            IParseStrategy parseStrategy = new CsvParser();

            var galaxy = parseStrategy.ParsePayload(payload);
            var galaxy2 = parseStrategy.ParsePayload(payload2);

            
        }
    }
}
