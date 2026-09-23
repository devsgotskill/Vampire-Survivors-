using UnityEngine;
using TMPro;

public class Player : MonoBehaviour
{
    public Animator animator;
    public int maxHealth;
    public int health;
    public TextMeshProUGUI healthText;
    public int movementSpeed;
    public int dashSpeed;
    public float dashTime;
    public float dashCooldown;
    public float invincibilityTime;
    private Vector3 movementDirection;
    private float dashTimer;
    public float dashCooldownTimer;
    private float invincibilityTimer;
    void Start()
    {
        health = maxHealth;
        UpdateHealthText();
    }
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
        if (movementDirection == Vector3.zero)
        {
            animator.SetInteger("AnimationState", 0);
        }
        else if (movementDirection.y > 0)
        {
            animator.SetInteger("AnimationState", 1);
        }
        else if (movementDirection.y < 0)
        {
            animator.SetInteger("AnimationState", 2);
        }
        else if (movementDirection.x < 0)
        {
            animator.SetInteger("AnimationState", 3);
        }
        else if (movementDirection.x > 0)
        {
            animator.SetInteger("AnimationState", 4);
        }
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
        UpdateHealthText();
    }
    void UpdateHealthText()
    {
        healthText.text = health + " / " + maxHealth;
    }
}