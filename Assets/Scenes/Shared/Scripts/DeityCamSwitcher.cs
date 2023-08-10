using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

namespace Daydream
{
    public class DeityCamSwitcher : MonoBehaviour
    {
        bool deityCamOn = false;
        [SerializeField] CinemachineVirtualCamera playerCam;
        [SerializeField] CinemachineVirtualCamera deityCam;
        

        public void SwitchCam()
        {
            if (deityCamOn)
            {
                playerCam.Priority = 10;
            }

            else
            {
                playerCam.Priority = 1;
            }

            deityCamOn = !deityCamOn;
        }

    }
}
