using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "MagicCard", menuName = "MagicCard / Create")]
public class CardScriptable : ScriptableObject
{
    public string cardName;
    public string description;
    public int manaCost;
    public CardType manaType;
    public Color backgoundColor;
    public Sprite sprite;
    
}
