using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public List<Items> items = new List<Items>();

    public void AddItem(Items item)
    {
        items.Add(item);
        Debug.Log(item.itemName + " added to inventory.");
    }

    public void RemoveItem(Items item)
    {
        if (items.Contains(item))
        {
            items.Remove(item);
            Debug.Log(item.itemName + " removed from inventory.");
        }
        else
        {
            Debug.Log("Item not found in inventory.");
        }
    }

    public void ListItems()
    {
        foreach (Items item in items)
        {
            Debug.Log("Item: " + item.itemName);
        }
    }
}
