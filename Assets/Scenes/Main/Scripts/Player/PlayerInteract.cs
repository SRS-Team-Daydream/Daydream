using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Windows;

namespace Daydream
{
    [RequireComponent(typeof(PlayerMovement))]
    [RequireComponent(typeof(GridMovement))]
    public class PlayerInteract : MonoBehaviour
    {
        [SerializeField] InputReaderSO inputSO;
        GridMovement gridMovement;

        [SerializeField]
        LayerMask mask;

        void Reset()
        {
            inputSO = SOUtil.Find<InputReaderSO>();
        }

        void Awake()
        {
            gridMovement = GetComponent<GridMovement>();
            inputSO.Gameplay.ActionEvent += Interact;
        }

        ///TODO: Public interact variant that allows the inventory to make the player interact using an item <summary>
        ///EG: public void ItemInteract(InventoryItemSO)
        ///or probably even better, make Interact into InteractInternal with an overload for 
        ///no inventory item and inventory item, and make the public function Interact

        void Interact()
        {
            Collider2D collider = Physics2D.OverlapPoint(
                transform.position + (Vector3)(Vector2)gridMovement.FacingDirection,
                mask.value
            );
            if (collider != null)
            {
                Interactable interactable = collider.gameObject.GetComponent<Interactable>();
                if(interactable != null)
                {
                    interactable.OnInteract();
                }
            }
        }
    }
}
