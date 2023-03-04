using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Daydream
{
    public class MenuButtonFunctions : MonoBehaviour
    {
        public void OnQuitPressed()
        {
#if UNITY_EDITOR
            Debug.Log("Quit Button Pressed");
#else
            Application.Quit();
#endif
        }
    }
}
