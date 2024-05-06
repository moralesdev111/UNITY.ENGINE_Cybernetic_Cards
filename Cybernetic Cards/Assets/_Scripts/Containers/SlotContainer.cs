using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public abstract class SlotContainer : MonoBehaviour
{
	
	[SerializeField] protected List<Card> container = new List<Card>();
	public List<Card> Container
	{
		get { return container; }
	}
	
	public int CurrentSize
	{
		get { return container.Count; }
		protected set 
		{
			if(value <= ContainerSizeLimit)
			CurrentSize = value;
		}
	}

	public int ContainerSizeLimit { get; protected set; } = 5;

	public void UpdateContainerSize()
	{
		CurrentSize = Container.Count;
	}
}
