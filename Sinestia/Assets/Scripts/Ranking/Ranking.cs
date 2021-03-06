using UnityEngine;
using System.IO;



    public class Ranking : MonoBehaviour
    {
        //public Ranking ranking;
        [SerializeField] private int maxScoreboardEntries = 5;
        [SerializeField] private Transform rankingHolderTransform = null;
        [SerializeField] private GameObject rankingEntryObject = null;

        

        private string SavePath => $"{Application.persistentDataPath}/highscores.json";

        private void Start()
        {
            RankingSaveData savedScores = GetSavedScores();
            
            
            SaveScores(savedScores);

            UpdateUI(savedScores);
        }

        

        public void AddEntry(RankingEntryData rankingEntryData)
        {
            RankingSaveData savedScores = GetSavedScores();

            bool scoreAdded = false;

            for (int i = 0; i < savedScores.highscores.Count; i++)
            {
                if (rankingEntryData.entryScore > savedScores.highscores[i].entryScore)
                {
                    savedScores.highscores.Insert(i, rankingEntryData);
                    scoreAdded = true;
                    break;
                }
            }

            if (!scoreAdded && savedScores.highscores.Count < maxScoreboardEntries)
            {
                savedScores.highscores.Add(rankingEntryData);
            }

            if (savedScores.highscores.Count > maxScoreboardEntries)
            {
                savedScores.highscores.RemoveRange(maxScoreboardEntries, savedScores.highscores.Count - maxScoreboardEntries);
            }

            
            SaveScores(savedScores);
        }

        private void UpdateUI(RankingSaveData savedScores)
        {
            foreach (Transform child in rankingHolderTransform)
            {
                Destroy(child.gameObject);
            }

            foreach (RankingEntryData highscore in savedScores.highscores)
            {
                Instantiate(rankingEntryObject, rankingHolderTransform).GetComponent<RankingEntryUI>().Initialise(highscore);
            }
        }

        private RankingSaveData GetSavedScores()
        {
            if (!File.Exists(SavePath))
            {
                File.Create(SavePath).Dispose();
                return new RankingSaveData();
            }

            using (StreamReader stream = new StreamReader(SavePath))
            {
                string json = stream.ReadToEnd();

                return JsonUtility.FromJson<RankingSaveData>(json);
            }
        }

        private void SaveScores(RankingSaveData rankingSaveData)
        {
            using (StreamWriter stream = new StreamWriter(SavePath))
            {
                string json = JsonUtility.ToJson(rankingSaveData, true);
                stream.Write(json);
            }
        }
    }
