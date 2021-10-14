using GalaxyLib.Builder;
using GalaxyLib.Model;

namespace GalaxyLib.Parser
{
    public interface IParseStrategy : IStrategy
    {
        BuildDirector BuildDirector { get; set; }

        Galaxy ParsePayload(string payload);
    }
}
