using UnityEngine;

public class Player : MonoBehaviour
{
    public int movementSpeed;
    public int dashSpeed;
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
            transform.Translate(new Vector3(-1, 0, 0) * movementSpeed * Time.deltaTime);
            if (Input.GetKey(KeyCode.LeftShift))
            {

            }
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(new Vector3(1, 0, 0) * movementSpeed * Time.deltaTime);
            if (Input.GetKey(KeyCode.LeftShift))
            {

            }
        }
    }
}
