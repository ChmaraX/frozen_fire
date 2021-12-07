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

    public void OnPickUp()
    {
        // TODO: additional logic what happens when fireball is picked up
        gameObject.SetActive(false);
    }

    public void OnUse()
    {
        Debug.Log("Item Iceball was used");
    }
}
