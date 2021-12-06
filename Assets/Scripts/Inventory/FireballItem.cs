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
        // TODO: additional logic what happens when fireball is picked up
        gameObject.SetActive(false);
    }
}
