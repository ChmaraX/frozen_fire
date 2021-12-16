
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelCompleteTriggerBehavior : MonoBehaviour
{
    
    public GameObject levelCompleteWindow;
    public PauseMenu pauseMenu;

    private void OnTriggerEnter2D(Collider2D collider) {
        //find out if player
        if (collider.gameObject.CompareTag("Player"))
        {
            ItemCollector itemCollector = collider.gameObject.GetComponent<ItemCollector>();
            pauseMenu.GetComponent<PauseMenu>().PauseGame();
            levelCompleteWindow.GetComponent<LevelCompletedController>()
                    .SetValuesAndOpenWindow(itemCollector.collectedCoins, itemCollector.deathCount);
                    
        }
    }

}
