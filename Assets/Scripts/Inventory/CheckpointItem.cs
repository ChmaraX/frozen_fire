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

    public bool IsStorable => false;

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.CompareTag("Player"))
        {
            // prevent checkpoint from being picked again
            BoxCollider2D boxCollider2D = gameObject.GetComponent<BoxCollider2D>();
            boxCollider2D.enabled = false;

            // change opacity to 0.5 to indicate it was already taken
            SpriteRenderer sprite = gameObject.GetComponent<SpriteRenderer>();
            sprite.color = new Color(255, 255, 255, .5f);
        }
    }

    public void OnUse()
    {
        Debug.Log("Item Checkpoint was used");
    }
}
