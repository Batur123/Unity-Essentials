using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace UnitySamples.Items
{
    public enum itemType { WEAPON, ARMOR, POTION, CONSUMABLE, HEALTH }
    public enum armorType { HELMET, CHESTPLATE, LEGGINGS}

    public class ItemBase : ScriptableObject
    {
        public int itemID;
        public int itemAmount;

        public string itemName;
        public string itemDesc;
        public string itemSprite;

        public string GameObjectName;

        public bool isStackable;
        public bool isUsable;

        public itemType IType;
        


        public ItemBase(int ItemID, int ItemAmount, string ItemName, string ItemDesc, string ItemSprite, itemType ItemType, bool IsStackable, bool IsUsable)
        {
            itemID = ItemID;
            itemAmount = ItemAmount;
            itemName = ItemName;
            itemDesc = ItemDesc;
            itemSprite = ItemSprite;
            IType = ItemType;
            isStackable = IsStackable;
            isUsable = IsUsable;
        }

        public itemType CurrentItemType
        {
            get { return IType; }
            set { IType = value; }
        }

        public virtual void Use()
        {
            
        }

        public virtual void GetGameObjectName(string ObjectName)
        {
            GameObjectName = ObjectName;
        }
    }

    [CreateAssetMenu(fileName = "New Item", menuName = "Items/Weapon")]
    public class Weapon : ItemBase
    {
        public Weapon(int ItemID, int ItemAmount, string ItemName, string ItemDesc, string ItemSprite, itemType ItemType, bool IsStackable, bool IsUsable) : base(ItemID, ItemAmount, ItemName, ItemDesc, ItemSprite, ItemType, IsStackable,IsUsable)
        {
            itemID = ItemID;
            itemAmount = ItemAmount;
            itemName = ItemName;
            itemDesc = ItemDesc;
            itemSprite = ItemSprite;
            IType = ItemType;
            isStackable = IsStackable;
            isUsable = IsUsable;
        }

        public override void Use()
        {
            Debug.Log("Silah kullandın.");
            Destroy(GameObject.Find(GameObjectName));
        }
    }

    [CreateAssetMenu(fileName = "New Item", menuName = "Items/Armor/Helmet")]
    public class Armor : ItemBase
    {
        public armorType ArmorType;
        public int ArmorAmount;

        public Armor(int ItemID, int ItemAmount, string ItemName, string ItemDesc, string ItemSprite, itemType ItemType, bool IsStackable, bool IsUsable, armorType Armortype, int ArmorAMOUNT) : base(ItemID, ItemAmount, ItemName, ItemDesc, ItemSprite, ItemType, IsStackable, IsUsable)
        {
            itemID = ItemID;
            itemAmount = ItemAmount;
            itemName = ItemName;
            itemDesc = ItemDesc;
            itemSprite = ItemSprite;
            IType = ItemType;
            isStackable = IsStackable;
            isUsable = IsUsable;
            ArmorType = Armortype;
            ArmorAmount = ArmorAMOUNT;
        }

        public override void Use()
        {

        }
    }



    [CreateAssetMenu(fileName = "New Item", menuName = "Items/HealthItem")]
    public class Health : ItemBase
    {
        public float HealthAmount;

        public Health(int ItemID, int ItemAmount, string ItemName, string ItemDesc, string ItemSprite, itemType ItemType, bool IsStackable, bool IsUsable, float HealAmount) : base(ItemID, ItemAmount, ItemName, ItemDesc, ItemSprite, ItemType, IsStackable, IsUsable)
        {
            itemID = ItemID;
            itemAmount = ItemAmount;
            itemName = ItemName;
            itemDesc = ItemDesc;
            itemSprite = ItemSprite;
            IType = ItemType;
            isStackable = IsStackable;
            isUsable = IsUsable;
            HealthAmount = HealAmount;
        }

        public override void Use()
        {
            //Eğer ilk kullanımda eşya buga girmiş ve miktarı 0 ise kullanmaya izin vermeden eşyayı yok eder.
            if (itemAmount <= 0)
            {
                Debug.Log("Item miktarı 0 dı. Nesne can doldurmadan yok edildi");
                Destroy(GameObject.Find(GameObjectName));
            }
            else 
            {

                itemAmount -= 1;
                HealthBar playerHealth = GameObject.Find("HealthBar").GetComponent<HealthBar>();
                playerHealth.Heal(HealthAmount);

                //Eşya kullanımından sonra eşya miktarı 0'ın altına düşerse eşya yok edilir. Düşmezse olduğu gibi kalır.
                if (itemAmount <= 0)
                {
                    Debug.Log(HealthAmount + " kadar can dolduruldu. Eşya bitti.");
                    Destroy(GameObject.Find(GameObjectName));
                }
                else
                {
                    Debug.Log(HealthAmount + " kadar can dolduruldu. Eşya miktarı 1 azaldı. Şuan ki eşya miktarı: "+itemAmount);
                }
               
            }
           

            

            
        }
    }
}


