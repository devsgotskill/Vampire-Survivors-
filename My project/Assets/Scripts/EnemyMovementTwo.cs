using System;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyMovementTwo : MonoBehaviour
{
    public float movementSpeed = 2f;
    public bool isInStopBox = false;
    private Player player;

    void Start()
    {
        GameObject playerObject = GameObject.FindGameObjectWithTag("Player");
        player = playerObject.GetComponent<Player>();
        GameObject stopBoxObject = GameObject.FindGameObjectWithTag("StopBox");
        BoxCollider stopBox = stopBoxObject.GetComponent<BoxCollider>();
    }

    void Update()
    {
        Vector3 direction = player.transform.position - transform.position;
        direction.z = 0;
        transform.position += direction.normalized * movementSpeed * Time.deltaTime;
        if(isInStopBox == true)
        {
            movementSpeed = 0f;
            Shoot();
        }
        else
        {
            movementSpeed = 2f;
        }
    }
    public void OnTriggerStay(Collider stopBox)
    {
        if (stopBox.CompareTag("StopBox"))
        {
            isInStopBox = true;
        }
    }
    public void OnTriggerExit(Collider stopBox)
    {
        if (stopBox.CompareTag("StopBox"))
        {
            isInStopBox = false;
        }
    }
    public void Shoot()
    {
        
    }
}