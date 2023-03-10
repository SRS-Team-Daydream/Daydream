using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Yarn.Unity;

namespace Daydream
{
    public class YarnspinnerInteractable : Interactable
    {
        [SerializeField] DialogueRunner dialogueRunner;
        [SerializeField] string node;

        void Reset()
        {
            dialogueRunner = FindObjectOfType<DialogueRunner>();
        }

        public override void Interact()
        {
            base.Interact();
            dialogueRunner.StartDialogue(node);
        }
    }
}
