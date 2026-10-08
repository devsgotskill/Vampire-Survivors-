using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
[Serializable]
public class LeaderboardEntry
{
    public string name;
    public int score;
    public LeaderboardEntry(string name, int score)
    {
        this.name = name;
        this.score = score;
    }
}
[Serializable]
public class LeaderboardData
{
    public List<LeaderboardEntry> entries = new List<LeaderboardEntry>();
}
public class LeaderboardManager : MonoBehaviour
{
    public static LeaderboardManager Instance;
    private string filePath;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            return;
        }
        filePath = Path.Combine(Application.persistentDataPath, "leaderboard.json");
    }
    public void AddScore(string name, int score)
    {
        LeaderboardData data = LoadLeaderboard();
        data.entries.Add(new LeaderboardEntry(name, score));
        data.entries.Sort((a, b) => b.score.CompareTo(a.score));
        string json = JsonUtility.ToJson(data, true);
        File.WriteAllText(filePath, json);
    }
    public LeaderboardData LoadLeaderboard()
    {
        if (!File.Exists(filePath))
        {
            return new LeaderboardData();
        }
        string json = File.ReadAllText(filePath);
        return JsonUtility.FromJson<LeaderboardData>(json);
    }
}