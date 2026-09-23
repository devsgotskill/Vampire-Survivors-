using UnityEngine;
using TMPro;
public class Gun : MonoBehaviour
{
    public AudioSource shooting;
    public AudioSource reloading;
    public GameObject bullet;
    public Transform firePoint;
    public TextMeshProUGUI ammoText;
    public int magazineSize;
    public float fireRate;
    public float reloadTime;
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
        if (Input.GetMouseButton(0) && currentMagazine > 0 && fireCooldown <= 0)
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
        shooting.Play();
        currentMagazine--;
        fireCooldown = fireRate;
        animator.SetTrigger("Shoot");
        Instantiate(bullet, firePoint.position, firePoint.rotation);
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
        reloading.Play();
        animator.SetTrigger("Reload");
        UpdateAmmoText();
    }
    void UpdateAmmoText()
    {
        ammoText.text = currentMagazine + " / " + magazineSize;
    }
}