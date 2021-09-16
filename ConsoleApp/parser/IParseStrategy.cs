using Builder;
using Model;

namespace ParserStrategy
{
    public interface IParseStrategy : IStrategy
    {
        BodyBuilderContext BuildContext { get; set; }

        Galaxy ParseString(string payload, BodyBuilderContext buildContext = null);

        ICelestialBody ParseLine(string payload, BodyBuilderContext buildContext = null);
    }
}
