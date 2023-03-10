using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Daydream
{
    [RequireComponent(typeof(Renderer))]
    public class Nonrendered : MonoBehaviour
    {
        void Awake()
        {
            Renderer[] renderers = GetComponents<Renderer>();
            foreach (Renderer renderer in renderers)
            {
                renderer.enabled = false;
            }
        }
    }
}
