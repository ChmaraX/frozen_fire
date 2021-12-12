using UnityEngine;

public class CoinItem : MonoBehaviour, IInventoryItem
{
    public string Name
    {
        get
        {
            return "Coin";
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
        // coins can't be used
    }
}
