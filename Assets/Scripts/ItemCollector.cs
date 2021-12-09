using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemCollector : MonoBehaviour
{

    public int collectedCoins = 0;
    public int collectedHPs = 0;

    [SerializeField] private Text coinsText;
    [SerializeField] private Text hpsText;


    public Inventory inventory;

    private void OnTriggerEnter2D(Collider2D collider)
    {
        IInventoryItem item = collider.gameObject.GetComponent<IInventoryItem>();

        if (item == null)
        {
            return;
        }

        // dont add coins to inventory
        if (item.Name == "Coin")
        {
            increaseCoinsBy(1);
            Destroy(collider.gameObject);
            return;
        }

        Debug.Log(item.Name);

        if (item.Name == "HP")
        {
            increaseHPsBy(1);
            Destroy(collider.gameObject);
            return;
        }

        inventory.AddItem(item);

    }

    private void increaseHPsBy(int amount)
    {
        collectedHPs += amount;
        hpsText.text = collectedHPs.ToString();
    }

    public void decreaseHPsBy(int amount)
    {
        collectedHPs -= amount;
        hpsText.text = collectedHPs.ToString();
    }

    private void increaseCoinsBy(int amount)
    {
        collectedCoins += amount;
        coinsText.text = collectedCoins.ToString();
    }

    public void decreaseCoinsBy(int amount)
    {
        collectedCoins -= amount;
        coinsText.text = collectedCoins.ToString();
    }

}
