using Builder;
using Model;

namespace ParserStrategy
{
    public class XmlParser : IParseStrategy
    {
        public BodyBuilderContext BuildContext { get; set; }

        public XmlParser() { }

        public XmlParser(BodyBuilderContext context) {
            BuildContext = context;
        }

        public ICelestialBody ParseLine(string payload, BodyBuilderContext buildContext = null)
        {
            throw new System.NotImplementedException();
        }

        public Galaxy ParseString(string payload, BodyBuilderContext buildContext = null)
        {
            throw new System.NotImplementedException();
        }
    }
}
