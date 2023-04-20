using Codice.Client.Common.FsNodeReaders.Watcher;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Daydream
{
    public class SetMoveDir : MonoBehaviour
    {

        Vector2Int oldPos = Vector2Int.zero;
        Vector2Int targetPos = Vector2Int.zero;
        Vector2 _direction = Vector2.zero;

        [SerializeField] float _speed = 5f;

        [SerializeField] GameObject origin;

        [SerializeField] Vector2Int gridDimensions;

        public void Move(Vector2 inputMove)
        {

            
            //only set new targetPos is previous target has been reached
            if (oldPos == targetPos)
            {
                targetPos = oldPos + new Vector2Int(
                Mathf.FloorToInt(inputMove.x),
                Mathf.FloorToInt(inputMove.y));
            }

            if (Mathf.Abs(targetPos.x) < gridDimensions.x && Mathf.Abs(targetPos.y) < gridDimensions.y)
            {
                _direction = (targetPos - oldPos);

                //Debug.Log(newPos.x + ", " + newPos.y);
                //Debug.Log(targetPos.x + ", " + targetPos.y);
                //Debug.Log(moveDir.x + ", " + moveDir.y);

                transform.position += new Vector3(_direction.x, _direction.y, 0).normalized * _speed * Time.deltaTime;

                //convert transform to grid coordinates
                oldPos = new Vector2Int
                    (Mathf.FloorToInt(transform.position.x - origin.transform.position.x),
                    Mathf.FloorToInt(transform.position.y - origin.transform.position.y));
            }

            else { targetPos = oldPos; }
            

        }
    }
}
