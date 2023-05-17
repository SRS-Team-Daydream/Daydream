using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Daydream
{
    [RequireComponent(typeof(DynamicGridLayout))]
    public class InventoryMenu : MonoBehaviour
    {
        [SerializeField] MenuPanel panel;
        [SerializeField] InventorySO inventory;
        [SerializeField] GameObject itemPrefab;
        [SerializeField] InventoryItemInfoPanel infoPanel;

        DynamicGridLayout grid;

        void Reset()
        {
            panel = GetComponentInParent<MenuPanel>();
            inventory = SOUtil.Find<InventorySO>();
            infoPanel = transform.parent.GetComponentInChildren<InventoryItemInfoPanel>();
        }

        void Awake()
        {
            grid = GetComponentInParent<DynamicGridLayout>();

            inventory.ListChangedEvent += DrawInventory;
        }

        void Start()
        {
            DrawInventory(inventory.Value);
        }

        void OnDestroy()
        {
            inventory.ListChangedEvent -= DrawInventory;

        }


        public void SelectItem(InventoryItemSO item)
        {
            infoPanel.SetInventoryItem(item);
        }

        public void SubmitItem(Selectable sender)
        {
            panel.Menu.PushSelectable(sender);
            if(infoPanel.FirstSelected != null)
            {
                infoPanel.FirstSelected.Select();
            }
        }


        void DrawInventory(List<InventoryItemSO> items)
        {
            StartCoroutine(DrawInventoryCoroutine(items));
        }

        IEnumerator DrawInventoryCoroutine(List<InventoryItemSO> items)
        {
            foreach(Transform child in transform)
            {
                Destroy(child.gameObject);
            }

            int i = 0;
            foreach(InventoryItemSO itemSO in items)
            {
                GameObject item = Instantiate(itemPrefab);
                item.transform.SetParent(transform);
                item.name = string.Format("Item {0}: {1}", i++, itemSO.name);

                var itemUI = item.GetComponent<InventoryItemUI>();
                itemUI.InventoryItem = itemSO;
                itemUI.InventoryMenu = this;
            }

            // wait for end of frame for transform to update
            yield return null;

            panel.FirstSelected = null;
            if (transform.childCount > 0)
            {
                panel.FirstSelected = transform.GetChild(0).gameObject.GetComponent<Button>();
            }

            // set navigation for all buttons (needs to be manual)
            foreach (Transform child in transform)
            {
                Button button = child.gameObject.GetComponent<Button>();
                Vector2Int coord = grid.GetChildGridCoordinate(child);
                GridSiblings gridSiblings = grid.GetChildSiblings(child);
                button.navigation = new Navigation
                {
                    mode = Navigation.Mode.Explicit,
                    selectOnRight = gridSiblings.Right == null ? null : gridSiblings.Right.gameObject.GetComponent<Button>(),
                    selectOnLeft = gridSiblings.Left == null ? null : gridSiblings.Left.gameObject.GetComponent<Button>(),
                    selectOnUp = gridSiblings.Up == null ? null : gridSiblings.Up.gameObject.GetComponent<Button>(),
                    selectOnDown = gridSiblings.Down == null ? null : gridSiblings.Down.gameObject.GetComponent<Button>(),
                };
            }
        }
    }
}
