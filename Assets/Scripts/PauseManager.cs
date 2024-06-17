using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseManager : MonoBehaviour
{
    public static bool isPaused;
    public GameObject pauseMenu;
    
    void Start()
    {
        isPaused = false;
    }

    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                Unpause();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Unpause()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
    }

    public void Pause()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
    }

    public void OnResumeClick()
    {
        Unpause();
    }
    
    public void OnMainMenuClick()
    {
        SceneManager.LoadScene(0);
    }
}
