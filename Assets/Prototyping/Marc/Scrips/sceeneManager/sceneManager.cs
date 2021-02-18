using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class sceneManager : MonoBehaviour
{
    private UIController uiController;
    public string HappySceenName;
    public string MediumSceenName;
    public string DarkSceenName;

    private void Awake()
    {
        uiController = FindObjectOfType<UIController>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(uiController.gummyBearCount <= 1f)
        {
        SceneManager.LoadScene(HappySceenName);
        }
        if (uiController.gummyBearCount > 1f)
        {
            SceneManager.LoadScene(MediumSceenName);
        }
        if (uiController.gummyBearCount > 2f)
        {
            SceneManager.LoadScene(DarkSceenName);
        }
    }
}
