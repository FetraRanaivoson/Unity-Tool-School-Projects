using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

[CustomPropertyDrawer(typeof(Player))]
public class PlayerCustomDrawer : PropertyDrawer
{
    private int hElement = 20;
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        SerializedProperty name = property.FindPropertyRelative("name");
        SerializedProperty life = property.FindPropertyRelative("life");
        Rect textPosition = new Rect(position.x, position.y, position.width, hElement);
        Rect lifePosition = new Rect(position.x, position.y + hElement, position.width,hElement);
        GUI.TextField(textPosition, name.stringValue);
        EditorGUI.IntField(lifePosition, life.intValue);
    }

    public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
    {
        return hElement * 2;
    }
}
