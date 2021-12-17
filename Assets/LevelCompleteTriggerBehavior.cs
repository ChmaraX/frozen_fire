using UnityEngine;

public class LevelCompleteTriggerBehavior : MonoBehaviour
{
    
    public GameObject levelCompleteWindow;
    public int levelToUnlock;

    private void OnTriggerEnter2D(Collider2D collider) {
        //find out if player
        if (collider.gameObject.CompareTag("Player"))
        {
            SoundManagerScript.PlaySound("victory");
            ItemCollector itemCollector = collider.gameObject.GetComponent<ItemCollector>();
            this.SaveProgress(itemCollector);
            collider.gameObject
                .GetComponent<Rigidbody2D>()
                .constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezePositionY;

            levelCompleteWindow.GetComponent<LevelCompletedController>()
                    .SetValuesAndOpenWindow(itemCollector.collectedCoins, itemCollector.deathCount);
                    
        }
    }

    private void SaveProgress(ItemCollector itemCollector) 
    {
        int savedUnlockedLevel = PlayerPrefs.GetInt("lastUnlockedLevel");
        int previousCollectedCoins = PlayerPrefs.GetInt(levelToUnlock-1 +"_coins", 0);
        int previousDeaths = PlayerPrefs.GetInt(levelToUnlock-1 +"_deaths", 0);

        //check if levelToUnlock is not already unlocked
        if (savedUnlockedLevel < levelToUnlock) 
        {
            PlayerPrefs.SetInt("lastUnlockedLevel", levelToUnlock);
        }

        //check if current coins collected & deaths are better than saved 
        if (previousCollectedCoins <= itemCollector.collectedCoins && previousDeaths >= itemCollector.deathCount) 
        {
            PlayerPrefs.SetInt(levelToUnlock-1 + "_coins", itemCollector.collectedCoins);
            PlayerPrefs.SetInt(levelToUnlock-1 + "_deaths", itemCollector.deathCount);
        }

        PlayerPrefs.Save();
    }

}
