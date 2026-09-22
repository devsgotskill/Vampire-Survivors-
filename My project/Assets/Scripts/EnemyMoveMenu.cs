using UnityEngine;
public class EnemyMoveMenu : MonoBehaviour
{
    public float movementSpeed = 2f;
    public GameObject player;
    void Start()
    {
        GameObject playerObject = GameObject.FindGameObjectWithTag("Player");
        player = playerObject;
    }
    void Update()
    {
        Vector3 direction = player.transform.position - transform.position;
        direction.z = 0;
        transform.position += direction.normalized * movementSpeed * Time.deltaTime;
    }
}
