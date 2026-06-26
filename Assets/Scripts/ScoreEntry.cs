using System.Collections.Generic;

[System.Serializable]
public class ScoreEntry
{
    public string playerName;
    public float distance;
}

[System.Serializable]
public class ScoreList
{
    public List<ScoreEntry> scores = new List<ScoreEntry>();
}