using UnityEngine;
using TMPro;

public class LeaderboardUI : MonoBehaviour
{
    [SerializeField] TMP_Text leaderboardText;

    void Start()
    {
        ScoreList list = LeaderboardManager.LoadScores();

        leaderboardText.text = "TOP SCORES\n";

        for (int i = 0; i < list.scores.Count; i++)
        {
            leaderboardText.text += (i + 1) + ". " + list.scores[i].playerName +
                " - " + Mathf.FloorToInt(list.scores[i].distance) + "m\n";
        }
    }
}