using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using Kulip;

#if UNITY_EDITOR
using UnityEditor;
#endif

namespace Daydream
{
    public class MenuButtonFunctions : MonoBehaviour
    {
        [SerializeField] StaticSO<float> masterVolume;

        public void OnQuitPressed()
        {
#if UNITY_EDITOR
            Debug.Log("Quit Button Pressed");
            EditorApplication.isPlaying = false;
#else
            Application.Quit();
#endif
        }



        public void OnVolumeChanged(float newVolume)
        {
            masterVolume.Value = newVolume;
        }
    }
}
