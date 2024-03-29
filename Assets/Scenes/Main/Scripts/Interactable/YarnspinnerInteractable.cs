using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Yarn.Unity;

namespace Daydream
{
    public class YarnspinnerInteractable : Interactable
    {
        [SerializeField] EventSO<string> dialogueStartEvent;
        [SerializeField] string node;

        public override void OnInteract()
        {
            base.OnInteract();
            dialogueStartEvent.Invoke(node);
        }
    }
}
