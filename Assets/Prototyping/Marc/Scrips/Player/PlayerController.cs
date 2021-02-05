using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float MoveSpeed;
    public float RayDistance = 1f;
    public LayerMask BoxMask;

    bool m_FacingRight;
    Vector2 LastDirektion;
    GameObject box;
    Rigidbody2D rb2D;
    Vector2 movement;

    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        // Getting the direktion for Player movement
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.D))
        {
            LastDirektion = movement;
        }

        Physics2D.queriesStartInColliders = false;
        RaycastHit2D hit = Physics2D.Raycast(transform.position, LastDirektion * transform.localScale.x, RayDistance, BoxMask);

        if(hit.collider != null && hit.collider.gameObject.tag == "Pushable" && Input.GetKey(KeyCode.LeftShift))
        {
            box = hit.collider.gameObject;

            box.GetComponent<FixedJoint2D>().enabled = true;
            box.GetComponent<BoxPull>().beeingPulled = true;
            box.GetComponent<FixedJoint2D>().connectedBody = this.GetComponent<Rigidbody2D>();

            if(LastDirektion.x != 0)
            {
                rb2D.constraints = RigidbodyConstraints2D.FreezePositionY;
            }else if(LastDirektion.y != 0)
            {
                rb2D.constraints = RigidbodyConstraints2D.FreezePositionX;
            }
        }
        else if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            box.GetComponent<FixedJoint2D>().enabled = false;
            box.GetComponent<BoxPull>().beeingPulled = false;

            rb2D.constraints = RigidbodyConstraints2D.None;
            rb2D.constraints = RigidbodyConstraints2D.FreezeRotation;
        }
        if (LastDirektion.x < 0)
        {
            m_FacingRight = false;
            transform.localRotation = Quaternion.Euler(0, 180, 0);
        }
        else
        {
            m_FacingRight = true;
            transform.localRotation = Quaternion.Euler(0, 0, 0);
        }
    }

    private void FixedUpdate()
    {
        //Moving the player
        rb2D.MovePosition(rb2D.position + movement * MoveSpeed * Time.fixedDeltaTime);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;

        Gizmos.DrawLine(transform.position, (Vector2)transform.position + LastDirektion * transform.localScale.x * RayDistance);
    }
}
