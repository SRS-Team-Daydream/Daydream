using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;
using static UnityEngine.UI.Image;

namespace Daydream
{
    public class NPCMove : MonoBehaviour
    {
        public Transform target;
        Vector2 targetPosition;
        public float nextWaypointDistance = 3;
        private int currentWaypoint = 0;
        public bool reachedEndOfPath;

        [SerializeField] float _speed = 5f;

        [SerializeField] GridMovement setMoveDir; 
        [SerializeField] Seeker seeker;
        public Vector2 move;
        Path path;

        void Start()
        {
            seeker = GetComponent<Seeker>();
            setMoveDir = GetComponent<GridMovement>();

            targetPosition = target.transform.position;
            targetPosition = new Vector2
                    (Mathf.FloorToInt(targetPosition.x),
                    Mathf.FloorToInt(targetPosition.y));
            Debug.Log(targetPosition);

            seeker.StartPath(transform.position, targetPosition, OnPathComplete);
        }

        public void OnPathComplete(Path p)
        {
            Debug.Log("A path was calculated. Did it fail with an error? " + p.error);

            if (!p.error)
            {
                path = p;
                // Reset the waypoint counter so that we start to move towards the first point in the path
                currentWaypoint = 0;
            }
        }

        void Update()
        {
            if (path == null)
            {
                // We have no path to follow yet, so don't do anything
                Debug.LogWarning("no path to follow!");
                return;
            }

            // Check if we are close enough to the current waypoint to switch to the next one.
            // We do this in a loop because many waypoints might be close to each other and we may reach
            // several of them in the same frame.
            reachedEndOfPath = false;
            Vector2 distanceToWaypoint;
            Vector2 moveDir = Vector2.zero;

            distanceToWaypoint = (-transform.position + path.vectorPath[currentWaypoint]);
            moveDir = distanceToWaypoint.normalized;
            if (Mathf.Abs(moveDir.x) > Mathf.Abs(moveDir.y))
            {
                moveDir.y = 0;
            }
            
            if (Mathf.Abs(moveDir.y) > Mathf.Abs(moveDir.x))
            {
                moveDir.x = 0;
            }

            moveDir = moveDir.normalized;

            if (distanceToWaypoint.sqrMagnitude > (0.1))
            {
                reachedEndOfPath = false;
                
            }

            else
            {
                if (currentWaypoint + 1 < path.vectorPath.Count)
                {
                    currentWaypoint++;
                }
                else
                {
                    // Set a status variable to indicate that the agent has reached the end of the path.
                    // You can use this to trigger some special code if your game requires that.
                    reachedEndOfPath = true;
                    Debug.Log("reached end");
                }
            }

            if(reachedEndOfPath == false)
            {
                
                setMoveDir.Move(moveDir);
                Debug.Log("moving");
            }

            move = moveDir;
        }
    }
}
