using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

namespace Daydream
{
    public class InventoryItemInfoPanel : MonoBehaviour
    {
        [SerializeField]
        new TMP_Text name;

        [SerializeField]
        Image image;

        [SerializeField]
        TMP_Text description;

        [SerializeField]
        public Selectable FirstSelected;

        void Reset()
        {
            TMP_Text[] tmps = GetComponentsInChildren<TMP_Text>();
            foreach(var tmp in tmps)
            {
                string nameLower = tmp.gameObject.name.ToLower();
                if (nameLower.EndsWith("name"))
                {
                    name = tmp;
                }
                else if (nameLower.EndsWith("description"))
                {
                    description = tmp;
                }
            }
            image = GetComponentInChildren<Image>();
        }

        public void SetInventoryItem(InventoryItemSO inventoryItem)
        {
            name.text = inventoryItem.Name;
            image.sprite = inventoryItem.Sprite;
            description.text = inventoryItem.Description;
        }
    }
}
