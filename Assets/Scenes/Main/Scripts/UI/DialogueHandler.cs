using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Yarn.Unity;

namespace Daydream
{
    [RequireComponent(typeof(DialogueRunner))]
    public class DialogueHandler : MonoBehaviour
    {
        DialogueRunner dialogueRunner;

        [SerializeField] InputReaderSO inputReader;
        [SerializeField] EventSO<string> startDialogueEvent;

        void Reset()
        {
            inputReader = SOUtil.Find<InputReaderSO>();
        }

        void Awake()
        {
            dialogueRunner = GetComponent<DialogueRunner>();
            startDialogueEvent += OnStartDialogue;
            dialogueRunner.onDialogueComplete.AddListener(OnDialogueComplete);
        }

        void OnDestroy()
        {
            startDialogueEvent -= OnStartDialogue;
            dialogueRunner.onDialogueComplete.RemoveListener(OnDialogueComplete);
        }

        void OnStartDialogue(string node)
        {
            inputReader.DisableAll();
            inputReader.EnableMenu();
            IEnumerator StartDialogueCoroutine()
            {
                yield return null;
                dialogueRunner.StartDialogue(node);
            }
            StartCoroutine(StartDialogueCoroutine());
        }

        void OnDialogueComplete()
        {
            inputReader.DisableAll();
            IEnumerator ResumeGampeplayCoroutine()
            {
                yield return null;
                yield return null;
                inputReader.EnableGameplay();
            }
            StartCoroutine(ResumeGampeplayCoroutine());
        }
    }
}
