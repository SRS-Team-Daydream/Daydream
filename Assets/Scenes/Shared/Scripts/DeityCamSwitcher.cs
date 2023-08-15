using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

namespace Daydream
{
    public class DeityCamSwitcher : MonoBehaviour
    {
        [SerializeField] CinemachineVirtualCamera playerCam;
        [SerializeField] CinemachineVirtualCamera deityCam;
        

        public void SwitchCam()
        {
            playerCam.Priority = 1;
        }

    }
}
