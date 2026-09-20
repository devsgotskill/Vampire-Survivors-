using UnityEngine;
public class Bullet : MonoBehaviour
{
    public float bulletSpeed = 15f;
    public float lifetime = 3f;
    private Rigidbody2D rb;
    private float lifetimeTimer;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        if (!GameManager.Instance.IsPlaying())
        {
            return;
        }
        lifetimeTimer += Time.deltaTime;

        if (lifetimeTimer >= lifetime)
        {
            Destroy(gameObject);
        }
    }
    void FixedUpdate()
    {
        if (!GameManager.Instance.IsPlaying())
        {
            return;
        }
        rb.linearVelocity = transform.right * bulletSpeed;
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            Destroy(gameObject);
        }
    }
}
