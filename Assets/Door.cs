using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public int myDoorIndex;

    public void OpenDoor(int index)
    {

        if(index == myDoorIndex)
        {
            gameObject.SetActive(false);
        }
        else if(index == myDoorIndex)
        {
            gameObject.SetActive(false);
        }

    }


}
