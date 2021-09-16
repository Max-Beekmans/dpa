using System;
using System.Collections.Generic;
using Builder;
using Model;

namespace ParserStrategy
{
    public class CsvParser : IParseStrategy
    {
        private char _columnDelim;
        private char _rowDelim;

        public BodyBuilderContext BuildContext { get; set; }

        public CsvParser() { }

        public CsvParser(BodyBuilderContext context, char columnDelim = ';', char rowDelim = '\r') {
            BuildContext = context;
            _columnDelim = columnDelim;
            _rowDelim = rowDelim;
        }

        public ICelestialBody ParseLine(string payload, BodyBuilderContext buildContext = null)
        {
            var rows = payload.Split(_rowDelim);
            var firstRow = rows[0].Split(_columnDelim);
            var columnIndices = new Dictionary<string, int>();

            for(int i = 0; i < firstRow.Length; i++) {
                columnIndices.Add(firstRow[i], i);
            }

            for(int i = 1; i < rows.Length; i++) {
                if(!columnIndices.TryGetValue("type", out var typeIndex))
                    throw new Exception("Type is required!");

                ICelestialBodyBuilder builder;
                string name;
                int xpos;
                int ypos;
                double vx;
                double vy;
                string neighbours;    

                if (rows[typeIndex].Equals("planet", StringComparison.InvariantCultureIgnoreCase)) {
                    builder = new PlanetBuilder();
                } else if (rows[typeIndex].Equals("astroid", StringComparison.InvariantCultureIgnoreCase)) {
                    builder = new AstroidBuilder();
                } else {
                    throw new Exception($"Type: {rows[typeIndex]} isn't supported");
                }

                if (!columnIndices.TryGetValue("name", out var nameIndex))
                    throw new Exception("Name is required!");

                if (!columnIndices.TryGetValue("x", out var xIndex))
                    throw new Exception("XPos is required!");

                if (!columnIndices.TryGetValue("y", out var yIndex))
                    throw new Exception("YPos is required!");

                if (!columnIndices.TryGetValue("vx", out var vxIndex))
                    throw new Exception("Vx is required!");

                if (!columnIndices.TryGetValue("vy", out var vyIndex))
                    throw new Exception("Vy is required!");

                if (!columnIndices.TryGetValue("neighbours", out var neighboursIndex))
                    throw new Exception("Neighbours is required!");
            }

            for (int i = 0; i < rows.Length; i++)
            {
                var firstRow = rows[0].Split(_columnDelim);
                var columnIndices = new Dictionary<string, int>();

                foreach (var columnHeader in firstRow)
                {
                    columnIndices.Add(columnHeader, i);
                }
                
            }

            foreach (var row in rows)
            {
                var columns = row.Split(_columnDelim);
            }

            var columns = payload.Split(_columnDelim);
            var columnIndices = new Dictionary<string, int>();
            
            for (int i = 0; i < columns.Length; i++)
            {
                columnIndices.Add(columns[i].ToLower(), i);
            }


        }

        public Galaxy ParseString(string payload, BodyBuilderContext buildContext = null)
        {
            throw new System.NotImplementedException();
        }
    }
}
