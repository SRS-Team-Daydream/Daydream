using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Daydream
{
    [CreateAssetMenu(fileName = "InventoryItem", menuName = "Inventory/Item")]
    public class InventoryItemSO : ScriptableObject
    {
        [SerializeField]
        public string Name;

        [SerializeField]
        public Sprite Sprite;

        [Multiline]
        [SerializeField]
        public string Description;
    }
}
