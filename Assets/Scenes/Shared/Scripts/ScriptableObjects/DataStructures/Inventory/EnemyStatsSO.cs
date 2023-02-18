using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Daydream
{
    [CreateAssetMenu(fileName = "EnemyStats", menuName = "Data/EnemyStats")]
    public class EnemyStatsSO : NPCStatsSO
    {
        [SerializeField]
        public float XPDrop;
        
        [SerializeField]
        public string LightDrop;

        [SerializeField]
        public string InventoryItemDrop;

        [SerializeField]
        public string WeaponEquipped;

        [SerializeField]
        public string AccessoryEquipped;
    }
}