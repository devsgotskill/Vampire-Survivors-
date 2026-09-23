using UnityEngine;
using UnityEngine.UI;

public class BulletBar : MonoBehaviour
{
    public Image bulletBar;
    public GameObject gunUI;
    private Gun gun;
    void Update()
    {
        if (gun == null || !gun.gameObject.activeInHierarchy)
        {
            GameObject gunObject = GameObject.FindGameObjectWithTag("Gun");

            if (gunObject != null)
            {
                gun = gunObject.GetComponent<Gun>();
            }
        }
        if (gun == null || !gun.gameObject.activeInHierarchy)
        {
            gunUI.SetActive(false);
            return;
        }
        gunUI.SetActive(true);

        if (gun.isReloading)
        {
            float startingFill = (float)gun.currentMagazine / gun.magazineSize;
            float reloadProgress = 1f - (gun.reloadTimer / gun.reloadTime);
            bulletBar.fillAmount = startingFill + (1f - startingFill) * reloadProgress;
        }
        else
        {
            bulletBar.fillAmount = (float)gun.currentMagazine / gun.magazineSize;
        }
    }
}