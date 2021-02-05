using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxPull : MonoBehaviour
{
    public bool beeingPulled;
    float xPos;
    float yPos;

    private void Start()
    {
        xPos = transform.position.x;
        yPos = transform.position.y;
    }

    void Update()
    {
        if(beeingPulled == false)
        {
            transform.position = new Vector3(xPos, yPos);
        }
        else
        {
            xPos = transform.position.x;
            yPos = transform.position.y;
        }
    }
}
