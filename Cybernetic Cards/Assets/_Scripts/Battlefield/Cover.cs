using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class Cover : MonoBehaviour, IPointerClickHandler
{
	public event Action onCoverHealthChanged;
	private int currentHealth;
	public int CurrentHealth
	{
		get { return currentHealth; }
		set
		{
			currentHealth = value;
			onCoverHealthChanged?.Invoke();
		}
	}

	public int maxHealth = 3;
	public bool hasTresspassed = false;
	[SerializeField] private Battlefield battlefield;

	void Start()
	{
		if(DataManager.Instance.BattleTypeEnum.GetBattleType == BattleTypeEnum.BattleType.Trainer)
		{
			gameObject.SetActive(false);
		}
		currentHealth = maxHealth;
		onCoverHealthChanged += OnHealthChanged;
	}

	private void OnDestroy()
	{
		onCoverHealthChanged -= OnHealthChanged;
	}

	private void OnHealthChanged()
	{
		if (currentHealth < 1)
		{
			hasTresspassed = true;
			gameObject.SetActive(false);
		}
	}

	public void OnPointerClick(PointerEventData eventData)
	{
		if (!hasTresspassed && battlefield)
		{
			BattleChecker battleChecker = battlefield.GetComponent<BattleChecker>();
			if (battleChecker != null && battleChecker.BattlingCards[0] != null)
			{
				CurrentHealth -= battleChecker.BattlingCards[0].card.attack;
				battleChecker.BattlingCards[0].GetComponent<CardAttack>().SetCanAttack(false);
				battleChecker.ClearBattlingCards(); 
			}
		}
	}
}
