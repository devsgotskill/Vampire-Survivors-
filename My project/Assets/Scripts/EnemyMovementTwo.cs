using System;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyMovementTwo : MonoBehaviour
{
    public float movementSpeed = 2f;
    public bool isInStopBox = false;
    private Player player;
    public GameObject fireballPrefab;
    public Transform fireballSpawnPoint;
    public float fireballCooldown = 2f;
    public float shootTimer;

    void Start()
    {
        GameObject playerObject = GameObject.FindGameObjectWithTag("Player");
        player = playerObject.GetComponent<Player>();
        GameObject stopBoxObject = GameObject.FindGameObjectWithTag("StopBox");
        BoxCollider stopBox = stopBoxObject.GetComponent<BoxCollider>();
    }
    void Update()
    {
        if (isInStopBox == true)
        {
            movementSpeed = 0f;
            shootTimer -= Time.deltaTime;
            if (shootTimer <= 0)
            {
                Shoot();
                shootTimer = fireballCooldown;
            }
        }
        else
        {
            movementSpeed = 2f;
            Vector3 direction = player.transform.position - transform.position;
            direction.z = 0;
            transform.position += direction.normalized * movementSpeed * Time.deltaTime;
        }
    }


    public void OnTriggerStay2D(Collider2D stopBox)
    {
        if (stopBox.CompareTag("StopBox"))
        {
            isInStopBox = true;
        }
    }
    public void OnTriggerExit2D(Collider2D stopBox)
    {
        if (stopBox.CompareTag("StopBox"))
        {
            isInStopBox = false;
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