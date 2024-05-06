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
    public BattleTypeEnum battleTypeEnum;


	// Start is called before the first frame update
	private void  Awake()
    {
		if (Instance == null)
		{
			Instance = this;
		}		
	}
}