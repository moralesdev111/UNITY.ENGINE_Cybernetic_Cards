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
	private bool needToRedrawUI = true;

	private void OnEnable()
	{
		if (playerParty != null)
		{
			myTransform = transform;
			slotPrefabParentTransform = myTransform.GetChild(0).GetChild(0);
			DataManager.Instance.GetSceneHandling.onSandboxSceneLoaded += DrawUI;
			healthCenter.onHealthCenterEntered += DrawUI;
		}
	}

	private void OnDisable()
	{
		DataManager.Instance.GetSceneHandling.onSandboxSceneLoaded -= DrawUI;
		healthCenter.onHealthCenterEntered -= DrawUI;
	}

	private void DrawUI()
	{
		needToRedrawUI = true;
		if (playerParty != null)
		{
			if (needToRedrawUI)
			{
				if (!healthCenter.HealthUIRedraw)
				{
					SceneRedrawUI();
				}
				else
				{
					HealthCenterRedrawUI();
				}
			}
		}
	}

	private void HealthCenterRedrawUI()
	{
		for (int i = 0; i < healthCenter.RemovedCards.Count; i++)
		{
			GameObject physicalCard = Instantiate(slotPrefab, slotPrefabParentTransform);
			physicalCard.GetComponent<Image>().sprite = playerParty.Container[i].artwork;
			healthCenter.HealthUIRedraw = false;
			needToRedrawUI = false;
		}
	}

	private void SceneRedrawUI()
	{
		for (int i = 0; i < playerParty.Container.Count; i++)
		{
			GameObject physicalCard = Instantiate(slotPrefab, slotPrefabParentTransform);
			physicalCard.GetComponent<Image>().sprite = playerParty.Container[i].artwork;
			needToRedrawUI = false;
		}
	}
}