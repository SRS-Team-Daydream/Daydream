using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

namespace Daydream
{
    [System.Serializable]
    class MenuTabPanelPair {
        public MenuTabButton Button;
        public CanvasGroup Panel;
    }

    public class Menu : MonoBehaviour
    {
        [SerializeField]
        InputReaderSO input;

        [SerializeField]
        CanvasGroup canvasGroup;

        [SerializeField]
        Selectable firstSelected;

        [SerializeField]
        List<MenuTabButton> tabButtons;

        MenuTabButton lastSelectedTab = null;
        
        public Stack<Selectable> CancelStack = new Stack<Selectable>();


        void Reset()
        {
            canvasGroup = GetComponent<CanvasGroup>();
            input = InputReaderSO.FindInputReaderSO();
        }

        void Awake()
        {
            input.Gameplay.MenuEvent += OnMenuButtonPress;
            input.Menu.CancelEvent += OnMenuCancelButtonPress;
            DisableMenu();

            foreach(var tabButton in tabButtons)
            {
                tabButton.SelectEvent += OnTabButtonSelect;
            }
        }
        void OnDestroy()
        {
            input.Gameplay.MenuEvent -= OnMenuButtonPress;
        }


        public void SelectCurrentTabButton()
        {
            if(lastSelectedTab != null)
            {
                lastSelectedTab.Button.Select();
            }
        }


        void OnMenuButtonPress()
        {
            EnableMenu();
        }


        void OnMenuCancelButtonPress()
        {
            if(CancelStack.Count == 0)
            {
                DisableMenu();
            }
            else
            {
                var top = CancelStack.Pop();
                top.Select();
            }
        }

        void OnTabButtonSelect(MenuTabButton button)
        {
            lastSelectedTab = button;
        }


        void DisableMenu()
        {
            canvasGroup.blocksRaycasts = false;
            canvasGroup.interactable = false;
            canvasGroup.alpha = 0;

            input.EnableGameplay();
        }

        void EnableMenu()
        {
            canvasGroup.blocksRaycasts = true;
            canvasGroup.interactable = true;
            canvasGroup.alpha = 1;

            input.EnableMenu();
            firstSelected.Select();
        }
    }
}
