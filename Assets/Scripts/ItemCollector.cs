using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemCollector : MonoBehaviour
{

    public int collectedCoins = 0;
    public int collectedHPs = 0;
    public Vector3 lastCheckpointPos;

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

        // dont add hps to inventory
        if (item.Name == "HP")
        {
            increaseHPsBy(1);
            Destroy(collider.gameObject);
            return;
        }

        if (item.Name == "Checkpoint")
        {
            lastCheckpointPos = collider.gameObject.transform.position;

            // prevent checkpoint from being picked again
            BoxCollider2D boxCollider2D = collider.gameObject.GetComponent<BoxCollider2D>();
            boxCollider2D.enabled = false;

            // change opacity to 0.5 to indicate it was already taken
            SpriteRenderer sprite = collider.gameObject.GetComponent<SpriteRenderer>();
            sprite.color = new Color(255, 255, 255, .5f);

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
