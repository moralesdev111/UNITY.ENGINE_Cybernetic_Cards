using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WildParty : SlotContainer
{
	[SerializeField] private CardCodex cardCodex;

	private void Start()
	{
		ContainerSizeLimit = 5;
	}

	public Card RandomizeWildCard() 
	{
		Card card = null;
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
}
