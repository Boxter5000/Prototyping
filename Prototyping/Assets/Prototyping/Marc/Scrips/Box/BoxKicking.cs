using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxKicking : MonoBehaviour
{
    public float moveSpeed = 5;
    public Transform movePoint;

    public LayerMask whatStopsMovement;
    private Vector2 lastBoxPos;

    void Start()
    {
        movePoint.parent = null;
        lastBoxPos = transform.position;
    }

    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, movePoint.position, moveSpeed * Time.deltaTime);
    }

    public void MoveBoxHorizontal(float direktion)
    {
        lastBoxPos = movePoint.position;
        if (Vector3.Distance(transform.position, movePoint.position) <= .05f)
        {
            if (!Physics2D.OverlapCircle(movePoint.position + new Vector3(direktion, 0f, 0f), .2f, whatStopsMovement))
            {
                lastBoxPos = movePoint.position;
                movePoint.position += new Vector3(direktion, 0f, 0f);
            }
        }
    }
    public void MoveBoxVertical(float direktion)
    {
        lastBoxPos = movePoint.position;
        if (Vector3.Distance(transform.position, movePoint.position) <= .05f)
        {
            if (!Physics2D.OverlapCircle(movePoint.position + new Vector3(0f, direktion, 0f), .2f, whatStopsMovement))
            {
                lastBoxPos = movePoint.position;
                movePoint.position += new Vector3(0f, direktion, 0f);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        movePoint.position = lastBoxPos;
    }

    public void ReturnToLastPosition()
    {
        movePoint.position = lastBoxPos;
    }
}
