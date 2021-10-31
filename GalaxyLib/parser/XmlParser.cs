using GalaxyLib.Builder;
using GalaxyLib.Model;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Xml;

namespace GalaxyLib.Parser
{
    public class XmlParser : IParseStrategy
    {
        public BuildDirector BuildDirector { get; set; }

        public XmlParser()
        {
            BuildDirector = new BuildDirector(); ;
        }

        public Galaxy ParsePayload(string payload)
        {
            var xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(payload);

            var galaxyElement = xmlDoc.SelectSingleNode("//galaxy");

            if (galaxyElement == null)
            {
                Console.WriteLine("Can't find galaxy element");
                return null;
            }

            var bodyElements = galaxyElement.ChildNodes;

            for (int i = 0; i < bodyElements.Count; i++)
            {
                var elem = bodyElements[i];
                var nameElem = elem.SelectSingleNode("name");
                var pos = elem.SelectSingleNode("position");
                var xPosElem = pos.SelectSingleNode("x");
                var yPosElem = pos.SelectSingleNode("y");
                var radiusElem = pos.SelectSingleNode("radius");
                var speed = elem.SelectSingleNode("speed");
                var vxElem = speed.SelectSingleNode("x");
                var vyElem = speed.SelectSingleNode("y");
                var neighboursElem = elem.SelectSingleNode("neighbours");
                var colorElem = elem.SelectSingleNode("color");
                var oncollisionElem = elem.SelectSingleNode("oncollision");

                List<string> neighbours = new List<string>();

                if (neighboursElem != null)
                {
                    var children = neighboursElem.ChildNodes;

                    for (int j = 0; j < children.Count; j++)
                    {
                        var planetNameElem = children[j];
                        neighbours.Add(planetNameElem.InnerText);
                    }
                }

                double xpos = double.Parse(xPosElem.InnerText, CultureInfo.InvariantCulture);
                double ypos = double.Parse(yPosElem.InnerText, CultureInfo.InvariantCulture);
                double vx = double.Parse(vxElem.InnerText, CultureInfo.InvariantCulture);
                double vy = double.Parse(vyElem.InnerText, CultureInfo.InvariantCulture);
                string onCollision = oncollisionElem.InnerText;


                if (elem.Name.Equals("planet", StringComparison.InvariantCultureIgnoreCase))
                {
                    string name = nameElem.InnerText;
                    int radius = int.Parse(radiusElem.InnerText);
                    string color = colorElem.InnerText;

                    BuildDirector.BuildPlanet(name, xpos, ypos, vx, vy, onCollision, radius, color, neighbours);
                }
                else if (elem.Name.Equals("asteroid", StringComparison.InvariantCultureIgnoreCase))
                {
                    BuildDirector.BuildAsteroid(xpos, ypos, vx, vy, onCollision);
                }
            }

            return BuildDirector.GetGalaxy();
        }
    }
}
