using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Daydream
{
    [RequireComponent(typeof(Button))]
    public class MenuButton : MonoBehaviour
    {
        [SerializeField]
        Menu menu;

        [SerializeField]
        MenuPanel panel;

        Button button;
        public Button Button => button;

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
            if(panel != null) panel.Hide();
        }

        public void OnPress()
        {
            if (panel != null && panel.CanSelect)
            {
                menu.PushPanel(button, panel);
            }
        }
    }
}
