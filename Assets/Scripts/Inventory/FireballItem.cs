using UnityEngine;

public class FireballItem : MonoBehaviour, IInventoryItem
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

    public void OnPickUp()
    {
        gameObject.SetActive(false);
    }

    public void OnUse()
    {
        Debug.Log("Item Fireball was used");
    }
}
