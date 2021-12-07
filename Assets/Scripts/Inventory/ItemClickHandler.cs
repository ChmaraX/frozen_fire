using UnityEngine;

public class ItemClickHandler : MonoBehaviour
{
    public Inventory _Inventory;
    public IInventoryItem Item { get; set; }

    [SerializeField] public KeyCode keyCode;

    public void OnItemClicked()
    {
        _Inventory.UseItem(Item);
    }

    public void Update()
    {
        if (Input.GetKeyDown(keyCode))
        {
            if (Item != null)
            {
                _Inventory.UseItem(Item);
            }
        }
    }

}
