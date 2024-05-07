using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Drag : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
	public Transform originalParent = null;
	private CardInstance cardInstance;
	private bool canDrag = false;
	private TurnSystem turnSystem;

	private void Start()
	{
		turnSystem = GameObject.FindObjectOfType<TurnSystem>();
	}

	public void OnBeginDrag(PointerEventData eventData)
	{
		cardInstance = GetComponent<CardInstance>();
		if(cardInstance.GetCurrentCardState != CardInstance.CardState.battlefield && cardInstance.card.manaCost <= turnSystem.currentMana)
		{// if card is not in battlefield and we have enough mana we can drag
			canDrag = true;
			originalParent = transform.parent;
			transform.SetParent(transform.root);
			GetComponent<CanvasGroup>().blocksRaycasts = false;
		}
		else // we cant drag
		{
			canDrag = false;
			return;
		}

	}

	public void OnDrag(PointerEventData eventData)
	{
		if (canDrag)
		{
			transform.position = eventData.position; // update card position to match mouse
		}
		else
		{
			return;
		}
	}


	public void OnEndDrag(PointerEventData eventData)
	{
		if(canDrag) // at end of drag set new parent
		{
			transform.SetParent(originalParent);
			GetComponent<CanvasGroup>().blocksRaycasts = true;
		}
		else
		{
			return;
		}
		
	}
}
