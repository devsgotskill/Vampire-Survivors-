using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int health = 10;
    public int swordDamage;
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

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Sword") && invincibilityTimer <= 0)
        {
            health -= swordDamage;
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