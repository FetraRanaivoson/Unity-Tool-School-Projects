using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomPropertyDrawer(typeof(DamageAttribute))]
public class CustomPropertyDrawerS : PropertyDrawer
{
    private int hProperty = 20;
    private Texture _texture;

    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        DamageAttribute damageAttribute = attribute as DamageAttribute;
        EditorGUI.PropertyField(new Rect(position.x, position.y + 25, position.width, hProperty), 
            property, new GUIContent("ExplosionForce"));


        EditorGUI.CurveField(new Rect(position.x, position.y + 50, position.width, 10*hProperty),
            AnimationCurve.EaseInOut(0, property.floatValue, 1, 0) );
        
        damageAttribute.explosionForce = property.floatValue;
        //Debug.Log(property.floatValue);
    }

    public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
    {
        _texture = EditorGUIUtility.whiteTexture;
        //return EditorGUI.GetPropertyHeight(property) * 2;
        return hProperty * 15;
    }
}
