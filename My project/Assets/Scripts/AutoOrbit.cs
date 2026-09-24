using UnityEngine;

public class AutoOrbit : MonoBehaviour
{
    public float distance = 1f;
    public float rotationSpeed = 100f;
    public Player player;
    private float angle;
    void Start()
    {
        player = GetComponentInParent<Player>();
    }
    void Update()
    {
        if (!GameManager.Instance.IsPlaying())
        {
            return;
        }
        angle += rotationSpeed * Time.deltaTime;
        transform.position = player.transform.position;
        transform.rotation = Quaternion.Euler(0, 0, angle);
        transform.position += transform.right * distance;
    }
}
