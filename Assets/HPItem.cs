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

    public void OnPickUp()
    {
        gameObject.SetActive(false);
    }

    public void OnUse()
    {
        // coins can't be used
    }
}
