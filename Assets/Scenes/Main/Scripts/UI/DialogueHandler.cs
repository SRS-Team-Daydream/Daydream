using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Yarn.Unity;

namespace Daydream
{
    [RequireComponent(typeof(DialogueRunner))]
    public class DialogueHandler : MonoBehaviour
    {
        static DialogueHandler instance;

        DialogueRunner dialogueRunner;

        [SerializeField] InputReaderSO inputReader;
        [SerializeField] EventSO<string> startDialogueEvent;

        string nextScene = null;

        void Reset()
        {
            inputReader = SOUtil.Find<InputReaderSO>();
        }

        void Awake()
        {
            if(instance != null) {
                Destroy(this);
                return;
            }
            instance = this;

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
                yield return new WaitForSeconds(0.5f);
                inputReader.EnableGameplay();
            }
            StartCoroutine(ResumeGampeplayCoroutine());

            if(nextScene != null)
            {
                IEnumerator SceneChangeCoroutine()
                {
                    yield return new WaitForSeconds(1);
                    SceneManager.LoadScene(nextScene);
                    nextScene = null;
                }
                StartCoroutine(SceneChangeCoroutine());
            }
        }

        [YarnCommand("change_scene")]
        static void ChangeSceneCommand(string scene)
        {
            instance.nextScene = scene;
        }
    }
}
