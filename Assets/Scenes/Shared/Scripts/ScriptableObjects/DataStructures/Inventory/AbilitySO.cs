using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Daydream
{
    [System.Serializable]
    public enum Target { 
        Self,
        Friend,
        Foe,
        Everybody
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
        public int ManaCost;

        [SerializeField]
        public Target AbilityTarget;

        [SerializeField]
        public float Attack;

        [SerializeField]
        public float Pierce;

        [SerializeField]
        public float HealAmount;

        // TODO:
        //[SerializeField]
        //public List<string> EffectList;
    }
}
