using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpponentHand : SlotContainer
{

	// Start is called before the first frame update
	void Start()
	{
		ContainerSizeLimit = 3;
	}

	// Update is called once per frame
	void Update()
	{

	}

	public void RemoveCard(Card card)
	{
		if (card && Container.Contains(card))
		{
			Container.Remove(card);
		}
	}
}
