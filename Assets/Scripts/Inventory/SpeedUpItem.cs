using UnityEngine;

public class SpeedUpItem : MonoBehaviour, IInventoryItem
{
    [SerializeField] GameObject pickupEffect;

    private PlayerMovement playerMovement;

    public string Name
    {
        get
        {
            return "SpeedUp";
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

    public bool IsStorable => true;

    public bool hasOnUse => true;

    public void OnUse()
    {
        playerMovement.moveSpeed = 14f;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.CompareTag("Player"))
        {
            playerMovement = collision.gameObject.GetComponent<PlayerMovement>();
            Destroy(gameObject);

            Instantiate(pickupEffect, transform.position, Quaternion.identity);
            SoundManagerScript.PlaySound("chestOpen");
        }
    }
}
