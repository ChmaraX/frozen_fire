using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
	//plays first available level, if level 4 (game complete) is the last unlocked, display credits
    public void PlayFirstAvailableLevel()
	{
		int lastUnlockedLevel = PlayerPrefs.GetInt("lastUnlockedLevel", 1);
		if (lastUnlockedLevel == 4) 
		{
			OpenCredits();
		}
		else 
		{
			OpenScene("Level_" + lastUnlockedLevel);
		}
	}

	public void OpenLevelSelect() 
	{
		OpenScene("LevelSelect");
	}

	public void OpenCredits() 
	{
		OpenScene("Credits");
	}

	private void OpenScene(string sceneName) 
	{
		SceneManager.LoadScene(sceneName);
	}

	public void ExitGame() 
	{
		Application.Quit();
	}

   
}
