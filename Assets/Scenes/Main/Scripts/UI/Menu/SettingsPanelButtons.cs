using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Daydream
{
    public class SettingsPanelButtons : MonoBehaviour
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
