using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMenu : MonoBehaviour
{
    private UIController uiController;
    private void Awake()
    {
        uiController = FindObjectOfType<UIController>();
    }

    public void Return()
    {
        gameObject.SetActive(false);
    }
    public void MainMenu()
    {
        gameObject.SetActive(false);
        uiController.OpenMenu();
        SceneManager.LoadScene("MainMenu");
    }
    public void Quit()
    {
        Application.Quit();
    }
    public void Open()
    {
        if (gameObject.activeSelf == true)
        {
            gameObject.SetActive(false);
        }
        else
        {
            gameObject.SetActive(true);
        }

    }
}
