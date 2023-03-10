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
        [SerializeField] Vector2 _offset = Vector2.one / 2;

        [SerializeField] LayerMask mask;

        Vector2 _moveDir = Vector2.zero;


        void Reset()
        {
            inputSO = SOUtil.Find<InputReaderSO>();
        }

        private void Awake()
        {
#if UNITY_EDITOR
            if(mask.value == 0)
            {
                Debug.LogWarning("PlayerInteract does not have a mask set. Interactions will not work.");
            }
#endif
            inputSO.Gameplay.ActionEvent += Interact;
            inputSO.Gameplay.MoveChangedEvent += OnMoveChanged;
        }

        void OnDestroy()
        {
            inputSO.Gameplay.ActionEvent -= Interact;
            inputSO.Gameplay.MoveChangedEvent -= OnMoveChanged;
        }

        public void Interact()
        {
            Collider2D collider = Physics2D.OverlapPoint((Vector2)transform.position + _offset + _moveDir * _interactdist, mask);
            Debug.Log((Vector2)transform.position + _offset + _moveDir * _interactdist);
            if (collider != null)
            {
                collider.gameObject.GetComponent<Interactable>().Interact();
            }
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
