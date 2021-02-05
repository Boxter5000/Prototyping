using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxKicking : MonoBehaviour
{
    public float moveSpeed = 5;
    public Transform movePoint;


    public LayerMask whatStopsMovement;
    public List<Vector3> LastBoxMoves;
    

    void Start()
    {
        movePoint.parent = null;
        LastBoxMoves = new List<Vector3>();
    }

    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, movePoint.position, moveSpeed * Time.deltaTime);
        if (Input.GetButtonDown("Vertical") || Input.GetButtonDown("Horizontal"))
        {
            UpdateBoxPosition();
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            ReturnToLastPosition();
        }
    }

    public void MoveBoxHorizontal(float direktion)
    {
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
        if (Vector3.Distance(transform.position, movePoint.position) <= .05f)
        {
            if (!Physics2D.OverlapCircle(movePoint.position + new Vector3(0f, direktion, 0f), .2f, whatStopsMovement))
            {
                movePoint.position += new Vector3(0f, direktion, 0f);
            }
        }
    }

    /*private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Collidet");
        if(collision.gameObject.tag == "Enemy")
        {
        movePoint.position = LastBoxMoves[LastBoxMoves.Count - 1];
        }
    }*/

    public void ReturnToLastPosition()
    {
        movePoint.position = LastBoxMoves[LastBoxMoves.Count - 2];
        LastBoxMoves.RemoveAt(LastBoxMoves.Count - 1);
    }

    public void UpdateBoxPosition()
    {
        LastBoxMoves.Add(movePoint.position);
    }
}
