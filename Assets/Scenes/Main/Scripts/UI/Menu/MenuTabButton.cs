using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Daydream
{
    [RequireComponent(typeof(Button))]
    public class MenuTabButton : MonoBehaviour, ISelectHandler, IDeselectHandler
    {
        [SerializeField]
        Menu menu;

        [SerializeField]
        MenuTabPanel panel;

        [System.NonSerialized]
        public System.Action<MenuTabButton> SelectEvent;

        Button button;
        public Button Button => button;

        bool panelSelected = false;

        void Reset()
        {
            menu = GetComponentInParent<Menu>();
        }

        void Awake()
        {
            button = GetComponent<Button>();
            button.onClick.AddListener(OnPress);
        }

        void OnDestroy()
        {
            button.onClick.RemoveListener(OnPress);
        }

        void Start()
        {
            panel.Hide();
        }

        public void OnSelect(BaseEventData eventData)
        {
            SelectEvent?.Invoke(this);
            panel.Show();
        }

        public void OnDeselect(BaseEventData eventData)
        {
            if (!panel.Selected)
            {
                panel.Hide();
            }
        }

        public void OnPress()
        {
            if (panel.CanSelect)
            {
                panel.Select();
                menu.CancelStack.Push(button);
            }
        }
    }
}
