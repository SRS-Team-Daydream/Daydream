using Kulip;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

namespace Daydream
{
    [CreateAssetMenu(fileName = "AudioChangedEventHandler", menuName = "Event Handlers/Settings/Audio Changed")]
    public class AudioChangedEventHandler : ScriptableObject
    {
        [SerializeField] EventSO<float> volumeChangedEvent;
        [SerializeField] AudioMixer mixer;
        [SerializeField] string masterVolumeParameter = "MasterVolume";

        void OnEnable()
        {
            if(volumeChangedEvent != null)
            {
                volumeChangedEvent += OnVolumeChanged;
            }
        }

        void OnVolumeChanged(float volume)
        {
            mixer.SetFloat(masterVolumeParameter, volume);
        }
    }
}
