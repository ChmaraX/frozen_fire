using System;
using UnityEngine;

public class ChestItem : MonoBehaviour, IInventoryItem
{
    [SerializeField] GameObject openHpEffect;
    [SerializeField] GameObject openCoinEffect;

    public string Name
    {
        get
        {
            return "Chest";
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
            ItemCollector itemCollector = collision.gameObject.GetComponent<ItemCollector>();

            var rnd = new System.Random(DateTime.Now.Millisecond);
            int chance = rnd.Next(0, 100);

            if (chance > 60)
            {
                itemCollector.increaseHPsBy(2);
                Instantiate(openHpEffect, transform.position, Quaternion.identity);
            }
            else
            {
                itemCollector.increaseCoinsBy(5);
                Instantiate(openCoinEffect, transform.position, Quaternion.identity);
            }

            Animator anim = gameObject.GetComponent<Animator>();
            anim.SetBool("isOpen", true);

            // prevent chest from being picked again
            BoxCollider2D boxCollider2D = gameObject.GetComponent<BoxCollider2D>();
            boxCollider2D.enabled = false;
        }
    }
}
