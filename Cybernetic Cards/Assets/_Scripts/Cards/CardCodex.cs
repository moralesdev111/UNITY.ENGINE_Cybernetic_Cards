using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CardCodex")]
public class CardCodex : ScriptableObject
{
    public List<Card> cards = new List<Card>();
}
