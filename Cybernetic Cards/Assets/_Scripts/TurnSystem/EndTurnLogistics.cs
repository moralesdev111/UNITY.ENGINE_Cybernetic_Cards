using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.XR;

public class EndTurnLogistics : MonoBehaviour
{
	[SerializeField] private TurnSystemSettings turnSystemSettings;
	[SerializeField] private PlayerHand playerHand;
	[SerializeField] private OpponentHand opponentHand;
	[SerializeField] private TurnState turnState;
	[SerializeField] private TextMeshProUGUI turnText;

	private void Start()
	{
		turnText.text = "Player Turn";
	}

	public void LogisticsForPlayer()
	{
		turnText.text = "Player Turn";
		turnSystemSettings.isPlayerTurn = true;
		turnSystemSettings.playerTurn += 1;

		turnSystemSettings.maxMana += 1;
		turnSystemSettings.currentMana = turnSystemSettings.maxMana;
		turnSystemSettings.startTurn = true;

		turnState.currentTurnState = TurnState.TurnStates.playerTurn;
	}

	public void LogisticsForOpponent()
	{
		turnText.text = "Opponent Turn";
		turnSystemSettings.isPlayerTurn = false;
		turnSystemSettings.opponentTurn += 1;

		turnSystemSettings.opponentMaxMana += 1;
		turnSystemSettings.opponentCurrentMana = turnSystemSettings.opponentMaxMana;
		turnSystemSettings.startTurn = false;

		turnState.currentTurnState = TurnState.TurnStates.opponentTurn;
	}
}
