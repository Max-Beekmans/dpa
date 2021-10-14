using System.Collections.Generic;
using GalaxyLib.Builder;
using GalaxyLib.Model;

namespace GalaxyLib.Parser
{
    public class CsvParser : IParseStrategy
    {
        private const char _columnDelim = ';';

        private const char _rowDelim = '\r';

        public BuildDirector BuildDirector { get; set; }

        public CsvParser()
        {
            BuildDirector = new BuildDirector();
        }

        public Galaxy ParsePayload(string payload)
        {
            var rows = payload.Split(_rowDelim);
            var indices = this.GetColumnIndices(rows[0]);
            var bodyList = new List<ICelestialBody>();

            for (int i = 1; i < rows.Length; i++)
            {
                var body = ParseLine(rows[i], indices);

                if (body == null)
                    continue;

                bodyList.Add(body);
            }

            return new Galaxy(bodyList);
        }

        private ICelestialBody
        ParseLine(
            string payload,
            IDictionary<string, int> columnIndices
        )
        {
            payload = payload.Replace('\n', ' ');
            payload = payload.Trim();

            if (string.IsNullOrWhiteSpace(payload))
                return null;

            var line = payload.Split(_columnDelim);

            string type = null;
            string name = null;
            int xpos = -1;
            int ypos = -1;
            double vx = -1;
            double vy = -1;
            int radius = -1;
            string color = null;

            if (columnIndices.TryGetValue("type", out var typeIndex))
                type = line[typeIndex];

            if (columnIndices.TryGetValue("name", out var nameIndex))
                name = line[nameIndex];

            if (columnIndices.TryGetValue("x", out var xIndex))
                xpos = int.Parse(line[xIndex]);

            if (columnIndices.TryGetValue("y", out var yIndex))
                ypos = int.Parse(line[yIndex]);

            if (columnIndices.TryGetValue("vx", out var vxIndex))
                vx = double.Parse(line[vxIndex]);

            if (columnIndices.TryGetValue("vy", out var vyIndex))
                vy = double.Parse(line[vyIndex]);

            // if (columnIndices.TryGetValue("neighbours", out var neighboursIndex))
            //     ypos = int.Parse(line[neighboursIndex]);
            if (columnIndices.TryGetValue("radius", out var radiusIndex))
                radius = int.Parse(line[radiusIndex]);

            if (columnIndices.TryGetValue("color", out var colorIndex))
                color = line[colorIndex];

            switch(type.ToLower()) {
                case "planet":
                    BuildDirector.ChangeBuilder(new PlanetBuilder());
                    break;
                case "asteroid":
                    BuildDirector.ChangeBuilder(new AsteroidBuilder());
                    break;
                default:
                    throw new System.Exception("Unknown type");
            }  

            // if (columnIndices.TryGetValue("oncollision", out var oncollisionIndex))
            //     ypos = int.Parse(line[oncollisionIndex]);
            return BuildDirector
                .Make(type, name, xpos, ypos, vx, vy, radius, color);
        }

        private IDictionary<string, int> GetColumnIndices(string firstRow)
        {
            var indices = new Dictionary<string, int>();
            var columns = firstRow.Split(_columnDelim);

            for (int i = 0; i < columns.Length; i++)
            {
                indices.Add(columns[i].ToLower(), i);
            }

            return indices;
        }
    }
}