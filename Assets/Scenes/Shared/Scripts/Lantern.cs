using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;
using Yarn.Unity;

namespace Daydream
{
    public class Lantern : MonoBehaviour
    {
        [YarnCommand("lightlantern")]
        public static void LightLantern(GameObject lantern)
        {
            if(lantern.gameObject != null)
            {
                Light2DBase _light;
                _light = lantern.GetComponent<Light2DBase>();
                _light.enabled = true;
            }
        }

    }
}
