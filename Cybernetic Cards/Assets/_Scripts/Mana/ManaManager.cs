using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Mana Manager")]
public class ManaManager : ScriptableObject
{
	[SerializeField] private TurnSystem turnSystem;

	public bool GreenLight(Card card)
	{
		return turnSystem.currentMana >= card.manaCost;
	}

	public int ManaDecrease(int amount)
	{
		return turnSystem.currentMana -= amount;
	}
}
