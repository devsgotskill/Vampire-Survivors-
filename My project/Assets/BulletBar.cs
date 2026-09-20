using UnityEngine;
using UnityEngine.UI;
public class BulletBar : MonoBehaviour
{
    public Image bulletBar;
    private Glock glock;

    void Start()
    {
        GameObject playerObject = GameObject.FindGameObjectWithTag("Gun");
        glock = playerObject.GetComponent<Glock>();
    }
    void Update()
    {
        if (glock.isReloading)
        {
            float startingFill = (float)glock.currentMagazine / glock.magazineSize;
            float reloadProgress = 1f - (glock.reloadTimer / glock.reloadTime);

            bulletBar.fillAmount = Mathf.Lerp(startingFill, 1f, reloadProgress);
        }
        else
        {
            bulletBar.fillAmount = (float)glock.currentMagazine / glock.magazineSize;
        }
    }
}