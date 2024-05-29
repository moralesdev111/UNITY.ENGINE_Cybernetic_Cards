using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    public static DataManager Instance;
    [SerializeField] private SceneHandling sceneHandling;
    public SceneHandling GetSceneHandling {  get { return sceneHandling; } }
	[SerializeField] private PlayerParty playerParty;
    public PlayerParty GetPlayerParty { get { return playerParty; } }
    [SerializeField] private BattleTypeEnum battleTypeEnum;
	public BattleTypeEnum BattleTypeEnum { get {  return battleTypeEnum; } }
	private GameObject trainer;
	public GameObject Trainer { get { return trainer; }  set { trainer = value; } }
	[SerializeField] private TrainerParty trainerParty;
	public TrainerParty OpponentPartyCards
	{
		get { return trainerParty; }
		set { trainerParty = value; }
	}


	// Start is called before the first frame update
	private void  Awake()
    {
		if (Instance == null)
		{
			Instance = this;
		}		
	}

	private void Update()
	{
		// REMOVE FROM GAME DEBUGGING TOOL
		if(Input.GetKey(KeyCode.Space))
		{
			sceneHandling.LoadScene(1);
		}
	}
}
