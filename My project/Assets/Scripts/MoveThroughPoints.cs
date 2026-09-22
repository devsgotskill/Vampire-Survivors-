using UnityEngine;
public class MoveThroughPoints : MonoBehaviour
{
    public Transform[] points;
    public float moveSpeed = 5f;

    private int currentPoint = 0;

    void Update()
    {
        if (points.Length == 0)
        {
            return;
        }
        transform.position = Vector3.MoveTowards(transform.position, points[currentPoint].position, moveSpeed * Time.deltaTime);
        if (transform.position == points[currentPoint].position)
        {
            currentPoint++;

            if (currentPoint >= points.Length)
            {
                currentPoint = 0;
            }
        }
    }
}