using UnityEngine;

public class UpgradeManager : MonoBehaviour
{
    public GameObject upgradeMenu;
    public GameObject upgradeMenuTwo;
    public GameObject sword;
    public GameObject axe;
    public GameObject katana;
    public GameObject pistol;
    public GameObject ak;
    public GameObject autoSwordOne;
    public GameObject healthUI;
    public GameObject xpUI;
    public GameObject bulletUI;
    private PlayerXp playerXp;

    void Start()
    {
        upgradeMenu.SetActive(false);
        playerXp = FindObjectOfType<PlayerXp>();
    }
    void Update()
    {
        if (GameManager.Instance.IsUpgrade() && playerXp.level == 3)
        {
            if (!upgradeMenu.activeSelf)
            {
                upgradeMenu.SetActive(true);
                upgradeMenuTwo.SetActive(false);
                healthUI.SetActive(false);
                xpUI.SetActive(false);
                bulletUI.SetActive(false);
            }
        }
        if (GameManager.Instance.IsUpgrade() && playerXp.level == 6)
        {
            if (!upgradeMenuTwo.activeSelf)
            {
                upgradeMenu.SetActive(false);
                upgradeMenuTwo.SetActive(true);
                healthUI.SetActive(false);
                xpUI.SetActive(false);
                bulletUI.SetActive(false);
            }
        }
    }
    public void SkipUpgrade()
    {
        upgradeMenu.SetActive(false);
        upgradeMenuTwo.SetActive(false);
        healthUI.SetActive(true);
        xpUI.SetActive(true);
        bulletUI.SetActive(true);
        GameManager.Instance.ChangeState(new PlayingState());
    }
    public void UpgradePistol()
    {
        sword.SetActive(false);
        autoSwordOne.SetActive(false);
        axe.SetActive(false);
        katana.SetActive(false);
        ak.SetActive(false);
        pistol.SetActive(true);
        CloseUpgrade();
    }
    public void UpgradeAutoSwordOne()
    {
        sword.SetActive(false);
        pistol.SetActive(false);
        axe.SetActive(false);
        katana.SetActive(false);
        ak.SetActive(false);
        autoSwordOne.SetActive(true);
        CloseUpgrade();
    }
    public void UpgradeAxe()
    {
        sword.SetActive(false);
        pistol.SetActive(false);
        autoSwordOne.SetActive(false);
        katana.SetActive(false);
        ak.SetActive(false);
        axe.SetActive(true);
        CloseUpgrade();
    }
    public void UpgradeAK()
    {
        sword.SetActive(false);
        autoSwordOne.SetActive(false);
        axe.SetActive(false);
        katana.SetActive(false);
        ak.SetActive(true);
        pistol.SetActive(false);
        CloseUpgrade();
    }
    public void UpgradeKatana()
    {
        sword.SetActive(false);
        autoSwordOne.SetActive(false);
        axe.SetActive(false);
        katana.SetActive(true);
        ak.SetActive(false);
        pistol.SetActive(false);
        CloseUpgrade();
    }
    public void UpgradeAutoSwordTwo()
    {
        sword.SetActive(false);
        autoSwordOne.SetActive(false);
        axe.SetActive(false);
        katana.SetActive(false);
        ak.SetActive(false);
        pistol.SetActive(false);
        CloseUpgrade();
    }
    private void CloseUpgrade()
    {
        upgradeMenu.SetActive(false);
        upgradeMenuTwo.SetActive(false);
        healthUI.SetActive(true);
        xpUI.SetActive(true);
        bulletUI.SetActive(true);
        GameManager.Instance.ChangeState(new PlayingState());
    }
}