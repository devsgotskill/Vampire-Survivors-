using UnityEngine;
using TMPro;
public class Glock : MonoBehaviour
{
    public GameObject pistolBullet;
    public Transform firePoint;
    public TextMeshProUGUI ammoText;
    public int magazineSize = 12;
    public float fireRate = 0.2f;
    public float reloadTime = 1.5f;
    public Animator animator;
    public int currentMagazine;
    public float fireCooldown;
    public float reloadTimer;
    public bool isReloading;
    void Start()
    {
        animator = GetComponent<Animator>();
        currentMagazine = magazineSize;
        UpdateAmmoText();
    }
    void Update()
    {
        if (!GameManager.Instance.IsPlaying())
        {
            return;
        }
        if (fireCooldown > 0)
        {
            fireCooldown -= Time.deltaTime;
        }
        if (isReloading)
        {
            reloadTimer -= Time.deltaTime;
            if (reloadTimer <= 0)
            {
                currentMagazine = magazineSize;
                isReloading = false;
            }
            return;
        }
        if (Input.GetKeyDown(KeyCode.R) && currentMagazine < magazineSize)
        {
            StartReload();
            UpdateAmmoText();
            return;
        }
        if (Input.GetMouseButtonDown(0) && currentMagazine > 0 && fireCooldown <= 0)
        {
            Shoot();
            UpdateAmmoText();
        }
        if (currentMagazine <= 0)
        {
            StartReload();
            UpdateAmmoText();
        }
    }
    void Shoot()
    {
        UpdateAmmoText();
        currentMagazine--;
        fireCooldown = fireRate;
        animator.SetTrigger("Shoot");
        Instantiate(pistolBullet, firePoint.position, firePoint.rotation);
        UpdateAmmoText();
    }
    void StartReload()
    {
        UpdateAmmoText();
        if (isReloading || currentMagazine >= magazineSize)
        {
            return;
        }
        isReloading = true;
        reloadTimer = reloadTime;
        animator.SetTrigger("Reload");
        UpdateAmmoText();
    }
    void UpdateAmmoText()
    {
        ammoText.text = currentMagazine + " / " + magazineSize;
    }
}