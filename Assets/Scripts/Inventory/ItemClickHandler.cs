using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemClickHandler : MonoBehaviour
{
    public IInventoryItem Item { get; set; }

    public void OnItemClicked()
    {
         Item.OnUse();
    }

}
