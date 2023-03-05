using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

namespace Daydream
{
    public class CancelContext
    {
        public CancelContext(Selectable sender, MenuPanel panel)
        {
            Sender = sender;
            Panel = panel;
        }

        public Selectable Sender;
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
        
        // sort of like a graph between panels and selectable (but they're grouped into pairs)
        // whenever a button (sender) links to another panel, we add the pair to the cancel stack
        // this makes it so when we press cancel, we pop the panel and selectable, hide the panel, select the selectable, and show whatever panel is on top of the stack
        // (if no panels are left, that means we pressed cancel on the entry menu, so we leave the menu)
        // but this also works when we go to a different region within a panel. we just only push the selectable
        // it also works if there is no selectable
        public Stack<CancelContext> CancelStack = new Stack<CancelContext>();

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
            if (CancelStack.TryPeek(out var cancelContext) && cancelContext.Panel != null)
            {
                cancelContext.Panel.Hide();
            }

            CancelStack.Push(new CancelContext(sender, panel));
            panel.Show();
            panel.Select();
        }
        
        public void PushSelectable(Selectable sender)
        {
            CancelStack.Push(new CancelContext(sender, null));
        }

        void OnMenuButtonPress()
        {
            EnableMenu();
        }


        void OnMenuCancelButtonPress()
        {
            var cancelContext = CancelStack.Pop();
            if (cancelContext.Panel != null)
            {
                cancelContext.Panel.Hide();
            }

            if(CancelStack.TryPeek(out var newCancelContext))
            {
                newCancelContext.Panel.Show();
                if (cancelContext.Sender != null)
                {
                    cancelContext.Sender.Select();
                }
                else
                {
                    newCancelContext.Panel.Select();
                }
            }
            // if no more cancel contexts, disable menu
            else
            {
                DisableMenu();
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
