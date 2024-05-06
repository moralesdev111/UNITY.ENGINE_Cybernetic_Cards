using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpponentParty : SlotContainer
{
	private void Start()
	{
		ContainerSizeLimit = 5;
	}

	public void RemoveCard(Card card)
	{
		if (card && Container.Contains(card))
		{
			Container.Remove(card);
		}
	}
}
