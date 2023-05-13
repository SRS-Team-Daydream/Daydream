using Codice.Client.Common.FsNodeReaders.Watcher;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Daydream
{
    public class GridMovement : MonoBehaviour
    {
        [SerializeField] float interval = 0.2f;
        [SerializeField] Grid grid;

        public Grid Grid => grid;
        public System.Action LandedOnTileEvent;

        Vector2Int moveDirection = Vector2Int.zero;
        Vector2Int lastPos = Vector2Int.zero;
        Vector2Int targetPos = Vector2Int.zero;
        float moveTime = float.NegativeInfinity;

        void Reset()
        {
            grid = GetComponentInParent<Grid>();
        }

        void Start()
        {
            lastPos = (Vector2Int)grid.WorldToCell(transform.position);
            transform.position = grid.CellToWorld((Vector3Int)lastPos);
        }

        // Moves ONE tile
        public void Move(Vector2Int input)
        {
            //only set new targetPos is previous target has been reached
            if (lastPos == targetPos)
            {
                targetPos = lastPos + Vector2Int.FloorToInt(input);
                moveTime = Time.time;
            }
        }

        // Moves tiles until direction changes
        public void SetMoveDirection(Vector2Int direction)
        {
            moveDirection = direction;
            Move(direction);
        }

        void Update()
        {
            if(Time.time < moveTime + interval)
            {
                transform.position = (Vector3)Vector2.Lerp(
                    grid.CellToWorld((Vector3Int)lastPos),
                    grid.CellToWorld((Vector3Int)targetPos),
                    (Time.time - moveTime)/interval
                ) + Vector3.up * transform.position.z;
            }
            else if(targetPos != lastPos)
            {
                transform.position = (Vector3)(Vector2)grid.CellToWorld((Vector3Int)targetPos)
                    + Vector3.up * transform.position.z;
                lastPos = targetPos;

                LandedOnTileEvent?.Invoke();

                if (moveDirection.sqrMagnitude > 0)
                {
                    Move(moveDirection);
                }
            }
        }
    }
}
