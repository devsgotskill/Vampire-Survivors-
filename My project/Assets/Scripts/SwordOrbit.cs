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
        Vector3 mousePosition = Input.mousePosition;
        mousePosition.z = -mainCamera.transform.position.z;

        Vector3 mouseWorldPosition = mainCamera.ScreenToWorldPoint(mousePosition);

        Vector3 direction = mouseWorldPosition - player.transform.position;
        direction.z = 0;

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg + rotationOffset;

        transform.position = player.transform.position;
        transform.rotation = Quaternion.Euler(0, 0, angle);

        transform.position += transform.right * distance;
    }
}