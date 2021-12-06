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

    public void OnPickUp()
    {
        // TODO: additional logic what happens when fireball is picked up
        gameObject.SetActive(false);
    }
}
