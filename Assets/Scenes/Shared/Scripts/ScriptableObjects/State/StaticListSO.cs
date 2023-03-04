using Kulip;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Daydream
{
    public class StaticListSO<T> : StaticSO<List<T>>
    {
        public Event<List<T>> ListChangedEvent;

        private void OnListChanged() {
            if(ListChangedEvent != null)
            {
                ListChangedEvent.Invoke(Value);
            }
        }

        public void Add(T item)
        {
            Value.Add(item);
            OnListChanged();
        }

        public void AddRange(IEnumerable<T> range)
        {
            Value.AddRange(range);
            OnListChanged();
        }

        public void Clear()
        {
            Value.Clear();
            OnListChanged();
        }

        public void Insert(int index, T item)
        {
            Value.Insert(index, item);
            OnListChanged();
        }

        public void Insert(int index, IEnumerable<T> range)
        {
            Value.InsertRange(index, range);
            OnListChanged();
        }

        public void Remove(T item)
        {
            Value.Remove(item);
            OnListChanged();
        }

        public void RemoveAll(Predicate<T> predicate)
        {
            Value.RemoveAll(predicate);
            OnListChanged();
        }

        public void RemoveAt(int idx)
        {
            Value.RemoveAt(idx);
            OnListChanged();
        }

        public void RemoveRange(int idx, int count)
        {
            Value.RemoveRange(idx, count);
            OnListChanged();
        }

        public void Sort()
        {
            Value.Sort();
            OnListChanged();
        }
    }
}
