using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnState : MonoBehaviour
{
	public enum TurnStates
	{
		playerTurn,
		opponentTurn
	}
	public TurnStates currentTurnState;

}
