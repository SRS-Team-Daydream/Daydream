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

        Vector2Int lastPos;
        Vector2Int targetPos;
        float moveTime;

        void Reset()
        {
            grid = GetComponentInParent<Grid>();
        }

        void Start()
        {
            lastPos = (Vector2Int)grid.WorldToCell(transform.position);
        }

        public void Move(Vector2Int input)
        {
            //only set new targetPos is previous target has been reached
            if (lastPos == targetPos)
            {
                targetPos = lastPos + Vector2Int.FloorToInt(input);
                moveTime = Time.time;
                Debug.Log(moveTime);
            }
        }

        void Update()
        {
            if(Time.time < moveTime + interval)
            {
                transform.position = (Vector3)Vector2.Lerp(
                    grid.CellToWorld((Vector3Int)lastPos),
                    grid.CellToWorld((Vector3Int)targetPos),
                    (Time.time - moveTime)/moveTime
                ) + Vector3.up * transform.position.z;
            }
            else if(targetPos != lastPos)
            {
                transform.position = (Vector3)(Vector2)grid.CellToWorld((Vector3Int)targetPos)
                    + Vector3.up * transform.position.z;
                lastPos = targetPos;
            }
        }
    }
}
