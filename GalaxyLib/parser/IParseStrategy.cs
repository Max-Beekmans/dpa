using System.Collections.Generic;
using Builder;
using Model;

namespace ParserStrategy
{
    public interface IParseStrategy : IStrategy
    {
        BuildDirector BuildDirector { get; set; }

        Galaxy ParsePayload(string payload);
    }
}
