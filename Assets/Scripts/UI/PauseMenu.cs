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
                PauseGameAndShowPauseMenu();
            }
        }    
    }

    public void LoadMainMenu() 
    {
        this.ToggleGamePaused();
        SceneManager.LoadScene("MainMenu");
        
    }


    public void ResumeGame() 
    {
        pauseMenuRef.SetActive(false);
        ToggleGamePaused();
    }

    public void PauseGame()
    {  
        ToggleGamePaused();
    }

    void PauseGameAndShowPauseMenu() 
    {
        pauseMenuRef.SetActive(true);
        this.PauseGame();
    }

    void ToggleGamePaused()
    {
        Time.timeScale = Time.timeScale == 0f? 1f : 0f;
        GamePaused = !GamePaused;
    }

}
