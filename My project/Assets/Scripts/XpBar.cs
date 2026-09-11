using UnityEngine;
using UnityEngine.UI;
public class XpBar : MonoBehaviour
{
    public Image xpBar;
    private PlayerXp playerXp;
    void Start()
    {
        GameObject playerObject = GameObject.FindGameObjectWithTag("Player");
        playerXp = playerObject.GetComponent<PlayerXp>();
    }
    void Update()
    {
        xpBar.fillAmount = (float)playerXp.XP / playerXp.XPNeeded;
    }
}
