using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public List<Item> items = new();

    public void AddItem(Item item)
    {
        if (item == null) return;
        items.Add(item);
        Debug.Log($"Item ajouté : {item.itemName}");
    }

    public void RemoveItem(Item item)
    {
        if (item == null) return;
        items.Remove(item);
    }

    public bool HasItem(ItemType type)
    {
        return items.Exists(i => i.type == type);
    }

    public Item GetFirst(ItemType type)
    {
        return items.Find(i => i.type == type);
    }
}