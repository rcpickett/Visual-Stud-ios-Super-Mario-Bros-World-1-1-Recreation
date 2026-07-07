using DataTypes;
using System.IO;
using System.Xml.Serialization;

namespace Team_Project
{
    public static class HighScoreLoader
    {
        public static HighScoreList[] Load(string filename)
        {
            XmlSerializer serializer =
                new XmlSerializer(typeof(HighScoreRoot));

            using FileStream stream = File.OpenRead(filename);

            HighScoreRoot root =
                (HighScoreRoot)serializer.Deserialize(stream);

            return root.Asset.Items.ToArray();
        }
    }
}