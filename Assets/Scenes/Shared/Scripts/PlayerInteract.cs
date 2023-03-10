using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Windows;

namespace Daydream
{
    public class PlayerInteract : MonoBehaviour
    {
        [System.NonSerialized]
        public PlayerInput PlayerInput;
        [System.NonSerialized]
        public Controls Controls;

        [SerializeField] InputReaderSO inputSO;

        [SerializeField] float _interactdist = 10f;

        [SerializeField]
        LayerMask mask;

        Vector2 _moveDir = Vector2.zero;
        

        private void Awake()
        {
            inputSO.Gameplay.ActionEvent += OnInteract;
        }

        void Start()
        {

        }

        public void Interact()
        {
            RaycastHit2D _hit;

            _hit = Physics2D.Raycast(transform.position, transform.right, _interactdist, mask);

            if (_hit.collider != null)
            {
                //Debug.DrawRay(transform.position, transform.right * _hit.distance, Color.yellow);

                //interaction code

                Debug.Log("hey chris");
            }

        }

        void OnInteract()
        {
            Interact();
            
        }


    }
}
