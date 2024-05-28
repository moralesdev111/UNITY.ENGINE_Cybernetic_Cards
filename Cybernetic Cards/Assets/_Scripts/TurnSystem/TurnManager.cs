using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnManager : MonoBehaviour
{
	[SerializeField] private TurnState turnState;
	[SerializeField] private TurnActions turnActions;
	[SerializeField] private TurnSystemSettings turnSystemSettings;


	void Start()
	{
		turnState.currentTurnState = TurnState.TurnStates.playerTurn;
		turnSystemSettings.InitialTurnSettings();
	}

	public void EndPlayerTurn()
	{
		if (turnSystemSettings.isPlayerTurn)
		{
			turnActions.EndTurnLogistics(true);
		}
	}

	public void EndOpponentTurn()
	{
		if (!turnSystemSettings.isPlayerTurn)
		{
			turnActions.EndTurnLogistics(false);
		}
	}
}
