using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

namespace Daydream
{
    public class BattleUIElements
    {
        public Button FightButton;
        public Button ItemButton;
        public Button RunButton;
    }

    [RequireComponent(typeof(UIDocument))]
    public class BattleUI : MonoBehaviour
    {
        UIDocument document;
        VisualElement root;

        BattleUIElements elements;

        void Awake()
        {
            document = GetComponent<UIDocument>();
            root = document.rootVisualElement;

            elements = new BattleUIElements
            {
                FightButton = root.Q<Button>("fight-button"),
                ItemButton = root.Q<Button>("item-button"),
                RunButton = root.Q<Button>("run-button"),
            };

            elements.FightButton.RegisterCallback<NavigationSubmitEvent>(FightButtonPressed);
            elements.ItemButton.RegisterCallback<NavigationSubmitEvent>(ItemButtonPressed);
            elements.RunButton.RegisterCallback<NavigationSubmitEvent>(RunButtonPressed);
        }

        void Start()
        {
            elements.FightButton.Focus();
        }

        void FightButtonPressed(NavigationSubmitEvent e)
        {
            
        }

        void ItemButtonPressed(NavigationSubmitEvent e)
        {

        }

        void RunButtonPressed(NavigationSubmitEvent e)
        {

        }
    }
}
