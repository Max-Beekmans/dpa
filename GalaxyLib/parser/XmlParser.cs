using GalaxyLib.Builder;
using GalaxyLib.Model;

namespace GalaxyLib.Parser
{
    public class XmlParser : IParseStrategy
    {
        public BuildDirector BuildDirector { get; set; }

        public XmlParser() { }

        public XmlParser(BuildDirector director) {
            BuildDirector = director;
        }

        public Galaxy ParsePayload(string payload)
        {
            return null;
        }
    }
}
