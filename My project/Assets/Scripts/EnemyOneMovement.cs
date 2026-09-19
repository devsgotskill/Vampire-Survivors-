using UnityEngine;
public class EnemyMovementOne : MonoBehaviour
{
    public float movementSpeed = 2f;
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
        transform.position += direction.normalized * movementSpeed * Time.deltaTime;
    }
}