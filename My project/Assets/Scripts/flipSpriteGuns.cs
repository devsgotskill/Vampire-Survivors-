using UnityEngine;
public class flipSpriteGuns : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    public GameObject weapon;
    void Start()
    {
        spriteRenderer = weapon.GetComponent<SpriteRenderer>();
    }
    void Update()
    {
        if (transform.localPosition.x < 0)
        {
            spriteRenderer.flipY = true;
        }
        else
        {
            spriteRenderer.flipY = false;
        }
    }
}
