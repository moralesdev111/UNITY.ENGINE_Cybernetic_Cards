using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Drag : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
	public Transform originalParent = null;

	public void OnBeginDrag(PointerEventData eventData)
	{
		originalParent = transform.parent;
		transform.SetParent(transform.root);
		GetComponent<CanvasGroup>().blocksRaycasts = false;
	}

	public void OnDrag(PointerEventData eventData)
	{
		transform.position = eventData.position;
	}


	public void OnEndDrag(PointerEventData eventData)
	{
		transform.SetParent(originalParent);
		GetComponent<CanvasGroup>().blocksRaycasts = true;
	}
}
