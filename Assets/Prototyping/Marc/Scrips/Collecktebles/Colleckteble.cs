using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Colleckteble : MonoBehaviour
{
    public int DialogeOnCollect;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        FindObjectOfType<UIController>().UpdateGummyBear();
        FindObjectOfType<GameDialog>().StartDialoge(DialogeOnCollect);
        //Some Animation shit
        Destroy(gameObject);
    }
}
