using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Daydream
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class movement : MonoBehaviour
    {
        //Movement Speed
        [SerializeField] private float speed = 10;

        [SerializeField] private InputReaderSO inputReader;

        private Rigidbody2D body;

        private Vector2Int movementVar;


        void Awake()
        {
            body = GetComponent<Rigidbody2D>();
            inputReader.Gameplay.MoveChangedEvent += OnMoveChanged;
        }

        void OnMoveChanged(Vector2Int newMovement)
        {
            movementVar = newMovement;
        }

        void FixedUpdate()
        {
            // Apply movement
            body.MovePosition(body.position + (Vector2)movementVar * speed * Time.fixedDeltaTime);
        }
    }
}
