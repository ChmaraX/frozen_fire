using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelCompleteTriggerBehavior : MonoBehaviour
{
    
    public int levelToUnlock;

    private int totalCoinsInLevel;

    void Start() 
    {
        //level has been activated - that means it's unlocked and total coin count should be persisted
        this.totalCoinsInLevel = GameObject.FindGameObjectsWithTag("Coin").Length;
        PlayerPrefs.SetInt(levelToUnlock - 1 + "_totalCoins", totalCoinsInLevel);
    }

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
            itemCollector.collectedCoins = LimitCollectedCoins(itemCollector.collectedCoins);
            
            GameObject levelCompleteWindow = GameObject.FindWithTag("LevelEnd");
            levelCompleteWindow.GetComponent<LevelEndController>()
                    .ShowLevelCompleted(collider.gameObject.GetComponent<PlayerLife>());
                    
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
            PlayerPrefs.SetInt(levelToUnlock-1 + "_coins", LimitCollectedCoins(itemCollector.collectedCoins));
            PlayerPrefs.SetInt(levelToUnlock-1 + "_deaths", itemCollector.deathCount);
        }

        PlayerPrefs.Save();
    }

    //In case player collected more coins than totalCoins in level (chest dropped coins), 
    //set collected coins to totalCoins instead of quantity larger than totalCoins
    private int LimitCollectedCoins(int collectedCoins) 
    {
        return totalCoinsInLevel < collectedCoins ? totalCoinsInLevel : collectedCoins;
    }

}
