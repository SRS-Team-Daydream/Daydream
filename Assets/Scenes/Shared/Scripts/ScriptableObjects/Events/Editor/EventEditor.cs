using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

namespace Daydream
{
    [CustomPropertyDrawer(typeof(Event))]
    [CustomPropertyDrawer(typeof(Event<float>))]
    public class EventEditor : PropertyDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            EditorGUI.BeginProperty(position, label, property);

            position = EditorGUI.PrefixLabel(position, GUIUtility.GetControlID(FocusType.Passive), label);

            EditorGUI.PropertyField(position, property.FindPropertyRelative("_eventSO"), GUIContent.none);

            EditorGUI.EndProperty();
        }
    }
}
