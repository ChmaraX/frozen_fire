using System;
using UnityEngine;

public interface IInventoryItem
{
    string Name { get; }

    bool IsStorable { get; }

    bool hasOnUse { get; }

    void OnUse();

    Sprite Image { get; }

    InventorySlot Slot { get; set; }
}

public class InventoryEventArgs : EventArgs
{
    public InventoryEventArgs(IInventoryItem item)
    {
        Item = item;
    }

    public IInventoryItem Item;
}
