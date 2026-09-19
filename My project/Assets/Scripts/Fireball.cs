using UnityEngine;
public class Fireball : MonoBehaviour
{
    public float speed = 5f;
    public float despawnTime = 5f;
    private Vector3 direction;
    private float despawnTimer;
    void Start()
    {
        despawnTimer = despawnTime;
    }
    void Update()
    {
        if (!GameManager.Instance.IsPlaying())
        {
            return;
        }
        transform.position += direction * speed * Time.deltaTime;
        despawnTimer -= Time.deltaTime;
        if (despawnTimer <= 0)
        {
            Destroy(gameObject);
        }
    }
    public void SetDirection(Vector3 newDirection)
    {
        direction = newDirection.normalized;
    }
}