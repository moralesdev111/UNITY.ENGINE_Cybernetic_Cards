using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerParty")]
public class PlayerParty : ScriptableObject
{
	[SerializeField] private List<Card> container = new List<Card>();
	public List<Card> Container
	{
		get { return container; }
	}
}
