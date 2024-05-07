using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DropZone : MonoBehaviour, IDropHandler
{
	private TurnSystem turnSystem;

	private void Start()
	{
		turnSystem = GameObject.FindObjectOfType<TurnSystem>();
	}

	public void OnDrop(PointerEventData eventData)
	{
		Drag drag = eventData.pointerDrag.GetComponent<Drag>();
		if (drag != null && eventData.pointerDrag.GetComponent<CardInstance>().card.manaCost <= turnSystem.currentMana)
		{
			drag.originalParent = transform; // set new parent origin
			
			if(gameObject.CompareTag("Battlefield"))
			{
				turnSystem.currentMana -= eventData.pointerDrag.GetComponent<CardInstance>().card.manaCost;
				eventData.pointerDrag.GetComponent<CardInstance>().currentCardState = CardInstance.CardState.battlefield;
			}
			else if(gameObject.CompareTag("Hand"))
			{
				if(eventData.pointerDrag.GetComponent<CardInstance>().currentCardState != CardInstance.CardState.battlefield)
				{
					eventData.pointerDrag.GetComponent<CardInstance>().currentCardState = CardInstance.CardState.hand;
				}
				
			}
		}		
	}
}
