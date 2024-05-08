using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleChecker : MonoBehaviour
{
	public CardInstance[] battlingCards = new CardInstance[2];
	public bool canBattle = false;
	public Transform battlefieldParent;

	// Start is called before the first frame update
	void Start()
	{

	}

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
		attacker.GetComponent<CardAttack>().canAttack = false;

		ClearBattlingCards();
		canBattle = false;
	}

	void ClearBattlingCards()
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
