using UnityEngine;

public class ChestItem : MonoBehaviour, IInventoryItem
{

    public string Name
    {
        get
        {
            return "Chest";
        }
    }

    public Sprite _Image = null;

    public Sprite Image
    {
        get
        {
            return _Image;
        }
    }

    public InventorySlot _Slot = null;

    public InventorySlot Slot
    {
        get
        {
            return _Slot;
        }
        set
        {
            _Slot = value;
        }
    }

    public bool IsStorable => false;

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.CompareTag("Player"))
        {
            ItemCollector itemCollector = collision.gameObject.GetComponent<ItemCollector>();
            itemCollector.increaseCoinsBy(5);
            Destroy(gameObject);
        }
    }

    public void OnUse()
    {
        Debug.Log("Item Chest was used");
    }
}
