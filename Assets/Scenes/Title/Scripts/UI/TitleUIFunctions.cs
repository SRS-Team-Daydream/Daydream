using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Daydream
{
    public class TitleUIFunctions : MonoBehaviour
    {
        [SerializeField] string mainScene = "main";
        
        public void Start()
        {
            SceneManager.LoadScene(mainScene);
        }

        public void Quit()
        {
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#else
            Application.Quit();
#endif
        }
    }
}
