using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemCollector : MonoBehaviour
{

    private int collectedCoins = 0;

    [SerializeField] private Text coinsText; 

    public Inventory inventory;

    private void OnTriggerEnter2D(Collider2D collider)
    {
        IInventoryItem item = collider.gameObject.GetComponent<IInventoryItem>();

        // dont add coins to inventory
        if (item.Name == "Coin")
        {
            collectedCoins++;
            Destroy(collider.gameObject);
            coinsText.text = collectedCoins.ToString();
            return;
        }

        if (item != null)
        {
            inventory.AddItem(item);
        }
    }
}
