using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxKicking : MonoBehaviour
{
    public float moveSpeed = 5;
    public Transform movePoint;

    public LayerMask whatStopsMovement;

    void Start()
    {
        movePoint.parent = null;
    }

    public void MoveBoxHorizontal(float direktion)
    {
        transform.position = Vector3.MoveTowards(transform.position, movePoint.position, moveSpeed * Time.deltaTime);

        if (Vector3.Distance(transform.position, movePoint.position) <= .05f)
        {
            if (!Physics2D.OverlapCircle(movePoint.position + new Vector3(direktion, 0f, 0f), .2f, whatStopsMovement))
            {
                movePoint.position += new Vector3(direktion, 0f, 0f);
            }
        }
    }
    public void MoveBoxVertical(float direktion)
    {
        transform.position = Vector3.MoveTowards(transform.position, movePoint.position, moveSpeed * Time.deltaTime);

        if (Vector3.Distance(transform.position, movePoint.position) <= .05f)
        {
            if (!Physics2D.OverlapCircle(movePoint.position + new Vector3(0f, direktion, 0f), .2f, whatStopsMovement))
            {
                movePoint.position += new Vector3(0f, direktion, 0f);
            }
        }
    }
}
