using UnityEngine;
[CreateAssetMenu]
public class Item : ScriptableObject
{
    public string itemName;
    public Sprite icon;
    public ItemType type;
    public int value;
}
public enum ItemType { HealthPotion, Weapon, Gold }
