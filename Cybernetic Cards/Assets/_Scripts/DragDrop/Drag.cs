using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Drag : MonoBehaviour //IBeginDragHandler, IDragHandler, IEndDragHandler
{
	//[SerializeField] PlaceHolder placeHolder;
	//[SerializeField] SetSiblingIndex setSiblingIndex;
	//public Transform defaultParent = null;
	//public Transform placeHolderParent = null;
	//private bool canDrag = false;
	//private ManaManager manaManager;
	//private CardInstance cardDetails;


	//public void OnBeginDrag(PointerEventData eventData)
	//{
	//	GetCardDetails();

	//	if (manaManager.GreenLight(cardDetails.card) && cardDetails.currentCardState != CardInstance.CardState.battlefield)
	//	{
	//		canDrag = true;
	//		placeHolder.CreatePlaceHolderObject();
	//		placeHolder.ManagePlaceHolderObjectParenting();
	//		GetComponent<CanvasGroup>().blocksRaycasts = false;
	//	}
	//	else
	//	{
	//		canDrag = false;
	//		return;
	//	}
	//}

	//public void OnDrag(PointerEventData eventData)
	//{
	//	if (canDrag)
	//	{
	//		this.transform.position = eventData.position;

	//		if (placeHolder.placeHolder.transform.parent != placeHolderParent)
	//		{
	//			placeHolder.placeHolder.transform.SetParent(placeHolderParent);
	//		}
	//		setSiblingIndex.SetSiblingIndexOnRuntime();
	//	}
	//	else
	//	{
	//		return;
	//	}
	//}


	//public void OnEndDrag(PointerEventData eventData)
	//{
	//	if (canDrag)
	//	{
	//		placeHolder.DestroyPlaceHolder();
	//		GetComponent<CanvasGroup>().blocksRaycasts = true;
	//	}
	//	else
	//	{
	//		return;
	//	}
	//}

	//private void GetCardDetails()
	//{
	//	manaManager = FindObjectOfType<ManaManager>();
	//	cardDetails = GetComponent<CardInstance>();
	//}
}