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
            if (movementVar.y > 0)
            {
                //animator.SetInteger("transitionVar", 1);
                animator.Play("PlayerUp", -1, 0f);
            }

            else if (movementVar.y < 0)
            {
                //animator.SetInteger("transitionVar", -1);
                animator.Play("PlayerDown", -1, 0f);
            }

            if (movementVar.x > 0)
            {
                animator.Play("PlayerSide", -1, 0f);
                
                gameObject.transform.localScale = new Vector3(1, 1, 1) * gameObject.transform.localScale.y;
            }

            if (movementVar.x < 0)
            {
                animator.Play("PlayerSide", -1, 0f);
                gameObject.transform.localScale = new Vector3(-1, 1, 1) * gameObject.transform.localScale.y;
            }
        }
    }
}
