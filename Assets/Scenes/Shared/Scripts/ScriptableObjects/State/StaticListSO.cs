using Kulip;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Daydream
{
    public class StaticListSO<T> : StaticSO<List<T>>
    {
        public System.Action<List<T>> ListChangedEvent;

        public void Add(T item)
        {
            Value.Add(item);
            ListChangedEvent?.Invoke(Value);
        }

        public void AddRange(IEnumerable<T> range)
        {
            Value.AddRange(range);
            ListChangedEvent?.Invoke(Value);
        }

        public void Clear()
        {
            Value.Clear();
            ListChangedEvent?.Invoke(Value);
        }

        public void Insert(int index, T item)
        {
            Value.Insert(index, item);
            ListChangedEvent?.Invoke(Value);
        }

        public void Insert(int index, IEnumerable<T> range)
        {
            Value.InsertRange(index, range);
            ListChangedEvent?.Invoke(Value);
        }

        public void Remove(T item)
        {
            Value.Remove(item);
            ListChangedEvent?.Invoke(Value);
        }

        public void RemoveAll(Predicate<T> predicate)
        {
            Value.RemoveAll(predicate);
            ListChangedEvent?.Invoke(Value);
        }

        public void RemoveAt(int idx)
        {
            Value.RemoveAt(idx);
            ListChangedEvent?.Invoke(Value);
        }

        public void RemoveRange(int idx, int count)
        {
            Value.RemoveRange(idx, count);
            ListChangedEvent?.Invoke(Value);
        }

        public void Sort()
        {
            Value.Sort();
            ListChangedEvent?.Invoke(Value);
        }
    }
}
