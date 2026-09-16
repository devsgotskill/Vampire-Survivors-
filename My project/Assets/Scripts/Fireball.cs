using UnityEngine;

public class Fireball : MonoBehaviour
{
    public float speed = 5f;
    public float despawnTime = 5f;

    private Vector3 direction;

    void Start()
    {
        GameObject stopBox = GameObject.FindGameObjectWithTag("StopBox");

        if (stopBox != null)
        {
            Collider2D fireballCollider = GetComponent<Collider2D>();
            Collider2D stopBoxCollider = stopBox.GetComponent<Collider2D>();

            if (fireballCollider != null && stopBoxCollider != null)
            {
                Physics2D.IgnoreCollision(fireballCollider, stopBoxCollider);
            }
        }

        Destroy(gameObject, despawnTime);
    }

    void Update()
    {
        transform.position += direction * speed * Time.deltaTime;
    }

    public void SetDirection(Vector3 newDirection)
    {
        direction = newDirection.normalized;
    }
}