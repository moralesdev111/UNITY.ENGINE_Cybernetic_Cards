using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerPartyUI : MonoBehaviour
{
    [SerializeField] private GameObject slotPrefab;    
    [SerializeField] private PlayerParty playerParty;
	[SerializeField] private HealthCenter healthCenter;
	private Transform slotPrefabParentTransform;
	private Transform myTransform;


	private void OnEnable()
	{
		if(playerParty != null)
		{
			healthCenter.needToRedrawUI = true;
			myTransform = transform;
			slotPrefabParentTransform = myTransform.GetChild(0).GetChild(0);
			DataManager.Instance.GetSceneHandling.onSandboxSceneLoaded += UpdatePartySlotUI;
			healthCenter.onHealthCenterEntered += UpdatePartySlotUI;
		}
	}

	private void OnDisable()
	{
		DataManager.Instance.GetSceneHandling.onSandboxSceneLoaded -= UpdatePartySlotUI;
		healthCenter.onHealthCenterEntered -= UpdatePartySlotUI;
	}

	private void UpdatePartySlotUI()
	{		
		if(playerParty != null)
		{
			SetPartyUI();
		}
	}

	private void SetPartyUI()
	{
		if(healthCenter.needToRedrawUI)
		{
			for (int i = 0; i < playerParty.Container.Count; i++)
			{
				GameObject physicalCard = Instantiate(slotPrefab, slotPrefabParentTransform); // instantiate party inventory
				physicalCard.GetComponent<Image>().sprite = playerParty.Container[i].artwork; // set artwork slot
			}
			healthCenter.needToRedrawUI = false;
		}
		
	}
}
