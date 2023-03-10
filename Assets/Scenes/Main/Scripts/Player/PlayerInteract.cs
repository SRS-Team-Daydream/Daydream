using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Windows;

namespace Daydream
{
    public class PlayerInteract : MonoBehaviour
    {
        [SerializeField] InputReaderSO inputSO;

        [SerializeField] float _interactdist = 1f;

        [SerializeField] LayerMask mask;

        Vector2 _moveDir = Vector2.zero;


        void Reset()
        {
            inputSO = SOUtil.Find<InputReaderSO>();
        }

        private void Awake()
        {
            inputSO.Gameplay.ActionEvent += OnInteract;
            inputSO.Gameplay.MoveChangedEvent += OnMoveChanged;
        }

        void OnDestroy()
        {
            inputSO.Gameplay.ActionEvent -= OnInteract;
            inputSO.Gameplay.MoveChangedEvent -= OnMoveChanged;
        }

        public void Interact()
        {
            Collider2D collider = Physics2D.OverlapPoint((Vector2)transform.position + _moveDir * _interactdist, mask);
            if (collider != null)
            {
                collider.gameObject.GetComponent<Interactable>().Interact();
            }
        }

        void OnInteract()
        {
            Interact();
        }

        void OnMoveChanged(Vector2 move)
        {
            if(move.sqrMagnitude > 0)
            {
                _moveDir = move;
            }
        }
    }
}
