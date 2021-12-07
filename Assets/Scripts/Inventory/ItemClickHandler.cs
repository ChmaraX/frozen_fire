using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemClickHandler : MonoBehaviour
{
    public Inventory _Inventory;
    public IInventoryItem Item { get; set; }

    public void OnItemClicked()
    {
        _Inventory.UseItem(Item);
    }

}
