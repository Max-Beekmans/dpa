using System.Collections.Generic;
using Builder;
using Model;

namespace ParserStrategy
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
            throw new System.NotImplementedException();
        }
    }
}
