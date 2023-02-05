using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Kulip
{
    [CreateAssetMenu(fileName = "Time", menuName = "Time/Time")]
    public class TimeSO : TimeSOBase
    {
        public System.Action<bool> PausedChangedEvent;
        public System.Action TimeZeroedEvent;
        public System.Action FixedTimeZeroedEvent;

        public bool Paused { 
            get => _paused;
            set {
                if (value) Pause();
                else Resume();
            }
        }

        override public float Time 
            => (
                _paused 
                ? _lastPauseUnityTime
                : UnityEngine.Time.time
            ) - _totalPauseDuration; 

        override public float FixedTime
            => (
                _paused
                ? _lastPauseUnityFixedTime
                : UnityEngine.Time.fixedTime
            ) - _totalPauseFixedDuration;

        override public float DeltaTime 
            => _paused
            ? 0f
            : UnityEngine.Time.deltaTime; 
        
        override public float FixedDeltaTime 
            => _paused 
            ? 0f 
            : UnityEngine.Time.fixedDeltaTime;

        bool _paused = false;

        // The Time.time of the last pause
        float _lastPauseUnityTime = 0f;
        // The Time.fixedTime of the last pause
        float _lastPauseUnityFixedTime = 0f;

        // The total amount of time paused.
        // Calculated via the difference between Time.time and _lastPauseUnityTime every
        // time resumed.
        float _totalPauseDuration = 0f;

        //Total amount of fixed time paused (see _totalPauseDuration)
        float _totalPauseFixedDuration = 0f;

        public void Pause()
        {
            if (_paused) return;
            _lastPauseUnityTime = UnityEngine.Time.time;
            _lastPauseUnityFixedTime = UnityEngine.Time.fixedTime;

            _paused = true;
            PausedChangedEvent?.Invoke(_paused);
        }

        public void Resume()
        {
            if (!_paused) return;
            _totalPauseDuration += UnityEngine.Time.time - _lastPauseUnityTime;
            _totalPauseFixedDuration += UnityEngine.Time.fixedTime - _lastPauseUnityFixedTime;

            _paused = false;
            PausedChangedEvent?.Invoke(_paused);
        }

        public void Zero()
        {
            ZeroTime();
            ZeroFixedTime();
        }

        public void ZeroTime()
        {
            _totalPauseDuration = UnityEngine.Time.time;
            TimeZeroedEvent?.Invoke();
        }

        public void ZeroFixedTime()
        {
            _totalPauseFixedDuration = UnityEngine.Time.fixedTime;
            TimeZeroedEvent?.Invoke();

        }

        virtual protected void OnEnable()
        {
            _paused = false;
            _lastPauseUnityTime = 0f;
            _lastPauseUnityFixedTime = 0f;
            _totalPauseDuration = 0f;
            _totalPauseFixedDuration = 0f;
        }
    }
}