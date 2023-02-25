using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Daydream
{
    public class InventoryItemUI : MonoBehaviour
    {
        [SerializeField]
        Image _image;

        [System.NonSerialized]
        public InventoryItemSO InventoryItem;

        void Start()
        {
            _image.sprite = InventoryItem.Sprite;
        }
    }
}
