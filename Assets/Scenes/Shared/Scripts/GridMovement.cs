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
        [SerializeField] LayerMask wallLayerMask;

        public Grid Grid => grid;
        public bool Moving { get; private set; } = false;
        public Vector2Int FacingDirection { get; private set; } = Vector2Int.right;

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
            if (input.sqrMagnitude > 0 && lastPos == targetPos)
            {
                FacingDirection = input;

                var newTarget = lastPos + Vector2Int.FloorToInt(input);
                Collider2D wall = Physics2D.OverlapPoint(
                    (Vector2)grid.CellToWorld((Vector3Int)newTarget),
                    wallLayerMask.value
                );
                if(wall == null)
                {
                    targetPos = newTarget;
                    moveTime = Time.time;
                    Moving = true;
                }
                else
                {
                    Moving = false;
                    moveDirection = Vector2Int.zero;
                }
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
                else
                {
                    Moving = false;
                }
            }
        }
    }
}
