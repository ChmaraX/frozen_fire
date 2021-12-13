using UnityEngine;

public class IceballItem : MonoBehaviour, IInventoryItem
{
    public string Name
    {
        get
        {
            return "Iceball";
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

    public bool IsStorable => true;

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }

    public void OnUse()
    {        
        Debug.Log("Item Iceball was used");
    }
}
