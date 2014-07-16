using UnityEngine;
using UnityEditor;
using System.Collections;


[CustomPropertyDrawer (typeof(Range))]
class RangeEditor : PropertyDrawer {
    
    public override void OnGUI (Rect position, SerializedProperty property, GUIContent label) {

        EditorGUI.BeginProperty (position, label, property);

        Rect contentPosition = EditorGUI.PrefixLabel (position, GUIUtility.GetControlID (FocusType.Passive), label);
        
        EditorGUI.indentLevel = 0;
        EditorGUIUtility.labelWidth = 30f;
        
        contentPosition.width /= 2;
        contentPosition.width -= 2;
        
        EditorGUI.PropertyField(new Rect(contentPosition.x, contentPosition.y, contentPosition.width, contentPosition.height), property.FindPropertyRelative("min"), new GUIContent("Min"));
       
        contentPosition.x += contentPosition.width + 4;

        EditorGUI.PropertyField(new Rect(contentPosition.x, contentPosition.y, contentPosition.width, contentPosition.height), property.FindPropertyRelative("max"), new GUIContent("Max"));
      
        EditorGUI.EndProperty ();
    }
}