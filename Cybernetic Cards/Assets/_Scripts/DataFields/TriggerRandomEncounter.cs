using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerRandomEncounter : MonoBehaviour
{
    private string targetType = "Player";

	private void OnTriggerEnter(Collider other)
	{
        if (Random.Range(1, 101) <= 15)
        {
			Debug.Log("Random Encounter");

			if (other.gameObject.CompareTag(targetType))
            {				
				Player player = other.gameObject.GetComponent<Player>();
				if (player != null)
				{
					player.SetOverridePlayerControls(true);
					StartCoroutine(WaitAndLoadBattleScene());
				}
			}
        }
	}

	private IEnumerator WaitAndLoadBattleScene()
	{
		yield return new WaitForSeconds(1.5f);
		SceneHandling.Instance.LoadScene(1);
	}
}
