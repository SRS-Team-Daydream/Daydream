using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Daydream
{
    public class InventoryItemUI : MonoBehaviour, ISelectHandler
    {
        [SerializeField]
        Image _image;

        [System.NonSerialized]
        public InventoryItemSO InventoryItem;

        [System.NonSerialized]
        public InventoryMenu InventoryMenu;

        void Start()
        {
            _image.sprite = InventoryItem.Sprite;
        }

        public void OnSelect(BaseEventData eventData)
        {
            InventoryMenu.SelectItem(InventoryItem);
        }
    }
}
