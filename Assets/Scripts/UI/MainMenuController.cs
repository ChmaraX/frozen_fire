using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    public void PlayFirstAvailableLevel()
	{
		int lastUnlockedLevel = PlayerPrefs.GetInt("lastUnlockedLevel", 1);
		SceneManager.LoadScene("Level_" + lastUnlockedLevel);
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
