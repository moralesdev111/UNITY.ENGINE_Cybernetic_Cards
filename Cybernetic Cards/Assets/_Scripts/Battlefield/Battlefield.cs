using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Battlefield : MonoBehaviour
{
    private RectTransform playerHandTransform;
    public RectTransform GetPlayerHandTransform { get { return playerHandTransform; } } 
	private RectTransform opponentHandTransform;
    public RectTransform GetOpponentHandTransform { get { return opponentHandTransform; } }
	[SerializeField] private GameObject cardPrefab;
	[SerializeField] private PlayerHand playerHand;
	public PlayerHand GetPlayerHand { get { return playerHand; } }
	[SerializeField]private OpponentHand opponentHand;
	public OpponentHand GetOpponentHand { get { return opponentHand; } }
	private OpponentParty opponentParty;
	public OpponentParty GetOpponentParty { get {  return opponentParty; } }

	private void Awake()
	{
        DataManager.Instance.GetSceneHandling.onBattleSceneLoaded += SetupHandParentTransforms; // if weird errors unsubscribe on scene unloaded or on destroy
	}
	private void OnDisable()
	{
		DataManager.Instance.GetSceneHandling.onBattleSceneLoaded -= SetupHandParentTransforms;
	}

	private void Start()
	{
		opponentParty = GameObject.FindObjectOfType<OpponentParty>();
		InstantiatePlayerAndOpponentCards();
	}
	public void SetupHandParentTransforms()
    {
		playerHandTransform = transform.GetChild(0).GetChild(0).GetChild(0).GetComponent<RectTransform>();
		opponentHandTransform = transform.GetChild(0).GetChild(1).GetChild(0).GetComponent<RectTransform>();
	}

	private void InstantiatePlayerAndOpponentCards()
	{
		if (DataManager.Instance && DataManager.Instance.battleTypeEnum.GetBattleType == BattleTypeEnum.BattleType.Wild)
		{
			PlayerSetup();
			OpponentSetup();
		}
	}

	private void OpponentSetup()
	{
		int opponentDeckCount = opponentParty.Container.Count;
		int cardsToSpawn = Mathf.Min(1, opponentDeckCount);

		if(opponentDeckCount > 0)
		{
			for (int i = 0; i < cardsToSpawn; i++)
			{
				Card card = opponentParty.Container[i];
				GameObject opponentCard = Instantiate(cardPrefab, opponentHandTransform);
				opponentCard.GetComponent<CardInstance>().card = opponentParty.Container[i];
				opponentHand.Container.Add(card);
			}
		}		
	}

	private void PlayerSetup()
	{
		int playerDeckCount = DataManager.Instance.GetPlayerParty.Container.Count;
		int cardsToSpawn = Mathf.Min(3, playerDeckCount);
		
		if (playerDeckCount > 0)
		{
			for (int i = 0; i < cardsToSpawn; i++)
			{
				Card card = DataManager.Instance.GetPlayerParty.Container[i];
				GameObject playerCard = Instantiate(cardPrefab, playerHandTransform);
				playerCard.GetComponent<CardInstance>().card = DataManager.Instance.GetPlayerParty.Container[i];
				playerHand.Container.Add(card);
			}
		}
		else
		{
			Debug.Log("Deck Empty");
		}
	}
}
