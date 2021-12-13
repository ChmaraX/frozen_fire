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

    public void OnPickUp()
    {
        gameObject.SetActive(false);
    }

    public void OnUse()
    {        
        Debug.Log("Item Iceball was used");
    }
}
