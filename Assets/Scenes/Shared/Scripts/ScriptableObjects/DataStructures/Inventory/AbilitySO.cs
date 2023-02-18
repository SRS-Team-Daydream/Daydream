using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Daydream
{
    [System.Serializable]
    public enum Target { 
        self,
        friend,
        foe,
        everybody
    }


    [CreateAssetMenu(fileName = "Ability", menuName = "Combat/Ability")]
    public class AbilitySO : ScriptableObject
    {
        [SerializeField]
        public string Name;

        //image

        [SerializeField]
        public string Description;

        [SerializeField]
        public float ManaCost;

        [SerializeField]
        public Target AbilityTarget;

        [SerializeField]
        public float Attack;

        [SerializeField]
        public float Pierce;

        //effect swap out string for a class for effects
        [SerializeField]
        public List<string> EffectList;

        [SerializeField]
        public float HealAmount;
    }
}
