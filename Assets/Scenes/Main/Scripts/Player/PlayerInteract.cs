using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Daydream
{
    public class PlayerInteract : MonoBehaviour
    {
        [System.NonSerialized]
        public PlayerInput PlayerInput;
        [System.NonSerialized]
        public Controls Controls;

        bool _interact = false;
        [SerializeField] float _interactdist = 10f;

        [SerializeField]
        LayerMask mask;

        

        private void Awake()
        {
            PlayerInput = GetComponent<PlayerInput>();
            Controls = new Controls();
            PlayerInput.actions = Controls.asset;
        }

        void Start()
        {
            Controls.Gameplay.Action.started += OnInteract;
        }

        private void OnDestroy()
        {
            Controls.Gameplay.Action.started -= OnInteract;
        }
        public void Interact()
        {
            int _layermask = 1 << 7;

            RaycastHit2D _hit;

            _hit = Physics2D.Raycast(transform.position, transform.right, _interactdist, _layermask);

            if (_hit.collider != null)
            {
                Debug.DrawRay(transform.position, transform.right * _hit.distance, Color.yellow);
            }
        }

        void OnInteract(InputAction.CallbackContext ctx)
        {
            Interact();
        }


    }
}
