using UnityEngine;

namespace Daydream
{
    public class Derenderer : MonoBehaviour
    {
        void Awake()
        {
            var renderer = GetComponent<Renderer>();
            if(renderer != null )
            {
                renderer.enabled = false;
            }
        }
    }
}