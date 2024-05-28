using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CardAttack : MonoBehaviour, IPointerClickHandler
{
	[SerializeField] private CardInstance cardInstance;
	private bool canAttack = false;
	public bool CanAttack { get { return canAttack; } }
	public bool SetCanAttack(bool _canAttack) { return canAttack = _canAttack; }
	private Battlefield battlefield;

	private void OnEnable()
	{
		battlefield = transform.root.GetComponent<Battlefield>();
		//battlefield.GetTurnSystem.onEndTurn += ResetAttackFlag;
	}
	public void OnPointerClick(PointerEventData eventData)
	{
		if (canAttack && cardInstance.GetCurrentCardState == CardInstance.CardState.battlefield && battlefield.TurnState.currentTurnState == TurnState.TurnStates.playerTurn)
		{
			if (battlefield.GetCover.GetComponent<Cover>().hasTresspassed)
			{
				if (canAttack && cardInstance.GetCurrentCardState == CardInstance.CardState.battlefield && battlefield.TurnState.currentTurnState == TurnState.TurnStates.playerTurn)
				{
					battlefield.GetComponent<BattleChecker>().BattlingCards[0] = cardInstance;
				}
				if (battlefield.GetComponent<BattleChecker>().BattlingCards[0] != null && gameObject.tag == "Opponent")
				{
					battlefield.GetComponent<BattleChecker>().BattlingCards[1] = cardInstance;
				}
			}
			else
			{ //LEFT OFF
				if (canAttack && cardInstance.GetCurrentCardState == CardInstance.CardState.battlefield && battlefield.TurnState.currentTurnState == TurnState.TurnStates.playerTurn)
				{
					battlefield.GetComponent<BattleChecker>().BattlingCards[0] = cardInstance;
				}
				if (battlefield.GetComponent<BattleChecker>().BattlingCards[0] != null && transform.GetComponent<Cover>())
				{
					transform.GetComponent<Cover>().CurrentHealth -= cardInstance.card.attack;
				}
			}
		}
			
		
		
	}

	private void Update()
	{
		ResetAttackFlag(battlefield.GetGameSettings.isPlayerTurn);
	}

	private void ResetAttackFlag(bool opponentTurn)
	{
		if (!opponentTurn && cardInstance.GetCurrentCardState == CardInstance.CardState.battlefield)
		{
			canAttack = true;
		}
		else if (battlefield.TurnState.currentTurnState == TurnState.TurnStates.opponentTurn)
		{
			canAttack = false;
		}
	}
}
