using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int health = 10;
    public int swordDamage = 1;
    public float invincibilityTime = 0.5f;
    public float flashSpeed = 0.05f;

    private SpriteRenderer spriteRenderer;
    private float invincibilityTimer;
    private float flashTimer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
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

            Debug.Log("Player hit the enemy! Enemy health: " + health);

            invincibilityTimer = invincibilityTime;

            if (health <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
}