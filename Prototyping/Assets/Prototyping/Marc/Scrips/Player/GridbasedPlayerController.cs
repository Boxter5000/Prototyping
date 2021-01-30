using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridbasedPlayerController : MonoBehaviour
{
    public float moveSpeed = 5;
    public Transform movePoint;

    [SerializeField]public LayerMask whatStopsMovement;
    [SerializeField]public LayerMask whatIsPushable;

    float RayDistance = 1f;
    Vector2 movement;
    Vector2 LastDirektion;
    GameObject box;

    // Start is called before the first frame update
    void Start()
    {
        movePoint.parent = null;
    }

    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        if (movement.x != 0f || movement.y != 0f)
        {
            LastDirektion = movement;
        }

        transform.position = Vector3.MoveTowards(transform.position, movePoint.position, moveSpeed * Time.deltaTime);

        if(Vector3.Distance(transform.position, movePoint.position) <= .05f)
        {
            if (Mathf.Abs(movement.x) == 1f)
            {
                if (!Physics2D.OverlapCircle(movePoint.position + new Vector3(movement.x, 0f, 0f), .2f, whatStopsMovement))
                {
                    movePoint.position += new Vector3(movement.x, 0f, 0f);
                }
                if (Physics2D.OverlapCircle(movePoint.position + new Vector3(movement.x, 0f, 0f), .2f, whatIsPushable))
                {
                    RaycastHit2D hit = Physics2D.Raycast(transform.position, LastDirektion * transform.localScale.x, RayDistance, whatIsPushable);
                    if(hit)
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
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;

        Gizmos.DrawLine(transform.position, (Vector2)transform.position + LastDirektion * transform.localScale.x * RayDistance);
    }
}