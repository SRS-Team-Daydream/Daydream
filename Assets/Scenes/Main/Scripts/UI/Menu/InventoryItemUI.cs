using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Daydream
{
    [RequireComponent(typeof(Selectable))]
    public class InventoryItemUI : MonoBehaviour, ISelectHandler, ISubmitHandler
    {
        [SerializeField]
        Image _image;

        [System.NonSerialized]
        public InventoryItemSO InventoryItem;

        [System.NonSerialized]
        public InventoryMenu InventoryMenu;

        Selectable selectable;

        void Start()
        {
            selectable = GetComponent<Selectable>();
            _image.sprite = InventoryItem.Sprite;
        }

        public void OnSelect(BaseEventData eventData)
        {
            InventoryMenu.SelectItem(InventoryItem);
        }

        public void OnSubmit(BaseEventData eventData)
        {
            InventoryMenu.SubmitItem(selectable);
        }
    }
}
