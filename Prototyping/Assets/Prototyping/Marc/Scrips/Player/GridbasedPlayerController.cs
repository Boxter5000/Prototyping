using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GridbasedPlayerController : MonoBehaviour
{
    //Parameter
    public float moveSpeed = 5;
    public Transform movePoint;

    public LayerMask whatStopsMovement;
    public LayerMask whatIsPushable;

    public List<Vector3> LastPlayerMoves;
    float RayDistance = 1f;
    Vector2 lastPlayerPos;
    Vector2 movement;
    Vector2 LastDirektion;
    GameObject box;
    int MoveCount;

    void Start()
    {
        // split movepoint from Player / create list to remember moves
        movePoint.parent = null;
        LastPlayerMoves = new List<Vector3>();
    }

    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        //if any move button is pressed, remember the last direktion for the Raycast
        if (movement.x != 0f || movement.y != 0f)
        {
            LastDirektion = movement;
            MovePlayer();
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            ReturnOneMove();
        }

        //try to move to the Movepoint
        transform.position = Vector3.MoveTowards(transform.position, movePoint.position, moveSpeed * Time.deltaTime);
    }

    public void MovePlayer()
    {
        if (Vector3.Distance(transform.position, movePoint.position) <= .05f)
        {
            // Horizontal movement
            if (Mathf.Abs(movement.x) == 1f)
            {
                //check if the path is free to move frome anything that shood stop your movement
                if (!Physics2D.OverlapCircle(movePoint.position + new Vector3(movement.x, 0f, 0f), .2f, whatStopsMovement))
                {
                    //save the move
                    SaveMove();
                    movePoint.position += new Vector3(movement.x, 0f, 0f);
                }

                //if the circle is detektng something that can be pushed, chast a ray to know what object it is
                if (Physics2D.OverlapCircle(movePoint.position + new Vector3(movement.x, 0f, 0f), .2f, whatIsPushable))
                {
                    RaycastHit2D hit = Physics2D.Raycast(transform.position, LastDirektion * transform.localScale.x, RayDistance, whatIsPushable);
                    if (hit)
                    {
                        box = hit.collider.gameObject;
                        box.GetComponent<BoxKicking>().MoveBoxHorizontal(movement.x);
                        //save the move
                        if (Input.GetButtonDown("Horizontal"))
                        {
                            SaveMove();
                        }
                    }
                    else
                    {
                        Debug.Log("target not found");
                    }
                }
            }
            // Vertical movement, Same as horizontal, just in y dir.
            else if (Mathf.Abs(movement.y) == 1f)
            {
                if (!Physics2D.OverlapCircle(movePoint.position + new Vector3(0f, movement.y, 0f), .2f, whatStopsMovement))
                {
                    SaveMove();
                    movePoint.position += new Vector3(0f, movement.y, 0f);
                }
                if (Physics2D.OverlapCircle(movePoint.position + new Vector3(0f, movement.y, 0f), .2f, whatIsPushable))
                {

                    RaycastHit2D hit = Physics2D.Raycast(transform.position, LastDirektion * transform.localScale.x, RayDistance, whatIsPushable);
                    if (hit)
                    {
                        box = hit.collider.gameObject;
                        box.GetComponent<BoxKicking>().MoveBoxVertical(movement.y);
                        if (Input.GetButtonDown("Vertical"))
                        {
                            SaveMove();
                        }
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
        if(LastPlayerMoves.Count > 0)
        {
        movePoint.position = LastPlayerMoves[LastPlayerMoves.Count - 1];
        LastPlayerMoves.RemoveAt(LastPlayerMoves.Count - 1);
        }
        else
        {
            Debug.LogWarning("No More Moves Left to go back");
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("aua");
        if (collision.gameObject.tag == "Enemy")
        {
            Scene scene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(scene.name);
        }
    }

    public void SaveMove()
    {
        LastPlayerMoves.Add(movePoint.position);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;

        Gizmos.DrawLine(transform.position, (Vector2)transform.position + LastDirektion * transform.localScale.x * RayDistance);
    }
}