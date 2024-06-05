using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using static BattleTypeEnum;

public class TriggerTrainerEncounter : MonoBehaviour
{
	public bool triggereable = false;
	private Coroutine checkKeyInputCoroutine;
	private GameObject player;
	[SerializeField] public TrainerParty opponentPartyCards;
	private Collider playerCollider;
	[SerializeField] private TextMeshProUGUI encounterText = null;

	private void OnTriggerEnter(Collider other)
	{
		playerCollider = other;
		if (other.CompareTag("Player"))
		{
			player = other.gameObject;
			triggereable = true;
			checkKeyInputCoroutine = StartCoroutine(CheckForKeyPress());
		}
	}


	private void OnTriggerExit(Collider other)
	{
		if (other.CompareTag("Player"))
		{
			player = null;
			playerCollider = null;
			triggereable = false;
			DataManager.Instance.Trainer = null;
			DataManager.Instance.OpponentPartyCards = null;
			if (checkKeyInputCoroutine != null)
			{
				StopCoroutine(checkKeyInputCoroutine);
				checkKeyInputCoroutine = null;
			}
		}
	}

	private IEnumerator CheckForKeyPress()
	{
		while (true)
		{
			if (Input.GetKeyDown(KeyCode.F)) 
			{
				if (player != null)
				{
					DataManager.Instance.BattleTypeEnum.SetBattleType(BattleType.Trainer);
					DataManager.Instance.Trainer = this.gameObject;
					DataManager.Instance.OpponentPartyCards = opponentPartyCards;
					DataManager.Instance.playerLoadPosition = playerCollider.transform.position;
					player.GetComponent<Player>().SetOverridePlayerControls(true);
					StartCoroutine(WaitAndLoadBattleScene());
					Debug.Log(DataManager.Instance.BattleTypeEnum.GetBattleType);
				}
			}
			yield return null;
		}
	}

	private IEnumerator WaitAndLoadBattleScene()
	{
		encounterText.text = "Trainer Encounter!";
		yield return new WaitForSeconds(1.5f);
		encounterText.text = null;
		DataManager.Instance.GetSceneHandling.LoadScene(1);
	}
}
