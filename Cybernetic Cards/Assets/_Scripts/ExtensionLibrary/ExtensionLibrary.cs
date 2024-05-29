using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;


public static class ExtensionLibrary
{
	public static void RemoveCard(Card card, List<Card> Container)
	{
		if (card && Container.Contains(card))
		{
			Container.Remove(card);
		}
	}
}
