using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

namespace Daydream
{
    [System.Serializable]
    public class Event
    {
        System.Action _event;
        [SerializeField] EventSO _eventSO;

        public static Event operator +(Event a, System.Action f)
        {
            if (a._eventSO != null)
            {
                a._eventSO += f;
            }
            else
            {
                a._eventSO += f;
            }
            return a;
        }

        public static Event operator -(Event a, System.Action f)
        {
            if (a._eventSO != null)
            {
                a._eventSO -= f;
            }
            else
            {
                a._eventSO -= f;
            }
            return a;
        }

        public void Invoke()
        {
            if (_eventSO != null)
            {
                _eventSO.Invoke();
            }
            else
            {
                _event?.Invoke();
            }
        }

        public void Clear()
        {
            _event = null;
            if (_eventSO != null)
            {
                _eventSO.Clear();
            }
        }
    }

    [System.Serializable]
    public class Event<T>
    {
        System.Action<T> _event;
        [SerializeField] EventSO<T> _eventSO;

        public static Event<T> operator +(Event<T> a, System.Action<T> f)
        {
            if(a._eventSO != null)
            {
                a._eventSO += f;
            }
            else
            {
                a._event += f;
            }
            return a;
        }

        public static Event<T> operator -(Event<T> a, System.Action<T> f)
        {
            if (a._eventSO != null)
            {
                a._eventSO -= f;
            }
            else
            {
                a._event -= f;
            }
            return a;
        }

        public void Invoke(T arg)
        {
            if (_eventSO != null)
            {
                _eventSO.Invoke(arg);
            }
            else
            {
                _event?.Invoke(arg);
            }
        }

        public void Clear()
        {
            _event = null;
            if(_eventSO != null)
            {
                _eventSO.Clear();
            }
        }
    }

    [CreateAssetMenu(fileName = "Event", menuName = "Events/()")]
    public class EventSO : ScriptableObject
    {
        System.Action _event;

        public static EventSO operator +(EventSO a, System.Action f)
        {
            a._event += f;
            return a;
        }

        public static EventSO operator -(EventSO a, System.Action f)
        {
            a._event -= f;
            return a;
        }

        public void Invoke()
        {
            _event?.Invoke();
        }

        public void Clear()
        {
            _event = null;
        }
    }

    public class EventSO<T> : ScriptableObject
    {
        System.Action<T> _event;

        public static EventSO<T> operator +(EventSO<T> a, System.Action<T> f)
        {
            a._event += f;
            return a;
        }

        public static EventSO<T> operator -(EventSO<T> a, System.Action<T> f)
        {
            a._event -= f;
            return a;
        }

        public void Invoke(T t)
        {
            _event?.Invoke(t);
        }

        public void Clear()
        {
            _event = null;
        }
    }
}
