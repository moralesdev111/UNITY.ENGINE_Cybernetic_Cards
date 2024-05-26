using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpponentHand : SlotContainer
{
	[SerializeField] private Battlefield battlefield;
	private List<GameObject> instantiatedCards = new List<GameObject>();
	private string tagName = "Opponent";

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
				Container.Clear();
				Card card = battlefield.GetOpponentParty.RandomizeOpponentCard();
				GameObject opponentCard = Instantiate(battlefield.GetCardPrefab, battlefield.GetOpponentHandTransform);
				opponentCard.GetComponent<CardInstance>().card = card;
				opponentCard.GetComponent<CardInstance>().SetCurrentCardState(CardInstance.CardState.hand);
				battlefield.GetOpponentParty.Container[0] = card;
				Container.Add(card);
				instantiatedCards.Add(opponentCard);
				opponentCard.tag = tagName;
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
