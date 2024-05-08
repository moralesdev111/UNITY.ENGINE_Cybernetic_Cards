using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpponentHand : SlotContainer
{
	[SerializeField] private Battlefield battlefield;
	private List<GameObject> instantiatedCards = new List<GameObject>();

	// Start is called before the first frame update
	void Start()
	{
		ContainerSizeLimit = 3;
	}

	public void HandSetup()
	{
		int opponentDeckCount = battlefield.GetOpponentParty.Container.Count;
		int cardsToSpawn = Mathf.Min(1, opponentDeckCount);

		if (opponentDeckCount > 0)
		{
			for (int i = 0; i < cardsToSpawn; i++)
			{
				Card card = battlefield.GetOpponentParty.Container[i];
				GameObject opponentCard = Instantiate(battlefield.GetCardPrefab, battlefield.GetOpponentHandTransform);
				opponentCard.GetComponent<CardInstance>().card = battlefield.GetOpponentParty.Container[i];
				opponentCard.GetComponent<CardInstance>().SetCurrentCardState(CardInstance.CardState.hand);
				Container.Add(card);
				instantiatedCards.Add(opponentCard);
			}
		}
	}

	public void RemoveCard(Card card)
	{
		if (card && Container.Contains(card))
		{
			Container.Remove(card);
		}
	}

	public List<GameObject> GetInstantiatedCards()
	{
		return instantiatedCards;
	}

}
