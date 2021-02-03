using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeMovement : MonoBehaviour
{
    public float moveSpeed = 5;
    public Transform movePoint;
    public float MoveDirektionX;               // 1 if you the Enemy to move Horitontal 
    public float MoveDirektionY;                 // 1 if you want the enemy to move vertical
    public LayerMask whatStopsMovement;

    Vector2 movement;
    Vector2 LastDirektion;

    void Start()
    {
        movePoint.parent = null;
    }

    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, movePoint.position, moveSpeed * Time.deltaTime);
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        if (movement.x != 0f || movement.y != 0f)
        {
            LastDirektion = movement;
            MoveSlime();
        }
    }

    public void MoveSlime()
    {
        if (LastDirektion.x != 0f || LastDirektion.y != 0f)
        {
            if (Vector3.Distance(transform.position, movePoint.position) <= 0f)
            {
                if (!Physics2D.OverlapCircle(movePoint.position + new Vector3(MoveDirektionX, MoveDirektionY, 0f), .2f, whatStopsMovement))
                {
                    LastDirektion.x = 0f;
                    LastDirektion.y = 0f;

                    movePoint.position += new Vector3(MoveDirektionX, MoveDirektionY, 0f);

                    MoveDirektionX *= -1;
                    MoveDirektionY *= -1;
                }
            }
        }
    }
}
