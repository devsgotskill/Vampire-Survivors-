using UnityEngine;

public class Player : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public int movementSpeed;
    public int dashSpeed;
    public bool flipSprite;
    void Start()
    {
        
    }
    void Update()
    {
        if(Input.GetKey(KeyCode.W))
        {
            transform.Translate(new Vector3(0, 1, 0) * movementSpeed * Time.deltaTime);
            if (Input.GetKey(KeyCode.LeftShift))
            {

            }
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(new Vector3(0, -1, 0) * movementSpeed * Time.deltaTime);
            if (Input.GetKey(KeyCode.LeftShift))
            {

            }
        }
        if (Input.GetKey(KeyCode.A))
        {
            flipSprite = true;
            transform.Translate(new Vector3(-1, 0, 0) * movementSpeed * Time.deltaTime);
            if (Input.GetKey(KeyCode.LeftShift))
            {

            }
        }
        if (Input.GetKey(KeyCode.D))
        {
            flipSprite = false;
            transform.Translate(new Vector3(1, 0, 0) * movementSpeed * Time.deltaTime);
            if (Input.GetKey(KeyCode.LeftShift))
            {

            }
        }
        if(flipSprite == true)
        {
            spriteRenderer.flipX = true;
        }
        if (flipSprite == false)
        {
            spriteRenderer.flipX = false;
        }
    }
}
