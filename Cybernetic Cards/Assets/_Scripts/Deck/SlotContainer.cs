using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SlotContainer : MonoBehaviour
{
	
	protected List<Card> container;
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

	public int ContainerSizeLimit { get; protected set; }





	public void UpdateContainerSize()
	{
		CurrentSize = Container.Count;
	}
}
