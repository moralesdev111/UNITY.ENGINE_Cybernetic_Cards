using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthCenter : MonoBehaviour
{
	[SerializeField] private PlayerParty playerParty;
	public event Action onHealthCenterEntered;
	public bool needToRedrawUI = true;

	private void OnTriggerEnter(Collider other)
	{
		if(other.tag == "Player")
		{
			PlayerGraveyard playerGraveyard = DataManager.Instance.GetPlayerGraveyard;
			if(playerGraveyard.Container.Count > 0)
			{
				needToRedrawUI = true;
				List<Card> removedCards = new List<Card>();

				foreach (var card in playerGraveyard.Container)
				{
					removedCards.Add(card);
				}
				playerGraveyard.Container.Clear();
				for(int i = 0; i < removedCards.Count; i++)
				{
					playerParty.Container.Add(removedCards[i]);
				}
			}
		}
		onHealthCenterEntered();
	}
}
