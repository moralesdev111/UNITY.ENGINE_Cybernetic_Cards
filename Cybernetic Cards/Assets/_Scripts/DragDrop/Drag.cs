using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Drag : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
	public Transform originalParent = null;
	private Card card;
	private bool canDrag = false;
	private TurnSystem turnSystem;

	private void Start()
	{
		turnSystem = GameObject.FindObjectOfType<TurnSystem>();
	}

	public void OnBeginDrag(PointerEventData eventData)
	{
		card = GetComponent<CardInstance>().card;
		if(GetComponent<CardInstance>().currentCardState != CardInstance.CardState.battlefield && card.manaCost <= turnSystem.currentMana)
		{
			canDrag = true;
			Debug.Log(card.name);
			originalParent = transform.parent;
			transform.SetParent(transform.root);
			GetComponent<CanvasGroup>().blocksRaycasts = false;
		}
		else
		{
			canDrag = false;
			return;
		}

	}

	public void OnDrag(PointerEventData eventData)
	{
		if (canDrag)
		{
			transform.position = eventData.position;
		}
		else
		{
			return;
		}
	}


	public void OnEndDrag(PointerEventData eventData)
	{
		if(canDrag)
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
