using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Daydream
{
    public class Interactable : MonoBehaviour
    {
        public virtual void OnInteract() { }

        ///TODO: Another function here (perhaps an overload of OnInteract) that takes in an InventoryItemSO
        ///signature example: public virtual void OnInteract(InventoryItemSO item) { }
    }
}
