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

        private Vector2 movementVar;

        [SerializeField] Animator animator;


        void Awake()
        {
            body = GetComponent<Rigidbody2D>();
            inputReader.Gameplay.MoveChangedEvent += OnMoveChanged;

            animator = GetComponent<Animator>();
        }

        void OnMoveChanged(Vector2 newMovement)
        {
            movementVar = newMovement;
        }

        void Update()
        {
            // Apply movement
            transform.position += (Vector3) movementVar * speed * Time.deltaTime;

            Animate();
        }

        void Animate()
        {
            if(movementVar.y > 0)
            {
                animator.SetInteger("transitionVar", 1);
            }

            else if (movementVar.y < 0)
            {
                animator.SetInteger("transitionVar", -1);
            }

            else if (movementVar.y == 0)
            {
                animator.SetInteger("transitionVar", 0);
            }
        }
    }
}
