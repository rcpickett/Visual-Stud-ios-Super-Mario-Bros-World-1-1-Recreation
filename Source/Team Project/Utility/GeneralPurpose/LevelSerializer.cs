using DataTypes;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace Team_Project
{
    [XmlRoot("XnaContent")]
    public class XnaContentFile
    {
        [XmlElement("Asset")]
        public XnaAsset Asset { get; set; }
    }

    public class XnaAsset
    {
        [XmlElement("Item")]
        public List<ObjectList> Items { get; set; } = new();
    }
}