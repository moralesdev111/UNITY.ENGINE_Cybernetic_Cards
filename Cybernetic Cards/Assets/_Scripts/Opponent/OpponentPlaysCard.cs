using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class OpponentPlaysCard : MonoBehaviour
{
	[SerializeField] TurnSystem turnSystem;
	[SerializeField] OpponentHand opponentHand;
	[SerializeField] Transform opponentBattlefield;
	[SerializeField] OpponentAttack opponentAttack;
	private bool hasPlayedCard = false;

	private void OnEnable()
	{
		turnSystem.onPlayerTurnEnd += OpponentTurnLogistics;
		turnSystem.onOpponentTurnEnd += PlayerTurnLogistics;
	}

	private void OnDisable()
	{
		turnSystem.onPlayerTurnEnd -= OpponentTurnLogistics;
		turnSystem.onOpponentTurnEnd -= PlayerTurnLogistics;
	}

	private void OpponentTurnLogistics()
	{
		if (!hasPlayedCard && turnSystem.currentTurnState == TurnStatus.opponent)
		{
			PlayCard();
			hasPlayedCard = true;
			opponentAttack.ReadyToAttack = true;
			opponentAttack.AttackExecuted = false;
		}
	}

	private void PlayerTurnLogistics()
	{
		if (turnSystem.currentTurnState == TurnStatus.player)
		{
			hasPlayedCard = false;
			opponentAttack.AttackExecuted = false;
		}
	}

	private void PlayCard()
	{
		if (turnSystem.opponentCurrentMana > 0)
		{
			StartCoroutine(DelayAction());
		}
	}

	private void SearchForFirstPlayableCard(int amountOfChecks)
	{
		bool foundPlayableCard = false;
		for (int i = 0; i < amountOfChecks; i++)
		{
			if (opponentHand.Container[i].manaCost <= turnSystem.opponentCurrentMana)
			{
				foundPlayableCard = true;
				Card chosenCard = opponentHand.Container[i];
				GameObject physicalCard = opponentHand.GetInstantiatedCards()[i];
				physicalCard.transform.SetParent(opponentBattlefield);

				AssignCardInstance(chosenCard, physicalCard);
				opponentHand.Container.Remove(chosenCard);
				//opponentHand.GetInstantiatedCards().Remove(physicalCard);
				break;
			}
		}
		if (!foundPlayableCard)
		{
			turnSystem.EndOpponentTurn();
			Debug.Log("No card is playable");
		}
	}

	private void AssignCardInstance(Card chosenCard, GameObject physicalCard)
	{
		CardInstance cardInstance = physicalCard.GetComponent<CardInstance>();
		cardInstance.card = chosenCard;
	}


	IEnumerator DelayAction()
	{
		yield return new WaitForSeconds(1.5f);
		SearchForFirstPlayableCard(opponentHand.CurrentSize);
	}
}
