using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Daydream
{
    public class Interactible : MonoBehaviour
    {
        [System.NonSerialized]
        public PlayerInput PlayerInput;
        [System.NonSerialized]
        public Controls Controls;

        private bool _interact = false;

        bool _interactible = true;

        void Awake()
        {
            PlayerInput = GetComponent<PlayerInput>();
            Controls = new Controls();
            PlayerInput.actions = Controls.asset;



        }

        void Update()
        {
            if (_interactible && _interact)
            {
                Interaction();
            }
        }

        void Start()
        {
            Controls.Gameplay.Action.started += OnInteract;
            Controls.Gameplay.Action.canceled += OnInteract;
            
        }

        
        void OnTriggerEnter2D(Collider2D collision)
        {
            Debug.Log("in");
            if (collision.gameObject.tag == "Player") 
            {
                _interactible = true;
                
            }
        }

        void OnTriggerExit2D(Collider2D collision)
        {
            _interactible = false;
        }

        void Interaction()
        {
            Debug.Log("Interact");

        }

        void OnInteract(InputAction.CallbackContext ctx)
        {
            if (ctx.started) { _interact = true; }
            if (ctx.canceled) { _interact = false; }
        }

    }
}
