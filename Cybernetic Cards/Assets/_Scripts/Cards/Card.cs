using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Card")]
public class Card : ScriptableObject
{
    public string cardName;
	public Sprite artwork;
	public Sprite artworkBack;
	public int manaCost;
	public int attack;
	public int health;
}
