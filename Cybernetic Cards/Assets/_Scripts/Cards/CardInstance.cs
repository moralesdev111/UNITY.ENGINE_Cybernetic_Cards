using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CardInstance : MonoBehaviour
{
	public Card card;
	
	[SerializeField] private TextMeshProUGUI cardName;
	[SerializeField] private Image artworkImage;
	[SerializeField] private Image cardBack;
	[SerializeField] private TextMeshProUGUI manaCost;
	[SerializeField] private TextMeshProUGUI attack;
	[SerializeField] private TextMeshProUGUI health;
	private int cardInstanceMaxHealth;
	private int cardInstanceCurrentHealth;
	public int CardInstanceCurrentHealth
	{
		get { return cardInstanceCurrentHealth; }
		set 
		{ 
			cardInstanceCurrentHealth = value;
			onCardHealthChanged?.Invoke();
		}
	}
	public event Action onCardHealthChanged;

	public enum CardState
	{
		party,
		hand,
		battlefield,
		corrupted
	}

	[SerializeField] private CardState currentCardState;
	public CardState GetCurrentCardState {  get { return currentCardState; } }
	public void SetCurrentCardState(CardState state) {  currentCardState = state; }

	// Start is called before the first frame update
	void Start()
    {
		if(card != null)
		{
			onCardHealthChanged += OnHealthChanged;
			cardInstanceMaxHealth = card.health;
			cardInstanceCurrentHealth = cardInstanceMaxHealth;
			SetCardUI();
		}
    }

	private void OnDestroy()
	{
		onCardHealthChanged -= OnHealthChanged;
	}
	public void SetCardUI()
	{
		cardName.text = card.cardName;
		artworkImage.sprite = card.artwork;
		//cardBack.sprite = card.artworkBack;
		manaCost.text = card.manaCost.ToString();
		attack.text = card.attack.ToString();
		health.text = card.health.ToString();
	}
	private void OnHealthChanged()
	{
		health.text = cardInstanceCurrentHealth.ToString();
		if (cardInstanceCurrentHealth < 1)
		{
			if (tag == "Opponent")
			{
				Destroy(gameObject);
				return;
			}
			DataManager.Instance.GetPlayerGraveyard.Container.Add(this.card);
			DataManager.Instance.GetPlayerParty.Container.Remove(this.card);
			Destroy(gameObject);
		}
	}
}
