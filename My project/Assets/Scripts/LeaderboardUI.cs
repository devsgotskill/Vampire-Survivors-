using UnityEngine;
using TMPro;

public class LeaderboardUI : MonoBehaviour
{
    public Transform content;
    public GameObject leaderboardEntryPrefab;
    private void Start()
    {
        LoadLeaderboard();
    }
    public void LoadLeaderboard()
    {
        LeaderboardData data = LeaderboardManager.Instance.LoadLeaderboard();
        foreach (LeaderboardEntry entry in data.entries)
        {
            GameObject newEntry = Instantiate(leaderboardEntryPrefab, content);
            TextMeshProUGUI[] texts = newEntry.GetComponentsInChildren<TextMeshProUGUI>();
            texts[0].text = entry.name;
            texts[1].text = entry.score.ToString();
        }
    }
}