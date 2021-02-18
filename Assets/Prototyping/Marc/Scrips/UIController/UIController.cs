using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public float gummyBearCount;
    public Text gummyBearText;
    public bool CoolecktetintheScene;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);       
    }

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
        CoolecktetintheScene = true;
        gummyBearText.text = gummyBearCount.ToString();
    }

    public void GummiBearDecrease()
    {
        gummyBearCount--;
        CoolecktetintheScene = false;
        gummyBearText.text = gummyBearCount.ToString();
    }

    public void NewScene()
    {
        CoolecktetintheScene = false;
        gameObject.SetActive(true);
    }

    public void OpenMenu()
    {

    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            transform.Find("GameMenu").GetComponent<GameMenu>().Open();
        }
    }
}
