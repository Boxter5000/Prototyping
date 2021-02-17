using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogTrigger : MonoBehaviour
{
    public int DialogeOnCollect;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
        FindObjectOfType<GameDialog>().StartDialoge(DialogeOnCollect);
        //Some Animation shit
        Destroy(gameObject);
        }
    }
}
