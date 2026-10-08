using UnityEngine;
public class PlayerXp : MonoBehaviour
{
    public int XP;
    public int totalXP;
    public int level = 0;
    public int[] xpRequiredPerLevel = { 100, 160, 300, 500, 750, 1050 };
    private bool upgradeTriggered = false;
    public int XPNeeded
    {
        get
        {
            if (level >= xpRequiredPerLevel.Length)
            {
                return xpRequiredPerLevel[xpRequiredPerLevel.Length - 1];
            }
            return xpRequiredPerLevel[level];
        }
    }
    public void AddXP(int amount)
    {
        XP += amount;
        totalXP += amount;
        DailyBestScore.SaveScore(totalXP);
        while (XP >= XPNeeded)
        {
            XP -= XPNeeded;
            level++;

            if (level == 2 || level == 4)
            {
                upgradeTriggered = true;
                break;
            }
        }
        if (upgradeTriggered)
        {
            upgradeTriggered = false;
            GameManager.Instance.ChangeState(new UpgradeState());
        }
    }
}
