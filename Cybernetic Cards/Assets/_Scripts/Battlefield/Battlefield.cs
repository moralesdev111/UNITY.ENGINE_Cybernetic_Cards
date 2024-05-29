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
	public GameObject GetCardPrefab { get { return cardPrefab; } }
	[SerializeField] private PlayerHand playerHand;
	public PlayerHand GetPlayerHand { get { return playerHand; } }
	[SerializeField]private OpponentHand opponentHand;
	public OpponentHand GetOpponentHand { get { return opponentHand; } }
	private WildParty wildParty;
	public WildParty GetOpponentParty { get {  return wildParty; } }
	private Transform myTransform;
	[SerializeField] private TurnSystemSettings gameSettings;
	public TurnSystemSettings GetGameSettings { get {  return gameSettings; } }
	[SerializeField] private Transform opponentBattlefield;
	public Transform GetOpponentBattlefield { get { return opponentBattlefield; } }
	[SerializeField] private Transform playerBattlefield;
	public Transform GetPlayerBattlefield { get { return playerBattlefield; } }

	private Transform cover;
	public Transform GetCover { get { return cover; } }
	[SerializeField] private TurnState turnState;
	public TurnState TurnState { get { return turnState; } }
	

	private void OnEnable()
	{
		myTransform = GetComponent<Transform>();
		cover = myTransform.GetChild(0).GetChild(0).GetChild(3);
		DataManager.Instance.GetSceneHandling.onBattleSceneLoaded += SetupHandParentTransforms; // if weird errors unsubscribe on scene unloaded or on destroy
	}
	private void OnDisable()
	{
		DataManager.Instance.GetSceneHandling.onBattleSceneLoaded -= SetupHandParentTransforms;
	}

	private void Start()
	{
		wildParty = GameObject.FindObjectOfType<WildParty>();
		InstantiatePlayerAndOpponentCards();
	}

	private void Update()
	{
		if(opponentHand.Container.Count == 0 && opponentBattlefield.transform.childCount == 0 || playerHand.Container.Count == 0 && playerBattlefield.transform.childCount == 0) 
		{
			DataManager.Instance.GetSceneHandling.LoadScene(0);
		}
	}
	public void SetupHandParentTransforms()
    {
		playerHandTransform = myTransform.GetChild(0).GetChild(1).GetChild(0).GetComponent<RectTransform>();
		opponentHandTransform = myTransform.GetChild(0).GetChild(0).GetChild(1).GetComponent<RectTransform>();
	}

	private void InstantiatePlayerAndOpponentCards()
	{
		if (DataManager.Instance)
		{
			playerHand.HandSetup();
			opponentHand.HandSetup();
		}
	}
}
