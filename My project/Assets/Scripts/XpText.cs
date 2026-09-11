using UnityEngine;

public class XpText : MonoBehaviour
{
    public float floatSpeed = 1f; public float lifetime = 0.5f;
    void Start()
    {
        Destroy(gameObject, lifetime);
    }
    void Update()
    {
        transform.position += Vector3.up * floatSpeed * Time.deltaTime;
    }
}

