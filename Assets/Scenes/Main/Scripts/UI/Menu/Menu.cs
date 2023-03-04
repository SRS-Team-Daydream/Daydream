using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

namespace Daydream
{
    [System.Serializable]
    class MenuTabPanelPair {
        public MenuButton Button;
        public MenuPanel Panel;
    }

    public class Menu : MonoBehaviour
    {
        [SerializeField]
        InputReaderSO input;

        [SerializeField]
        CanvasGroup canvasGroup;

        [SerializeField]
        MenuPanel entryPanel;
        
        public Stack<(Selectable, MenuPanel)> PanelStack = new Stack<(Selectable, MenuPanel)>();


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
        }
        void OnDestroy()
        {
            input.Gameplay.MenuEvent -= OnMenuButtonPress;
        }

        public void PushPanel(MenuPanel panel)
            => PushPanel(null, panel);

        public void PushPanel(Selectable sender, MenuPanel panel)
        {
            if(PanelStack.Count > 0)
            {
                PanelStack.Peek().Item2.Hide();
            }

            PanelStack.Push((sender, panel));
            panel.Show();
            panel.Select();
        }

        void OnMenuButtonPress()
        {
            EnableMenu();
        }


        void OnMenuCancelButtonPress()
        {
            var top = PanelStack.Pop();
            top.Item2.Hide();
            if(PanelStack.Count == 0)
            {
                DisableMenu();
            }
            else
            {
                PanelStack.Peek().Item2.Show();
                if (top.Item1 != null)
                {
                    top.Item1.Select();
                }
                else
                {
                    PanelStack.Peek().Item2.Select();
                }
            }
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
            PushPanel(entryPanel);
        }
    }
}
