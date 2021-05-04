using System;
using System.Collections.Generic;

namespace Sinestia.Rankings
{
    [Serializable]
    public class RankingSaveData
    {
        public List<RankingEntryData> highscores = new List<RankingEntryData>();
    }
}