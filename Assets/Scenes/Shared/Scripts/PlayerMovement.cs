using Codice.Client.Common.FsNodeReaders.Watcher;
using PlasticPipe.PlasticProtocol.Messages;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Daydream
{
    public class PlayerMovement : MonoBehaviour
    {

        [SerializeField] InputReaderSO inputSO;

        public Vector2 _inputVec = Vector2.zero;
        [SerializeField]float _speed = 5f;

        [SerializeField] SetMoveDir setMoveDir;
        


        void Awake()
        {
            inputSO.Gameplay.MoveChangedEvent += OnInputMove;

            
        }

        void Update()
        {
            setMoveDir.Move(_inputVec);
        }

        void OnInputMove(Vector2 inputVector)
        {
            _inputVec = inputVector;
        }


        
    }
}
