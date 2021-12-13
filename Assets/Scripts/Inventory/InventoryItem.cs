using System;
using UnityEngine;

public interface IInventoryItem
{
    string Name { get; }

    bool IsStorable { get; }

    Sprite Image { get; }

    void OnUse();

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
