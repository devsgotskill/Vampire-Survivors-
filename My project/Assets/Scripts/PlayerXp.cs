using UnityEngine;

public class PlayerXp : MonoBehaviour
{
    public int XP;
    public int level = 0;

    public int[] xpRequiredPerLevel = { 100, 160, 300, 500, 750, 1050 };

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

        while (XP >= XPNeeded)
        {
            XP -= XPNeeded;
            level++;
        }
    }
}