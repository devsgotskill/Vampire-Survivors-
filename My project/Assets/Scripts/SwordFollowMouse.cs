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
        Vector3 mousePosition = Input.mousePosition;
        mousePosition.z = -mainCamera.transform.position.z;

        Vector3 mouseWorldPosition = mainCamera.ScreenToWorldPoint(mousePosition);

        Vector3 direction = mouseWorldPosition - player.transform.position;

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg + rotationOffset;

        transform.rotation = Quaternion.Euler(0, 0, angle);
    }
}