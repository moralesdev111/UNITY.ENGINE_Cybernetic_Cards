using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleTypeEnum : MonoBehaviour
{
	private BattleType battleType;
	public BattleType GetBattleType {  get { return battleType; } }
	public void SetBattleType(BattleType battleType)
	{
		this.battleType = battleType; 
	}

   public enum BattleType
	{
		Wild,
		Trainer
	}
}
