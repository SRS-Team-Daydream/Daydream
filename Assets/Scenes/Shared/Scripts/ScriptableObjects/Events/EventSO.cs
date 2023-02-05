using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

namespace Kulip
{
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
