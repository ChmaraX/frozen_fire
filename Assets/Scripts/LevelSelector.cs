using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelSelector : MonoBehaviour
{

    public Button[] levelEntries;

    void Start() 
    {
        int lastUnlockedLevel = PlayerPrefs.GetInt("lastUnlockedLevel", 1) ;
        
        // Debug.Log(levelEntries[i].GetComponentsInChildren<Text>());

        // levelEntries = new Button[transform.childCount];
        for (int i = 0; i < levelEntries.Length; i++) 
        {
            int levelNumber = i+1;
            int coins = PlayerPrefs.GetInt(levelNumber + "_coins", 0);
            int deaths = PlayerPrefs.GetInt(levelNumber + "_deaths", 0);
            levelEntries[i].GetComponentInChildren<LevelSelectEntry>().SetLevelData(coins, deaths);
            
            //unlock levels that are only one above last completed level
            if (i+1 > lastUnlockedLevel) 
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
