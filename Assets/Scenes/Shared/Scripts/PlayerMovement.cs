using Codice.Client.Common.FsNodeReaders.Watcher;
using PlasticPipe.PlasticProtocol.Messages;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Daydream
{
    [RequireComponent(typeof(GridMovement))]
    public class PlayerMovement : MonoBehaviour
    {

        [SerializeField] InputReaderSO inputSO;

        GridMovement gridMovement;

        void Reset()
        {
            inputSO = SOUtil.Find<InputReaderSO>();    
        }

        void Awake()
        {
            inputSO.Gameplay.MoveChangedEvent += OnInputMove;
            gridMovement = GetComponent<GridMovement>();
        }

        void OnInputMove(Vector2 input)
        {
            gridMovement.Move(input);
        }
    }
}
