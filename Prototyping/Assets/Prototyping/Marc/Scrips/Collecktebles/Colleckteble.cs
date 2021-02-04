using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Colleckteble : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        FindObjectOfType<UIController>().UpdateGummyBear();
        //Some Animation shit
        Destroy(gameObject);
    }
}
