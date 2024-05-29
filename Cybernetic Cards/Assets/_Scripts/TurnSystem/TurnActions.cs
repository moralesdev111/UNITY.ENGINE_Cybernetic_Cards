using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TurnActions : MonoBehaviour
{
	[Header("References")]
	public TurnState turnState;
	
	[SerializeField] private TextMeshProUGUI manaText;
	[SerializeField] private TextMeshProUGUI opponentManaText;
	[SerializeField] private TurnSystemSettings turnSystemSettings;
	[SerializeField] private EndTurnLogistics endTurnLogistics;

	void Update()
	{
		UpdateManaText();
	}

	public void EndTurnLogistics(bool ownerTurn)
	{
		if (ownerTurn)
		{
			endTurnLogistics.LogisticsForOpponent();
		}
		else
		{
			endTurnLogistics.LogisticsForPlayer();
		}
	}

	private void UpdateManaText()
	{
		manaText.text = turnSystemSettings.currentMana + " / " + turnSystemSettings.maxMana;
		opponentManaText.text = turnSystemSettings.opponentCurrentMana + " / " + turnSystemSettings.opponentMaxMana;
	}
}
