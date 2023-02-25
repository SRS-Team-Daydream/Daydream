using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Daydream
{
    [CreateAssetMenu(fileName = "EnemyStats", menuName = "Data/EnemyStats")]
    public class EnemyStatsSO : NPCStatsSO
    {
        [SerializeField]
        public int XPDrop;
        
        [SerializeField]
        public int LightDrop;

        [SerializeField]
        public InventoryItemSO InventoryItemDrop;

        [SerializeField]
        public EquippableSO WeaponEquipped;

        [SerializeField]
        public EquippableSO AccessoryEquipped;
    }
}