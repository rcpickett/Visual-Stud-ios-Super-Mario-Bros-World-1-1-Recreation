using DataTypes;
using System.IO;
using System.Xml.Serialization;

namespace Team_Project
{
    public static class LevelLoader
    {
        public static ObjectList[] Load(string filename)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(XnaContentFile));

            using FileStream stream = File.OpenRead(filename);

            XnaContentFile level =
                (XnaContentFile)serializer.Deserialize(stream);

            return level.Asset.Items.ToArray();
        }
    }
}