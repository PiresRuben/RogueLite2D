using UnityEngine;

[CreateAssetMenu(menuName = "RogueLite/Item")]
public class Item : ScriptableObject
{
    public string itemName;
    public Sprite icon;
    public ItemType type;
    public int value;   // ex : quantité de heal, prix, etc.
}

public enum ItemType
{
    HealthPotion,
    Weapon,
    Gold
}