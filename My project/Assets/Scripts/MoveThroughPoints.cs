using UnityEngine;

public class MoveThroughPoints : MonoBehaviour
{
    public Transform[] points;
    public float moveSpeed = 5f;
    private int currentPoint = 0;
    private Vector3 movementDirection;
    public Animator animator;

    void Update()
    {
        if (points.Length == 0)
        {
            return;
        }
        movementDirection = points[currentPoint].position - transform.position;
        movementDirection = movementDirection.normalized;
        transform.position = Vector3.MoveTowards(transform.position, points[currentPoint].position, moveSpeed * Time.deltaTime);
        if (transform.position == points[currentPoint].position)
        {
            currentPoint++;

            if (currentPoint >= points.Length)
            {
                currentPoint = 0;
            }
        }
        if (movementDirection.y > 0)
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
    }
}