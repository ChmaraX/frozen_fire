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

      
        if (item.Name == "Checkpoint")
        {
            lastCheckpointPos = collider.gameObject.transform.position;
        }

        if (item.GetType().ToString() == "FireballItem3x")
        {
            // add +2 Fireball items to inv
            inventory.AddItem(item);
            inventory.AddItem(item);
        }

        if (item.IsStorable)
        {
            inventory.AddItem(item);
        }

    }

    public void increaseHPsBy(int amount)
    {
        collectedHPs += amount;
        hpsText.text = collectedHPs.ToString();
    }

    public void decreaseHPsBy(int amount)
    {
        collectedHPs -= amount;
        hpsText.text = collectedHPs.ToString();
    }

    public void increaseCoinsBy(int amount)
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
