using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "MagicCard", menuName = "MagicCard / Create")]
public class CardScriptable : ScriptableObject
{
    public static int CardId = 0;
    
    public string cardName;
    public string description;
    public int manaCost;
    public CardType manaType;
    public Color backgroundColor;
    public Sprite sprite;
    
}
