using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Item
{
    public int ID;
    public string name;
    public Sprite icon;
    public GameObject _3DModel;
    
    public enum ItemType
    {
        Weapon,
        Consumable,
        Armor
    }

    public ItemType itemType;

    public void Action()
    {
        switch (itemType)
        {
            case ItemType.Weapon:
                {
                    Debug.Log("You have "+name);
                    break;
                }
            case ItemType.Armor:
                {
                    Debug.Log("You have " + name);
                    break;
                }
            case ItemType.Consumable:
                {
                    Debug.Log("You have " + name);
                    break;
                }

        }
    }
}
