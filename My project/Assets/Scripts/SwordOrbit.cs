using UnityEngine;
public class SwordOrbit : MonoBehaviour
{
    public float distance = 1f;
    public float rotationOffset;
    private Camera mainCamera;
    private Player player;
    void Start()
    {
        mainCamera = Camera.main;
        player = GetComponentInParent<Player>();
    }
    void Update()
    {
        if (!GameManager.Instance.IsPlaying())
        {
            return;
        }
        Vector3 mousePosition = Input.mousePosition;
        mousePosition.z = -mainCamera.transform.position.z;
        Vector3 mouseWorldPosition = mainCamera.ScreenToWorldPoint(mousePosition);
        Vector2 direction = mouseWorldPosition - player.transform.position;
        float angle = Vector2.Angle(Vector2.right, direction);
        if (direction.y < 0)
        {
            angle = -angle;
        }
        angle += rotationOffset;
        transform.position = player.transform.position;
        transform.rotation = Quaternion.Euler(0, 0, angle);
        transform.position += transform.right * distance;
    }
}