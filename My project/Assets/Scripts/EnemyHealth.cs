using UnityEngine;
public class EnemyHealth : MonoBehaviour
{
    public AudioSource damageByGunSound;
    public AudioSource damageByMeleeSound;
    public int health;
    public int swordDamage;
    public int axeDamage;
    public int katanaDamage;
    public int pistolBulletDamage;
    public int akBulletDamage;
    public float invincibilityTime = 0.5f;
    public float flashSpeed = 0.05f;
    public GameObject deadTextPrefab;
    private SpriteRenderer spriteRenderer;
    private float invincibilityTimer;
    private float flashTimer;
    private PlayerXp playerXP;
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        GameObject playerObject = GameObject.FindGameObjectWithTag("Player");
        playerXP = playerObject.GetComponent<PlayerXp>();
    }
    void Update()
    {
        if (!GameManager.Instance.IsPlaying())
        {
            return;
        }
        if (invincibilityTimer > 0)
        {
            invincibilityTimer -= Time.deltaTime;

            flashTimer += Time.deltaTime;

            if (flashTimer >= flashSpeed)
            {
                spriteRenderer.enabled = !spriteRenderer.enabled;
                flashTimer = 0;
            }
            if (invincibilityTimer <= 0)
            {
                invincibilityTimer = 0;
                spriteRenderer.enabled = true;
                flashTimer = 0;
            }
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (!GameManager.Instance.IsPlaying())
        {
            return;
        }
        if (other.CompareTag("Sword") && invincibilityTimer <= 0)
        {
            health -= swordDamage;
            damageByMeleeSound.Play();
            invincibilityTimer = invincibilityTime;        
            if (health <= 0)
            {
                playerXP.AddXP(20);
                Instantiate(deadTextPrefab, transform.position, Quaternion.identity);
                Destroy(gameObject);
            }
        }
        if (other.CompareTag("Axe") && invincibilityTimer <= 0)
        {
            health -= axeDamage;
            damageByMeleeSound.Play();
            invincibilityTimer = invincibilityTime;
            if (health <= 0)
            {
                playerXP.AddXP(20);
                Instantiate(deadTextPrefab, transform.position, Quaternion.identity);
                Destroy(gameObject);
            }
        }
        if (other.CompareTag("Katana") && invincibilityTimer <= 0)
        {
            health -= katanaDamage;
            damageByMeleeSound.Play();
            invincibilityTimer = invincibilityTime;
            if (health <= 0)
            {
                playerXP.AddXP(20);
                Instantiate(deadTextPrefab, transform.position, Quaternion.identity);
                Destroy(gameObject);
            }
        }
        if (other.CompareTag("PistolBullet"))
        {
            health -= pistolBulletDamage;
            damageByGunSound.Play();
            invincibilityTimer = invincibilityTime;
            if (health <= 0)
            {
                playerXP.AddXP(20);
                Instantiate(deadTextPrefab, transform.position, Quaternion.identity);
                Destroy(gameObject);
            }
        }
        if (other.CompareTag("AkBullet"))
        {
            health -= akBulletDamage;
            damageByGunSound.Play();
            invincibilityTimer = invincibilityTime;
            if (health <= 0)
            {
                playerXP.AddXP(20);
                Instantiate(deadTextPrefab, transform.position, Quaternion.identity);
                Destroy(gameObject);
            }
        }
    }
}