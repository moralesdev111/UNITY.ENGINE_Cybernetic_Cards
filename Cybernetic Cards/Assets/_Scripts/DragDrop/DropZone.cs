using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DropZone : MonoBehaviour, IDropHandler
{
	private TurnSystemSettings gameSettings;
	[SerializeField] private Battlefield battlefield;
	private CardInstance cardInstance;

	private void Start()
	{
		gameSettings = GameObject.FindObjectOfType<TurnSystemSettings>();
	}

	public void OnDrop(PointerEventData eventData)
	{
		Drag drag = eventData.pointerDrag.GetComponent<Drag>();
		cardInstance = eventData.pointerDrag.GetComponent<CardInstance>();
		if (drag != null && cardInstance.card.manaCost <= gameSettings.currentMana && cardInstance.GetCurrentCardState != CardInstance.CardState.battlefield) // if we have enough mana
		{
			drag.originalParent = transform; // set new parent origin
			
			if(gameObject.CompareTag("Battlefield")) // if we drag on top of battlefield
			{

				gameSettings.currentMana -= cardInstance.card.manaCost;
				cardInstance.SetCurrentCardState(CardInstance.CardState.battlefield);
				battlefield.GetPlayerHand.Container.Remove(cardInstance.card);
			}

			else if(gameObject.CompareTag("Hand")) // if we drag on top of hand
			{

				if(cardInstance.GetCurrentCardState != CardInstance.CardState.battlefield)
				{
					cardInstance.SetCurrentCardState(CardInstance.CardState.hand);
				}				

			}
		}		
	}
}
