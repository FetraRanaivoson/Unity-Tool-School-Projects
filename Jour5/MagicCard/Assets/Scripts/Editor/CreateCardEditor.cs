using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

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
    }

    private Texture _texture;
    private string _cardName = "Enter card name";
    private string _description = "Enter description";
    private int _manaCost = 0;
    private void OnGUI()
    {
        Rect leftAreaRect = LayoutUtil.GetRect(position, 0,0, 4,12);
        DrawLeftArea(leftAreaRect);
        Rect rightArea = LayoutUtil.GetRect(position, 4, 0, 8,12);
        DrawRightArea(rightArea);
        
        //Preview Area
        Rect previewRect = LayoutUtil.GetRect(leftAreaRect, 1,6, 11,6);
        GUILayout.BeginArea(previewRect);
            GUI.color = Color.green;

            float height = position.height;
            float size = height / 10;
            
            GUI.DrawTexture(LayoutUtil.GetRect(previewRect, 0,0, 12,11), _texture);
        GUILayout.EndArea();
    }
    private void DrawLeftArea(Rect leftAreaRect)
    {
        GUILayout.BeginArea(new Rect(leftAreaRect));
        SetColors(Color.white, Color.white); 
        AddSpace(10);
        GUILayout.Label(new GUIContent("Card Name: "));
        _cardName = EditorGUILayout.TextArea(_cardName);
        AddSpace(10);
            
        GUILayout.Label(new GUIContent("Description: "));
        _description = EditorGUILayout.TextArea(_description);
        AddSpace(10);
            
        GUILayout.Label(new GUIContent("Mana Cost: "));
        _manaCost = EditorGUILayout.IntField(_manaCost);
        AddSpace(10);
            
        GUILayout.Label(new GUIContent("Background Color: "));
        EditorGUILayout.ColorField(Color.white);
        AddSpace(10);
            
        GUILayout.Label(new GUIContent("Image: "));
        GUI.Button(new Rect( leftAreaRect.width/2 - (leftAreaRect.width)/2,250, leftAreaRect.width, leftAreaRect.height /20), "Create New Card");
        
        GUILayout.EndArea();
        
        // Rect cardArea = CreateRect(leftAreaRect.width, 0 , leftAreaRect.width / 4, 150);
        // GUILayout.BeginArea(cardArea);
        //     SetColors(Color.yellow, Color.yellow);
        //     GUI.DrawTexture(cardArea, _texture);
        // GUILayout.EndArea();
     
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
