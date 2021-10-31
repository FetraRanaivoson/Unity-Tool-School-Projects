using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomPropertyDrawer(typeof(IntAttribute))]
public class BrickCustomDrawer : PropertyDrawer
{
    private int hProperty = 20;
    
    //Player
    private Vector2 _playerPosition;
    private Vector2 _playerSize = new Vector2(60, 15);
    private float _sliderMoveValue = 0.5f;
    private float _playerSpeed = 25;
    //Breaker
    private Vector2 _breakerPosition = new Vector2(300, 150);
    private Vector2 _breakerSize = new Vector2(20,20);
    private Vector2 _breakerVelocity = new Vector2(2, 2);
    
    private Texture _texture;
    
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        IntAttribute nbBriqueAttr = attribute as IntAttribute;
        EditorGUI.PropertyField(new Rect(position.x, position.y, position.width, hProperty), property,
            new GUIContent("NbBrique"));

        //Display background
        GUI.color = Color.white;
        Rect bgPosition = new Rect(position.x, position.y + hProperty, position.width, hProperty * 13 - position.y);
        GUI.DrawTexture(bgPosition, _texture);

        //Display bricks
        for (int i = 0; i < property.intValue; i++)
        {
            GUI.color = Color.red;
            int boxWidth = 30;
            int boxHeight = 15;
            int boxSpacing = 10;
            int marginLeft = 5;
            int marginTop = 30;
            GUI.DrawTexture(new Rect(bgPosition.x + marginLeft + (boxWidth + boxSpacing) * i + boxSpacing,
                bgPosition.y + marginTop, boxWidth, boxHeight), _texture);
        }

        //"Casse-brique" Control
        GUI.color = Color.white;
        _sliderMoveValue = EditorGUI.Slider(new Rect(position.x, hProperty * 14, position.width, hProperty), "Move",
            _sliderMoveValue, 0, 1);

        //Display "casse-brique"
        GUI.color = Color.blue;
        //_playerPosition = new Vector2(bgPosition.width / 2 + _sliderMoveValue * _playerSpeed, hProperty * 13);
        _playerPosition = new Vector2(
                Mathf.Lerp(bgPosition.x, bgPosition.width - _playerSize.x/2, _sliderMoveValue),
                hProperty * 13);
        GUI.DrawTexture(new Rect(_playerPosition, _playerSize), _texture);

        
        //Display breaker
        GUI.color = Color.black;
        // _breakerPosition -= _breakerVelocity;
        GUI.DrawTexture(new Rect(_breakerPosition, _breakerSize), _texture);
        
        

        //EditorGUI.TextField(new Rect(position.x, position.y + hElement, position.width, hElement),
        //CreateRect(property.intValue));
        // if (property.propertyType == SerializedPropertyType.Integer)
        // {
        //     property.intValue = EditorGUI.IntField(
        //         new Rect(position.x, position.y, position.width, position.height / 2), label,
        //         Mathf.Max(0, attr.NbBrique));
        //     EditorGUI.LabelField(new Rect(position.x, position.y + position.height/2, position.width, position.height/2),
        //         "ggg", GUIStyle.none);
        // }
    }

    private GUIStyle IntFormat(int propertyINTValue)
    {
        throw new System.NotImplementedException();
    }

    public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
    {
        _texture = EditorGUIUtility.whiteTexture;
        //return EditorGUI.GetPropertyHeight(property) * 2;
        return hProperty * 15;
    }
}