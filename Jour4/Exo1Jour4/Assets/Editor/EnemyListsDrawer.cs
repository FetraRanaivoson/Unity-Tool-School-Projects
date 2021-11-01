using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomPropertyDrawer(typeof(EnemyListsAttribute))]
public class EnemyListsDrawer : PropertyDrawer
{
    private int hProperty = 20;

    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        EnemyListsAttribute attr = attribute as EnemyListsAttribute;
        //EditorGUI.PropertyField(new Rect(position.x, position.y, position.width, hProperty),
          //  property, new GUIContent("EnemyType"));
        //EditorGUI.DropdownButton(new Rect(position.x, position.y, position.width, hProperty),
          //  new GUIContent("fdfd"), FocusType.Passive);
    }

    public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
    {
        return hProperty;
    }
}
