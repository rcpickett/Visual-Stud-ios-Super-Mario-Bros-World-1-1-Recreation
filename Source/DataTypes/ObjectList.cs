using Microsoft.Xna.Framework;
using System;
using System.Globalization;
using System.Xml.Serialization;

namespace DataTypes
{
    public class ObjectList
    {
        public string Type { get; set; }

        [XmlElement("Location")]
        public string LocationRaw { get; set; }

        public string AdditionalInfo { get; set; }

        [XmlIgnore]
        public Vector2 Location
        {
            get
            {
                if (string.IsNullOrWhiteSpace(LocationRaw))
                    return Vector2.Zero;

                var parts = LocationRaw.Split(' ', StringSplitOptions.RemoveEmptyEntries);

                if (parts.Length < 2)
                    return Vector2.Zero;

                return new Vector2(
                    float.Parse(parts[0], CultureInfo.InvariantCulture),
                    float.Parse(parts[1], CultureInfo.InvariantCulture)
                );
            }
        }
    }
}