using UnityEngine;
using UnityEngine.UI;

public class ItemCollector : MonoBehaviour
{

    public int collectedCoins = 0;
    public int collectedHPs = 0;
    public int deathCount = 0;
    public Vector3 lastCheckpointPos;

    public Inventory inventory;

    void Start() {
        this.increaseHPsBy(3);
    }

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
            return;
        }

        string itemTypeString = item.GetType().ToString();

        if (item.IsStorable)
        {
            if (itemTypeString[^2..] == "3x")
            {
                // add +2 of item to inv
                inventory.AddItem(item);
                inventory.AddItem(item);
            }
            inventory.AddItem(item);
        }

    }

    public void increaseHPsBy(int amount)
    {
        collectedHPs += amount;
        inventory.AddHps(amount);
    }

    public void decreaseHPsBy(int amount)
    {
        deathCount++;
        if (collectedHPs == 0) 
        {
            //GAME OVER GO DIE MAIN MENU
        }
        collectedHPs -= amount;
        inventory.AddHps(-amount);
    }

    public void increaseCoinsBy(int amount)
    {
        collectedCoins += amount;
        inventory.AddCoins(amount);
    }

    public void decreaseCoinsBy(int amount)
    {
        collectedCoins -= amount;
        inventory.AddCoins(-amount);
    }

}
