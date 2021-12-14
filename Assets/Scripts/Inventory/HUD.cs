using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{

    public Inventory Inventory;

    void Start()
    {
        Inventory.ItemAdded += InventoryScript_ItemAdded;
        Inventory.ItemRemoved += Inventory_ItemRemoved;
    }

    private void InventoryScript_ItemAdded(object sender, InventoryEventArgs e)
    {
        Transform inventoryPanel = transform.Find("Inventory");
        int slotIndex = -1;

        Debug.Log("Item added listner");

        foreach (Transform slot in inventoryPanel)
        {
            slotIndex++;
            Image image = slot.GetChild(0).GetComponent<Image>();
            ItemClickHandler itemClickHandler = slot.GetChild(0).GetComponent<ItemClickHandler>();
            Text stackCountText = slot.GetChild(1).GetComponent<Text>();

            if (slotIndex == e.Item.Slot.Id)
            {
                image.enabled = true;
                image.sprite = e.Item.Image;

                int itemCount = e.Item.Slot.Count;

                if (itemCount > 1)
                {
                    stackCountText.text = itemCount.ToString();
                }
                else
                {
                    stackCountText.text = "";
                }

                // store a reference to the item
                itemClickHandler.Item = e.Item.Slot.FirstItem;
                break;
            }
        }
    }

    private void Inventory_ItemRemoved(object sender, InventoryEventArgs e)
    {
        Transform inventoryPanel = transform.Find("Inventory");
        int slotIndex = -1;

        foreach (Transform slot in inventoryPanel)
        {
            slotIndex++;
            Image image = slot.GetChild(0).GetComponent<Image>();
            ItemClickHandler itemClickHandler = slot.GetChild(0).GetComponent<ItemClickHandler>();
            Text stackCountText = slot.GetChild(1).GetComponent<Text>();

            // we found the item in slot
            if (e.Item.Slot.Id == slotIndex)
            {
                int itemCount = e.Item.Slot.Count;

                // assign first item from slot to be used (null if slot is empty)
                itemClickHandler.Item = e.Item.Slot.FirstItem;

                if (itemCount < 2)
                {
                    stackCountText.text = "";
                } else
                {
                    stackCountText.text = itemCount.ToString();
                }

                if (itemCount == 0)
                {
                    image.enabled = false;
                    image.sprite = null;
                }
                break;
            }
        }
    }
}
