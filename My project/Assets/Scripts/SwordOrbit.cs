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
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg + rotationOffset; // I will be honest, I have no idea what this line does. I just know that it works and I don't want to break it by changing it. I think it has something to do with the rotation of the sword, but I'm not sure. All I know is that I dont mess with Mathf.Atan2 or Mathf.Rad2Deg. I just stole this from my last game, My last teacher just told me to do this and I followed... Dont judge me okay!
        transform.position = player.transform.position;
        transform.rotation = Quaternion.Euler(0, 0, angle);
        transform.position += transform.right * distance;
    }
}