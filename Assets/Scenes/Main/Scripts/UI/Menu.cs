using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Daydream
{
    public class Menu : MonoBehaviour
    {
        [SerializeField]
        InputReaderSO input;

        [SerializeField]
        CanvasGroup canvasGroup;

        void Reset()
        {
            canvasGroup = GetComponent<CanvasGroup>();
            input = InputReaderSO.FindInputReaderSO();
        }

        void Awake()
        {
            input.Gameplay.MenuEvent += OnMenuButtonPress;
        }

        void OnDestroy()
        {
            input.Gameplay.MenuEvent -= OnMenuButtonPress;
        }

        void OnMenuButtonPress()
        {

        }



        void HideMenu()
        {
            canvasGroup.blocksRaycasts = false;
            canvasGroup.interactable = false;
            canvasGroup.alpha = 0;
        }

        void ShowMenu()
        {
            canvasGroup.blocksRaycasts = true;
            canvasGroup.interactable = true;
            canvasGroup.alpha = 1;
        }
    }
}
