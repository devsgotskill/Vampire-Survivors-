
using UnityEngine;
using TMPro;

public class DailyBestScoreText : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    void Start()
    {
        UpdateScoreText();
    }
    void Update()
    {
        UpdateScoreText();
    }
    public void UpdateScoreText()
    {
        int bestScore = DailyBestScore.GetTodayBest();
        scoreText.text = "Today's Best: " + bestScore;
    }
}
