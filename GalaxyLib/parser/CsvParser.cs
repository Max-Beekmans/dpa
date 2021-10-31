using GalaxyLib.Builder;
using GalaxyLib.Model;
using System.Collections.Generic;
using System.Globalization;

namespace GalaxyLib.Parser
{
    public class CsvParser : IParseStrategy
    {
        private const char _columnDelim = ';';

        private const char _rowDelim = '\r';

        private const char _elementDelim = ',';

        public BuildDirector BuildDirector { get; set; }

        public CsvParser()
        {
            BuildDirector = new BuildDirector();
        }

        public Galaxy ParsePayload(string payload)
        {
            var rows = payload.Split(_rowDelim);
            var indices = GetColumnIndices(rows[0]);

            for (int i = 1; i < rows.Length; i++)
            {
                ParseLine(rows[i], indices);
            }

            return BuildDirector.GetGalaxy();
        }

        private void ParseLine(
            string payload,
            IDictionary<string, int> columnIndices)
        {
            payload = payload.Replace('\n', ' ');
            payload = payload.Trim();

            if (string.IsNullOrWhiteSpace(payload))
                return;

            var line = payload.Split(_columnDelim);

            string type = null;
            string name = null;
            double xpos = -1;
            double ypos = -1;
            double vx = -1;
            double vy = -1;
            int radius = -1;
            string color = null;
            string onCollision = null;
            List<string> neighbours = new List<string>();

            if (columnIndices.TryGetValue("type", out var typeIndex))
                type = line[typeIndex];

            if (columnIndices.TryGetValue("name", out var nameIndex))
                name = line[nameIndex];

            if (columnIndices.TryGetValue("x", out var xIndex))
                xpos = double.Parse(line[xIndex]);

            if (columnIndices.TryGetValue("y", out var yIndex))
                ypos = double.Parse(line[yIndex]);

            if (columnIndices.TryGetValue("vx", out var vxIndex))
                vx = double.Parse(line[vxIndex], CultureInfo.InvariantCulture);

            if (columnIndices.TryGetValue("vy", out var vyIndex))
                vy = double.Parse(line[vyIndex], CultureInfo.InvariantCulture);

            if (columnIndices.TryGetValue("neighbours", out var neighboursIndex))
            {
                string neighbourstr = line[neighboursIndex];

                if (!string.IsNullOrWhiteSpace(neighbourstr))
                {
                    var arr = neighbourstr.Split(_elementDelim);
                    foreach (var str in arr)
                    {
                        neighbours.Add(str);
                    }
                }
            }

            if (columnIndices.TryGetValue("oncollision", out var oncollisionIndex))
                onCollision = line[oncollisionIndex];

            if (columnIndices.TryGetValue("radius", out var radiusIndex))
                radius = int.Parse(line[radiusIndex]);

            if (columnIndices.TryGetValue("color", out var colorIndex))
                color = line[colorIndex];

            switch (type.ToLower())
            {
                case "planet":
                    BuildDirector.BuildPlanet(name, xpos, ypos, vx, vy, onCollision, radius, color, neighbours);
                    break;
                case "asteroid":
                    BuildDirector.BuildAsteroid(xpos, ypos, vx, vy, onCollision);
                    break;
            }
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

        private void SetNeighbours(IList<ICelestialBody> bodyList)
        {
            foreach (var body in bodyList)
            {

            }
        }
    }
}