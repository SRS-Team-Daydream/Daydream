using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Yarn.Unity;

namespace Daydream
{
    public class ChangeSceneInteractable : Interactable
    {
        [SerializeField] string scene;

        public override void OnInteract()
        {
            IEnumerator ChangeSceneCoroutine()
            {
                yield return new WaitForSeconds(0.5f);

                SceneManager.LoadScene(scene);
            }

            StartCoroutine(ChangeSceneCoroutine());
        }
    }
}
