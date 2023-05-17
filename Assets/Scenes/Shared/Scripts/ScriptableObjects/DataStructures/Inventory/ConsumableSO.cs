using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Daydream
{
    [CreateAssetMenu(fileName = "Consumable", menuName = "Inventory/Consumable")]
    public class ConsumableSO : InventoryItemSO
    {
        [SerializeField]
        public float HealthRestore;
    }
}