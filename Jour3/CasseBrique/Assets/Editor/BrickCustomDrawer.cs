using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomPropertyDrawer(typeof(Brique))]
public class BrickCustomDrawer : PropertyDrawer
{
    private int hElement = 20;
    //private Texture _texture;

    
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        SerializedProperty nbBrick = property.FindPropertyRelative("nbBrick");
        Rect textPosition = new Rect(position.x, position.y, position.width, hElement);
        EditorGUI.IntField(textPosition, nbBrick.intValue);
    }

    public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
    {
        //_texture = EditorGUIUtility.whiteTexture;
        return hElement * 20;
    }

}
