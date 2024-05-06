using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHand : SlotContainer
{
	[SerializeField] private Battlefield battlefield;
    // Start is called before the first frame update
    void Start()
    {
        ContainerSizeLimit = 3;
    }

	public void HandSetup()
	{
		int playerDeckCount = DataManager.Instance.GetPlayerParty.Container.Count;
		int cardsToSpawn = Mathf.Min(3, playerDeckCount);

		if (playerDeckCount > 0)
		{
			for (int i = 0; i < cardsToSpawn; i++)
			{
				Card card = DataManager.Instance.GetPlayerParty.Container[i];
				GameObject playerCard = Instantiate(battlefield.GetCardPrefab, battlefield.GetPlayerHandTransform);
				playerCard.GetComponent<CardInstance>().card = DataManager.Instance.GetPlayerParty.Container[i];
				Container.Add(card);
			}
		}
		else
		{
			Debug.Log("Deck Empty");
		}
	}

	public void RemoveCard(Card card)
	{
		if (card && Container.Contains(card))
		{
			Container.Remove(card);
		}
	}
}
