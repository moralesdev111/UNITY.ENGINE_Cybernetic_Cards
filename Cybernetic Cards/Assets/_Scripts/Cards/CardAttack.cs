using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CardAttack : MonoBehaviour, IPointerClickHandler
{
	[SerializeField] CardInstance cardInstance;
	public bool canAttack = false;
	private Battlefield battlefield;

	private void OnEnable()
	{
		battlefield = transform.root.GetComponent<Battlefield>();
		//battlefield.GetTurnSystem.onEndTurn += ResetAttackFlag;
	}
	public void OnPointerClick(PointerEventData eventData)
	{
		if (canAttack && cardInstance.GetCurrentCardState == CardInstance.CardState.battlefield && battlefield.GetTurnSystem.currentTurnState == TurnStatus.player)
		{
			battlefield.GetComponent<BattleChecker>().battlingCards[0] = cardInstance;
		}
		if (battlefield.GetComponent<BattleChecker>().battlingCards[0] != null && gameObject.tag == "Opponent")
		{
			battlefield.GetComponent<BattleChecker>().battlingCards[1] = cardInstance;
		}
	}

	private void Update()
	{
		ResetAttackFlag(battlefield.GetTurnSystem.isPlayerTurn);
	}

	private void ResetAttackFlag(bool opponentTurn)
	{
		if (!opponentTurn && cardInstance.GetCurrentCardState == CardInstance.CardState.battlefield)
		{
			canAttack = true;
		}
		else if (battlefield.GetTurnSystem.currentTurnState == TurnStatus.opponent)
		{
			canAttack = false;
		}
	}
}
