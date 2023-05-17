using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Daydream
{
    public class StaticSO<T> : ScriptableObject
    {
        [SerializeField] bool _keepAlive = true;
        [SerializeField] T _defaultValue;

        static List<StaticSO<T>> _keepAliveList = new List<StaticSO<T>>();

        public Event<T> ValueChangedEvent;

        T _value;
        public T Value
        {
            get => _value;
            set
            {
                _value = value;
                if(ValueChangedEvent != null) ValueChangedEvent.Invoke(_value);
            }
        }

        void OnEnable()
        {
            _value = _defaultValue;
            if (_keepAlive)
            {
                _keepAliveList.Add(this);
            }
        }

        private void OnDestroy()
        {
            _keepAliveList.Remove(this);
        }
    }
}
