using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using Yarn.Unity;

namespace Daydream
{
    public class DeityCamSwitcher : MonoBehaviour
    {
        [YarnCommand("switchcam")]
        public static void SwitchCam(CinemachineVirtualCamera playerCam)
        {
            playerCam.Priority = 1;
        }

    }
}
