using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public float gummyBearCount;
    public Text gummyBearText;



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Gummibear")
        {
            UpdateGummyBear();
        }
    }

    public void UpdateGummyBear()
    {
        gummyBearCount++;
        gummyBearText.text = gummyBearCount.ToString();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            transform.Find("GameMenu").GetComponent<GameMenu>().Open();
        }
    }
}
