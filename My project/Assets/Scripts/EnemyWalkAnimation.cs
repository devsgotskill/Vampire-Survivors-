using UnityEngine;

public class EnemyWalkAnimation : MonoBehaviour
{
    public float flipTime = 0.5f;

    private SpriteRenderer spriteRenderer;
    private float flipTimer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        flipTimer += Time.deltaTime;

        if (flipTimer >= flipTime)
        {
            spriteRenderer.flipX = !spriteRenderer.flipX;
            flipTimer = 0;
        }
    }
}