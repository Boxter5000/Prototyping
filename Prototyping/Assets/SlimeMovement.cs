using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeMovement : MonoBehaviour
{
    public float moveSpeed = 5;
    public Transform movePoint;

    public float MoveDirektionHorizontal;               // 1 if you the Enemy to move Horitontal 
    public float MoveDirektionVertical;                 // 1 if you want the enemy to move vertical
    public LayerMask whatStopsMovement;

    void Start()
    {
        movePoint.parent = null;
    }
    
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, movePoint.position, moveSpeed * Time.deltaTime);

        if (Vector3.Distance(transform.position, movePoint.position) <= .05f)
        {
            if (!Physics2D.OverlapCircle(movePoint.position + new Vector3(MoveDirektionHorizontal, MoveDirektionVertical, 0f), .2f, whatStopsMovement))
            {
                movePoint.position += new Vector3(MoveDirektionHorizontal, MoveDirektionVertical, 0f);

                MoveDirektionHorizontal *= -1;
                MoveDirektionVertical *= -1;
            }
        }
    }

    public void MoveEnemy()
    {
        transform.position = Vector3.MoveTowards(transform.position, movePoint.position, moveSpeed * Time.deltaTime);

        if (Vector3.Distance(transform.position, movePoint.position) <= .05f)
        {
            if (!Physics2D.OverlapCircle(movePoint.position + new Vector3(MoveDirektionHorizontal, MoveDirektionVertical, 0f), .2f, whatStopsMovement))
            {
                movePoint.position += new Vector3(MoveDirektionHorizontal, MoveDirektionVertical, 0f);

                MoveDirektionHorizontal *= -1;
                MoveDirektionVertical *= -1;
            }
        }
    }
}