using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;
using static UnityEngine.UI.Image;
using TMPro;

namespace Daydream
{
    public class NPCMove : MonoBehaviour
    {
        public System.Action PathStartedEvent;
        public System.Action PathChangedEvent;
        public System.Action PathCompletedEvent;

        public Vector2Int? Target { get; private set; } = null;

        int currentWaypoint = 0;
        bool reachedEndOfPath;

        Seeker seeker;
        GridMovement gridMovement;
        Path path;
        Vector2Int? newTarget = null;

        void Awake()
        {
            seeker = GetComponent<Seeker>();
            gridMovement = GetComponent<GridMovement>();

            gridMovement.LandedOnTileEvent += UpdateWaypoint;
        }

        public void MoveToCoordinate(Vector2Int target)
        {
            if(path == null)
            {
                RecalculatePath(target);
                PathStartedEvent?.Invoke();
            }
            else
            {
                newTarget = target;
            }
        }

        void OnPathCalculated(Path path)
        {
            if (path.error)
            {
                Debug.LogError($"A* failed: {path.errorLog}");
                return;
            }

            this.path = path;
            currentWaypoint = 1; // skip the 0th waypoint, which is the current position
            UpdateWaypoint();
        }

        void RecalculatePath(Vector2Int target)
        {
            Target = target;
            seeker.StartPath(
                transform.position, 
                gridMovement.Grid.CellToWorld((Vector3Int)target), 
                OnPathCalculated
            );
        }

        void UpdateWaypoint()
        {
            if(this.newTarget is Vector2Int newTarget)
            {
                path = null;
                RecalculatePath(newTarget);
                PathChangedEvent?.Invoke();
                return;
            }

            if (currentWaypoint < path.vectorPath.Count)
            {
                Vector2Int moveDir = Vector2Int.RoundToInt((path.vectorPath[currentWaypoint] - transform.position).normalized);
                ++currentWaypoint;
                gridMovement.Move(moveDir);
            }
            else
            {
                path = null;
                PathCompletedEvent?.Invoke();
            }
        }
    }
}
