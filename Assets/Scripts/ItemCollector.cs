using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemCollector : MonoBehaviour
{

    private int collectedCoins = 0;

    [SerializeField] private Text coinsText; 

    private void OnTriggerEnter2D(Collider2D collider) 
    {
        if (collider.gameObject.CompareTag("Coin")) 
        {
            collectedCoins++;
            Destroy(collider.gameObject);
            coinsText.text = collectedCoins.ToString();
        }
    }
}
