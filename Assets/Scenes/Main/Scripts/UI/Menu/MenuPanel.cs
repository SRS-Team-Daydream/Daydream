using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.Windows;

namespace Daydream
{
    [RequireComponent(typeof(CanvasGroup))]
    public class MenuPanel : MonoBehaviour
    {
        [SerializeField]
        bool canSelect = true;
        public bool CanSelect => canSelect && FirstSelected != null;

        [SerializeField]
        Selectable defaultFirstSelected;

        [SerializeField]
        Menu menu;

        [SerializeField]
        InputReaderSO input;

        [System.NonSerialized]
        public Selectable FirstSelected;

        CanvasGroup canvasGroup;
        public CanvasGroup CanvasGroup => canvasGroup;

        void Reset()
        {
            input = InputReaderSO.FindInputReaderSO();
            menu = GetComponentInParent<Menu>();
        }

        void Awake()
        {
            canvasGroup = GetComponent<CanvasGroup>();
            FirstSelected = defaultFirstSelected;

            Hide();
        }

        public void Show()
        {
            canvasGroup.alpha = 1;
            canvasGroup.interactable = true;
            canvasGroup.blocksRaycasts = true;
        }

        public void Hide()
        {
            canvasGroup.alpha = 0;
            canvasGroup.interactable = false;
            canvasGroup.blocksRaycasts = false;
        }


        public void Select()
        {
            FirstSelected.Select();
        }
    }
}
