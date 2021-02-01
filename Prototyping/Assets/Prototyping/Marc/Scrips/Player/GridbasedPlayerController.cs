using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridbasedPlayerController : MonoBehaviour
{
    public float moveSpeed = 5;
    public Transform movePoint;

    [SerializeField]public LayerMask whatStopsMovement;
    [SerializeField]public LayerMask whatIsPushable;

    public List<Vector3> LastMoves;
    float RayDistance = 1f;
    Vector2 lastPlayerPos;
    Vector2 movement;
    Vector2 LastDirektion;
    GameObject box;
    int MoveCount;

    void Start()
    {
        movePoint.parent = null;
        LastMoves = new List<Vector3>(30);
    }

    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        if (movement.x != 0f || movement.y != 0f)
        {
            LastDirektion = movement;
            MovePlayer();
        }

        if (Input.GetKeyDown(KeyCode.Z))
        {
            ReturnOneMove();
        }

        transform.position = Vector3.MoveTowards(transform.position, movePoint.position, moveSpeed * Time.deltaTime);
    }

    public void MovePlayer()
    {
        if (Vector3.Distance(transform.position, movePoint.position) <= .05f)
        {
            if (Mathf.Abs(movement.x) == 1f)
            {
                if (!Physics2D.OverlapCircle(movePoint.position + new Vector3(movement.x, 0f, 0f), .2f, whatStopsMovement))
                {
                    LastMoves.Add(movePoint.position);
                    movePoint.position += new Vector3(movement.x, 0f, 0f);
                }
                if (Physics2D.OverlapCircle(movePoint.position + new Vector3(movement.x, 0f, 0f), .2f, whatIsPushable))
                {
                    RaycastHit2D hit = Physics2D.Raycast(transform.position, LastDirektion * transform.localScale.x, RayDistance, whatIsPushable);
                    if (hit)
                    {
                        box = hit.collider.gameObject;
                        box.GetComponent<BoxKicking>().MoveBoxHorizontal(movement.x);
                    }
                    else
                    {
                        Debug.Log("target not found");
                    }
                }
            }
            else if (Mathf.Abs(movement.y) == 1f)
            {
                if (!Physics2D.OverlapCircle(movePoint.position + new Vector3(0f, movement.y, 0f), .2f, whatStopsMovement))
                {
                    LastMoves.Add(movePoint.position);
                    movePoint.position += new Vector3(0f, movement.y, 0f);
                }
                if (Physics2D.OverlapCircle(movePoint.position + new Vector3(0f, movement.y, 0f), .2f, whatIsPushable))
                {
                    RaycastHit2D hit = Physics2D.Raycast(transform.position, LastDirektion * transform.localScale.x, RayDistance, whatIsPushable);
                    if (hit)
                    {
                        box = hit.collider.gameObject;
                        box.GetComponent<BoxKicking>().MoveBoxVertical(movement.y);
                    }
                    else
                    {
                        Debug.Log("target not found");
                    }
                }
            }
        }
    }

    private void ReturnOneMove()
    {
        if(LastMoves.Count > 0)
        {
        movePoint.position = LastMoves[LastMoves.Count - 1];
        LastMoves.RemoveAt(LastMoves.Count - 1);
        FindObjectOfType<BoxKicking>().ReturnToLastPosition();
        }
        else
        {
            Debug.LogWarning("No More Moves Left to go back");
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;

        Gizmos.DrawLine(transform.position, (Vector2)transform.position + LastDirektion * transform.localScale.x * RayDistance);
    }
}