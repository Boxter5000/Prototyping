using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Druckplatte : MonoBehaviour
{
    public int DoorIndex;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        FindObjectOfType<Door>().OpenDoor(DoorIndex);
    }
}
