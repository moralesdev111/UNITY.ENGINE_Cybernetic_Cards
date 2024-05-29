using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName= "TrainerParty")]
public class TrainerParty : ScriptableObject
{
	[SerializeField] private List<Card> container = new List<Card>();
	public List<Card> Container
	{
		get { return container; }
	}
}
