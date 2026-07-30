using NUnit.Framework;
using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class GameData
{
    public int gold;
    public SerializableDictionary<string, int> inventory;
    public SerializableDictionary<string, int> storageItems;
    public SerializableDictionary<string, int> storageMaterials;
    public List<Inventory_Item> itemsList;


    public SerializableDictionary<string, ItemType> equipedItems; // slotsType -> ItemSaveid;

    public int skillsPoints;
    public SerializableDictionary<string, bool> SkillsTreeUI;
    public SerializableDictionary<SkillType, SkillUpgradeType> skillUpgrades;

    public GameData()
    {
        inventory =  new SerializableDictionary<string, int>();
        storageItems = new SerializableDictionary<string, int>();
        storageMaterials = new SerializableDictionary<string, int>();

        equipedItems = new SerializableDictionary<string,ItemType>();

        SkillsTreeUI = new SerializableDictionary<string, bool>();
        skillUpgrades = new SerializableDictionary<SkillType, SkillUpgradeType>();
        
    }


}
