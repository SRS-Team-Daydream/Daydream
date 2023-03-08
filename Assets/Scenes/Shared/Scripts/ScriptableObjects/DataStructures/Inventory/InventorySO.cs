using Kulip;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Daydream
{
    [CreateAssetMenu(fileName = "Inventory", menuName = "Data/Inventory")]
    public class InventorySO : StaticListSO<InventoryItemSO>
    {}
}