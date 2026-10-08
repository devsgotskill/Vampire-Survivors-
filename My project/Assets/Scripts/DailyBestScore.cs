using UnityEngine;
using System;
public static class DailyBestScore
{
    private static string GetTodayKey()
    {
        return "DailyBest_" + DateTime.Now.ToString("yyyyMMdd");
    }
    public static void SaveScore(int score)
    {
        string key = GetTodayKey();
        int bestScore = PlayerPrefs.GetInt(key, 0);
        if (score > bestScore)
        {
            PlayerPrefs.SetInt(key, score);
            PlayerPrefs.Save();
        }
    }
    public static int GetTodayBest()
    {
        return PlayerPrefs.GetInt(GetTodayKey(), 0);
    }
}
