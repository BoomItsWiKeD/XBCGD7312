using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour
{
    public void OnPlayClick()
    {
        SceneManager.LoadScene(1);
    }

    public void OnQuitClick()
    {
        Application.Quit();
    }
}
