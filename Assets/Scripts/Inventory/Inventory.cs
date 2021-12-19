using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    private const int SLOTS = 5;

    public IList<InventorySlot> mSlots = new List<InventorySlot>();

    public bool itemUseHalted = false;

    public event EventHandler<InventoryEventArgs> ItemAdded;
    public event EventHandler<int> HpsAdded;
    public event EventHandler<int> CoinsAdded;
    public event EventHandler<InventoryEventArgs> ItemRemoved;
    public event EventHandler<InventoryEventArgs> ItemUsed;
    public event EventHandler InvCleared;

    public Inventory()
    {
        for (int i = 0; i < SLOTS; i++)
        {
            mSlots.Add(new InventorySlot(i));
        }
    }

    public void ClearInventory()
    {
        mSlots = new List<InventorySlot>();

        for (int i = 0; i < SLOTS; i++)
        {
            mSlots.Add(new InventorySlot(i));
        }

        InvCleared?.Invoke(this, null);
    }

    private InventorySlot FindStackableSlot(IInventoryItem item)
    {
        foreach (InventorySlot slot in mSlots)
        {
            if (slot.IsStackable(item))
            {
                return slot;
            }
        }
        return null;
    }

    private InventorySlot FindNextEmptySlot()
    {
        foreach (InventorySlot slot in mSlots)
        {
            if (slot.IsEmpty)
            {
                return slot;
            }
        }
        return null;
    }

    internal void UseItem(IInventoryItem item)
    {
        if (!this.itemUseHalted) 
        {
            ItemUsed?.Invoke(this, new InventoryEventArgs(item));

            if (item.hasOnUse)
            {
                item.OnUse();
            }

            RemoveItem(item);
        }
    }

    public void AddCoins(int amount)
    {
        CoinsAdded?.Invoke(this, amount);
    }

    public void AddHps(int amount)
    {
        HpsAdded?.Invoke(this, amount);
    }

    public void AddItem(IInventoryItem item)
    {
        InventorySlot freeSlot = FindStackableSlot(item);

        if (freeSlot == null)
        {
            freeSlot = FindNextEmptySlot();
        }

        if (freeSlot != null)
        {
            freeSlot.AddItem(item);
            ItemAdded?.Invoke(this, new InventoryEventArgs(item));
        }
    }

    public void RemoveItem(IInventoryItem item)
    {
        foreach (InventorySlot slot in mSlots)
        {
            bool isRemoved = slot.Remove(item);

            if (isRemoved)
            {
                ItemRemoved?.Invoke(this, new InventoryEventArgs(item));
                break;
            }
        }
    }
}
