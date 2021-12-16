using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelCompleteTriggerBehavior : MonoBehaviour
{
    
    public GameObject levelCompleteWindow;
    public int levelToUnlock;

    private void OnTriggerEnter2D(Collider2D collider) {
        //find out if player
        if (collider.gameObject.CompareTag("Player"))
        {
            PlayerPrefs.SetInt("lastUnlockedLevel", levelToUnlock);
            PlayerPrefs.Save();
            ItemCollector itemCollector = collider.gameObject.GetComponent<ItemCollector>();
            collider.gameObject
                .GetComponent<Rigidbody2D>()
                .constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezePositionY;

            levelCompleteWindow.GetComponent<LevelCompletedController>()
                    .SetValuesAndOpenWindow(itemCollector.collectedCoins, itemCollector.deathCount);
                    
        }
    }

}
