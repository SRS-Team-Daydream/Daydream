using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Daydream
{
    public class Player : MonoBehaviour
    {
        [System.NonSerialized]
        public PlayerInput PlayerInput;
        [System.NonSerialized]
        public Controls Controls;

        private void Awake()
        {
            PlayerInput = GetComponent<PlayerInput>();
            Controls = new Controls();
            PlayerInput.actions = Controls.asset;
        }

    }
}
