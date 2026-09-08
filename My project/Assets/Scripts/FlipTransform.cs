using UnityEngine;

public class FlipTransform : MonoBehaviour
{
    public Transform transform;
    public bool Switch;
    void Start()
    {
 
    }
    void Update()
    {
        if (Switch == true)
        {
            
        }
        if (Switch == false)
        {
            transform.Rotate(new Vector3(0, 0, 0));
        }
        if (Input.GetKey(KeyCode.A))
        {
            Switch = true;
        }
        if (Input.GetKey(KeyCode.D))
        {
            Switch = false;
        }
       
    }
    public void test()
    {
        
    }
}
