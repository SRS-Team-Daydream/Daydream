using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Daydream
{
    [System.Serializable]
    public class Player : Character
    {
        [SerializeField]
        public EquippableSO WeaponEquipped;

        [SerializeField]
        public EquippableSO AccessoryEquipped;
    }

}