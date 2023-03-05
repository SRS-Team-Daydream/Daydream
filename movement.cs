using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Daydream
{
    public class movement : MonoBehaviour
    {
        // Start is called before the first frame update


        //Movement Speed
        public float speed = 10;

        public Rigidbody2D body;

        private Vector2 movementVar;

        // Update used to take in input (Don't know if there is another method preffered though :/ )
        void Update()
        {
            //Returns value 1 or -1 based on input 
            movementVar.x = Input.GetAxisRaw("Horizontal");
            movementVar.y = Input.GetAxisRaw("Vertical");
        }


        // Apply movement
        void FixedUpdate()
        {
            body.MovePosition(body.position + movementVar * speed * Time.fixedDeltaTime);
        }
    }
}
