using System;
using System.Collections.Generic;
using System.Linq;
using Builder;
using Model;

namespace ParserStrategy
{
    public class CsvParser : IParseStrategy
    {
        private char _columnDelim;

        private char _rowDelim;

        private IDictionary<string, int> _columnIndices;

        public BodyBuilderContext BuildContext { get; set; }

        public CsvParser()
        {
        }

        public CsvParser(
            BodyBuilderContext context,
            char columnDelim = ';',
            char rowDelim = '\r'
        )
        {
            BuildContext = context;
            _columnDelim = columnDelim;
            _rowDelim = rowDelim;
        }

        public ICelestialBody
        ParseLine(string payload, string[] columns, BodyBuilderContext buildContext = null)
        {
            var columns = payload.Split(_columnDelim);
            var props = GetProperties(payload);

            var rows = payload.Split(_rowDelim);
            var firstRow = rows[0].Split(_columnDelim);

            this._columnIndices = this.GetColumnIndices(rows[0]);

            var columnIndices = new Dictionary<string, int>();

            for (int i = 0; i < firstRow.Length; i++)
            {
                columnIndices.Add(firstRow[i], i);
            }

            for (int i = 1; i < rows.Length; i++)
            {
                if (!columnIndices.TryGetValue("type", out var typeIndex))
                    throw new Exception("Type is required!");

                ICelestialBodyBuilder builder;
                string name;
                int xpos;
                int ypos;
                double vx;
                double vy;
                string neighbours;

                if (
                    rows[typeIndex]
                        .Equals("planet",
                        StringComparison.InvariantCultureIgnoreCase)
                )
                {
                    builder = new PlanetBuilder();
                }
                else if (
                    rows[typeIndex]
                        .Equals("astroid",
                        StringComparison.InvariantCultureIgnoreCase)
                )
                {
                    builder = new AstroidBuilder();
                }
                else
                {
                    throw new Exception($"Type: {
                            rows[typeIndex]} isn't supported");
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

                if (
                    !columnIndices
                        .TryGetValue("neighbours", out var neighboursIndex)
                ) throw new Exception("Neighbours is required!");
            }

            for (int i = 0; i < rows.Length; i++)
            {
                var firstRow = rows[0].Split(_columnDelim);
                var columnIndices = new Dictionary<string, int>();

                foreach (var columnHeader in firstRow)
                {
                    columnIndices.Add (columnHeader, i);
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

        public Galaxy
        ParseString(string payload, BodyBuilderContext buildContext = null)
        {
            var rows = payload.Split(_rowDelim);
            this._columnIndices = this.GetColumnIndices(rows[0]);
            
            for (int i = 1; i < rows.Length; i++)
            {
                var line = ParseLine(rows[i], buildContext);
            }

            return new Galaxy();
        }

        private IDictionary<string, int> GetColumnIndices(string firstRow)
        {
            var indices = new Dictionary<string, int>();
            var columns = firstRow.Split(_rowDelim);

            for (int i = 0; i < columns.Length; i++)
            {
                indices.Add(columns[i].ToLower(), i);
            }

            return indices;
        }

        private int GetColumnIndex(string prop)
        {
            if (_columnIndices == null || _columnIndices.Any())
                throw new Exception("Indices are empty");

            if (!_columnIndices.TryGetValue(prop, out var index))
                throw new Exception($"Can't find prop with name: {prop}");

            return index;
        }

        private IDictionary<string, string> GetProperties(string row)
        {
            string[] propertyNames =
                new string[] {
                    "name",
                    "type",
                    "x",
                    "y",
                    "vx",
                    "vy",
                    "neighbours",
                    "radius",
                    "color",
                    "oncollision"
                };

            return GetProperties(row.Split(_columnDelim), propertyNames);
        }

        private IDictionary<string, string>
        GetProperties(string[] row, string[] propertyNames)
        {
            var props = new Dictionary<string, string>();

            foreach (var str in propertyNames)
            {
                var index = GetColumnIndex(str);
                props.Add(str, row[index]);
            }

            return props;
        }
    }
}
