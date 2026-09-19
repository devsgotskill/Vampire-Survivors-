using UnityEngine;
public class EnemyMovementTwo : MonoBehaviour
{
    public float movementSpeed = 2f;
    public float shootingDistance = 5f;
    public GameObject fireballPrefab;
    public Transform fireballSpawnPoint;
    public float fireballCooldown = 2f;
    public float shootTimer;
    private Player player;
    void Start()
    {
        GameObject playerObject = GameObject.FindGameObjectWithTag("Player");
        player = playerObject.GetComponent<Player>();
        shootTimer = fireballCooldown;
    }
    void Update()
    {
        if (!GameManager.Instance.IsPlaying())
        {
            return;
        }
        float distanceToPlayer = Vector3.Distance(transform.position, player.transform.position);
        if (distanceToPlayer > shootingDistance)
        {
            Vector3 direction = player.transform.position - transform.position;
            direction.z = 0;
            transform.position += direction.normalized * movementSpeed * Time.deltaTime;
        }
        else
        {
            shootTimer -= Time.deltaTime;

            if (shootTimer <= 0)
            {
                Shoot();
                shootTimer = fireballCooldown;
            }
        }
    }
    public void Shoot()
    {
        Vector3 direction = player.transform.position - fireballSpawnPoint.position;
        direction.z = 0;
        GameObject fireball = Instantiate(fireballPrefab, fireballSpawnPoint.position, Quaternion.identity);
        Fireball fireballScript = fireball.GetComponent<Fireball>();
        fireballScript.SetDirection(direction.normalized);
    }
}