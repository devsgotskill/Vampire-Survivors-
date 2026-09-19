using UnityEngine;

public class PlayerDamage : MonoBehaviour
{
    private Player player;
    private BoxCollider2D playerCollider;
    public float damageCooldown = 1f;
    private float damageTimer;
    void Start()
    {
        player = GetComponent<Player>();
        playerCollider = GetComponent<BoxCollider2D>();
    }
    void Update()
    {
        if (!GameManager.Instance.IsPlaying())
        {
            return;
        }
        if (damageTimer > 0)
        {
            damageTimer -= Time.deltaTime;
        }
    }
    void OnTriggerStay2D(Collider2D other)
    {
        if (!GameManager.Instance.IsPlaying())
        {
            return;
        }

        if (!playerCollider.IsTouching(other))
        {
            return;
        }
        if (other.CompareTag("Enemy")) 
        {
            if (damageTimer <= 0)
            {
                player.TakeDamage(10);
                damageTimer = damageCooldown;
            }
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (!GameManager.Instance.IsPlaying())
        {
            return;
        }
        if (!playerCollider.IsTouching(other))
        {
            return;
        }
        if (other.CompareTag("Fireball"))
        {
            player.TakeDamage(10);
            Destroy(other.gameObject);
        }
    }
}