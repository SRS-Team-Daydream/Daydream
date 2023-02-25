using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Daydream
{
    [CreateAssetMenu(fileName = "AllyStats", menuName = "Data/AllyStats")]
    public class AllyStatsSO : NPCStatsSO
    {
        [SerializeField]
        public EquippableSO WeaponEquipped;
    }
}