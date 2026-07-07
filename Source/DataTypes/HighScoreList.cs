using System;

namespace DataTypes
{
    public class HighScoreList : IComparable<HighScoreList>
    {
        public int Score { get; set; }
        public string Name { get; set; }
        public DateTime TimeStamp { get; set; }

        public int CompareTo(HighScoreList other)
        {
            // Highest scores first
            return other.Score.CompareTo(Score);
        }
    }
}