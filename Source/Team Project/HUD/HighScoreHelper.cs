using DataTypes;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Serialization;

namespace Team_Project
{
    public class HighScoreHelper
    {
        private readonly List<HighScoreList> highScores;

        public IReadOnlyList<HighScoreList> HighScores => highScores;

        public HighScoreHelper(HighScoreList[] scores)
        {
            highScores = scores.ToList();
            highScores.Sort();
        }

        public bool CheckHighScore(int score)
        {
            return score > highScores.Last().Score;
        }

        public void AddScore(string name, int score)
        {
            highScores.Add(new HighScoreList
            {
                Name = name,
                Score = score,
                TimeStamp = DateTime.Now
            });

            highScores.Sort();

            while (highScores.Count > 10)
                highScores.RemoveAt(highScores.Count - 1);
        }

        public void Save(string filename, IEnumerable<HighScoreList> scores)
        {
            var root = new HighScoreRoot
            {
                Asset = new HighScoreAsset
                {
                    Items = scores.ToList()
                }
            };

            XmlSerializer serializer = new XmlSerializer(typeof(HighScoreRoot));

            using FileStream stream = File.Create(filename);
            serializer.Serialize(stream, root);
        }
    }
}
