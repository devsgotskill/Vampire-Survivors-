using UnityEngine;

public class UpgradeManager : MonoBehaviour
{
    public GameObject upgradeMenu;
    public GameObject sword;
    public GameObject axe;
    public GameObject katana;
    public GameObject pistol;
    public GameObject ak;
    public GameObject autoSwordOne;
    public GameObject healthUI;
    public GameObject xpUI;
    public GameObject bulletUI;
    void Start()
    {
        upgradeMenu.SetActive(false);
    }
    void Update()
    {
        if (GameManager.Instance.IsUpgrade())
        {
            if (!upgradeMenu.activeSelf)
            {
                upgradeMenu.SetActive(true);
                healthUI.SetActive(false);
                xpUI.SetActive(false);
                bulletUI.SetActive(false);
            }
        }
    }
    public void SkipUpgrade()
    {
        upgradeMenu.SetActive(false);
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
        healthUI.SetActive(true);
        xpUI.SetActive(true);
        bulletUI.SetActive(true);
        upgradeMenu.SetActive(false);
        GameManager.Instance.ChangeState(new PlayingState());
    }
    public void UpgradeAutoSwordOne()
    {
        sword.SetActive(false);
        pistol.SetActive(false);
        axe.SetActive(false);
        katana.SetActive(false);
        ak.SetActive(false);
        autoSwordOne.SetActive(true);
        healthUI.SetActive(true);
        xpUI.SetActive(true);
        bulletUI.SetActive(true);
        upgradeMenu.SetActive(false);
        GameManager.Instance.ChangeState(new PlayingState());
    }
    public void UpgradeAxe()
    {
        sword.SetActive(false);
        pistol.SetActive(false);
        autoSwordOne.SetActive(false);
        katana.SetActive(false);
        ak.SetActive(false);
        axe.SetActive(true);
        healthUI.SetActive(true);
        xpUI.SetActive(true);
        bulletUI.SetActive(true);
        upgradeMenu.SetActive(false);
        GameManager.Instance.ChangeState(new PlayingState());
    }
}