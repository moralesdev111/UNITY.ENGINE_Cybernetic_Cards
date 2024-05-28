using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleChecker : MonoBehaviour
{
	private CardInstance[] battlingCards = new CardInstance[2];
	public CardInstance[] BattlingCards { get { return battlingCards; } }
	private bool canBattle = false;



	private void Update()
	{
		if (CheckBattleReady() && canBattle)
		{
			Battle(battlingCards[0], battlingCards[1]);
		}
		canBattle = true;
	}

	public void Battle(CardInstance attacker, CardInstance defender)
	{
		Debug.Log("battle started");
		defender.cardInstanceCurrentHealth -= attacker.card.attack;
		attacker.cardInstanceCurrentHealth -= defender.card.attack;
		attacker.GetComponent<CardAttack>().SetCanAttack(false);

		ClearBattlingCards();
		canBattle = false;
	}

	public void ClearBattlingCards()
	{
		Debug.Log("Battle Finished");
		for (int i = 0; i < battlingCards.Length; i++)
		{
			battlingCards[i] = null;
		}
	}

	public bool CheckBattleReady()
	{
		return battlingCards[0] != null && battlingCards[1] != null;
	}
}
