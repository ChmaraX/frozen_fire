using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    private const int SLOTS = 5;

    public List<IInventoryItem> mItems = new List<IInventoryItem>();

    public event EventHandler<InventoryEventArgs> ItemAdded;
    public event EventHandler<InventoryEventArgs> ItemRemoved;
    public event EventHandler<InventoryEventArgs> ItemUsed;

    internal void UseItem(IInventoryItem item)
    {
        ItemUsed?.Invoke(this, new InventoryEventArgs(item));
        item.OnUse();
        RemoveItem(item);
    }

    public void AddItem(IInventoryItem item)
    {
        if (mItems.Count < SLOTS)
        {
            Collider2D collider = (item as MonoBehaviour).GetComponent<Collider2D>();

            Destroy(collider.gameObject);
            mItems.Add(item);
            item.OnPickUp();

            ItemAdded?.Invoke(this, new InventoryEventArgs(item));
        }
    }

    public void RemoveItem(IInventoryItem item)
    {
        if (mItems.Contains(item))
        {
            mItems.Remove(item);
            ItemRemoved?.Invoke(this, new InventoryEventArgs(item));
        }
    }
}
