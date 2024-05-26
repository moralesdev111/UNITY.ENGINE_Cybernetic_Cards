using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpponentParty : SlotContainer
{
	[SerializeField] private CardCodex cardCodex;
	public Card card;

	private void Start()
	{
		ContainerSizeLimit = 5;
	}

	public Card RandomizeOpponentCard() // update to the battletrigger to randomize this classes container
	{
		int randomNumber = Random.Range(0, 3);
		switch (randomNumber)
		{
			case 0:
				card = cardCodex.Cards[0];
				break;
			case 1:
				card = cardCodex.Cards[1];
				break;
			case 2:
				card = cardCodex.Cards[2];
				break;
		}
		return card;
	}

	public void RemoveCard(Card card)
	{
		if (card && Container.Contains(card))
		{
			Container.Remove(card);
		}
	}
}
