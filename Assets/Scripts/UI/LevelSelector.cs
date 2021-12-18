using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelSelector : MonoBehaviour
{

    public Button[] levelEntries;

    void Start() 
    {
        int lastUnlockedLevel = PlayerPrefs.GetInt("lastUnlockedLevel", 1) ;
        
        for (int i = 0; i < levelEntries.Length; i++) 
        {
            int levelNumber = i+1;
            int coins = PlayerPrefs.GetInt(levelNumber + "_coins", 0);
            int deaths = PlayerPrefs.GetInt(levelNumber + "_deaths", 0);
            int totalCoinsInLevel = PlayerPrefs.GetInt(levelNumber + "_totalCoins", 0);
            levelEntries[i].GetComponentInChildren<LevelSelectEntry>().SetLevelData(coins, deaths, totalCoinsInLevel);
            
            //unlock levels that are only one above last completed level
            if (levelNumber > lastUnlockedLevel) 
            {
                levelEntries[i].interactable = false;
            }
        }
    }

    public void SelectSceneByTitle(string levelSceneTitle) 
    {
        SceneManager.LoadScene(levelSceneTitle);
    }
    
}
