using UnityEngine;

[System.Serializable]
public class Items
{
    public string itemName;
    public Sprite itemIcon;
    public int itemID;
    public string itemDescription;

    public Items(string name, Sprite icon, int id, string description)
    {
        itemName = name;
        itemIcon = icon;
        itemID = id;
        itemDescription = description;
    }
}
