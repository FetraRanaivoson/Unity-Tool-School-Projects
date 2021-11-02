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
        Rect leftAreaRect = CreateRect(0,0,position.width/4, 3*position.height/4);
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
        
            GUI.color = Color.green;
            Rect cardBg = CreateRect(0,0,10,10);
            GUI.DrawTexture(LayoutUtil.GetRect(leftAreaRect, 0, 0, 2, 2), _texture);
            
            // Rect cardArea = CreateRect(leftAreaRect.width, 0 , leftAreaRect.width / 4, 150);
            // GUILayout.BeginArea(cardArea);
            //     SetColors(Color.yellow, Color.yellow);
            //     GUI.DrawTexture(cardArea, _texture);
            // GUILayout.EndArea();
            

        GUILayout.EndArea();
        
        
        Rect creationRect = CreateRect(leftAreaRect.width+1, 0, position.width - leftAreaRect.width, position.height);
        GUILayout.BeginArea(creationRect);
            SetColors(Color.white, Color.white); 
            GUI.DrawTexture(new Rect(0, 0, position.width - leftAreaRect.x, position.height ), _texture);
            GUI.Button(new Rect(creationRect.width/2, 0, position.width/10, position.height / 15), "test");
            GUILayout.BeginHorizontal();
                GUI.color = Color.gray;
                GUI.DrawTexture(new Rect(0,position.height - 50, position.width - leftAreaRect.x, position.height/2), _texture);
            GUILayout.EndHorizontal();
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
