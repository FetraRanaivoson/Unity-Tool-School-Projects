using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;
using Directory = UnityEngine.Windows.Directory;
using Object = System.Object;


public class CreateCardEditor : EditorWindow
{
    private Texture _texture;
    private string _cardName;
    private string _description;
    private int _manaCost;
    private Color _bgColor;
    private Sprite _sprite;
    private string[] _cardTypesList;
    
    private float _labelWidth = 80;
    private float _labelHeight = 25;
    private float _fieldWidth = 200;
    private float _fieldHeight = 20;
    private float _leftMargin = 20;
    private float _fieldSpacing = 1.2f;
    private int _selectedCardIndex = 0;
    
    
    [MenuItem("MagicCard / Editor")]
    public static void CreateWindow()
    {
        GetWindow<CreateCardEditor>().Show();
    }

    private void OnEnable()
    {
        _texture = EditorGUIUtility.whiteTexture;
        _cardName = "Enter card name";
        _description = "Enter description";
        _manaCost = 0;
        _bgColor = Color.white;
        _cardTypesList = new[] {"Fire", "Wood", "Earth", "Metal", "Water"};
    }
    
    private void OnGUI()
    {
        Rect leftArea = LayoutUtil.GetRect(position, 0, 0, 4, 12);
        DrawLeftArea(leftArea);

        Rect rightArea = LayoutUtil.GetRect(position, 4, 0, 8, 12);
        DrawRightArea(rightArea);

        Rect previewArea = LayoutUtil.GetRect(leftArea, 1, 4, 11, 6);
        DrawCardPreview(previewArea);
    }

    private string[] GetCardScriptableFileName()
    {
        List<string> card = new List<string>();
        string[] temp = System.IO.Directory.GetFiles("Assets/Datas");
        foreach (var file in temp)
        {
            if (!file.Contains(".meta"))
            {
                card.Add(file.Split('/')[1]);
            }
        }
        return card.ToArray();
    }

    private CardScriptable[] GetAllCards()
    {
        //  Get all the files
        string[] files = AssetDatabase.FindAssets("", new[] {"Assets/Datas"});
        foreach (string file in files)
        {
            AssetDatabase.GUIDToAssetPath(file);
        }

        //  Convert them to just the file name
        string[] convertedFiles = new string [files.Length];
        for (int i = 0; i < convertedFiles.Length; i++)
        {
            convertedFiles[i] = AssetDatabase.GUIDToAssetPath(files[i]);
            convertedFiles[i] = convertedFiles[i].Split('/')[2]/*.Split('.')[0]*/;
        }

        //  Load each .assets, the scriptable cards
        CardScriptable[] allCardAssets = new CardScriptable[convertedFiles.Length]; 
        for (int i = 0; i < allCardAssets.Length; i++)
        {
            allCardAssets[i] =  AssetDatabase.LoadAssetAtPath(Path.Combine("Assets", "Datas", convertedFiles[i]), 
                typeof(Object)) as CardScriptable;
        }
        
        return allCardAssets;
    }

    private void DrawLeftArea(Rect leftAreaRect)
    {
        //Manuel: GUI, EditorGUI, EditorGUIUtility
        //Auto: GUILayout, EditorGUILayout, GUILayoutUtility

        GUILayout.BeginArea(new Rect(leftAreaRect));
        SetColors(Color.white, Color.white);
        Rect cardLabelPosition = new Rect(_leftMargin, position.height / 30, _labelWidth, _labelHeight);
        CreateTextField(cardLabelPosition, "Card Name: ", ref _cardName);

        Rect descLabelPosition = new Rect(_leftMargin, cardLabelPosition.y + _fieldSpacing * _labelHeight, _labelWidth,
            _labelHeight);
        CreateTextField(descLabelPosition, "Description: ", ref _description);

        Rect manaLabelPosition = new Rect(_leftMargin, descLabelPosition.y + _fieldSpacing * _labelHeight, _labelWidth,
            _labelHeight);
        CreateIntField(manaLabelPosition, "Mana Cost: ", ref _manaCost);

        Rect bgLabelPosition = new Rect(_leftMargin, manaLabelPosition.y + _fieldSpacing * _labelHeight, _labelWidth,
            _labelHeight);
        CreateColorField(bgLabelPosition, "Background: ", ref _bgColor);

        Rect spriteLabelPosition = new Rect(_leftMargin, bgLabelPosition.y + _fieldSpacing * _labelHeight, _labelWidth,
            _labelHeight);
        CreateSpriteField(spriteLabelPosition, "Image: ", ref _sprite);

        Rect cardTypeLabelPosition = new Rect(_leftMargin, spriteLabelPosition.y + _fieldSpacing * _labelHeight,
            _labelWidth, _labelHeight);
        _selectedCardIndex = EditorGUI.Popup(new Rect(_leftMargin, spriteLabelPosition.y + _fieldSpacing * _labelHeight,
            _labelWidth * 3, _labelHeight), "Card Type: ", _selectedCardIndex, _cardTypesList);

        if (GUI.Button(
            new Rect(leftAreaRect.width / 2 - leftAreaRect.width / 4, position.height - 50, leftAreaRect.width / 2,
                leftAreaRect.height / 20), "Create New Card"))
        {
            CardScriptable cs = ScriptableObject.CreateInstance<CardScriptable>();
            cs.cardName = _cardName;
            cs.description = _description;
            cs.manaCost = _manaCost;
            cs.sprite = _sprite;
            cs.backgroundColor = _bgColor;
            switch (_selectedCardIndex)
            {
                case 0:
                    cs.manaType = CardType.Fire;
                    break;
                case 1:
                    cs.manaType = CardType.Wood;
                    break;
                case 2:
                    cs.manaType = CardType.Earth;
                    break;
                case 3:
                    cs.manaType = CardType.Metal;
                    break;
                case 4:
                    cs.manaType = CardType.Water;
                    break;
            }

            if (!Directory.Exists(Path.Combine("Assets", "Datas")))
            {
                Directory.CreateDirectory(Path.Combine("Assets", "Datas"));
            }

            //AssetDatabase.CreateAsset(cardAsset, "Assets/Datas/" + _cardName + ".asset");
            AssetDatabase.CreateAsset(cs, Path.Combine("Assets", "Datas", _cardName + ".asset"));
            AssetDatabase.SaveAssets();
        }
        GUILayout.EndArea();
    }
    
    private void DrawRightArea(Rect rightArea)
    {
        GUILayout.BeginArea(rightArea);
        CardScriptable [] allCards = GetAllCards();
        
        for (int i = 0; i < allCards.Length; i++)
        {
            if (GUI.Button(LayoutUtil.GetRect(rightArea, 1, 1 + i * 1, 6, 1),
                allCards[i].cardName))
            {
                //Get all the information
                CardScriptable cs = CreateInstance<CardScriptable>();
                cs.name = allCards[i].cardName;
                cs.description = allCards[i].description;
                cs.manaCost = allCards[i].manaCost;
                cs.backgroundColor = allCards[i].backgroundColor;
                cs.sprite = allCards[i].sprite;
                cs.manaType = allCards[i].manaType;

                //Display the information
                _cardName = cs.name;
                _description = cs.description;
                _manaCost = cs.manaCost;
                _bgColor = cs.backgroundColor;
                _sprite = cs.sprite;
                switch (cs.manaType)
                {
                    case CardType.Fire:
                        _selectedCardIndex = 0;
                        break;
                    case CardType.Wood:
                        _selectedCardIndex = 1;
                        break;
                    case CardType.Earth:
                        _selectedCardIndex = 2;
                        break;
                    case CardType.Metal:
                        _selectedCardIndex = 3;
                        break;
                    case CardType.Water:
                        _selectedCardIndex = 4;
                        break;
                }
            }
        }

        // //Card placer 1
        // SetColors(Color.white, Color.white);
        // GUI.DrawTexture(LayoutUtil.GetRect(rightArea, 1, 1, 4, 4), _texture);
        //
        // //Card placer 2
        // SetColors(Color.white, Color.white);
        // GUI.DrawTexture(LayoutUtil.GetRect(rightArea, 6, 1, 4, 4), _texture);
        //
        // //Card placer 3
        // SetColors(Color.white, Color.white);
        // GUI.DrawTexture(LayoutUtil.GetRect(rightArea, 1, 6, 4, 4), _texture);
        //
        // //Card placer 4
        // SetColors(Color.white, Color.white);
        // GUI.DrawTexture(LayoutUtil.GetRect(rightArea, 6, 6, 4, 4), _texture);

        GUILayout.EndArea();
    }

    private void DrawCardPreview(Rect previewRect)
    {
        GUILayout.BeginArea(previewRect);
        //Bg
        GUI.color = _bgColor;
        GUI.DrawTexture(LayoutUtil.GetRect(previewRect, 0, 0, 12, 11), _texture);


        //Image
        GUI.color = Color.blue;
        if (_sprite != null)
        {
            var spriteTexture = new Texture2D((int) _sprite.rect.width, (int) _sprite.rect.height);
            var pixels = _sprite.texture.GetPixels((int) _sprite.textureRect.x,
                (int) _sprite.textureRect.y,
                (int) _sprite.textureRect.width,
                (int) _sprite.textureRect.height);
            spriteTexture.SetPixels(pixels);
            spriteTexture.Apply();
            GUI.DrawTexture(LayoutUtil.GetRect(previewRect, 1, 1, 10, 9), spriteTexture);
        }


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
        GUI.Label(labelPosition, new GUIContent(labelName));
        sprite = EditorGUI.ObjectField(
            new Rect(labelPosition.x + labelPosition.width, labelPosition.y, _fieldWidth, _fieldHeight),
            sprite, typeof(Sprite), true) as Sprite;
    }
    private void CreateColorField(Rect labelPosition, string labelName, ref Color bgColor)
    {
        GUI.Label(labelPosition, new GUIContent(labelName));
        bgColor = EditorGUI.ColorField(
            new Rect(labelPosition.x + labelPosition.width, labelPosition.y, _fieldWidth, _fieldHeight), bgColor);
    }
    private void CreateTextField(Rect labelPosition, string labelName, ref string fieldContent)
    {
        GUI.Label(labelPosition, new GUIContent(labelName));
        fieldContent =
            EditorGUI.TextArea(
                new Rect(labelPosition.x + labelPosition.width, labelPosition.y, _fieldWidth, _fieldHeight),
                fieldContent);
    }
    private void CreateIntField(Rect labelPosition, string labelName, ref int fieldContent)
    {
        GUI.Label(labelPosition, new GUIContent(labelName));
        fieldContent =
            EditorGUI.IntField(
                new Rect(labelPosition.x + labelPosition.width, labelPosition.y, _fieldWidth, _fieldHeight),
                fieldContent);
    }
    private void SetColors(Color background, Color font)
    {
        GUI.backgroundColor = background;
        GUI.color = font;
    }
}