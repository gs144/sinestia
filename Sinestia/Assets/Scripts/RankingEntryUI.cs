using UnityEngine;
using UnityEngine.UI;
namespace Sinestia.Rankings
{
    public class RankingEntryUI : MonoBehaviour
    {
        [SerializeField] private Text entryNameText = null;
        [SerializeField] private Text entryScoreText = null;

        public void Initialise(RankingEntryData rankingEntryData)
        {
            entryNameText.text = rankingEntryData.entryName;
            entryScoreText.text = rankingEntryData.entryScore.ToString();
        }
    }
}
