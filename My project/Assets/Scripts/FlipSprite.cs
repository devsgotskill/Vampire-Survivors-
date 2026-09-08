using UnityEngine;

public class FlipSprite : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public bool flipSprite;
    void Start()
    {
        
    }
    void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            flipSprite = true;
        }
        if (Input.GetKey(KeyCode.D))
        {
            flipSprite = false;
        }
        if (flipSprite == true)
        {
            spriteRenderer.flipX = true;
        }
        if (flipSprite == false)
        {
            spriteRenderer.flipX = false;
        }
    }
}
