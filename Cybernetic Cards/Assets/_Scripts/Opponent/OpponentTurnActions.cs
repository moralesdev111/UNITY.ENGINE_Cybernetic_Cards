using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpponentTurnActions : MonoBehaviour
{
	[SerializeField] private TurnState turnState;
	[SerializeField] private TurnSystemSettings turnSystemSettings;
	[SerializeField] private OpponentHand opponentHand;
	[SerializeField] private Transform opponentBattlefield;
	[SerializeField] private Transform playerBattlefield;
	[SerializeField] private TurnManager turnManager;

	private bool hasPlayedCard = false;
	private bool readyToAttack = false;
	private bool attackExecuted = false;

	void Update()
	{
		WhilePlayerTurn();
		PlayCardAction();
		AttackAction();
	}

	private void AttackAction()
	{
		if (readyToAttack)
		{
			if (!attackExecuted)
			{
				if (opponentBattlefield.childCount > 0)
				{
					if (playerBattlefield.childCount == 0)
					{
						StartCoroutine(DelayAction());
						readyToAttack = false;
						attackExecuted = true;
					}
					else
					{
						StartCoroutine(DelayAction2());
						readyToAttack = false;
						attackExecuted = true;
					}
				}
			}
			else
			{
				StartCoroutine(DelayAction3());
			}
		}
	}

	private void PlayCardAction()
	{
		if (!hasPlayedCard && turnState.currentTurnState == TurnState.TurnStates.opponentTurn)
		{
			if (turnSystemSettings.opponentCurrentMana > 0 && opponentHand.CurrentSize > 0)
			{
				StartCoroutine(DelayPlayCardAction());
			}
			else
			{
				hasPlayedCard = true;
				readyToAttack = true;
				attackExecuted = false;
				StartCoroutine(DelayAction3());
			}
		}
	}

	private void WhilePlayerTurn()
	{
		if (turnState.currentTurnState == TurnState.TurnStates.playerTurn)
		{
			hasPlayedCard = false;
			attackExecuted = false;
		}
	}

	private void SearchForFirstPlayableCard(int amountOfChecks)
	{
		bool foundPlayableCard = false;
		for (int i = 0; i < amountOfChecks; i++)
		{
			if (opponentHand.Container[i].manaCost <= turnSystemSettings.opponentCurrentMana)
			{
				foundPlayableCard = true;
				Card chosenCard = opponentHand.Container[i];
				GameObject physicalCard = opponentHand.GetInstantiatedCards()[i];

				physicalCard.transform.SetParent(opponentBattlefield);

				AssignCardInstance(chosenCard, physicalCard);
				opponentHand.Container.Remove(chosenCard);
				opponentHand.GetInstantiatedCards().Remove(physicalCard);
				turnSystemSettings.opponentCurrentMana -= chosenCard.manaCost;
				break;
			}
		}

		if (!foundPlayableCard)
		{
			// No playable card found, end the turn
			StartCoroutine(DelayAction3());
		}
	}

	private void AssignCardInstance(Card chosenCard, GameObject physicalCard)
	{
		CardInstance cardInstance = physicalCard.GetComponent<CardInstance>();
		cardInstance.card = chosenCard;
	}

	private void AttackHero()
	{
		//audioManager.PlaySFX("attack");

		Debug.Log("Attack Hero");
		Transform selectedCard = ChooseRandomBattlefieldCard(opponentBattlefield);

		CardInstance cardInstance = selectedCard.GetComponent<CardInstance>();

		//playerHealth.currentHealth -= cardInstance.card.attack;
		//playerHealthText.color = Color.red;
		//StartCoroutine(ChangeColorToBlack());
	}

	private void AttackCard()
	{
		//audioManager.PlaySFX("attack");
		Debug.Log("Attack Card");

		Transform selectedCard = ChooseRandomBattlefieldCard(opponentBattlefield);
		CardInstance attackingCard = selectedCard.GetComponent<CardInstance>();

		Transform selectedEnemyCard = ChooseRandomBattlefieldCard(playerBattlefield);
		CardInstance defendingCard = selectedEnemyCard.GetComponent<CardInstance>();

		defendingCard.cardInstanceCurrentHealth -= attackingCard.card.attack;
		attackingCard.cardInstanceCurrentHealth -= defendingCard.card.attack;
	}

	private Transform ChooseRandomBattlefieldCard(Transform battlefieldOwner)
	{
		int randomIndex = UnityEngine.Random.Range(0, battlefieldOwner.childCount);
		Transform selectedCard = battlefieldOwner.GetChild(randomIndex);
		return selectedCard;
	}
	IEnumerator DelayPlayCardAction()
	{
		yield return new WaitForSeconds(1.5f);
		SearchForFirstPlayableCard(opponentHand.CurrentSize);
	}

	IEnumerator DelayAction()
	{
		yield return new WaitForSeconds(3.5f);
		AttackHero();
	}

	IEnumerator DelayAction2()
	{
		yield return new WaitForSeconds(3.5f);
		AttackCard();
	}

	IEnumerator DelayAction3()
	{
		yield return new WaitForSeconds(5f);
		turnManager.EndOpponentTurn();
	}
}
