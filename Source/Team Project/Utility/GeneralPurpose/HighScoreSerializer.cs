using System.Collections.Generic;
using System.Xml.Serialization;

namespace DataTypes
{
    [XmlRoot("XnaContent")]
    public class HighScoreRoot
    {
        [XmlElement("Asset")]
        public HighScoreAsset Asset { get; set; }
    }

    public class HighScoreAsset
    {
        [XmlElement("Item")]
        public List<HighScoreList> Items { get; set; } = new();
    }
}