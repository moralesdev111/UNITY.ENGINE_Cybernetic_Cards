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

	// Start is called before the first frame update
	void Start()
    {
		if(card != null)
		{
			SetCardUI();
		}
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

}
