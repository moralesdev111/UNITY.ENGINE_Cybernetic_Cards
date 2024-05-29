using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using static TurnState;

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
		if (canAttack && cardInstance.GetCurrentCardState == CardInstance.CardState.battlefield && battlefield.TurnState.currentTurnState == TurnStates.playerTurn)
		{
			battlefield.GetComponent<BattleChecker>().BattlingCards[0] = cardInstance;
		}
		if(battlefield.GetCover.gameObject.activeInHierarchy)
		{
			if (battlefield.GetCover.GetComponent<Cover>().hasTresspassed && canAttack && battlefield.GetComponent<BattleChecker>().BattlingCards[0] != null && gameObject.tag == "Opponent")
			{
				battlefield.GetComponent<BattleChecker>().BattlingCards[1] = cardInstance;
			}
		}
		else if(battlefield.GetComponent<BattleChecker>().BattlingCards[0] != null && gameObject.tag == "Opponent")	
			{
			battlefield.GetComponent<BattleChecker>().BattlingCards[1] = cardInstance;
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
