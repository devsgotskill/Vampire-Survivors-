using UnityEngine;
public class flipSpriteGuns : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    public GameObject gun;
    void Start()
    {
        gun = GameObject.FindGameObjectWithTag("Gun");
        spriteRenderer = gun.GetComponent<SpriteRenderer>();
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
