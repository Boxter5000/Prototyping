using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeMovement : MonoBehaviour
{
    public float moveSpeed = 5;
    public Transform movePoint;
    public float MoveDirektionX;               // 1 if you the Enemy to move Horitontal 
    public float MoveDirektionY;                 // 1 if you want the enemy to move vertical
    public float moves;
    public LayerMask whatStopsMovement;
    public float movesLeft;

    Vector2 movement;
    Vector2 LastDirektion;
    public List<Vector3> LastEnemyMove;

    void Start()
    {
        movePoint.parent = null;

        LastEnemyMove = new List<Vector3>();

        if(movesLeft == 0)
        {
            movesLeft = moves;
        }
    }

    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, movePoint.position, moveSpeed * Time.deltaTime);
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        if (Input.GetButtonDown("Horizontal") || Input.GetButtonDown("Vertical"))
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
                    movesLeft--;
                    SaveMove();
                    if (movesLeft <= 0)
                    {
                        MoveDirektionX *= -1;
                        MoveDirektionY *= -1;
                        movesLeft += moves;
                    }
                }
                else
                {
                    MoveDirektionX *= -1;
                    MoveDirektionY *= -1;
                    movesLeft = moves - movesLeft;
                }
            }
        }
    }
    public void SaveMove()
    {
        LastEnemyMove.Add(movePoint.position);
    }

    public void ReturnToLastPosition()
    {
        movePoint.position = LastEnemyMove[LastEnemyMove.Count - 2];
        LastEnemyMove.RemoveAt(LastEnemyMove.Count - 1);
        movesLeft++;
        if(movesLeft == moves)
        {
            movesLeft = 0f;
        }
    }
}
