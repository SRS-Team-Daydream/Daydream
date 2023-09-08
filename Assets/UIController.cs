using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

namespace Daydream
{
    public class UIController : MonoBehaviour
    {
        public UIDocument uiDoc;
        public VisualElement options;
        public Button fightButton;
        public Button itemButton;
        public Button runButton;

        public VisualElement fight;
        public Label actionsLabel;
        public Button actionsBackButton;

        public VisualElement items;
        public Label itemsLabel;
        public Button itemsBackButton;

        void Start()
        {
            uiDoc = GetComponent<UIDocument>();
            options = uiDoc.rootVisualElement.Q<VisualElement>("Options");
            fightButton = uiDoc.rootVisualElement.Q<Button>("fight-button");
            itemButton = uiDoc.rootVisualElement.Q<Button>("item-button");
            runButton = uiDoc.rootVisualElement.Q<Button>("run-button");


            fight = uiDoc.rootVisualElement.Q<VisualElement>("Fight");
            actionsLabel = uiDoc.rootVisualElement.Q<Label>("actions-label");
            actionsBackButton = uiDoc.rootVisualElement.Q<Button>("actions-back");

            items = uiDoc.rootVisualElement.Q<VisualElement>("Items");
            itemsLabel = uiDoc.rootVisualElement.Q<Label>("items-label");
            itemsBackButton = uiDoc.rootVisualElement.Q<Button>("items-back");

            fightButton.clicked += FightButtonPressed;
            itemButton.clicked += ItemButtonPressed;
            runButton.clicked += RunButtonPressed;

            actionsBackButton.clicked += ActionsBackPressed;
            itemsBackButton.clicked += ItemsBackPressed;
        }

        void FightButtonPressed(){
            options.style.display = DisplayStyle.None;
            fight.style.display = DisplayStyle.Flex;
        }
        void ItemButtonPressed(){
            options.style.display = DisplayStyle.None;
            items.style.display = DisplayStyle.Flex;
        }
        void RunButtonPressed(){
        }

        void ActionsBackPressed(){
            options.style.display = DisplayStyle.Flex;
            fight.style.display = DisplayStyle.None;
        }
        void ItemsBackPressed(){
            options.style.display = DisplayStyle.Flex;
            items.style.display = DisplayStyle.None;
        }
    }
}
