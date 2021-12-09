using UnityEngine;

public class CheckpointItem : MonoBehaviour, IInventoryItem
{

    public string Name
    {
        get
        {
            return "Checkpoint";
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
        Debug.Log("Item Checkpoint was used");
    }
}
