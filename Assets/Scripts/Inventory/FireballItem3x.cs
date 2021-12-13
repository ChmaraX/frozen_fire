using UnityEngine;

public class FireballItem3x : MonoBehaviour, IInventoryItem
{
    public string Name
    {
        get
        {
            return "Fireball";
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
        Debug.Log("Item Fireball3x was used");
    }
}
