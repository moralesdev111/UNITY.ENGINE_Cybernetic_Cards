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
		if(DataManager.Instance.BattleTypeEnum.GetBattleType == BattleTypeEnum.BattleType.Wild)
		{
			int opponentDeckCount = battlefield.GetOpponentParty.Container.Count;
			int cardsToSpawn = Mathf.Min(1, opponentDeckCount);

			if (opponentDeckCount > 0)
			{
				Container.Clear();
				for (int i = 0; i < cardsToSpawn; i++)
				{
					Card card = battlefield.GetOpponentParty.RandomizeWildCard();
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
		else if(DataManager.Instance.BattleTypeEnum.GetBattleType == BattleTypeEnum.BattleType.Trainer)
		{
			int opponentDeckCount = DataManager.Instance.OpponentPartyCards.Container.Count;
			int cardsToSpawn = Mathf.Max(1, opponentDeckCount);

			if (opponentDeckCount > 0)
			{
				Container.Clear();
				for (int i = 0; i < cardsToSpawn; i++)
				{
					Card card = DataManager.Instance.OpponentPartyCards.Container[i];
					GameObject opponentCard = Instantiate(battlefield.GetCardPrefab, battlefield.GetOpponentHandTransform);
					opponentCard.GetComponent<CardInstance>().card = card;
					opponentCard.GetComponent<CardInstance>().SetCurrentCardState(CardInstance.CardState.hand);
					DataManager.Instance.OpponentPartyCards.Container[i] = card;
					Container.Add(card);
					instantiatedCards.Add(opponentCard);
					opponentCard.tag = tagName;
				}
			}
		}
	}

	public List<GameObject> GetInstantiatedCards()
	{
		return instantiatedCards;
	}
}
