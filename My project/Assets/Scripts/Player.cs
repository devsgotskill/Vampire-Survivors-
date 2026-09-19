using UnityEngine;

public class Player : MonoBehaviour
{
    public int movementSpeed;
    public int dashSpeed;
    public float dashTime = 0.15f;
    public float dashCooldown = 1f;
    public int health = 100;
    public float invincibilityTime = 1f;
    private Vector3 movementDirection;
    private float dashTimer;
    public float dashCooldownTimer;
    private float invincibilityTimer;
    void Update()
    {
        if (!GameManager.Instance.IsPlaying())
        {
            return;
        }

        movementDirection = Vector3.zero;

        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            movementDirection += Vector3.up;
        }

        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            movementDirection += Vector3.down;
        }

        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            movementDirection += Vector3.left;
        }

        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            movementDirection += Vector3.right;
        }

        movementDirection = movementDirection.normalized;

        if (dashCooldownTimer > 0)
        {
            dashCooldownTimer -= Time.deltaTime;
        }

        if (invincibilityTimer > 0)
        {
            invincibilityTimer -= Time.deltaTime;
        }

        if (Input.GetKeyDown(KeyCode.LeftShift) && movementDirection != Vector3.zero && dashCooldownTimer <= 0)
        {
            dashTimer = dashTime;
            dashCooldownTimer = dashCooldown;
        }

        if (dashTimer > 0)
        {
            transform.Translate(movementDirection * dashSpeed * Time.deltaTime);
            dashTimer -= Time.deltaTime;
        }
        else
        {
            transform.Translate(movementDirection * movementSpeed * Time.deltaTime);
        }
    }

    public void TakeDamage(int damage)
    {
        if (invincibilityTimer > 0)
        {
            return;
        }

        health -= damage;
        invincibilityTimer = invincibilityTime;

        if (health <= 0)
        {
            health = 0;
        }
    }
}