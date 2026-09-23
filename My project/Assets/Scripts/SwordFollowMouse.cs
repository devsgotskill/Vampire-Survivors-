using UnityEngine;

public class SwordFollowMouse : MonoBehaviour
{
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
        transform.rotation = Quaternion.Euler(0, 0, angle);
    }
}