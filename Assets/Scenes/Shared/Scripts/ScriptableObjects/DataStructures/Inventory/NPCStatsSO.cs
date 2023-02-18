using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Daydream
{
    public class NPCStatsSO : CharacterStatsSO
    {
        [SerializeField]
        public string NPCName;

        [SerializeField]
        public List<string> AbilityList;
    }
}