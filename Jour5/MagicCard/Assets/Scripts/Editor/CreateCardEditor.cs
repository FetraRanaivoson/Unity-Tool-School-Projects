using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using Object = System.Object;


public class CreateCardEditor : EditorWindow
{

    [MenuItem("MagicCard / Editor")]
    public static void CreateWindow()
    {
        GetWindow<CreateCardEditor>().Show();
    }

    private void OnEnable()
    {
        _texture = EditorGUIUtility.whiteTexture;
        _cardTypesList = new[] {"Fire", "Wood", "Earth", "Metal", "Water"};
    }

    private Texture _texture;
    private string _cardName = "Enter card name";
    private string _description = "Enter description";
    private int _manaCost = 0;
    private Color _bgColor = Color.red;
    private Sprite _sprite;
    private void OnGUI()
    {
        Rect leftArea = LayoutUtil.GetRect(position, 0,0, 4,12);
        DrawLeftArea(leftArea);
        
        Rect rightArea = LayoutUtil.GetRect(position, 4, 0, 8,12);
        DrawRightArea(rightArea);
        
        Rect previewArea = LayoutUtil.GetRect(leftArea, 1,4, 11,6);
        DrawCard(previewArea);
    }

    private float _labelWidth = 80;
    private float _labelHeight = 25;
    private float _fieldWidth = 200;
    private float _fieldHeight = 20;
    private float _leftMargin = 20;
    private float _fieldSpacing = 1.2f;
    private int _selectedCardIndex = 0;
    private string [] _cardTypesList = new string[5];
    private void DrawLeftArea(Rect leftAreaRect)
    {
        //Manuel: GUI, EditorGUI, EditorGUIUtility
        //Auto: GUILayout, EditorGUILayout, GUILayoutUtility
        
        GUILayout.BeginArea(new Rect(leftAreaRect));
            SetColors(Color.white, Color.white);
            Rect cardLabelPosition = new Rect(_leftMargin, position.height / 30, _labelWidth, _labelHeight);
            CreateTextField(cardLabelPosition, "Card Name: ", ref _cardName);

            Rect descLabelPosition = new Rect(_leftMargin, cardLabelPosition.y + _fieldSpacing *_labelHeight, _labelWidth, _labelHeight);
            CreateTextField(descLabelPosition, "Description: ", ref _description);

            Rect manaLabelPosition = new Rect(_leftMargin, descLabelPosition.y + _fieldSpacing *_labelHeight, _labelWidth, _labelHeight);
            CreateIntField(manaLabelPosition, "Mana Cost: ", ref _manaCost);
            
            Rect bgLabelPosition = new Rect(_leftMargin, manaLabelPosition.y + _fieldSpacing *_labelHeight, _labelWidth, _labelHeight);
            CreateColorField(bgLabelPosition, "Background: ", ref _bgColor);
            
            Rect spriteLabelPosition = new Rect(_leftMargin, bgLabelPosition.y + _fieldSpacing *_labelHeight, _labelWidth, _labelHeight);
            CreateSpriteField(spriteLabelPosition, "Image: ", ref _sprite);

            Rect cardTypeLabelPosition = new Rect(_leftMargin, spriteLabelPosition.y + _fieldSpacing * _labelHeight,
                _labelWidth, _labelHeight);
            _selectedCardIndex = EditorGUI.Popup(new Rect(_leftMargin, spriteLabelPosition.y + _fieldSpacing * _labelHeight,
                _labelWidth *3, _labelHeight ),"Card Type: ", _selectedCardIndex, _cardTypesList);
            
            GUI.Button(new Rect( leftAreaRect.width/2 - leftAreaRect.width/4, position.height - 50, leftAreaRect.width/2, leftAreaRect.height /20), "Create New Card");
        GUILayout.EndArea();
    }

    private void DrawCard(Rect previewRect)
    {
        GUILayout.BeginArea(previewRect);
            //Bg
            GUI.color = _bgColor;
            GUI.DrawTexture(LayoutUtil.GetRect(previewRect, 0, 0, 12, 11), _texture);
            //Image
            GUI.color = Color.blue;
            GUI.DrawTexture(LayoutUtil.GetRect(previewRect, 1, 1, 10, 9), _texture);
            //Description
            GUI.color = Color.white;
            GUI.DrawTexture(LayoutUtil.GetRect(previewRect, 1, 8, 10, 2), _texture);
            GUI.TextArea(LayoutUtil.GetRect(previewRect, 1, 8, 10, 2), _description);
            //Mana cost
            GUI.color = Color.green;
            GUI.TextArea(LayoutUtil.GetRect(previewRect, 10, 0, 2, 1), _manaCost.ToString());
            //Name
            GUI.color = Color.white;
            GUI.TextArea(LayoutUtil.GetRect(previewRect, 4, 0.667f, 4, 1), _cardName);
        GUILayout.EndArea();
    }
    
    private void CreateSpriteField(Rect labelPosition, string labelName, ref Sprite sprite)
    {
        GUI.Label(labelPosition,new GUIContent(labelName));
        sprite = EditorGUI.ObjectField(
            new Rect(labelPosition.x + labelPosition.width, labelPosition.y, _fieldWidth, _fieldHeight),
            sprite, typeof(Sprite), true) as Sprite;
    }
    private void CreateColorField(Rect labelPosition, string labelName, ref Color bgColor)
    {
        GUI.Label(labelPosition,new GUIContent(labelName)); 
        bgColor = EditorGUI.ColorField(
            new Rect(labelPosition.x + labelPosition.width, labelPosition.y, _fieldWidth, _fieldHeight), bgColor);
    }
    private void CreateTextField(Rect labelPosition, string labelName, ref string fieldContent)
    {
        GUI.Label(labelPosition,new GUIContent(labelName));
        fieldContent = EditorGUI.TextArea(new Rect(labelPosition.x + labelPosition.width, labelPosition.y, _fieldWidth,_fieldHeight), fieldContent);

    }
    private void CreateIntField(Rect labelPosition, string labelName, ref int fieldContent)
    {
        GUI.Label(labelPosition,new GUIContent(labelName));
        fieldContent = EditorGUI.IntField(new Rect(labelPosition.x + labelPosition.width, labelPosition.y, _fieldWidth,_fieldHeight), fieldContent);

    }
    private void DrawRightArea(Rect rightArea)
    {
        GUILayout.BeginArea(rightArea);
        
        //Card placer 1
        SetColors(Color.white, Color.white);
        GUI.DrawTexture(LayoutUtil.GetRect(rightArea, 1, 1, 4, 4), _texture);
        
        //Card placer 2
        SetColors(Color.white, Color.white);
        GUI.DrawTexture(LayoutUtil.GetRect(rightArea, 6, 1, 4, 4), _texture);
        
        //Card placer 3
        SetColors(Color.white, Color.white);
        GUI.DrawTexture(LayoutUtil.GetRect(rightArea, 1, 6, 4, 4), _texture);
        
        //Card placer 4
        SetColors(Color.white, Color.white);
        GUI.DrawTexture(LayoutUtil.GetRect(rightArea, 6, 6, 4, 4), _texture);
        
        GUILayout.EndArea();
    }

    

    private Rect CreateRect(float positionX, float positionY, float width, float height)
    {
        Rect rectArea = new Rect(positionX, positionY, width, height);
        return rectArea;
        // GUILayout.BeginArea(rectArea);
        //     GUI.color = color;
        //     GUI.DrawTexture(rectArea, _texture);
        // GUILayout.EndArea();
    }
    
    private void AddSpace(float pixel)
    {
        GUILayout.Space(pixel);
    }
    private void SetColors(Color background, Color font)
    {
        GUI.backgroundColor = background;
        GUI.color = font;
    }

}