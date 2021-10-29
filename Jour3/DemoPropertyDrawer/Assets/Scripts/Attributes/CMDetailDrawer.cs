using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomPropertyDrawer(typeof(CMDetailAttribute))]
public class CMDetailDrawer : PropertyDrawer
{
    private int hElement = 18;

    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        CMDetailAttribute detailAttribute = attribute as CMDetailAttribute;

        if (detailAttribute.IsVisible)
        {
            EditorGUI.PropertyField(new Rect(position.x, position.y, position.width, hElement), property,
                new GUIContent("Cm"));
            EditorGUI.TextField(new Rect(position.x, position.y + hElement, position.width, hElement),
                ConvertIntToMettreCm(property.intValue));
        }
        else
        {
            EditorGUI.PropertyField(position, property, new GUIContent("Cm"));
        }
    }
    
    public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
    {
        CMDetailAttribute detailAttribute = attribute as CMDetailAttribute;
        return detailAttribute.IsVisible ? hElement * 2 : hElement;
    }
    
    private string ConvertIntToMettreCm(int value)
    {
        int meter = value / 100;
        int cm = value % 100;
        string retour = "meter : " + meter + " cm : " + cm ;
        
        return retour;
    }
}