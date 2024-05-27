using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using TMPro;
using UnityEngine;

public enum TurnStatus
{
    player,
    opponent
}

public class TurnSystem : MonoBehaviour
{
	//CHANGE VARIABLES TO PRIVATE AFTER DEBUGGING
    public TurnStatus currentTurnState;
    public bool isPlayerTurn;
    public int playerTurnNumber;
    public int opponentTurnNumber;
    public TextMeshProUGUI turnOwnerText;

    public int maxMana;
    public int currentMana;
    public TextMeshProUGUI manaText;

    public int opponentMaxMana;
    public int opponentCurrentMana;
	public TextMeshProUGUI opponentManaText;

	public event Action onPlayerTurnEnd;
	public event Action onOpponentTurnEnd;

	// Start is called before the first frame update
	void Start()
	{
		FirstTurnLogistics();
		UpdateManaText(); // also need to update on card play 
	}

	private void Update()
	{
		manaText.text = currentMana + "/" + maxMana;
		opponentManaText.text = opponentCurrentMana + "/" + opponentMaxMana;
		UpdateTurnText();
	}

	private void UpdateManaText()
	{
		manaText.text = currentMana + "/" + maxMana;
		opponentManaText.text = opponentCurrentMana + "/" + opponentMaxMana;
	}

	public void EndPlayerTurn()
    {
        currentTurnState = TurnStatus.opponent;
		isPlayerTurn = false;

		//turnOwnerText.text = "Opponent Turn";
		opponentTurnNumber += 1;

		opponentMaxMana += 1;
		opponentCurrentMana = maxMana;

		//UpdateManaText();
		onPlayerTurnEnd?.Invoke();
	}

    public void EndOpponentTurn()
    {
		currentTurnState = TurnStatus.player;
		isPlayerTurn = true;

		//turnOwnerText.text = "Player Turn";
		playerTurnNumber += 1;

        maxMana += 1;
        currentMana = maxMana;

		//UpdateManaText();
		onOpponentTurnEnd?.Invoke();
	}

	private void FirstTurnLogistics()
	{
		//turnOwnerText.text = "Player Turn";
		currentTurnState = TurnStatus.player;
		isPlayerTurn = true;
		playerTurnNumber = 1;
		opponentTurnNumber = 0;

		maxMana = 1;
		currentMana = maxMana;

		opponentCurrentMana = 0;
		opponentMaxMana = 0;
	}

	private void UpdateTurnText()
	{
		turnOwnerText.text = currentTurnState == TurnStatus.player ? "Player Turn" : "Opponent Turn";
	}
}
