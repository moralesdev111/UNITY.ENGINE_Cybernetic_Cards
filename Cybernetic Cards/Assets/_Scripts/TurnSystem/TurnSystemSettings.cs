using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnSystemSettings : MonoBehaviour
{
	public int maxMana;
	public int currentMana;
	public bool startTurn = false;
	public bool isPlayerTurn;
	public int playerTurn;
	public int opponentTurn;
	public int opponentMaxMana;
	public int opponentCurrentMana;


	public void InitialTurnSettings()
	{
		isPlayerTurn = true;
		playerTurn = 1;
		opponentTurn = 0;

		maxMana = 1;
		currentMana = 1;

		opponentCurrentMana = 0;
		opponentMaxMana = 0;
	}
}
