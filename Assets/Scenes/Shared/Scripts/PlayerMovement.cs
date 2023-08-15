using Codice.Client.Common.FsNodeReaders.Watcher;
using PlasticPipe.PlasticProtocol.Messages;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Windows;

namespace Daydream
{
    [RequireComponent(typeof(GridMovement))]
    public class PlayerMovement : MonoBehaviour
    {

        [SerializeField] InputReaderSO inputSO;
        Vector2 move = Vector2.zero;

        GridMovement gridMovement;
        //Vector2Int movementVar = Vector2Int.zero;
        Animator animator;

        void Reset()
        {
            inputSO = SOUtil.Find<InputReaderSO>();    
        }

        void Awake()
        {
            inputSO.Gameplay.MoveChangedEvent += OnMoveChange;
            gridMovement = GetComponent<GridMovement>();
            animator = GetComponentInChildren<Animator>();
        }

        void OnDestroy()
        {
            inputSO.Gameplay.MoveChangedEvent -= OnMoveChange;    
        }

        void OnMoveChange(Vector2Int input)
        {
            gridMovement.SetMoveDirection(input);
            move = input;
        }

        void Update()
        {
            Animate(move);
        }

        void Animate(Vector2 movementVar)
        {
            float Speed = movementVar.magnitude;
            animator.SetFloat("Horizontal", movementVar.x);
            animator.SetFloat("Vertical", movementVar.y);
            animator.SetFloat("Input", Speed);

            if(Speed > 0.01)
            {
                animator.SetFloat("LastHorizontal", movementVar.x);
                animator.SetFloat("LastVertical", movementVar.y);
            }

            if (movementVar.x > 0)
            {   
                gameObject.transform.localScale = new Vector3(1, 1, 1) * gameObject.transform.localScale.y;
            }

            if (movementVar.x < 0)
            {
                gameObject.transform.localScale = new Vector3(-1, 1, 1) * gameObject.transform.localScale.y;
            }
        }
    }
}
