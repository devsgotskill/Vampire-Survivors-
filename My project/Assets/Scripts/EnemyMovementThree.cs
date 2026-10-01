using UnityEngine;

public class EnemyMovementThree : MonoBehaviour
{
    public float movementSpeed = 2f;
    public float rotationSpeed = 180f;
    public float attackRange = 5f;
    private Player player;
    void Start()
    {
        GameObject playerObject = GameObject.FindGameObjectWithTag("Player");
        player = playerObject.GetComponent<Player>();
    }
    void Update()
    {
        if (!GameManager.Instance.IsPlaying())
        {
            return;
        }
        Vector3 direction = player.transform.position - transform.position;
        direction.z = 0;
        if (direction.magnitude > attackRange)
        {
            transform.position += direction.normalized * movementSpeed * Time.deltaTime;
        }
        else
        {
            Quaternion originalRotation = transform.rotation; transform.RotateAround(player.transform.position, Vector3.forward, rotationSpeed * Time.deltaTime);
            transform.position = Vector3.MoveTowards(transform.position, player.transform.position, movementSpeed * Time.deltaTime);
            transform.rotation = originalRotation;
        }
    }
}
