using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Daydream
{
    public class PlayerInteract : MonoBehaviour
    {
        [SerializeField] InputReaderSO inputReader;

        bool _interact = false;
        [SerializeField] float _interactdist = 1f;

        [SerializeField]
        LayerMask mask;

        void Reset()
        {
            inputReader = SOUtil.Find<InputReaderSO>();
        }

        void Awake()
        {
            inputReader.Gameplay.ActionEvent += OnInteract;
        }

        private void OnDestroy()
        {
            inputReader.Gameplay.ActionEvent -= OnInteract;
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

        void OnInteract()
        {
            Interact();
        }


    }
}
