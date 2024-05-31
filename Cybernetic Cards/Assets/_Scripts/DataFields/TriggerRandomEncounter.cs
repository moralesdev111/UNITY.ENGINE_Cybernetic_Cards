using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static BattleTypeEnum;

public class TriggerRandomEncounter : MonoBehaviour
{
    private string targetType = "Player";
	private Collider playerCollider;

	private void OnTriggerEnter(Collider other)
	{
		playerCollider = other;
		PossibleBattleEncounter(other);
	}

	private void OnTriggerExit(Collider other)
	{
		playerCollider = null;
	}

	private void PossibleBattleEncounter(Collider other)
	{
		if (UnityEngine.Random.Range(1, 101) <= 15)
		{
			if (other.gameObject.CompareTag(targetType))
			{
				Player player = other.gameObject.GetComponent<Player>();
				if (player != null)
				{
					DataManager.Instance.BattleTypeEnum.SetBattleType(BattleType.Wild);
					player.SetOverridePlayerControls(true);
					DataManager.Instance.playerLoadPosition = other.transform.position;
					StartCoroutine(WaitAndLoadBattleScene());
					Debug.Log(DataManager.Instance.BattleTypeEnum.GetBattleType);
				}
			}
		}
	}

	private IEnumerator WaitAndLoadBattleScene()
	{
		yield return new WaitForSeconds(1.5f);
		DataManager.Instance.GetSceneHandling.LoadScene(1);
	}
}
