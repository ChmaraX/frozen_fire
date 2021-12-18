using UnityEngine;

public class FireballItem : MonoBehaviour, IInventoryItem
{
    public FireProjectileBehaviour fireProjectile;
    private PlayerMovement playerMovement;

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

    public bool IsStorable => true;

    public bool hasOnUse => true;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerMovement = collision.gameObject.GetComponent<PlayerMovement>();
            Destroy(gameObject);
        }
    }

    public void OnUse()
    {
        Instantiate(fireProjectile,
            new Vector3(
                playerMovement.transform.position.x + 1,
                playerMovement.transform.position.y,
                -1),
            playerMovement.transform.rotation);
        SoundManagerScript.PlaySound("playerFire");
    }
}
