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
	private OpponentParty opponentParty;
	public OpponentParty GetOpponentParty { get {  return opponentParty; } }
	private Transform myTransform;
	[SerializeField] private TurnSystem turnSystem;
	public TurnSystem GetTurnSystem { get {  return turnSystem; } }
	[SerializeField] private GameObject opponentBattlefield;

	private Transform cover;
	public Transform GetCover { get { return cover; } }


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
		opponentParty = GameObject.FindObjectOfType<OpponentParty>();
		InstantiatePlayerAndOpponentCards();
	}

	private void Update()
	{
		if(opponentHand.Container.Count == 0 && opponentBattlefield.transform.childCount == 0) 
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
		if (DataManager.Instance && DataManager.Instance.BattleTypeEnum.GetBattleType == BattleTypeEnum.BattleType.Wild)
		{
			playerHand.HandSetup();
			opponentHand.HandSetup();
		}
	}
}
