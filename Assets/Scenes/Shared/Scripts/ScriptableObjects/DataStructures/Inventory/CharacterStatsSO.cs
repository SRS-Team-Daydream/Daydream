using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Daydream
{
    public class CharacterStatsSO : ScriptableObject
    {
        [SerializeField]
        public float DefaultHealth;

        [SerializeField]
        public float MaxHealth;

        [SerializeField]
        public float Defense;
    }
}
