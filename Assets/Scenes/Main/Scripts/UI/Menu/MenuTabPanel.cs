using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.Windows;

namespace Daydream
{
    [RequireComponent(typeof(CanvasGroup))]
    public class MenuTabPanel : MonoBehaviour
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

        bool selected = false;
        public bool Selected => selected;

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
            selected = true;
            FirstSelected.Select();

            input.Menu.CancelEvent += OnMenuCancelButton;
        }

        void OnMenuCancelButton()
        {
            selected = false;

            input.Menu.CancelEvent -= OnMenuCancelButton;
        }
    }
}
