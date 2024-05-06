using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CardCodex")]
public class CardCodex : ScriptableObject
{
    [SerializeField] private List<Card> cards = new List<Card>();
    public List<Card> Cards { get { return cards; } }
}
