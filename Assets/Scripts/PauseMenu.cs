using System.Threading;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool GamePaused = false;

    public GameObject pauseMenuRef;
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) 
        {
            if (GamePaused) 
            {
                ResumeGame();
            } 
            else 
            {
                PauseGame();
            }
        }    
    }

    public void LoadMainMenu() 
    {
        SceneManager.LoadScene("MainMenu");
    }


    public void ResumeGame() 
    {
        pauseMenuRef.SetActive(false);
        Time.timeScale = 1f;
        ToggleGamePaused();
        
    }

    void PauseGame() 
    {
        pauseMenuRef.SetActive(true);
        Time.timeScale = 0f;
        ToggleGamePaused();
    }

    void ToggleGamePaused()
    {
        GamePaused = !GamePaused;
    }

}
