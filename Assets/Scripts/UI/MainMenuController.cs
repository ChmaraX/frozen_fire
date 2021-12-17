using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    public void PlayFirstAvailableLevel()
	{
		SceneManager.LoadScene("Level1_Tutorial");
	}

	public void OpenLevelSelect() 
	{
		SceneManager.LoadScene("LevelSelect");
	}

	public void ExitGame() 
	{
		Application.Quit();
	}

   
}
