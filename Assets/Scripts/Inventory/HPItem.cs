using UnityEngine;

public class HPItem : MonoBehaviour, IInventoryItem
{
    public string Name
    {
        get
        {
            return "HP";
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
            itemCollector.increaseHPsBy(1);
            Destroy(gameObject);
        }
    }

    public void OnUse()
    {
        // coins can't be used
    }
}
