using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DropZone : MonoBehaviour, IDropHandler
{
	[SerializeField] private ManaManager manaManager;
	public void OnDrop(PointerEventData eventData)
	{
		Drag drag = eventData.pointerDrag.GetComponent<Drag>();
		if (drag != null)
		{
			drag.originalParent = transform; // set new parent origin
			manaManager.ManaDecrease(eventData.pointerDrag.GetComponent<CardInstance>().card.manaCost);
		}		
	}
}
