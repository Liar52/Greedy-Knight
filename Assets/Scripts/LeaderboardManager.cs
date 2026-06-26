using UnityEngine;

public class LeaderboardManager : MonoBehaviour
{
    private const string SAVE_KEY = "Leaderboard";
    private const int MAX_ENTRIES = 5; // cuántos puestos guarda el top

    public static void SaveScore(string playerName, float distance)
    {
        ScoreList list = LoadScores();

        list.scores.Add(new ScoreEntry { playerName = playerName, distance = distance });

        // ordena de mayor a menor distancia
        list.scores.Sort((a, b) => b.distance.CompareTo(a.distance));

        // recorta para quedarse solo con el top
        if (list.scores.Count > MAX_ENTRIES)
            list.scores.RemoveRange(MAX_ENTRIES, list.scores.Count - MAX_ENTRIES);

        string json = JsonUtility.ToJson(list);
        PlayerPrefs.SetString(SAVE_KEY, json);
        PlayerPrefs.Save();
    }

    public static ScoreList LoadScores()
    {
        if (PlayerPrefs.HasKey(SAVE_KEY))
        {
            string json = PlayerPrefs.GetString(SAVE_KEY);
            return JsonUtility.FromJson<ScoreList>(json);
        }
        return new ScoreList();
    }
}