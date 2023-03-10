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

        [SerializeField] float _interactdist = 10f;

        [SerializeField]
        LayerMask mask;

        Vector2 _moveDir = Vector2.zero;


        void Reset()
        {
            inputSO = SOUtil.Find<InputReaderSO>();
        }

        private void Awake()
        {
            inputSO.Gameplay.ActionEvent += OnInteract;
        }

        public void Interact()
        {
            RaycastHit2D _hit;

            _hit = Physics2D.Raycast(transform.position, transform.right, _interactdist, mask);

            if (_hit.collider != null)
            {
                
            }
        }

        void OnInteract()
        {
            Interact();

        }


    }
}
