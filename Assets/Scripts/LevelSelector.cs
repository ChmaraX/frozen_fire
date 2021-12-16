using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelSelector : MonoBehaviour
{

    public Button[] levelEntries;

    void Start() 
    {
        int levelReached = PlayerPrefs.GetInt("LastReachedLevel", 1);

        for (int i = 0; i < levelEntries.Length; i++) 
        {
            Debug.Log(levelEntries[i]);
            
            if (i+1 > levelReached) 
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
