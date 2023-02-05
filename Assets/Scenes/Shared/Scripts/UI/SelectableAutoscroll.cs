using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Daydream
{
    [RequireComponent(typeof(RectTransform))]
    public class SelectableAutoscroll : MonoBehaviour, ISelectHandler
    {
        [SerializeField] ScrollRect scrollRect;
        RectTransform rectTransform;

        float MinYVisible => 
            (scrollRect.content.sizeDelta.y - ((RectTransform)scrollRect.transform).sizeDelta.y)
            * (1 - scrollRect.verticalScrollbar.value);
        float MaxYVisible =>
            (scrollRect.content.sizeDelta.y - ((RectTransform)scrollRect.transform).sizeDelta.y)
            * (1 - scrollRect.verticalScrollbar.value)
            + ((RectTransform)scrollRect.transform).sizeDelta.y;

        float Position => -rectTransform.anchoredPosition.y - rectTransform.sizeDelta.y / 2;

        private void Reset()
        {
            scrollRect = GetComponentInParent<ScrollRect>();
        }

        private void Awake()
        {
            rectTransform = transform as RectTransform;
        }

        public void OnSelect(BaseEventData eventData)
        {
            Debug.LogFormat("MIN: {0}, MAX: {1}", MinYVisible, MaxYVisible);
            Debug.LogFormat("POS: {0}", Position);
            if (MinYVisible > Position)
            {
                ScrollTopTo(Position);
            }
            else if (MaxYVisible < Position + rectTransform.sizeDelta.y)
            {
                ScrollBottomTo(Position + rectTransform.sizeDelta.y);
            }
        }

        void ScrollTopTo(float y)
        {
            /*
             * (content.sizeDelta.y - scrollRect.sizeDelta.y) * (1 - v) = y;
             * v = 1 - y/(content.sizeDelta.y - scrollRect.sizeDelta.y)
             */
            scrollRect.verticalScrollbar.value = 1 
                - y 
                / (scrollRect.content.sizeDelta.y - ((RectTransform)scrollRect.transform).sizeDelta.y);
        }

        void ScrollBottomTo(float y)
        {
            /*
             * (content.sizeDelta.y - scrollRect.transform.sizeDelta.y) * (1 - v) + scrollRect.sizeDelta.y = y;
             * v = 1 - (y - scrollRect.sizeDelta.y)/(content.sizeDelta.y - scrollRect.transform.sizeDelta.y)
             */
            scrollRect.verticalScrollbar.value = 1 
                - (y - ((RectTransform)scrollRect.transform).sizeDelta.y) 
                / (scrollRect.content.sizeDelta.y - ((RectTransform)scrollRect.transform).sizeDelta.y);
        }
    }
}
