using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Daydream
{
    [System.Serializable]
    public enum EquipSlot { 
        Weapon,
        Accessory
    }

    [CreateAssetMenu(fileName = "Equippable", menuName = "Inventory/Equippable")]
    public class EquippableSO : InventoryItemSO
    {
        [SerializeField]
        public StatMods StatMods;

        [SerializeField]
        public float HealthMod;

        [SerializeField]
        public float DefenseMod;


        [SerializeField]
        public List<AbilitySO> AbilityList;

        [SerializeField]
        public EquipSlot EquipSlot;
    }
}
