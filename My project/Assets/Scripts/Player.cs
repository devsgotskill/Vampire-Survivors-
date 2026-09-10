using UnityEngine;

public class Player : MonoBehaviour
{
    public int movementSpeed;
    public int dashSpeed;
    public float dashTime = 0.15f;
    public float dashCooldown = 1f;

    private Vector3 movementDirection;
    private float dashTimer;
    public float dashCooldownTimer;

    void Start()
    {

    }

    void Update()
    {
        movementDirection = Vector3.zero;

        if (Input.GetKey(KeyCode.W))
        {
            movementDirection += new Vector3(0, 1, 0);
        }

        if (Input.GetKey(KeyCode.S))
        {
            movementDirection += new Vector3(0, -1, 0);
        }

        if (Input.GetKey(KeyCode.A))
        {
            movementDirection += new Vector3(-1, 0, 0);
        }

        if (Input.GetKey(KeyCode.D))
        {
            movementDirection += new Vector3(1, 0, 0);
        }

        if (dashCooldownTimer > 0)
        {
            dashCooldownTimer -= Time.deltaTime;
        }

        if (Input.GetKeyDown(KeyCode.LeftShift) && movementDirection != Vector3.zero && dashCooldownTimer <= 0)
        {
            dashTimer = dashTime;
            dashCooldownTimer = dashCooldown;
        }

        if (dashTimer > 0)
        {
            transform.Translate(movementDirection.normalized * dashSpeed * Time.deltaTime);
            dashTimer -= Time.deltaTime;
        }
        else
        {
            transform.Translate(movementDirection.normalized * movementSpeed * Time.deltaTime);
        }
    }
}