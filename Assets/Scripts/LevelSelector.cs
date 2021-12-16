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
